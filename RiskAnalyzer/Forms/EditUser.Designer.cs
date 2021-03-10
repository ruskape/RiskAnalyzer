namespace RiskAnalyzer.Forms
{
    partial class EditUser
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
            this.label21 = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.addbutton = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(426, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(124, 20);
            this.label21.TabIndex = 45;
            this.label21.Text = "Введите логин";
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(679, 16);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(140, 26);
            this.login.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(452, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "Тип пользователя: 1 - Администратор, 2 - Исследователь";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "Пароль";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(825, 103);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(140, 26);
            this.password.TabIndex = 40;
            // 
            // cancelbutton
            // 
            this.cancelbutton.Location = new System.Drawing.Point(12, 786);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(140, 46);
            this.cancelbutton.TabIndex = 47;
            this.cancelbutton.Text = "Отменить";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // addbutton
            // 
            this.addbutton.Location = new System.Drawing.Point(620, 786);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(140, 46);
            this.addbutton.TabIndex = 46;
            this.addbutton.Text = "Изменить";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // help
            // 
            this.help.Location = new System.Drawing.Point(419, 786);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(140, 46);
            this.help.TabIndex = 48;
            this.help.Text = "Помощь";
            this.help.UseVisualStyleBackColor = true;
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBox1.Location = new System.Drawing.Point(825, 156);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 28);
            this.comboBox1.TabIndex = 49;
            // 
            // EditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 844);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.help);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.addbutton);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Name = "EditUser";
            this.Text = "Редактирование данных пользователя";
            this.Activated += new System.EventHandler(this.EditUser_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion

        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}