namespace MailDownloader
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.settings_btn = new System.Windows.Forms.Button();
            this.threads_lbl = new System.Windows.Forms.Label();
            this.threads_tb = new System.Windows.Forms.TextBox();
            this.start_btn = new System.Windows.Forms.Button();
            this.stop_btn = new System.Windows.Forms.Button();
            this.left_btn = new System.Windows.Forms.Button();
            this.accounts_lbl = new System.Windows.Forms.Label();
            this.accounts_tb = new System.Windows.Forms.TextBox();
            this.valid_tb = new System.Windows.Forms.TextBox();
            this.valid_lbl = new System.Windows.Forms.Label();
            this.invalid_tb = new System.Windows.Forms.TextBox();
            this.invalid_lbl = new System.Windows.Forms.Label();
            this.files_tb = new System.Windows.Forms.TextBox();
            this.files_lbl = new System.Windows.Forms.Label();
            this.valid_btn = new System.Windows.Forms.Button();
            this.files_btn = new System.Windows.Forms.Button();
            this.invalid_btn = new System.Windows.Forms.Button();
            this.mail_pass_buffer = new System.Windows.Forms.Button();
            this.mail_pass_file = new System.Windows.Forms.Button();
            this.left_btn2 = new System.Windows.Forms.Button();
            this.left_tb = new System.Windows.Forms.TextBox();
            this.left_lbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.address_tb = new System.Windows.Forms.TextBox();
            this.adress_lbl = new System.Windows.Forms.Label();
            this.proxy_type_group = new System.Windows.Forms.GroupBox();
            this.proxy_type2 = new System.Windows.Forms.RadioButton();
            this.proxy_type1 = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.proxy_type_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // settings_btn
            // 
            this.settings_btn.Enabled = false;
            this.settings_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.settings_btn.Location = new System.Drawing.Point(220, 19);
            this.settings_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.settings_btn.Name = "settings_btn";
            this.settings_btn.Size = new System.Drawing.Size(195, 246);
            this.settings_btn.TabIndex = 1;
            this.settings_btn.Text = "Настройки";
            this.settings_btn.UseVisualStyleBackColor = true;
            this.settings_btn.Click += new System.EventHandler(this.settings_btn_Click);
            // 
            // threads_lbl
            // 
            this.threads_lbl.AutoSize = true;
            this.threads_lbl.Enabled = false;
            this.threads_lbl.Location = new System.Drawing.Point(85, 410);
            this.threads_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.threads_lbl.Name = "threads_lbl";
            this.threads_lbl.Size = new System.Drawing.Size(65, 20);
            this.threads_lbl.TabIndex = 3;
            this.threads_lbl.Text = "Потоки";
            // 
            // threads_tb
            // 
            this.threads_tb.Enabled = false;
            this.threads_tb.Location = new System.Drawing.Point(219, 405);
            this.threads_tb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.threads_tb.Name = "threads_tb";
            this.threads_tb.Size = new System.Drawing.Size(193, 26);
            this.threads_tb.TabIndex = 4;
            // 
            // start_btn
            // 
            this.start_btn.Enabled = false;
            this.start_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.start_btn.Location = new System.Drawing.Point(17, 445);
            this.start_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(195, 78);
            this.start_btn.TabIndex = 5;
            this.start_btn.Text = "Старт";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // stop_btn
            // 
            this.stop_btn.Enabled = false;
            this.stop_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.stop_btn.Location = new System.Drawing.Point(221, 445);
            this.stop_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(195, 78);
            this.stop_btn.TabIndex = 6;
            this.stop_btn.Text = "Стоп";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // left_btn
            // 
            this.left_btn.Enabled = false;
            this.left_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.left_btn.Location = new System.Drawing.Point(18, 531);
            this.left_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.left_btn.Name = "left_btn";
            this.left_btn.Size = new System.Drawing.Size(397, 78);
            this.left_btn.TabIndex = 7;
            this.left_btn.Text = "Остаток";
            this.left_btn.UseVisualStyleBackColor = true;
            this.left_btn.Click += new System.EventHandler(this.left_btn_Click);
            // 
            // accounts_lbl
            // 
            this.accounts_lbl.AutoSize = true;
            this.accounts_lbl.Enabled = false;
            this.accounts_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.accounts_lbl.Location = new System.Drawing.Point(461, 427);
            this.accounts_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.accounts_lbl.Name = "accounts_lbl";
            this.accounts_lbl.Size = new System.Drawing.Size(76, 17);
            this.accounts_lbl.TabIndex = 10;
            this.accounts_lbl.Text = "Аккаунтов";
            // 
            // accounts_tb
            // 
            this.accounts_tb.Enabled = false;
            this.accounts_tb.Location = new System.Drawing.Point(636, 416);
            this.accounts_tb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.accounts_tb.Name = "accounts_tb";
            this.accounts_tb.ReadOnly = true;
            this.accounts_tb.Size = new System.Drawing.Size(136, 26);
            this.accounts_tb.TabIndex = 11;
            this.accounts_tb.TextChanged += new System.EventHandler(this.accounts_tb_TextChanged);
            // 
            // valid_tb
            // 
            this.valid_tb.Enabled = false;
            this.valid_tb.Location = new System.Drawing.Point(636, 456);
            this.valid_tb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.valid_tb.Name = "valid_tb";
            this.valid_tb.ReadOnly = true;
            this.valid_tb.Size = new System.Drawing.Size(136, 26);
            this.valid_tb.TabIndex = 13;
            // 
            // valid_lbl
            // 
            this.valid_lbl.AutoSize = true;
            this.valid_lbl.Enabled = false;
            this.valid_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.valid_lbl.Location = new System.Drawing.Point(461, 467);
            this.valid_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.valid_lbl.Name = "valid_lbl";
            this.valid_lbl.Size = new System.Drawing.Size(75, 17);
            this.valid_lbl.TabIndex = 12;
            this.valid_lbl.Text = "Валидные";
            // 
            // invalid_tb
            // 
            this.invalid_tb.Enabled = false;
            this.invalid_tb.Location = new System.Drawing.Point(636, 496);
            this.invalid_tb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.invalid_tb.Name = "invalid_tb";
            this.invalid_tb.ReadOnly = true;
            this.invalid_tb.Size = new System.Drawing.Size(136, 26);
            this.invalid_tb.TabIndex = 15;
            // 
            // invalid_lbl
            // 
            this.invalid_lbl.AutoSize = true;
            this.invalid_lbl.Enabled = false;
            this.invalid_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.invalid_lbl.Location = new System.Drawing.Point(461, 507);
            this.invalid_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.invalid_lbl.Name = "invalid_lbl";
            this.invalid_lbl.Size = new System.Drawing.Size(95, 17);
            this.invalid_lbl.TabIndex = 14;
            this.invalid_lbl.Text = "Не валидные";
            // 
            // files_tb
            // 
            this.files_tb.Enabled = false;
            this.files_tb.Location = new System.Drawing.Point(636, 576);
            this.files_tb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.files_tb.Name = "files_tb";
            this.files_tb.ReadOnly = true;
            this.files_tb.Size = new System.Drawing.Size(136, 26);
            this.files_tb.TabIndex = 17;
            // 
            // files_lbl
            // 
            this.files_lbl.AutoSize = true;
            this.files_lbl.Enabled = false;
            this.files_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.files_lbl.Location = new System.Drawing.Point(461, 587);
            this.files_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.files_lbl.Name = "files_lbl";
            this.files_lbl.Size = new System.Drawing.Size(60, 17);
            this.files_lbl.TabIndex = 16;
            this.files_lbl.Text = "Файлов";
            // 
            // valid_btn
            // 
            this.valid_btn.Enabled = false;
            this.valid_btn.Location = new System.Drawing.Point(783, 456);
            this.valid_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.valid_btn.Name = "valid_btn";
            this.valid_btn.Size = new System.Drawing.Size(46, 32);
            this.valid_btn.TabIndex = 21;
            this.valid_btn.Text = "...";
            this.valid_btn.UseVisualStyleBackColor = true;
            this.valid_btn.Click += new System.EventHandler(this.filter_btn_Click);
            // 
            // files_btn
            // 
            this.files_btn.Enabled = false;
            this.files_btn.Location = new System.Drawing.Point(783, 575);
            this.files_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.files_btn.Name = "files_btn";
            this.files_btn.Size = new System.Drawing.Size(46, 32);
            this.files_btn.TabIndex = 23;
            this.files_btn.Text = "...";
            this.files_btn.UseVisualStyleBackColor = true;
            this.files_btn.Click += new System.EventHandler(this.files_btn_Click);
            // 
            // invalid_btn
            // 
            this.invalid_btn.Enabled = false;
            this.invalid_btn.Location = new System.Drawing.Point(783, 495);
            this.invalid_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.invalid_btn.Name = "invalid_btn";
            this.invalid_btn.Size = new System.Drawing.Size(46, 32);
            this.invalid_btn.TabIndex = 22;
            this.invalid_btn.Text = "...";
            this.invalid_btn.UseVisualStyleBackColor = true;
            this.invalid_btn.Click += new System.EventHandler(this.filter_btn_Click);
            // 
            // mail_pass_buffer
            // 
            this.mail_pass_buffer.Enabled = false;
            this.mail_pass_buffer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.mail_pass_buffer.Location = new System.Drawing.Point(18, 19);
            this.mail_pass_buffer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mail_pass_buffer.Name = "mail_pass_buffer";
            this.mail_pass_buffer.Size = new System.Drawing.Size(194, 118);
            this.mail_pass_buffer.TabIndex = 26;
            this.mail_pass_buffer.Text = "mail:pass из буфера";
            this.mail_pass_buffer.UseVisualStyleBackColor = true;
            this.mail_pass_buffer.Click += new System.EventHandler(this.mail_pass_buffer_Click);
            // 
            // mail_pass_file
            // 
            this.mail_pass_file.Enabled = false;
            this.mail_pass_file.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.mail_pass_file.Location = new System.Drawing.Point(18, 147);
            this.mail_pass_file.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mail_pass_file.Name = "mail_pass_file";
            this.mail_pass_file.Size = new System.Drawing.Size(194, 118);
            this.mail_pass_file.TabIndex = 27;
            this.mail_pass_file.Text = "mail:pass из файла";
            this.mail_pass_file.UseVisualStyleBackColor = true;
            this.mail_pass_file.Click += new System.EventHandler(this.mail_pass_file_Click);
            // 
            // left_btn2
            // 
            this.left_btn2.Enabled = false;
            this.left_btn2.Location = new System.Drawing.Point(783, 535);
            this.left_btn2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.left_btn2.Name = "left_btn2";
            this.left_btn2.Size = new System.Drawing.Size(46, 32);
            this.left_btn2.TabIndex = 32;
            this.left_btn2.Text = "...";
            this.left_btn2.UseVisualStyleBackColor = true;
            this.left_btn2.Click += new System.EventHandler(this.filter_btn_Click);
            // 
            // left_tb
            // 
            this.left_tb.Enabled = false;
            this.left_tb.Location = new System.Drawing.Point(636, 536);
            this.left_tb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.left_tb.Name = "left_tb";
            this.left_tb.ReadOnly = true;
            this.left_tb.Size = new System.Drawing.Size(136, 26);
            this.left_tb.TabIndex = 31;
            // 
            // left_lbl
            // 
            this.left_lbl.AutoSize = true;
            this.left_lbl.Enabled = false;
            this.left_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.left_lbl.Location = new System.Drawing.Point(461, 547);
            this.left_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.left_lbl.Name = "left_lbl";
            this.left_lbl.Size = new System.Drawing.Size(71, 17);
            this.left_lbl.TabIndex = 30;
            this.left_lbl.Text = "Осталось";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button1.Location = new System.Drawing.Point(441, 19);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(397, 326);
            this.button1.TabIndex = 33;
            this.button1.Text = "Запросить доступ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // address_tb
            // 
            this.address_tb.Location = new System.Drawing.Point(534, 355);
            this.address_tb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.address_tb.Name = "address_tb";
            this.address_tb.ReadOnly = true;
            this.address_tb.Size = new System.Drawing.Size(286, 26);
            this.address_tb.TabIndex = 39;
            // 
            // adress_lbl
            // 
            this.adress_lbl.AutoSize = true;
            this.adress_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.adress_lbl.Location = new System.Drawing.Point(459, 360);
            this.adress_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.adress_lbl.Name = "adress_lbl";
            this.adress_lbl.Size = new System.Drawing.Size(55, 17);
            this.adress_lbl.TabIndex = 38;
            this.adress_lbl.Text = "Адресс";
            // 
            // proxy_type_group
            // 
            this.proxy_type_group.Controls.Add(this.proxy_type2);
            this.proxy_type_group.Controls.Add(this.proxy_type1);
            this.proxy_type_group.Enabled = false;
            this.proxy_type_group.Location = new System.Drawing.Point(225, 275);
            this.proxy_type_group.Name = "proxy_type_group";
            this.proxy_type_group.Size = new System.Drawing.Size(189, 117);
            this.proxy_type_group.TabIndex = 41;
            this.proxy_type_group.TabStop = false;
            this.proxy_type_group.Text = "Тип прокси";
            // 
            // proxy_type2
            // 
            this.proxy_type2.AutoSize = true;
            this.proxy_type2.Location = new System.Drawing.Point(7, 57);
            this.proxy_type2.Name = "proxy_type2";
            this.proxy_type2.Size = new System.Drawing.Size(85, 24);
            this.proxy_type2.TabIndex = 1;
            this.proxy_type2.TabStop = true;
            this.proxy_type2.Text = "Socks-5";
            this.proxy_type2.UseVisualStyleBackColor = true;
            // 
            // proxy_type1
            // 
            this.proxy_type1.AutoSize = true;
            this.proxy_type1.Location = new System.Drawing.Point(7, 31);
            this.proxy_type1.Name = "proxy_type1";
            this.proxy_type1.Size = new System.Drawing.Size(85, 24);
            this.proxy_type1.TabIndex = 0;
            this.proxy_type1.TabStop = true;
            this.proxy_type1.Text = "Socks-4";
            this.proxy_type1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button3.Location = new System.Drawing.Point(18, 275);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(194, 118);
            this.button3.TabIndex = 40;
            this.button3.Text = "Прокси-лист (ip:port)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 646);
            this.Controls.Add(this.proxy_type_group);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.address_tb);
            this.Controls.Add(this.adress_lbl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.left_btn2);
            this.Controls.Add(this.left_tb);
            this.Controls.Add(this.left_lbl);
            this.Controls.Add(this.mail_pass_file);
            this.Controls.Add(this.mail_pass_buffer);
            this.Controls.Add(this.files_btn);
            this.Controls.Add(this.invalid_btn);
            this.Controls.Add(this.valid_btn);
            this.Controls.Add(this.files_tb);
            this.Controls.Add(this.files_lbl);
            this.Controls.Add(this.invalid_tb);
            this.Controls.Add(this.invalid_lbl);
            this.Controls.Add(this.valid_tb);
            this.Controls.Add(this.valid_lbl);
            this.Controls.Add(this.accounts_tb);
            this.Controls.Add(this.accounts_lbl);
            this.Controls.Add(this.left_btn);
            this.Controls.Add(this.stop_btn);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.threads_tb);
            this.Controls.Add(this.threads_lbl);
            this.Controls.Add(this.settings_btn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "MailDownloader (Client)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.proxy_type_group.ResumeLayout(false);
            this.proxy_type_group.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button settings_btn;
        private System.Windows.Forms.Label threads_lbl;
        private System.Windows.Forms.TextBox threads_tb;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.Button left_btn;
        private System.Windows.Forms.Label accounts_lbl;
        private System.Windows.Forms.TextBox accounts_tb;
        private System.Windows.Forms.TextBox valid_tb;
        private System.Windows.Forms.Label valid_lbl;
        private System.Windows.Forms.TextBox invalid_tb;
        private System.Windows.Forms.Label invalid_lbl;
        private System.Windows.Forms.TextBox files_tb;
        private System.Windows.Forms.Label files_lbl;
        private System.Windows.Forms.Button valid_btn;
        private System.Windows.Forms.Button files_btn;
        private System.Windows.Forms.Button invalid_btn;
        private System.Windows.Forms.Button mail_pass_buffer;
        private System.Windows.Forms.Button mail_pass_file;
        private System.Windows.Forms.Button left_btn2;
        private System.Windows.Forms.TextBox left_tb;
        private System.Windows.Forms.Label left_lbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox address_tb;
        private System.Windows.Forms.Label adress_lbl;
        private System.Windows.Forms.GroupBox proxy_type_group;
        private System.Windows.Forms.RadioButton proxy_type2;
        private System.Windows.Forms.RadioButton proxy_type1;
        private System.Windows.Forms.Button button3;
    }
}

