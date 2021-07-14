using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
//using S22.Imap;
using MailKit.Net.Imap;
namespace MailDownloader.Logic
{
    public class MultiMailDownloadManagerProxy
    {
        public delegate void StatusUpdateHandler();
        public event StatusUpdateHandler OnUpdateStatus;
        public delegate void StopDownloadingHandler();
        public event StopDownloadingHandler OnStoppedDownloading;
        private MailFilterer filterer;
        public DownloadSettings settings;
        private string created_path;
        private Thread initiator;
        private System.Threading.Timer updater;
        public string FilterPath { get; private set; }
        private List<MailDownloader> downloaders;
        public int DownloadedFileCount
        {
            get
            {
                int res = 0;
                DirectoryInfo dir = new DirectoryInfo(created_path);
                res = dir.GetFiles().Length;
                return res;
            }
        }
        public MultiMailDownloadManagerProxy()
        {
            settings = new DownloadSettings();
        }
        private int index = 0;
        private object locker = new object();
        private int unfinished = 0;
        private IEnumerable<Mail> mails;
        public void StartDownloading(IEnumerable<Mail> mails2, int threads_count)
        {
            index = 0;
            mails = mails2;
            string filter_path;
            CreateDirectories(out filter_path);
            filterer = new MailFilterer(mails.ToList(), filter_path);
            FilterPath = filter_path;
            downloaders = new List<MailDownloader>();
            if (mails.Count() == 0)
                return;
            for (int i = 0; i < threads_count && i < mails.Count(); i++)
            {
                MailDownloader res = new MailDownloader();
                res.OnStoppedDownloading += StopHandler;
                res.CreatedPath = created_path;
                downloaders.Add(res);
            }
            unfinished = downloaders.Count;
            updater = new System.Threading.Timer(new TimerCallback((obj) =>
            {
                UpdateStatus();
            }), null, 0, 100 * threads_count);
            initiator = new Thread(() => {
                foreach (var i in downloaders)
                {
                    i.StartDownload();
                }
            });
            initiator.Start();
        }
        private void StopHandler(MailDownloader md)
        {
            lock (locker)
            {
                if (index < mails.Count())
                {
                    md.Recopy(AddDownloader(mails.ElementAt(index)));
                    index++;
                }
                else
                {
                    unfinished--;
                    if (unfinished == 0)
                    {
                        StopDownloading();
                    }
                    return;
                }
            }
            md.StartDownload();
        }
        private MailDownloader AddDownloader(Mail mail)
        {
            ImapClient ic = ConfigManagerFabric.Manager.GetClient(mail.Login.Split('@')[1]);
            MailDownloader md;
            if (filterer.CheckMail(mail, out ic) == MailValue.Valid)
            {
                md = new MailDownloader(ic, settings, mail);
            }
            else
            {
                md = new MailDownloader();
            }
            md.OnStoppedDownloading += StopHandler;
            md.CreatedPath = created_path;
            UpdateStatus();
            return md;
        }
        private void CreateDirectories(out string filter_path)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(settings.OutputPath);
            sb.Append("\\");
            sb.Append(DateTime.Now.ToString("MM-dd-yyyy_HH-mm"));
            sb.Append("\\");
            string path = sb.ToString();
            Directory.CreateDirectory(path);
            created_path = path;
            sb.Append("Mails");
            filter_path = sb.ToString();
            Directory.CreateDirectory(filter_path);
        }
        public string GetCreatedPath()
        {
            return created_path;
        }
        public void StopDownloading()
        {
            if (updater != null)
                updater.Dispose();
            if (initiator != null)
                if (initiator.IsAlive)
                    initiator.Abort();
            if (downloaders == null)
                return;
            foreach (MailDownloader i in downloaders)
            {
                i.OnStoppedDownloading -= StopHandler;
                i.StopDownload();
            }
            filterer.SaveMail();
            if (OnStoppedDownloading == null) return;
            OnStoppedDownloading();
        }
        private void UpdateStatus()
        {
            if (OnUpdateStatus == null) return;
            OnUpdateStatus();
        }
        public void GetDownloadStats(out int valid, out int invalid, out int left, out int questionable)
        {
            filterer.GetInfo(out valid, out invalid, out left, out questionable);
        }
        public string GetDownloadProgress()
        {
            string res = "";
            int downloaded = 0;
            int all = 0;
            if (downloaders != null)
                foreach (var i in downloaders)
                {
                    all += i.AllMails;
                    downloaded += i.DownloadedMails;
                }
            res = downloaded + "\\" + all;
            return res;
        }
    }
}
