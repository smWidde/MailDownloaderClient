using System.Text;

namespace MailDownloader.Logic
{
    public class ServerConfig
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public bool SSL { get; set; }
        public ServerConfig()
        {
            Server = "";
            Port = 0;
            SSL = false;
        }
        public ServerConfig(string server, int port, bool ssl)
        {
            Server = server;
            Port = port;
            SSL = ssl;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Server);
            sb.Append(":");
            sb.Append(Port);
            sb.Append(":");
            sb.Append(SSL);
            return sb.ToString();
        }
    }
}
