using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using MailKit.Net.Imap;
using Org.Mentalis.Network.ProxySocket;

namespace MailDownloader.Logic
{
    class ProxyConfigManager : ConfigManagerFabric
    {
        private List<ProxyConfig> proxies;
        private int index_socket;
        private int uses;
        private ProxyTypes type;
        public ProxyConfigManager(List<ProxyConfig> proxies, ProxyTypes type) : base()
        {
            this.proxies = proxies;
            this.type = type;
            index_socket = 0;
            uses = 0;
            manager = this;
        }
        public override ImapClient GetClient(string domain)
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
            ic = new ImapClient();
            if (proxies.Count != 0)
            {
                ProxySocket socket = new ProxySocket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.ProxyEndPoint = new IPEndPoint(proxies[index_socket].IpAddress, proxies[index_socket].Port);
                if (uses >= 100)
                {
                    index_socket++;
                    index_socket %= proxies.Count;
                    uses = 0;
                }
                socket.ProxyType = type;
                try
                {
                    socket.Connect(sc.Server, sc.Port);
                    if (socket.Connected)
                    {
                        ic.Connect(socket, sc.Server, sc.Port);
                        uses++;
                    }
                    else
                    {
                        try
                        {
                            ic.Connect(sc.Server, sc.Port, sc.SSL);
                            proxies.RemoveAt(index_socket);
                            index_socket--;
                            uses = 0;
                        }
                        catch (Exception ex)
                        {
                            Logger.Log(ex.Message + " proxy plain connect");
                            ic = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        ic.Connect(sc.Server, sc.Port, sc.SSL);
                        uses = 0;
                    }
                    catch (Exception ex2)
                    {
                        Logger.Log(ex2.Message + " proxy plain connect");
                        ic = null;
                    }
                    Logger.Log(ex.Message + " socket connect");
                }
            }
            else
            {
                try
                {
                    ic.Connect(sc.Server, sc.Port, sc.SSL);
                    uses = 0;
                }
                catch (Exception ex)
                {
                    ic = null;
                    Logger.Log(ex.Message + " proxy plain connect");
                }
            }
            ticks[domain] = Environment.TickCount;
            return ic;
        }
    }
}
