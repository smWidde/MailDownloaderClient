namespace MailDownloader
{
    partial class ImapForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.imapTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sslCheckBox = new System.Windows.Forms.CheckBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.problemTextBox = new System.Windows.Forms.TextBox();
            this.helpButton = new System.Windows.Forms.Button();
            this.invalid_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(16, 257);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "IMAP домен сервера";
            // 
            // imapTextBox
            // 
            this.imapTextBox.Location = new System.Drawing.Point(20, 294);
            this.imapTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.imapTextBox.Name = "imapTextBox";
            this.imapTextBox.Size = new System.Drawing.Size(275, 23);
            this.imapTextBox.TabIndex = 1;
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(16, 374);
            this.portTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(279, 23);
            this.portTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(16, 338);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Порт сервера";
            // 
            // sslCheckBox
            // 
            this.sslCheckBox.AutoSize = true;
            this.sslCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.sslCheckBox.Location = new System.Drawing.Point(20, 423);
            this.sslCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sslCheckBox.Name = "sslCheckBox";
            this.sslCheckBox.Size = new System.Drawing.Size(59, 24);
            this.sslCheckBox.TabIndex = 5;
            this.sslCheckBox.Text = "SSL";
            this.sslCheckBox.UseVisualStyleBackColor = true;
            // 
            // acceptButton
            // 
            this.acceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.acceptButton.Location = new System.Drawing.Point(16, 466);
            this.acceptButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(280, 59);
            this.acceptButton.TabIndex = 6;
            this.acceptButton.Text = "Потвердить";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(16, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Конфликтующий домен:";
            // 
            // problemTextBox
            // 
            this.problemTextBox.Location = new System.Drawing.Point(16, 79);
            this.problemTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.problemTextBox.Name = "problemTextBox";
            this.problemTextBox.ReadOnly = true;
            this.problemTextBox.Size = new System.Drawing.Size(279, 23);
            this.problemTextBox.TabIndex = 8;
            // 
            // helpButton
            // 
            this.helpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.helpButton.Location = new System.Drawing.Point(16, 111);
            this.helpButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(280, 59);
            this.helpButton.TabIndex = 9;
            this.helpButton.Text = "Что делать?";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // invalid_btn
            // 
            this.invalid_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.invalid_btn.Location = new System.Drawing.Point(16, 177);
            this.invalid_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.invalid_btn.Name = "invalid_btn";
            this.invalid_btn.Size = new System.Drawing.Size(280, 59);
            this.invalid_btn.TabIndex = 10;
            this.invalid_btn.Text = "Невалидный";
            this.invalid_btn.UseVisualStyleBackColor = true;
            this.invalid_btn.Click += new System.EventHandler(this.invalid_btn_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 540);
            this.Controls.Add(this.invalid_btn);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.problemTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.sslCheckBox);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imapTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ImapForm";
            this.Text = "Настройки домена";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox imapTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox sslCheckBox;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox problemTextBox;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button invalid_btn;
    }
}