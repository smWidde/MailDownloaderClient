using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace MailDownloader.Logic
{
    public static class Logger
    {
        private static string path = "logs.txt";
        private static List<string> msgs = new List<string>();
        public static bool IsAutosave
        {
            get { return th.ThreadState != ThreadState.Running; }
            set
            {
                if (value)
                {
                    th = new Thread(() => {
                        while (true)
                        {
                            Thread.Sleep(5000);
                            SaveLogs();
                        }
                    });
                    th.Start();
                }
                else
                {
                    th?.Abort();
                }
            }
        }
        private static Thread th;
        public static void SaveLogs()
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                while (msgs.Count != 0)
                {
                    sw.WriteLine(msgs[0]);
                    msgs.RemoveAt(0);
                }
            }
        }
        public static void Log(string msg)
        {
            msgs.Add(msg);
        }
    }
}
