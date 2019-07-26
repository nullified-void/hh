using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ConsoleApplication1
{
    partial class Form1
    {

        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.CheckBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Browserbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(332, 173);
            this.listBox1.TabIndex = 0;
            // 
            // CheckBtn
            // 
            this.CheckBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBtn.Location = new System.Drawing.Point(369, 12);
            this.CheckBtn.Name = "CheckBtn";
            this.CheckBtn.Size = new System.Drawing.Size(75, 23);
            this.CheckBtn.TabIndex = 1;
            this.CheckBtn.Text = "Check";
            this.CheckBtn.UseVisualStyleBackColor = true;
            this.CheckBtn.Click += new System.EventHandler(this.CheckBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(369, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 22);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Browserbtn
            // 
            this.Browserbtn.Location = new System.Drawing.Point(369, 69);
            this.Browserbtn.Name = "Browserbtn";
            this.Browserbtn.Size = new System.Drawing.Size(75, 23);
            this.Browserbtn.TabIndex = 3;
            this.Browserbtn.Text = "Browsers";
            this.Browserbtn.UseVisualStyleBackColor = true;
            this.Browserbtn.Click += new System.EventHandler(this.Browserbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 197);
            this.Controls.Add(this.Browserbtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CheckBtn);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox listBox1;
        private Button CheckBtn;
        private Button button1;
        private Button Browserbtn;
    }
}