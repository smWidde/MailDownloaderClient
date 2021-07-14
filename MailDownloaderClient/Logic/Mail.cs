using System.Text;

namespace MailDownloader.Logic
{
    public class Mail
    {
        public string Login { get; set; }
        public string Pass { get; set; }
        public Mail() { }
        public Mail(string email, string pass)
        {
            this.Login = email;
            this.Pass = pass;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Login);
            sb.Append(":");
            sb.Append(Pass);
            return sb.ToString();
        }
    }
}
