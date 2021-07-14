namespace MailDownloader
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.output_path_btn = new System.Windows.Forms.Button();
            this.output_path_lbl = new System.Windows.Forms.Label();
            this.output_path_tb = new System.Windows.Forms.TextBox();
            this.file_type_lbl = new System.Windows.Forms.Label();
            this.file_type_cb = new System.Windows.Forms.ComboBox();
            this.extensions_lbl = new System.Windows.Forms.Label();
            this.extensions_tb = new System.Windows.Forms.TextBox();
            this.mask_hint = new System.Windows.Forms.Label();
            this.extension_adder_btn = new System.Windows.Forms.Button();
            this.extensions_lv_lbl = new System.Windows.Forms.Label();
            this.extensions_lv = new System.Windows.Forms.ListView();
            this.extension_deleter_btn = new System.Windows.Forms.Button();
            this.mask_hint2 = new System.Windows.Forms.Label();
            this.from_cb = new System.Windows.Forms.ComboBox();
            this.from_lbl = new System.Windows.Forms.Label();
            this.from_tb = new System.Windows.Forms.TextBox();
            this.to_tb = new System.Windows.Forms.TextBox();
            this.to_lb = new System.Windows.Forms.Label();
            this.to_cb = new System.Windows.Forms.ComboBox();
            this.agree_btn = new System.Windows.Forms.Button();
            this.mask_hint3 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // output_path_btn
            // 
            this.output_path_btn.Location = new System.Drawing.Point(329, 25);
            this.output_path_btn.Margin = new System.Windows.Forms.Padding(4);
            this.output_path_btn.Name = "output_path_btn";
            this.output_path_btn.Size = new System.Drawing.Size(44, 25);
            this.output_path_btn.TabIndex = 5;
            this.output_path_btn.Text = "...";
            this.output_path_btn.UseVisualStyleBackColor = true;
            this.output_path_btn.Click += new System.EventHandler(this.output_path_btn_Click);
            // 
            // output_path_lbl
            // 
            this.output_path_lbl.AutoSize = true;
            this.output_path_lbl.Location = new System.Drawing.Point(8, 5);
            this.output_path_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.output_path_lbl.Name = "output_path_lbl";
            this.output_path_lbl.Size = new System.Drawing.Size(151, 17);
            this.output_path_lbl.TabIndex = 4;
            this.output_path_lbl.Text = "Путь к месту выкачки";
            // 
            // output_path_tb
            // 
            this.output_path_tb.Location = new System.Drawing.Point(11, 26);
            this.output_path_tb.Margin = new System.Windows.Forms.Padding(4);
            this.output_path_tb.Name = "output_path_tb";
            this.output_path_tb.ReadOnly = true;
            this.output_path_tb.Size = new System.Drawing.Size(310, 23);
            this.output_path_tb.TabIndex = 3;
            // 
            // file_type_lbl
            // 
            this.file_type_lbl.AutoSize = true;
            this.file_type_lbl.Location = new System.Drawing.Point(8, 53);
            this.file_type_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.file_type_lbl.Name = "file_type_lbl";
            this.file_type_lbl.Size = new System.Drawing.Size(87, 17);
            this.file_type_lbl.TabIndex = 6;
            this.file_type_lbl.Text = "Тип файлов";
            // 
            // file_type_cb
            // 
            this.file_type_cb.FormattingEnabled = true;
            this.file_type_cb.Items.AddRange(new object[] {
            "Видео",
            "Изображения",
            "Презентации",
            "Документы",
            "Архивы",
            "Все",
            "Использовать маску"});
            this.file_type_cb.Location = new System.Drawing.Point(11, 76);
            this.file_type_cb.Margin = new System.Windows.Forms.Padding(4);
            this.file_type_cb.Name = "file_type_cb";
            this.file_type_cb.Size = new System.Drawing.Size(362, 24);
            this.file_type_cb.TabIndex = 7;
            this.file_type_cb.SelectedValueChanged += new System.EventHandler(this.file_type_cb_SelectedValueChanged);
            // 
            // extensions_lbl
            // 
            this.extensions_lbl.AutoSize = true;
            this.extensions_lbl.Enabled = false;
            this.extensions_lbl.Location = new System.Drawing.Point(12, 104);
            this.extensions_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.extensions_lbl.Name = "extensions_lbl";
            this.extensions_lbl.Size = new System.Drawing.Size(135, 17);
            this.extensions_lbl.TabIndex = 8;
            this.extensions_lbl.Text = "Маска расширений";
            // 
            // extensions_tb
            // 
            this.extensions_tb.Enabled = false;
            this.extensions_tb.Location = new System.Drawing.Point(11, 127);
            this.extensions_tb.Margin = new System.Windows.Forms.Padding(4);
            this.extensions_tb.Name = "extensions_tb";
            this.extensions_tb.Size = new System.Drawing.Size(360, 23);
            this.extensions_tb.TabIndex = 9;
            // 
            // mask_hint
            // 
            this.mask_hint.AutoSize = true;
            this.mask_hint.Location = new System.Drawing.Point(103, 55);
            this.mask_hint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mask_hint.Name = "mask_hint";
            this.mask_hint.Size = new System.Drawing.Size(16, 17);
            this.mask_hint.TabIndex = 10;
            this.mask_hint.Text = "?";
            // 
            // extension_adder_btn
            // 
            this.extension_adder_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.extension_adder_btn.Location = new System.Drawing.Point(11, 156);
            this.extension_adder_btn.Margin = new System.Windows.Forms.Padding(4);
            this.extension_adder_btn.Name = "extension_adder_btn";
            this.extension_adder_btn.Size = new System.Drawing.Size(362, 44);
            this.extension_adder_btn.TabIndex = 11;
            this.extension_adder_btn.Text = "+";
            this.extension_adder_btn.UseVisualStyleBackColor = true;
            this.extension_adder_btn.Click += new System.EventHandler(this.extension_adder_btn_Click);
            // 
            // extensions_lv_lbl
            // 
            this.extensions_lv_lbl.AutoSize = true;
            this.extensions_lv_lbl.Location = new System.Drawing.Point(8, 204);
            this.extensions_lv_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.extensions_lv_lbl.Name = "extensions_lv_lbl";
            this.extensions_lv_lbl.Size = new System.Drawing.Size(91, 17);
            this.extensions_lv_lbl.TabIndex = 12;
            this.extensions_lv_lbl.Text = "Расширения";
            // 
            // extensions_lv
            // 
            this.extensions_lv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.extensions_lv.HideSelection = false;
            this.extensions_lv.Location = new System.Drawing.Point(11, 225);
            this.extensions_lv.Margin = new System.Windows.Forms.Padding(4);
            this.extensions_lv.Name = "extensions_lv";
            this.extensions_lv.Size = new System.Drawing.Size(359, 122);
            this.extensions_lv.TabIndex = 13;
            this.extensions_lv.UseCompatibleStateImageBehavior = false;
            // 
            // extension_deleter_btn
            // 
            this.extension_deleter_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.extension_deleter_btn.Location = new System.Drawing.Point(11, 356);
            this.extension_deleter_btn.Margin = new System.Windows.Forms.Padding(4);
            this.extension_deleter_btn.Name = "extension_deleter_btn";
            this.extension_deleter_btn.Size = new System.Drawing.Size(359, 44);
            this.extension_deleter_btn.TabIndex = 14;
            this.extension_deleter_btn.Text = "-";
            this.extension_deleter_btn.UseVisualStyleBackColor = true;
            this.extension_deleter_btn.Click += new System.EventHandler(this.extension_deleter_btn_Click);
            // 
            // mask_hint2
            // 
            this.mask_hint2.AutoSize = true;
            this.mask_hint2.Enabled = false;
            this.mask_hint2.Location = new System.Drawing.Point(155, 104);
            this.mask_hint2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mask_hint2.Name = "mask_hint2";
            this.mask_hint2.Size = new System.Drawing.Size(16, 17);
            this.mask_hint2.TabIndex = 15;
            this.mask_hint2.Text = "?";
            // 
            // from_cb
            // 
            this.from_cb.FormattingEnabled = true;
            this.from_cb.Items.AddRange(new object[] {
            "б",
            "Кб",
            "Мб",
            "Гб",
            "Тб"});
            this.from_cb.Location = new System.Drawing.Point(290, 408);
            this.from_cb.Margin = new System.Windows.Forms.Padding(4);
            this.from_cb.Name = "from_cb";
            this.from_cb.Size = new System.Drawing.Size(79, 24);
            this.from_cb.TabIndex = 16;
            // 
            // from_lbl
            // 
            this.from_lbl.AutoSize = true;
            this.from_lbl.Location = new System.Drawing.Point(8, 412);
            this.from_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.from_lbl.Name = "from_lbl";
            this.from_lbl.Size = new System.Drawing.Size(26, 17);
            this.from_lbl.TabIndex = 17;
            this.from_lbl.Text = "От";
            // 
            // from_tb
            // 
            this.from_tb.Location = new System.Drawing.Point(37, 409);
            this.from_tb.Margin = new System.Windows.Forms.Padding(4);
            this.from_tb.Name = "from_tb";
            this.from_tb.Size = new System.Drawing.Size(245, 23);
            this.from_tb.TabIndex = 18;
            // 
            // to_tb
            // 
            this.to_tb.Location = new System.Drawing.Point(37, 441);
            this.to_tb.Margin = new System.Windows.Forms.Padding(4);
            this.to_tb.Name = "to_tb";
            this.to_tb.Size = new System.Drawing.Size(245, 23);
            this.to_tb.TabIndex = 21;
            // 
            // to_lb
            // 
            this.to_lb.AutoSize = true;
            this.to_lb.Location = new System.Drawing.Point(8, 444);
            this.to_lb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.to_lb.Name = "to_lb";
            this.to_lb.Size = new System.Drawing.Size(27, 17);
            this.to_lb.TabIndex = 20;
            this.to_lb.Text = "До";
            // 
            // to_cb
            // 
            this.to_cb.FormattingEnabled = true;
            this.to_cb.Items.AddRange(new object[] {
            "б",
            "Кб",
            "Мб",
            "Гб",
            "Тб"});
            this.to_cb.Location = new System.Drawing.Point(290, 441);
            this.to_cb.Margin = new System.Windows.Forms.Padding(4);
            this.to_cb.Name = "to_cb";
            this.to_cb.Size = new System.Drawing.Size(79, 24);
            this.to_cb.TabIndex = 19;
            // 
            // agree_btn
            // 
            this.agree_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.agree_btn.Location = new System.Drawing.Point(11, 501);
            this.agree_btn.Margin = new System.Windows.Forms.Padding(4);
            this.agree_btn.Name = "agree_btn";
            this.agree_btn.Size = new System.Drawing.Size(359, 44);
            this.agree_btn.TabIndex = 22;
            this.agree_btn.Text = "Потвердить";
            this.agree_btn.UseVisualStyleBackColor = true;
            this.agree_btn.Click += new System.EventHandler(this.agree_btn_Click);
            // 
            // mask_hint3
            // 
            this.mask_hint3.AutoSize = true;
            this.mask_hint3.Location = new System.Drawing.Point(107, 204);
            this.mask_hint3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mask_hint3.Name = "mask_hint3";
            this.mask_hint3.Size = new System.Drawing.Size(16, 17);
            this.mask_hint3.TabIndex = 23;
            this.mask_hint3.Text = "?";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(128, 472);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(240, 23);
            this.dateTimePicker.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 477);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "С какого числа";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 553);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.mask_hint3);
            this.Controls.Add(this.agree_btn);
            this.Controls.Add(this.to_tb);
            this.Controls.Add(this.to_lb);
            this.Controls.Add(this.to_cb);
            this.Controls.Add(this.from_tb);
            this.Controls.Add(this.from_lbl);
            this.Controls.Add(this.from_cb);
            this.Controls.Add(this.mask_hint2);
            this.Controls.Add(this.extension_deleter_btn);
            this.Controls.Add(this.extensions_lv);
            this.Controls.Add(this.extensions_lv_lbl);
            this.Controls.Add(this.extension_adder_btn);
            this.Controls.Add(this.mask_hint);
            this.Controls.Add(this.extensions_tb);
            this.Controls.Add(this.extensions_lbl);
            this.Controls.Add(this.file_type_cb);
            this.Controls.Add(this.file_type_lbl);
            this.Controls.Add(this.output_path_btn);
            this.Controls.Add(this.output_path_lbl);
            this.Controls.Add(this.output_path_tb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingsForm";
            this.Text = "MailDownloader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button output_path_btn;
        private System.Windows.Forms.Label output_path_lbl;
        private System.Windows.Forms.TextBox output_path_tb;
        private System.Windows.Forms.Label file_type_lbl;
        private System.Windows.Forms.ComboBox file_type_cb;
        private System.Windows.Forms.Label extensions_lbl;
        private System.Windows.Forms.TextBox extensions_tb;
        private System.Windows.Forms.Label mask_hint;
        private System.Windows.Forms.Button extension_adder_btn;
        private System.Windows.Forms.Label extensions_lv_lbl;
        private System.Windows.Forms.ListView extensions_lv;
        private System.Windows.Forms.Button extension_deleter_btn;
        private System.Windows.Forms.Label mask_hint2;
        private System.Windows.Forms.ComboBox from_cb;
        private System.Windows.Forms.Label from_lbl;
        private System.Windows.Forms.TextBox from_tb;
        private System.Windows.Forms.TextBox to_tb;
        private System.Windows.Forms.Label to_lb;
        private System.Windows.Forms.ComboBox to_cb;
        private System.Windows.Forms.Button agree_btn;
        private System.Windows.Forms.Label mask_hint3;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label1;
    }
}