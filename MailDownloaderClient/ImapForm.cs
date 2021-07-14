using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailDownloader
{
    public partial class ImapForm : Form
    {
        string problem;
        public string server;
        public int port;
        public bool ssl;
        public ImapForm()
        {
            InitializeComponent();
        }
        public ImapForm(string problem)
        {
            InitializeComponent();
            this.problem = problem;
            problemTextBox.Text = this.problem;
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(problem + " - неизвестный домен почты. Нужно найти данные IMAP сервера для данного домена, чтобы продолжить работу. Учтите, что при неправильном вводе эта форма откроется снова");
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            server = imapTextBox.Text;
            if(!int.TryParse(portTextBox.Text, out port))
            {
                MessageBox.Show("Неправильный формат числа порта");
                return;
            }
            ssl = sslCheckBox.Checked;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void invalid_btn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
