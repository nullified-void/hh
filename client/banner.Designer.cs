namespace client
{
    partial class banner
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
            this.components = new System.ComponentModel.Container();
            this.FIOtxt = new System.Windows.Forms.TextBox();
            this.Acception = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // FIOtxt
            // 
            this.FIOtxt.Location = new System.Drawing.Point(46, 228);
            this.FIOtxt.Name = "FIOtxt";
            this.FIOtxt.Size = new System.Drawing.Size(727, 20);
            this.FIOtxt.TabIndex = 0;
            this.FIOtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FIOtxt_KeyDown);
            // 
            // Acception
            // 
            this.Acception.Location = new System.Drawing.Point(386, 254);
            this.Acception.Name = "Acception";
            this.Acception.Size = new System.Drawing.Size(75, 23);
            this.Acception.TabIndex = 1;
            this.Acception.Text = "Accept";
            this.Acception.UseVisualStyleBackColor = true;
            this.Acception.Click += new System.EventHandler(this.Acception_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // banner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::client.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(842, 495);
            this.Controls.Add(this.Acception);
            this.Controls.Add(this.FIOtxt);
            this.DoubleBuffered = true;
            this.Name = "banner";
            this.Text = "banner";
            this.Deactivate += new System.EventHandler(this.banner_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.banner_FormClosing);
            this.Leave += new System.EventHandler(this.banner_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FIOtxt;
        private System.Windows.Forms.Button Acception;
        private System.Windows.Forms.Timer timer1;
    }
}