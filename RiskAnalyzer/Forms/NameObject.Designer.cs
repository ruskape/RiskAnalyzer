namespace RiskAnalyzer.Forms
{
    partial class NameObject
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
            this.nameobject_label = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.Callculate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameobject_label
            // 
            this.nameobject_label.Location = new System.Drawing.Point(207, 40);
            this.nameobject_label.Name = "nameobject_label";
            this.nameobject_label.Size = new System.Drawing.Size(131, 26);
            this.nameobject_label.TabIndex = 91;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(27, 43);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(151, 20);
            this.label38.TabIndex = 90;
            this.label38.Text = "Название объекта";
            // 
            // Callculate
            // 
            this.Callculate.Location = new System.Drawing.Point(112, 105);
            this.Callculate.Name = "Callculate";
            this.Callculate.Size = new System.Drawing.Size(140, 46);
            this.Callculate.TabIndex = 92;
            this.Callculate.Text = "Рассчитать";
            this.Callculate.UseVisualStyleBackColor = true;
            this.Callculate.Click += new System.EventHandler(this.Callculate_Click);
            // 
            // NameObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 163);
            this.Controls.Add(this.Callculate);
            this.Controls.Add(this.nameobject_label);
            this.Controls.Add(this.label38);
            this.Name = "NameObject";
            this.Text = "NameObject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameobject_label;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button Callculate;
    }
}