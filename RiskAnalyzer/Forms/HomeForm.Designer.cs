namespace RiskAnalyzer.Forms
{
    partial class HomeForm
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
            this.login_textbox = new System.Windows.Forms.TextBox();
            this.password_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.enter_button = new System.Windows.Forms.Button();
            this.help_button = new System.Windows.Forms.Button();
            this.about_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // login_textbox
            // 
            this.login_textbox.Location = new System.Drawing.Point(929, 194);
            this.login_textbox.Name = "login_textbox";
            this.login_textbox.Size = new System.Drawing.Size(140, 26);
            this.login_textbox.TabIndex = 0;
            this.login_textbox.Text = "admin";
            // 
            // password_textbox
            // 
            this.password_textbox.Location = new System.Drawing.Point(929, 278);
            this.password_textbox.Name = "password_textbox";
            this.password_textbox.PasswordChar = '*';
            this.password_textbox.Size = new System.Drawing.Size(140, 26);
            this.password_textbox.TabIndex = 1;
            this.password_textbox.Text = "admin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(738, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(738, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Введите пароль";
            // 
            // enter_button
            // 
            this.enter_button.Location = new System.Drawing.Point(929, 364);
            this.enter_button.Name = "enter_button";
            this.enter_button.Size = new System.Drawing.Size(140, 46);
            this.enter_button.TabIndex = 6;
            this.enter_button.Text = "Войти";
            this.enter_button.UseVisualStyleBackColor = true;
            this.enter_button.Click += new System.EventHandler(this.enter_button_Click);
            // 
            // help_button
            // 
            this.help_button.Location = new System.Drawing.Point(203, 786);
            this.help_button.Name = "help_button";
            this.help_button.Size = new System.Drawing.Size(140, 46);
            this.help_button.TabIndex = 7;
            this.help_button.Text = "Помощь";
            this.help_button.UseVisualStyleBackColor = true;
            this.help_button.Click += new System.EventHandler(this.help_button_Click);
            // 
            // about_button
            // 
            this.about_button.Location = new System.Drawing.Point(394, 786);
            this.about_button.Name = "about_button";
            this.about_button.Size = new System.Drawing.Size(140, 46);
            this.about_button.TabIndex = 8;
            this.about_button.Text = "О программе";
            this.about_button.UseVisualStyleBackColor = true;
            this.about_button.Click += new System.EventHandler(this.about_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(12, 786);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(140, 46);
            this.exit_button.TabIndex = 9;
            this.exit_button.Text = "Выход";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1026, 786);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 46);
            this.button1.TabIndex = 10;
            this.button1.Text = "Настройки";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(491, 710);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(578, 60);
            this.label4.TabIndex = 13;
            this.label4.Text = "Санкт-Петербургский государственный технологический институт\r\n(технический универ" +
    "ситет) \r\n2020";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(738, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(331, 60);
            this.label5.TabIndex = 14;
            this.label5.Text = "Учебно-исследовательский комплекс\r\nдля оценки зон поражения\r\nобъектов нефтехранен" +
    "ия\r\n";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RiskAnalyzer.Properties.Resources.фон1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1154, 768);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 844);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.about_button);
            this.Controls.Add(this.help_button);
            this.Controls.Add(this.enter_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password_textbox);
            this.Controls.Add(this.login_textbox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "HomeForm";
            this.Text = "Авторизация";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox login_textbox;
        private System.Windows.Forms.TextBox password_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button enter_button;
        private System.Windows.Forms.Button help_button;
        private System.Windows.Forms.Button about_button;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}