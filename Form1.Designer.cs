namespace OSMTilesDownloader
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoundary = new System.Windows.Forms.TextBox();
            this.btnOpenOSM = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(522, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Click on below button and choose especial area, and then put the content of \"Osmo" +
    "sis Copy\" into below box.";
            // 
            // txtBoundary
            // 
            this.txtBoundary.Location = new System.Drawing.Point(99, 41);
            this.txtBoundary.Name = "txtBoundary";
            this.txtBoundary.Size = new System.Drawing.Size(361, 20);
            this.txtBoundary.TabIndex = 2;
            this.txtBoundary.Text = "left=50.7 bottom=34.51 right=51.66 top=35.89";
            // 
            // btnOpenOSM
            // 
            this.btnOpenOSM.Location = new System.Drawing.Point(12, 39);
            this.btnOpenOSM.Name = "btnOpenOSM";
            this.btnOpenOSM.Size = new System.Drawing.Size(81, 23);
            this.btnOpenOSM.TabIndex = 3;
            this.btnOpenOSM.Text = "Open";
            this.btnOpenOSM.UseVisualStyleBackColor = true;
            this.btnOpenOSM.Click += new System.EventHandler(this.btnOpenOSM_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(466, 39);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(81, 23);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // pbDownload
            // 
            this.pbDownload.Location = new System.Drawing.Point(15, 332);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(532, 23);
            this.pbDownload.TabIndex = 6;
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtConsole.ForeColor = System.Drawing.Color.GreenYellow;
            this.txtConsole.Location = new System.Drawing.Point(15, 68);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(532, 258);
            this.txtConsole.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 367);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.pbDownload);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpenOSM);
            this.Controls.Add(this.txtBoundary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "OSM Tiles Downloader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoundary;
        private System.Windows.Forms.Button btnOpenOSM;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ProgressBar pbDownload;
        private System.Windows.Forms.TextBox txtConsole;
    }
}

