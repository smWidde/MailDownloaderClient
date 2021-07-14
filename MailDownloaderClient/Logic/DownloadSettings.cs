using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailDownloader.Logic
{
    public class DownloadSettings
    {
        private string settings = "settings.txt";
        private string output_path;
        private long size_from;
        private long size_to;
        private string[] extensions;
        private long from_date_ticks;
        public string OutputPath { get { return output_path; } }
        public DownloadSettings()
        {
            GetSettings();
        }
        public void SetSettings(string output, long size_from, long size_to, string[] extensions, long ticks)
        {
            output_path = output;
            this.size_from = size_from;
            this.size_to = size_to;
            this.extensions = extensions;
            from_date_ticks = ticks;
            SaveSettings();
        }
        public void GetSettings(out string output, out long size_from, out long size_to, out string[] extensions, out long ticks)
        {
            output = output_path;
            size_from = this.size_from;
            size_to = this.size_to;
            extensions = this.extensions;
            ticks = from_date_ticks;
        }
        public bool ExtensionMatch(string extension)
        {
            extension = extension.ToLower();
            foreach (string i in extensions)
            {
                if (extension == "." + i.ToLower() || i == "*")
                    return true;
            }
            return false;
        }
        public bool SizeMatch(long file_size)
        {
            return file_size >= size_from && file_size <= size_to;
        }
        public DateTime GetDate()
        {
            return new DateTime(from_date_ticks);
        }
        private void GetSettings()
        {
            output_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            size_from = 0;
            size_to = 25000000;
            extensions = new string[] { "*" };
            from_date_ticks = DateTime.Now.Ticks;
            if (File.Exists(settings))
            {
                try
                {
                    string[] settings_strs = File.ReadAllLines(settings);
                    if (settings_strs.Length == 5)
                    {
                        output_path = settings_strs[0];
                        size_from = long.Parse(settings_strs[1]);
                        size_to = long.Parse(settings_strs[2]);
                        extensions = settings_strs[3].Split(':');
                        from_date_ticks = long.Parse(settings_strs[4]);
                    }
                }
                catch (Exception)
                {
                    SaveSettings();
                }
            }
        }
        private void SaveSettings()
        {
            using (StreamWriter sw = File.CreateText(settings))
            {
                sw.WriteLine(output_path);
                sw.WriteLine(size_from);
                sw.WriteLine(size_to);
                string res = extensions[0];
                for (int i = 1; i < extensions.Length; i++)
                    res += ":" + extensions[i];
                sw.WriteLine(res);
                sw.WriteLine(from_date_ticks);
            }
        }
    }
}
