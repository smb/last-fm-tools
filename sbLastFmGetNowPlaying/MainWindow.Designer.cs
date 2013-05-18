namespace sbLastFmGetNowPlaying
{
    partial class MainWindow
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
            this.tbArtist = new System.Windows.Forms.TextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbFileLocation = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbOutputWindow = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPrefix = new System.Windows.Forms.TextBox();
            this.linkLabelSource = new System.Windows.Forms.LinkLabel();
            this.linkLabelAuthor = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // tbArtist
            // 
            this.tbArtist.Location = new System.Drawing.Point(88, 48);
            this.tbArtist.Name = "tbArtist";
            this.tbArtist.Size = new System.Drawing.Size(209, 20);
            this.tbArtist.TabIndex = 0;
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(88, 70);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(209, 20);
            this.tbTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Artist";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Track";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbFileLocation
            // 
            this.tbFileLocation.Location = new System.Drawing.Point(88, 135);
            this.tbFileLocation.Name = "tbFileLocation";
            this.tbFileLocation.ReadOnly = true;
            this.tbFileLocation.Size = new System.Drawing.Size(209, 20);
            this.tbFileLocation.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output-File";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(303, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "....";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbOutputWindow
            // 
            this.tbOutputWindow.Location = new System.Drawing.Point(325, 38);
            this.tbOutputWindow.Name = "tbOutputWindow";
            this.tbOutputWindow.Size = new System.Drawing.Size(19, 20);
            this.tbOutputWindow.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Prefix";
            // 
            // tbPrefix
            // 
            this.tbPrefix.Location = new System.Drawing.Point(88, 113);
            this.tbPrefix.Name = "tbPrefix";
            this.tbPrefix.Size = new System.Drawing.Size(209, 20);
            this.tbPrefix.TabIndex = 7;
            // 
            // linkLabel1
            // 
            this.linkLabelSource.AutoSize = true;
            //this.linkLabelSource.LinkArea = new System.Windows.Forms.LinkArea(8, 36);
            this.linkLabelSource.Location = new System.Drawing.Point(4, 3);
            this.linkLabelSource.Name = "linkLabel1";
            this.linkLabelSource.Size = new System.Drawing.Size(225, 17);
            this.linkLabelSource.TabIndex = 9;
            this.linkLabelSource.TabStop = true;
            this.linkLabelSource.Text = "Source: https://github.com/smb/last-fm-tools";
            this.linkLabelSource.UseCompatibleTextRendering = true;
            this.linkLabelSource.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabelAuthor.AutoSize = true;
            //this.linkLabelAuthor.LinkArea = new System.Windows.Forms.LinkArea(22, 15);
            this.linkLabelAuthor.Location = new System.Drawing.Point(4, 21);
            this.linkLabelAuthor.Name = "linkLabel2";
            this.linkLabelAuthor.Size = new System.Drawing.Size(209, 17);
            this.linkLabelAuthor.TabIndex = 10;
            this.linkLabelAuthor.TabStop = true;
            this.linkLabelAuthor.Text = "Author: Steffen Buehl <sb@sbuehl.com>";
            this.linkLabelAuthor.UseCompatibleTextRendering = true;
            this.linkLabelAuthor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(346, 162);
            this.Controls.Add(this.linkLabelAuthor);
            this.Controls.Add(this.linkLabelSource);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPrefix);
            this.Controls.Add(this.tbOutputWindow);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbFileLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.tbArtist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "sbLastFmGetNowPlaying";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbArtist;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbFileLocation;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbOutputWindow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPrefix;
        private System.Windows.Forms.LinkLabel linkLabelSource;
        private System.Windows.Forms.LinkLabel linkLabelAuthor;
    }
}

