using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MailDownloader.Logic;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Linq;
using System.IO;
using Org.Mentalis.Network.ProxySocket;

namespace MailDownloader
{
    public partial class MainForm : Form
    {
        private MultiMailDownloadManagerProxy mmdm;
        private List<Mail> mails;
        private List<ProxyConfig> proxies;
        private Thread download;
        private State current = State.Blocked;
        private State request = State.Blocked;
        IPAddress serverAddr;
        int port;
        public string macAddress;
        private string path = "ipconfig.txt";
        TcpClient client;
        private NetworkStream stream;
        public void RequestWork()
        {
            SendMessage("access");
            request = State.Requesting;
        }
        public void Downloading()
        {
            SendMessage("download");
            request = State.Downloading;
        }
        public void Stopped()
        {
            SendMessage("stop");
            request = State.Stopped;
        }
        private void SendMessage(string msg)
        {
            try
            {
                byte[] data = new byte[256];
                StringBuilder response = new StringBuilder();
                data = Encoding.Unicode.GetBytes(macAddress + " " + msg);
                stream.Write(data, 0, data.Length);
            }
            catch
            {
                MessageBox.Show("Запрос не отправлен");
            }
        }

        private void GetIp()
        {
            serverAddr = IPAddress.Parse("127.0.0.1");
            port = 8888;
            if (File.Exists(path))
            {
                string[] strs = File.ReadAllLines(path);
                if (strs.Length != 0)
                {
                    string[] dcs_str = strs[0].Split(':');
                    if (dcs_str.Length == 2)
                    {
                        string ip_s = dcs_str[0];
                        IPAddress tmp;
                        if (IPAddress.TryParse(ip_s, out tmp))
                        {
                            int ptmp;
                            if (int.TryParse(dcs_str[1], out ptmp))
                            {
                                serverAddr = tmp;
                                port = ptmp;
                            }
                        }
                    }
                }
            }
        }
        Thread connection;
        private void Connect()
        {
            try
            {
                client = new TcpClient();
                GetIp();
                client.Connect(serverAddr, port);
                stream = client.GetStream();
                MessageBox.Show("Вы - онлайн, запросите доступ");
                byte[] data = new byte[256];
                RequestWork();
                while (true)
                {
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);
                    string message = builder.ToString();
                    if (message == "OK")
                    {
                        current = request;
                        this.Invoke((MethodInvoker)delegate
                        {
                            mail_pass_file.Enabled = settings_btn.Enabled = threads_lbl.Enabled =
                            threads_tb.Enabled = start_btn.Enabled = stop_btn.Enabled = left_btn.Enabled =
                            accounts_lbl.Enabled = accounts_tb.Enabled = valid_lbl.Enabled = valid_tb.Enabled =
                            valid_btn.Enabled = invalid_lbl.Enabled = invalid_tb.Enabled = invalid_btn.Enabled =
                            left_lbl.Enabled = left_tb.Enabled = mail_pass_buffer.Enabled = left_btn2.Enabled =
                            files_lbl.Enabled = files_tb.Enabled = files_btn.Enabled = proxy_type_group.Enabled =
                            button3.Enabled = true;
                        });
                    }
                    else
                    {
                        current = State.Blocked;
                        this.Invoke((MethodInvoker)delegate
                        {
                            stop_btn_Click(null, null);
                            mail_pass_file.Enabled = settings_btn.Enabled = threads_lbl.Enabled =
                            threads_tb.Enabled = start_btn.Enabled = stop_btn.Enabled = left_btn.Enabled =
                            accounts_lbl.Enabled = accounts_tb.Enabled = valid_lbl.Enabled = valid_tb.Enabled =
                            valid_btn.Enabled = invalid_lbl.Enabled = invalid_tb.Enabled = invalid_btn.Enabled =
                            left_lbl.Enabled = left_tb.Enabled = mail_pass_buffer.Enabled = left_btn2.Enabled =
                            files_lbl.Enabled = files_tb.Enabled = files_btn.Enabled = proxy_type_group.Enabled = 
                            button3.Enabled = false;
                        });
                    }
                }
            }
            catch (ThreadAbortException)
            {
                if (client != null)
                    client.Close();
                if (stream != null)
                    stream.Close();
                client = null;
                stream = null;
            }
            catch (Exception)
            {
                if (client != null)
                    client.Close();
                if (stream != null)
                    stream.Close();
                client = null;
                stream = null;
                MessageBox.Show("Хост - оффлайн");
            }
        }
        public MainForm()
        {
            macAddress = NetworkInterface
    .GetAllNetworkInterfaces()
    .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
    .Select(nic => nic.GetPhysicalAddress().ToString())
    .FirstOrDefault();
            connection = new Thread(Connect);
            connection.Start();
            ConfigManagerFabric.DomainNotFound += Manager_DomainNotFound;
            mmdm = new MultiMailDownloadManagerProxy();
            InitializeComponent();
            mmdm.OnUpdateStatus += delegate
            {
                this.Invoke((MethodInvoker)delegate
                {
                    int all, left, valid, invalid, questionable;
                    mmdm.GetDownloadStats(out valid, out invalid, out left, out questionable);
                    all = valid + invalid + left + questionable;
                    accounts_tb.Text = all.ToString();
                    invalid_tb.Text = invalid.ToString();
                    valid_tb.Text = valid.ToString();
                    left_tb.Text = left.ToString();
                    files_tb.Text = mmdm.DownloadedFileCount.ToString();
                });
            };
            mmdm.OnStoppedDownloading += delegate
            {
                this.Invoke((MethodInvoker)delegate
                {
                    left_btn2.Enabled = invalid_btn.Enabled = valid_btn.Enabled = true;
                });
                if (current != State.Blocked)
                    Stopped();
            };
            address_tb.Text = serverAddr.ToString() + ":" + port;
        }
        private ServerConfig Manager_DomainNotFound(string domain)
        {
            ImapForm form = new ImapForm(domain);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.No)
            {
                return new ServerConfig();
            }
            else if (dr == DialogResult.OK)
            {
                return new ServerConfig(form.server, form.port, form.ssl);
            }
            else
            {
                return null;
            }
        }
        private void settings_btn_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm(mmdm.settings);
            form.ShowDialog();
        }
        private void mailsFromText(string[] mails_str)
        {
            mails = new List<Mail>();
            for (int i = 0; i < mails_str.Length; i++)
            {
                string[] res = mails_str[i].Split(':');
                if (res.Length >= 2)
                {
                    string pass = res[1];
                    for (int j = 2; j < res.Length; j++)
                    {
                        pass += ":" + res[j];
                    }
                    mails.Add(new Mail(res[0], pass));
                }
                else
                {
                    mails.Add(new Mail(mails_str[i], null));
                }
            }
        }
        private void mail_pass_buffer_Click(object sender, EventArgs e)
        {
            string text = Clipboard.GetText();
            string[] mails_str = text.Split('\n');
            mailsFromText(mails_str);
            mail_pass_buffer.BackColor = Color.LimeGreen;
            mail_pass_file.BackColor = settings_btn.BackColor;
        }
        private ProxyTypes GetProxy()
        {
            ProxyTypes res = ProxyTypes.None;
            if (proxy_type1.Checked)
                res = ProxyTypes.Socks4;
            else if (proxy_type2.Checked)
                res = ProxyTypes.Socks5;
            return res;
        }
        private void start_btn_Click(object sender, EventArgs e)
        {
            int? threads = parseThreadsCount();
            if (threads == null)
                return;
            if (mails != null)
            {
                if (proxies != null && proxies?.Count != 0)
                {
                    DialogResult dr = MessageBox.Show("Использовать прокси?", "", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        ProxyTypes res = GetProxy();
                        if (res != ProxyTypes.None)
                            new ProxyConfigManager(proxies, res);
                        else
                        {
                            MessageBox.Show("Не выбран тип прокси");
                            return;
                        }
                    }
                    else
                    {
                        ConfigManagerFabric.SummonBase();
                    }
                }
                mail_pass_buffer.BackColor = settings_btn.BackColor;
                mail_pass_file.BackColor = settings_btn.BackColor;
                download = new Thread(() =>
                {
                    mmdm.StartDownloading(mails, threads.Value);
                });
                download.Start();
            }
            else
            {
                MessageBox.Show("mail:pass коллекция не выбрана");
                return;
            }
            left_btn2.Enabled = invalid_btn.Enabled = valid_btn.Enabled = false;
            files_btn.Enabled = true;
        }
        private int? parseThreadsCount()
        {
            int res;
            if (int.TryParse(threads_tb.Text, out res))
                return res;
            MessageBox.Show("Неправильный формат числа");
            return null;
        }
        private void mail_pass_file_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = mmdm.GetCreatedPath();
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                mailsFromText(System.IO.File.ReadAllLines(dialog.FileName));
                mail_pass_buffer.BackColor = settings_btn.BackColor;
                mail_pass_file.BackColor = Color.LimeGreen;
            }
        }
        private void left_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Проверено писем\\всего: " + mmdm.GetDownloadProgress());
        }
        private void stop_btn_Click(object sender, EventArgs e)
        {
            mmdm.StopDownloading();
            left_btn2.Enabled = invalid_btn.Enabled = valid_btn.Enabled = true;
            mmdm.StopDownloading();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mmdm != null)
                stop_btn_Click(null, null);
            if (stream != null)
            {
                stream.Close();
            }
            if (client != null)
            {
                client.Close();
            }
            if (connection.ThreadState == System.Threading.ThreadState.Running)
            {
                connection.Abort();
            }
            ConfigManagerFabric.DomainNotFound -= Manager_DomainNotFound;
        }
        private void filter_btn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", mmdm.FilterPath);
        }
        private void files_btn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", mmdm.GetCreatedPath());
        }

        private void accounts_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (stream == null || client == null)
            {
                if (connection.ThreadState != System.Threading.ThreadState.Running)
                {
                    connection = new Thread(Connect);
                    connection.Start();
                }
            }
            else
            {
                RequestWork();
            }
        }
        private List<ProxyConfig> proxiesFromText(string[] strs)
        {
            List<ProxyConfig> proxies = new List<ProxyConfig>();
            for (int i = 0; i < strs.Length; i++)
            {
                string[] res = strs[i].Split(':');
                if (res.Length >= 2)
                {
                    System.Net.IPAddress ip;
                    if (System.Net.IPAddress.TryParse(res[0], out ip))
                    {
                        int port;
                        if (int.TryParse(res[1], out port))
                            proxies.Add(new ProxyConfig(ip, port));
                    }
                }
            }
            return proxies;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = mmdm.GetCreatedPath();
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                proxies = proxiesFromText(System.IO.File.ReadAllLines(dialog.FileName));
                proxy_type_group.Enabled = true;
                button3.BackColor = Color.LimeGreen;
            }
        }
    }
}
