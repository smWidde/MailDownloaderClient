using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
//using S22.Imap;
using MailKit.Net.Imap;
using MimeKit;

namespace MailDownloader.Logic
{
    public class MailDownloader
    {
        private ImapClient ic;
        private Mail mail;
        public DownloadSettings Settings;
        private Thread download_thread;
        public delegate void StopDownloadingHandler(MailDownloader md);
        public event StopDownloadingHandler OnStoppedDownloading;
        public int DownloadedMails { get; private set; }
        public int AllMails { get; private set; }
        public string CreatedPath { get { return created_path; } set { created_path = value; if (value.Last() != '\\') created_path += "\\"; } }
        private string created_path;
        private const int refresh_count = 10000;
        public void Recopy(MailDownloader md)
        {
            ic = md.ic;
            mail = md.mail;
            Settings = md.Settings;
        }
        public MailDownloader(ImapClient ic, DownloadSettings settings, Mail mail)
        {
            this.ic = ic;
            this.mail = mail;
            Settings = settings;
        }
        public MailDownloader() { }
        private void ThreadStopper(MailDownloader md)
        {
            download_thread?.Abort();
        }
        public void StartDownload(int threads_count = 4)
        {
            if (ic == null || mail == null || Settings == null)
            {
                StopDownload();
                return;
            }
            download_thread = new Thread(() =>
            {
                try
                {
                    //S22
                    //List<uint> ids = new List<uint>();
                    //IEnumerable<string> mailboxes = ic.ListMailboxes();
                    //foreach (var mailbox in mailboxes)
                    //{
                    //    ic.DefaultMailbox = mailbox;
                    //    ids.AddRange(ic.Search(SearchCondition.All()));
                    //}
                    //ids.AddRange(ic.Search(SearchCondition.All()));
                    //foreach (uint id in ids)
                    //{
                    //    RetrieveAttachments(ic, id);
                    //}
                    //MailKit
                    AllMails = DownloadedMails = 0;
                    Dictionary<MailKit.UniqueId, string> ids = new Dictionary<MailKit.UniqueId, string>();
                    foreach (var folder in ic.GetFolders(ic.PersonalNamespaces[0]))
                    {
                        try
                        {
                            folder.Open(MailKit.FolderAccess.ReadOnly);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                        List<MailKit.UniqueId> tids = folder.Search(MailKit.Search.SearchQuery.DeliveredAfter(Settings.GetDate())).ToList();
                        tids.AddRange(folder.Search(MailKit.Search.SearchQuery.DeliveredOn(Settings.GetDate())).ToList());
                        foreach (var i in tids)
                        {
                            if (!ids.ContainsKey(i))
                                ids.Add(i, folder.FullName);
                        }
                        folder.Close();
                        AllMails = ids.Count;
                    }
                    AllMails = ids.Count;
                    int curr = 0;
                    ic.Disconnect(true);
                    ic = ConfigManagerFabric.Manager.GetClient(mail.Login.Split('@').Last());
                    ic.Authenticate(mail.Login, mail.Pass);
                    foreach (var id in ids)
                    {
                        MailKit.IMailFolder folder = ic.GetFolder(id.Value);
                        folder.Open(MailKit.FolderAccess.ReadOnly);
                        RetrieveAttachments(folder, id.Key);
                        folder.Close();
                        curr++;
                        if (curr >= refresh_count)
                        {
                            ic.Disconnect(true);
                            ic = ConfigManagerFabric.Manager.GetClient(mail.Login.Split('@').Last());
                            ic.Authenticate(mail.Login, mail.Pass);
                            curr = 0;
                        }
                    }
                    OnStoppedDownloading -= ThreadStopper;
                    StopDownload();
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.Message + " start download");
                    OnStoppedDownloading -= ThreadStopper;
                    StopDownload();
                }
            });
            OnStoppedDownloading += ThreadStopper;
            download_thread.Start();
        }
        public void StopDownload()
        {
            OnStoppedDownloading?.Invoke(this);
        }
        private void RetrieveAttachments(MailKit.IMailFolder imapf, MailKit.UniqueId id, int attempt = 0)
        {
            StringBuilder sb = new StringBuilder();
            MimeMessage mm;
            try
            {
                mm = imapf.GetMessage(id);
                foreach (var j in mm.Attachments)
                {
                    string file_name;
                    if (GetFileName(j.ContentDisposition.FileName, out file_name))
                        if (j is MessagePart)
                        {
                            var rfc822 = (MessagePart)j;
                            if (Settings.SizeMatch(MeasureAttachmentSize(rfc822)))
                                using (var stream = File.Create(file_name))
                                {
                                    rfc822.Message.WriteTo(stream);
                                }
                        }
                        else
                        {
                            var part = (MimePart)j;
                            if (Settings.SizeMatch(MeasureAttachmentSize(part)))
                                using (var stream = File.Create(file_name))
                                {
                                    part.Content.DecodeTo(stream);
                                }
                        }
                }
                DownloadedMails++;
            }
            catch (Exception ex)
            {
                attempt++;
                if (attempt <= 10)
                    RetrieveAttachments(imapf, id, attempt);
                Logger.Log(ex.Message + "Retrieve attachments");
            }
        }
        private static long MeasureAttachmentSize(MessagePart part)
        {
            using (var measure = new MimeKit.IO.MeasuringStream())
            {
                part.Message.WriteTo(measure);
                return measure.Length;
            }
        }
        private static long MeasureAttachmentSize(MimePart part)
        {
            using (var measure = new MimeKit.IO.MeasuringStream())
            {
                part.Content.DecodeTo(measure);
                return measure.Length;
            }
        }
        private bool GetFileName(string name, out string file_name)
        {
            file_name = DecodeMime(name);
            if (file_name.Contains("?"))
            {
                file_name = "unknown";
                if (!Path.GetExtension(file_name).Contains("?"))
                    file_name += Path.GetExtension(file_name);
            }
            if (Settings.ExtensionMatch(Path.GetExtension(file_name)))
            {
                StringBuilder sb = new StringBuilder();
                file_name.Replace('\\', 't');
                sb.Append(CreatedPath);
                sb.Append(mail.Login);
                sb.Append(" ");
                sb.Append(file_name);
                file_name = sb.ToString();
                sb.Clear();
                while (File.Exists(file_name))
                {
                    sb.Append(CreatedPath);
                    sb.Append(Path.GetFileNameWithoutExtension(file_name));
                    sb.Append("_");
                    sb.Append(Path.GetExtension(file_name));
                    file_name = sb.ToString();
                    sb.Clear();
                }
                return true;
            }
            return false;
        }
        private string DecodeMime(string text)
        {
            Regex regex = new Regex(@"=\?{1}(.+)\?{1}([B|Q])\?{1}(.+)\?{1}=");
            if (regex.IsMatch(text))
            {
                string res = "";
                foreach (string i in text.Split(' ', '\t').Select(x => x).Where(x => x != ""))
                {
                    byte[] bytes;
                    if (i.Split('?')[2] == "B")
                    {
                        bytes = Convert.FromBase64String(i.Split('?')[3]);
                    }
                    else
                    {
                        bytes = DecodeQuotedPrintable(i.Split('?')[3]);
                    }
                    res += Encoding.GetEncoding(i.Split('?')[1]).GetString(bytes);
                }
                return res;
            }
            return text;
        }
        private byte[] DecodeQuotedPrintable(string str)
        {
            var result = new List<byte>();
            str = str.Replace("=\r\n", "");
            for (int i = 0; i < str.Length; i++)
            {
                var c = str[i];
                switch (c)
                {
                    case '=':
                        var b = Convert.ToByte(str.Substring(i + 1, 2), 16);
                        result.Add(b);
                        i += 2;
                        break;
                    default:
                        result.Add((byte)c);
                        break;
                }
            }

            return result.ToArray();
        }
    }
}
