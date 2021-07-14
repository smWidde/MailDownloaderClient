using System.Net;
using System.Text;

namespace MailDownloader.Logic
{
    class ProxyConfig
    {
        public IPAddress IpAddress { get; set; }
        public int Port { get; set; }
        public ProxyConfig() { }
        public ProxyConfig(IPAddress ipaddress, int port)
        {
            IpAddress = ipaddress;
            Port = port;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(IpAddress.ToString());
            sb.Append(":");
            sb.Append(Port);
            return sb.ToString();
        }
    }
}
