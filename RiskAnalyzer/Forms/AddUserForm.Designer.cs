namespace RiskAnalyzer.Forms
{
    partial class AddUserForm
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
            this.cancelbutton = new System.Windows.Forms.Button();
            this.addbutton = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.role = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.help = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cancelbutton
            // 
            this.cancelbutton.Location = new System.Drawing.Point(12, 786);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(140, 46);
            this.cancelbutton.TabIndex = 3;
            this.cancelbutton.Text = "Отменить";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // addbutton
            // 
            this.addbutton.Location = new System.Drawing.Point(603, 786);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(140, 46);
            this.addbutton.TabIndex = 2;
            this.addbutton.Text = "Добавить";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(426, 28);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(124, 20);
            this.label21.TabIndex = 39;
            this.label21.Text = "Введите логин";
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(679, 22);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(140, 26);
            this.login.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(452, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Тип пользователя: 1 - Администратор, 2 - Исследователь";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Пароль";
            // 
            // role
            // 
            this.role.Location = new System.Drawing.Point(825, 159);
            this.role.MaxLength = 1;
            this.role.Name = "role";
            this.role.Size = new System.Drawing.Size(140, 26);
            this.role.TabIndex = 35;
            this.role.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.role_KeyPress);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(825, 109);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(140, 26);
            this.password.TabIndex = 34;
            // 
            // help
            // 
            this.help.Location = new System.Drawing.Point(435, 786);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(140, 46);
            this.help.TabIndex = 40;
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
            this.comboBox1.Location = new System.Drawing.Point(825, 211);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 28);
            this.comboBox1.TabIndex = 41;
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 844);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.help);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.role);
            this.Controls.Add(this.password);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.addbutton);
            this.Name = "AddUserForm";
            this.Text = "Добавление пользователя в систему";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox role;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}