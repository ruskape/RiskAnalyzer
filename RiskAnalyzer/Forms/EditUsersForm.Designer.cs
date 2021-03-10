namespace RiskAnalyzer.Forms
{
    partial class EditUsersForm
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
            this.backToAdminForm = new System.Windows.Forms.Button();
            this.UpdateUsers = new System.Windows.Forms.Button();
            this.DeleteUsers = new System.Windows.Forms.Button();
            this.EditUsers = new System.Windows.Forms.Button();
            this.AddUsers = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.help = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // backToAdminForm
            // 
            this.backToAdminForm.Location = new System.Drawing.Point(12, 785);
            this.backToAdminForm.Name = "backToAdminForm";
            this.backToAdminForm.Size = new System.Drawing.Size(140, 46);
            this.backToAdminForm.TabIndex = 10;
            this.backToAdminForm.Text = "Назад";
            this.backToAdminForm.UseVisualStyleBackColor = true;
            this.backToAdminForm.Click += new System.EventHandler(this.backToAdminForm_Click);
            // 
            // UpdateUsers
            // 
            this.UpdateUsers.Location = new System.Drawing.Point(1026, 654);
            this.UpdateUsers.Name = "UpdateUsers";
            this.UpdateUsers.Size = new System.Drawing.Size(140, 46);
            this.UpdateUsers.TabIndex = 9;
            this.UpdateUsers.Text = "Обновить";
            this.UpdateUsers.UseVisualStyleBackColor = true;
            this.UpdateUsers.Click += new System.EventHandler(this.UpdateUsers_Click);
            // 
            // DeleteUsers
            // 
            this.DeleteUsers.Location = new System.Drawing.Point(1026, 589);
            this.DeleteUsers.Name = "DeleteUsers";
            this.DeleteUsers.Size = new System.Drawing.Size(140, 46);
            this.DeleteUsers.TabIndex = 8;
            this.DeleteUsers.Text = "Удалить";
            this.DeleteUsers.UseVisualStyleBackColor = true;
            this.DeleteUsers.Click += new System.EventHandler(this.DeleteUsers_Click);
            // 
            // EditUsers
            // 
            this.EditUsers.Location = new System.Drawing.Point(1026, 719);
            this.EditUsers.Name = "EditUsers";
            this.EditUsers.Size = new System.Drawing.Size(140, 46);
            this.EditUsers.TabIndex = 7;
            this.EditUsers.Text = "Изменить";
            this.EditUsers.UseVisualStyleBackColor = true;
            this.EditUsers.Click += new System.EventHandler(this.EditUsers_Click);
            // 
            // AddUsers
            // 
            this.AddUsers.Location = new System.Drawing.Point(1026, 784);
            this.AddUsers.Name = "AddUsers";
            this.AddUsers.Size = new System.Drawing.Size(140, 46);
            this.AddUsers.TabIndex = 6;
            this.AddUsers.Text = "Добавить";
            this.AddUsers.UseVisualStyleBackColor = true;
            this.AddUsers.Click += new System.EventHandler(this.AddUsers_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1150, 519);
            this.dataGridView1.TabIndex = 11;
            // 
            // help
            // 
            this.help.Location = new System.Drawing.Point(194, 786);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(140, 46);
            this.help.TabIndex = 35;
            this.help.Text = "Помощь";
            this.help.UseVisualStyleBackColor = true;
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // EditUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 844);
            this.Controls.Add(this.help);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.backToAdminForm);
            this.Controls.Add(this.UpdateUsers);
            this.Controls.Add(this.DeleteUsers);
            this.Controls.Add(this.EditUsers);
            this.Controls.Add(this.AddUsers);
            this.Name = "EditUsersForm";
            this.Text = "Управление ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backToAdminForm;
        private System.Windows.Forms.Button UpdateUsers;
        private System.Windows.Forms.Button DeleteUsers;
        private System.Windows.Forms.Button EditUsers;
        private System.Windows.Forms.Button AddUsers;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button help;
    }
}