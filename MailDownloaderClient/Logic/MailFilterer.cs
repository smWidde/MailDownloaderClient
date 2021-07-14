using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
//using S22.Imap;
using System.Linq;
using MailKit.Net.Imap;
using MailKit.Search;

namespace MailDownloader.Logic
{
    public enum MailValue
    {
        Valid, Invalid, Left, Questionable
    }
    public class MailFilterer
    {
        private bool isSaving = false;
        private string[] pathes = { "valid.txt", "invalid.txt", "left.txt", "questionable.txt" };
        private Dictionary<Mail, MailValue> mails;
        public MailFilterer(List<Mail> mails, string path)
        {
            this.mails = new Dictionary<Mail, MailValue>();
            foreach (var i in mails)
                this.mails.Add(i, MailValue.Left);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < pathes.Length; i++)
            {
                sb.Append(path);
                sb.Append("\\");
                sb.Append(pathes[i]);
                pathes[i] = sb.ToString();
                sb.Clear();
            }
        }
        public MailValue CheckMail(Mail mail, out ImapClient ic)
        {
            ic = null;
            if (mail.Pass == null)
                return MailValue.Invalid;
            MailValue value;
            ic = ConfigManagerFabric.Manager.GetClient(mail.Login.Split('@')[1]);
            if (ic != null)
                try
                {
                    ic.Authenticate(mail.Login, mail.Pass);
                    try
                    {
                        ic.Inbox.Open(MailKit.FolderAccess.ReadOnly);
                        ic.Inbox.Search(SearchQuery.All);
                        ic.Inbox.Close();
                        value = MailValue.Valid;
                    }
                    catch (Exception ex)
                    {
                        value = MailValue.Invalid;
                        Logger.Log(" Inbox провалился:" + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    value = MailValue.Invalid;
                    Logger.Log(" Authenticate провалился:" + ex.Message);
                    ic = null;
                }
            else
            {
                value = MailValue.Invalid;
                Logger.Log("Can`t connect to server");
            }
            if (mails.ContainsKey(mail))
                mails[mail] = value;
            else
                mails.Add(mail, value);
            while (isSaving)
                System.Threading.Thread.Sleep(1000);
            return value;
        }
        public void GetInfo(out int valid, out int invalid, out int left, out int questionable)
        {
            valid = invalid = left = questionable = 0;
            var values = mails.Values.ToList();
            for (int i = 0; i < values.Count; i++)
                switch (values[i])
                {
                    case MailValue.Valid:
                        valid++;
                        break;
                    case MailValue.Invalid:
                        invalid++;
                        break;
                    case MailValue.Left:
                        left++;
                        break;
                    case MailValue.Questionable:
                        questionable++;
                        break;
                }
        }
        public void SaveMail()
        {
            List<StreamWriter> sws = new List<StreamWriter>();
            for (int i = 0; i < pathes.Length; i++)
                sws.Add(new StreamWriter(pathes[i]));
            var keys = mails.Keys.ToList();
            var values = mails.Values.ToList();
            for (int i = 0; i < values.Count; i++)
                sws[(int)values[i]].WriteLine(keys[i]);
            foreach (var i in sws)
            {
                i.Flush();
                i.Close();
            }
        }
    }
}
