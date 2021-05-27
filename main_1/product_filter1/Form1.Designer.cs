namespace product_filter1
{
    partial class Form1
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
            this.txt_1 = new System.Windows.Forms.RichTextBox();
            this.txt_2 = new System.Windows.Forms.RichTextBox();
            this.bt_do = new System.Windows.Forms.Button();
            this.bt_excel = new System.Windows.Forms.Button();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_1
            // 
            this.txt_1.Location = new System.Drawing.Point(46, 77);
            this.txt_1.Name = "txt_1";
            this.txt_1.Size = new System.Drawing.Size(325, 350);
            this.txt_1.TabIndex = 0;
            this.txt_1.Text = "";
            // 
            // txt_2
            // 
            this.txt_2.Location = new System.Drawing.Point(419, 44);
            this.txt_2.Name = "txt_2";
            this.txt_2.Size = new System.Drawing.Size(325, 350);
            this.txt_2.TabIndex = 1;
            this.txt_2.Text = "";
            // 
            // bt_do
            // 
            this.bt_do.Location = new System.Drawing.Point(69, 433);
            this.bt_do.Name = "bt_do";
            this.bt_do.Size = new System.Drawing.Size(181, 38);
            this.bt_do.TabIndex = 2;
            this.bt_do.Text = "button1";
            this.bt_do.UseVisualStyleBackColor = true;
            this.bt_do.Click += new System.EventHandler(this.bt_do_Click);
            // 
            // bt_excel
            // 
            this.bt_excel.Location = new System.Drawing.Point(685, 416);
            this.bt_excel.Name = "bt_excel";
            this.bt_excel.Size = new System.Drawing.Size(73, 38);
            this.bt_excel.TabIndex = 5;
            this.bt_excel.Text = "Excel";
            this.bt_excel.UseVisualStyleBackColor = true;
            this.bt_excel.Click += new System.EventHandler(this.bt_excel_Click);
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(46, 35);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(305, 20);
            this.txt_url.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 483);
            this.Controls.Add(this.txt_url);
            this.Controls.Add(this.bt_excel);
            this.Controls.Add(this.bt_do);
            this.Controls.Add(this.txt_2);
            this.Controls.Add(this.txt_1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txt_1;
        private System.Windows.Forms.RichTextBox txt_2;
        private System.Windows.Forms.Button bt_do;
        private System.Windows.Forms.Button bt_excel;
        private System.Windows.Forms.TextBox txt_url;
    }
}

