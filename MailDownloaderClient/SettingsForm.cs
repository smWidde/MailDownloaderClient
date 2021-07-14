using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailDownloader.Logic;
using Microsoft.WindowsAPICodePack.Dialogs;
namespace MailDownloader
{
    public partial class SettingsForm : Form
    {
        private DownloadSettings settings;
        public SettingsForm()
        {
            InitializeComponent();
        }
        public SettingsForm(DownloadSettings settings)
        {
            InitializeComponent();
            this.settings = settings;
            string output;
            long from, to;
            string[] extensions;
            long ticks;
            settings.GetSettings(out output, out from, out to, out extensions, out ticks);
            output_path_tb.Text = output;
            int grade = bytes_to_Mbytes(from);
            from_tb.Text = (from / (int)Math.Pow(1000, grade)).ToString();
            from_cb.SelectedIndex = grade;
            grade = bytes_to_Mbytes(to);
            to_tb.Text = (to / (int)Math.Pow(1000, grade)).ToString();
            to_cb.SelectedIndex = grade;
            foreach (var i in extensions)
            {
                extensions_lv.Items.Add(i);
            }
            dateTimePicker.Value = new DateTime(ticks);
            ToolTip tt = new ToolTip();
            tt.SetToolTip(mask_hint, "Выберите тип файла и нажмите \"+\". При выборе \"Использовать маску\", активируется \"Маска расширений\".");
            ToolTip tt2 = new ToolTip();
            tt2.SetToolTip(mask_hint2, "Введите свои расширения по формату 'расширение1; расширение2; расширение3'.\nЗатем нажмите \"+\".");
            ToolTip tt3 = new ToolTip();
            tt3.SetToolTip(mask_hint3, "Выделите расширения в списке, затем нажмите \"-\", чтобы удалить их.");
        }
        private int bytes_to_Mbytes(long bytes)
        {
            int res = 0;
            while (bytes % 1000 == 0 && res < 4 && bytes != 0)
            {
                res += 1;
                bytes /= 1000;
            }
            return res;
        }
        private void output_path_btn_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = settings.OutputPath;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                output_path_tb.Text = dialog.FileName;
            }
        }

        private void file_type_cb_SelectedValueChanged(object sender, EventArgs e)
        {
            bool value = file_type_cb.SelectedItem.ToString() == "Использовать маску";
            mask_hint2.Enabled = value;
            extensions_tb.Enabled = value;
            extensions_lbl.Enabled = value;
        }

        private void add_to_list(string txt)
        {
            if (extensions_lv.Items.Cast<ListViewItem>().Where(x => x.Text == txt).FirstOrDefault() == null)
            {
                extensions_lv.Items.Add(txt);
            }
        }

        private void extension_adder_btn_Click(object sender, EventArgs e)
        {
            if (file_type_cb.SelectedItem == null)
                return;
            switch (file_type_cb.SelectedItem.ToString())
            {
                case "Видео":
                    {
                        add_to_list("webm");
                        add_to_list("mkv");
                        add_to_list("flv");
                        add_to_list("vob");
                        add_to_list("ogv");
                        add_to_list("ogg");
                        add_to_list("drc");
                        add_to_list("gif");
                        add_to_list("gifv");
                        add_to_list("mng");
                        add_to_list("avi");
                        add_to_list("MTS");
                        add_to_list("M2TS");
                        add_to_list("TS");
                        add_to_list("mov");
                        add_to_list("qt");
                        add_to_list("wmv");
                        add_to_list("yuv");
                        add_to_list("rm");
                        add_to_list("rmvb");
                        add_to_list("viv");
                        add_to_list("asf");
                        add_to_list("amv");
                        add_to_list("mp4");
                        add_to_list("m4p");
                        add_to_list("m4v");
                        add_to_list("mpg");
                        add_to_list("mp2");
                        add_to_list("mpeg");
                        add_to_list("mpe");
                        add_to_list("mpv");
                        add_to_list("svi");
                        add_to_list("3gp");
                        add_to_list("3g2");
                        add_to_list("mxf");
                        add_to_list("roq");
                        add_to_list("nsv");
                        add_to_list("f4v");
                        add_to_list("f4p");
                        add_to_list("f4a");
                        add_to_list("f4b");
                        break;
                    }
                case "Изображения":
                    {
                        add_to_list("png");
                        add_to_list("tif");
                        add_to_list("tiff");
                        add_to_list("bmp");
                        add_to_list("jpg");
                        add_to_list("jpeg");
                        add_to_list("gif");
                        add_to_list("eps");
                        add_to_list("raw");
                        add_to_list("cr2");
                        add_to_list("nef");
                        add_to_list("orf");
                        add_to_list("sr2");
                        break;
                    }
                case "Презентации":
                    {
                        add_to_list("pptx");
                        add_to_list("pptm");
                        add_to_list("ppt");
                        add_to_list("potx");
                        add_to_list("potm");
                        add_to_list("pot");
                        add_to_list("ppsx");
                        add_to_list("ppsm");
                        add_to_list("pps");
                        add_to_list("ppam");
                        add_to_list("ppa");
                        add_to_list("key");
                        break;
                    }
                case "Документы":
                    {
                        add_to_list("doc");
                        add_to_list("docm");
                        add_to_list("docx");
                        add_to_list("dot");
                        add_to_list("dotm");
                        add_to_list("dotx");
                        add_to_list("htm");
                        add_to_list("html");
                        add_to_list("mht");
                        add_to_list("mhtml");
                        add_to_list("odt");
                        add_to_list("pdf");
                        add_to_list("rtf");
                        add_to_list("txt");
                        add_to_list("wps");
                        add_to_list("xml");
                        add_to_list("xmal");
                        add_to_list("xps");
                        add_to_list("csv");
                        add_to_list("dbf");
                        add_to_list("dif");
                        add_to_list("ods");
                        add_to_list("prn");
                        add_to_list("slk");
                        add_to_list("xla");
                        add_to_list("xls");
                        add_to_list("xlsb");
                        add_to_list("xlsm");
                        add_to_list("xlsx");
                        add_to_list("xlt");
                        add_to_list("xltm");
                        add_to_list("xltx");
                        break;
                    }
                case "Архивы":
                    {
                        add_to_list("zip");
                        add_to_list("7z");
                        add_to_list("s7z");
                        add_to_list("ace");
                        add_to_list("afa");
                        add_to_list("alz");
                        add_to_list("apk");
                        add_to_list("arc");
                        add_to_list("ark");
                        add_to_list("cdx");
                        add_to_list("arj");
                        add_to_list("b1");
                        add_to_list("b6z");
                        add_to_list("ba");
                        add_to_list("bh");
                        add_to_list("cab");
                        add_to_list("car");
                        add_to_list("cfs");
                        add_to_list("cpt");
                        add_to_list("dar");
                        add_to_list("dd");
                        add_to_list("dgc");
                        add_to_list("dmg");
                        add_to_list("ear");
                        add_to_list("gca");
                        add_to_list("ha");
                        add_to_list("hki");
                        add_to_list("ice");
                        add_to_list("jar");
                        add_to_list("kgb");
                        add_to_list("lzh");
                        add_to_list("lha");
                        add_to_list("lzx");
                        add_to_list("pak");
                        add_to_list("partimg");
                        add_to_list("paq6");
                        add_to_list("paq7");
                        add_to_list("paq8");
                        add_to_list("pea");
                        add_to_list("phar");
                        add_to_list("pim");
                        add_to_list("pit");
                        add_to_list("qda");
                        add_to_list("rar");
                        add_to_list("rk");
                        add_to_list("sda");
                        add_to_list("sea");
                        add_to_list("sen");
                        add_to_list("sfx");
                        add_to_list("shk");
                        add_to_list("sit");
                        add_to_list("sitx");
                        add_to_list("sqx");
                        add_to_list("tar");
                        add_to_list("gz");
                        add_to_list("tgz");
                        add_to_list("tbz2");
                        add_to_list("tlz");
                        add_to_list("txz");
                        add_to_list("uc");
                        add_to_list("uc0");
                        add_to_list("uc2");
                        add_to_list("ucn");
                        add_to_list("ur2");
                        add_to_list("ue2");
                        add_to_list("uca");
                        add_to_list("uha");
                        add_to_list("war");
                        add_to_list("wim");
                        add_to_list("xar");
                        add_to_list("xp3");
                        add_to_list("yz1");
                        add_to_list("zipx");
                        add_to_list("zoo");
                        add_to_list("zpaq");
                        add_to_list("zz");
                        break;
                    }
                case "Все":
                    {
                        add_to_list("*");
                        break;
                    }
                case "Использовать маску":
                    {
                        string[] res = extensions_tb.Text.Split(';');
                        foreach (string i in res)
                        {
                            add_to_list(i.Trim());
                        }

                        break;
                    }
            }
        }

        private void extension_deleter_btn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in extensions_lv.SelectedItems)
            {
                extensions_lv.Items.Remove(i);
            }
        }

        private void agree_btn_Click(object sender, EventArgs e)
        {
            long from = long.Parse(from_tb.Text) * (long)Math.Pow(1000, from_cb.SelectedIndex);
            long to = long.Parse(to_tb.Text) * (long)Math.Pow(1000, to_cb.SelectedIndex);
            string[] extensions = new string[extensions_lv.Items.Count];
            for (int i = 0; i < extensions.Length; i++)
            {
                extensions[i] = extensions_lv.Items[i].Text;
            }
            settings.SetSettings(output_path_tb.Text, from, to, extensions, dateTimePicker.Value.Ticks);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
