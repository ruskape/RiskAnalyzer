namespace RiskAnalyzer.Forms
{
    partial class DBConnect
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
            this.save = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.servername_label = new System.Windows.Forms.TextBox();
            this.username_label = new System.Windows.Forms.TextBox();
            this.database_label = new System.Windows.Forms.TextBox();
            this.password_label = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(648, 392);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(140, 46);
            this.save.TabIndex = 9;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(12, 392);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(140, 46);
            this.back.TabIndex = 10;
            this.back.Text = "Отменить";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Имя сервера";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Имя пользователя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Пароль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Имя базы данных";
            // 
            // servername_label
            // 
            this.servername_label.Location = new System.Drawing.Point(468, 145);
            this.servername_label.Name = "servername_label";
            this.servername_label.Size = new System.Drawing.Size(121, 26);
            this.servername_label.TabIndex = 15;
            this.servername_label.Text = "localhost";
            // 
            // username_label
            // 
            this.username_label.Location = new System.Drawing.Point(468, 190);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(121, 26);
            this.username_label.TabIndex = 16;
            this.username_label.Text = "root";
            // 
            // database_label
            // 
            this.database_label.Location = new System.Drawing.Point(468, 235);
            this.database_label.Name = "database_label";
            this.database_label.Size = new System.Drawing.Size(121, 26);
            this.database_label.TabIndex = 17;
            this.database_label.Text = "riskdata";
            // 
            // password_label
            // 
            this.password_label.Location = new System.Drawing.Point(468, 280);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(121, 26);
            this.password_label.TabIndex = 18;
            this.password_label.Text = "Nastya238017";
            // 
            // DBConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.database_label);
            this.Controls.Add(this.username_label);
            this.Controls.Add(this.servername_label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.back);
            this.Controls.Add(this.save);
            this.Name = "DBConnect";
            this.Text = "DBConnect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox servername_label;
        private System.Windows.Forms.TextBox username_label;
        private System.Windows.Forms.TextBox database_label;
        private System.Windows.Forms.TextBox password_label;
    }
}