using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
//using S22.Imap;
using MailKit.Net.Imap;
namespace MailDownloader.Logic
{
    public class ConfigManagerFabric
    {
        protected static ConfigManagerFabric manager;
        protected static string path = "configs.txt";
        public delegate ServerConfig DomainNotFoundHandler(string domain);
        public static event DomainNotFoundHandler DomainNotFound;
        protected ServerConfig FindDomain(string domain)
        {
            ServerConfig sc = null;
            sc = DomainNotFound?.Invoke(domain);
            while (sc == null)
            {
                if (DomainNotFound == null)
                    return null;
                sc = DomainNotFound(domain);
            }
            return sc;
        }
        public static ConfigManagerFabric Manager
        {
            get
            {
                if (manager == null)
                    manager = new ConfigManagerFabric();
                return manager;
            }
        }
        protected ConfigManagerFabric()
        {
            GetConfigs();
        }
        public static void SummonBase()
        {
            if (manager is ProxyConfigManager)
                manager = new ConfigManagerFabric();
        }
        protected static Dictionary<string, ServerConfig> configs;
        protected static List<string> invalidConfigs;
        protected static Dictionary<string, int> ticks;
        protected int WaitTime = 200;
        public ServerConfig AddConfig(string domain, ServerConfig sc)
        {
            if (sc.Server == "")
            {
                invalidConfigs.Add(domain);
                return sc;
            }
            if (!CheckConfig(sc))
            {
                return null;
            }
            configs.Add(domain, sc);
            SaveConfigs();
            return sc;
        }
        public ServerConfig AddConfig(string domain, string server, int port, bool ssl)
        {
            return AddConfig(domain, new ServerConfig(server, port, ssl));
        }
        public bool CheckConfig(ServerConfig sc)
        {
            return CheckConfig(sc.Server, sc.Port, sc.SSL);
        }
        public bool CheckConfig(string server, int port, bool ssl)
        {
            try
            {
                ImapClient ic = new ImapClient();
                ic.Connect(server, port, ssl);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public virtual ImapClient GetClient(string domain)
        {
            ImapClient ic = null;
            int tick = 0;
            if (ticks.ContainsKey(domain))
            {
                tick = ticks[domain];
            }
            int time = Environment.TickCount - tick - WaitTime;
            if (time < 0)
                Thread.Sleep(-time);
            ServerConfig sc = null;
            if (configs.ContainsKey(domain))
                sc = configs[domain];
            if (sc == null)
            {
                if (!invalidConfigs.Contains(domain))
                {
                    sc = FindDomain(domain);
                    AddConfig(domain, sc);
                    return GetClient(domain);
                }
                else
                    return null;
            }
            try
            {
                ic = new ImapClient();
                ic.Connect(sc.Server, sc.Port, sc.SSL);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message + " get client");
                ic = null;
            }
            ticks[domain] = Environment.TickCount;
            return ic;
        }
        protected static void GetConfigs()
        {
            configs = new Dictionary<string, ServerConfig>();
            invalidConfigs = new List<string>();
            ticks = new Dictionary<string, int>();
            if (File.Exists(path))
            {
                string[] dcs_str = File.ReadAllLines(path);
                for (int i = 0; i < dcs_str.Length; i++)
                {
                    string[] res = dcs_str[i].Split(':');
                    if (res.Length == 4)
                        configs.Add(res[0], new ServerConfig(res[1], int.Parse(res[2]), bool.Parse(res[3])));
                    else
                        invalidConfigs.Add(dcs_str[i]);
                }
            }
        }
        protected static void SaveConfigs()
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (var i in configs)
                    sw.WriteLine(i.Key + ":" + i.Value);
                foreach (string i in invalidConfigs)
                    sw.WriteLine(i);
            }
        }
    }
}