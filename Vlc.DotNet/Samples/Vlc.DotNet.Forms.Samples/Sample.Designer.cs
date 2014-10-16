namespace Vlc.DotNet.Forms.Samples
{
    partial class Sample
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
            this.vlcRincewindControl1 = new Vlc.DotNet.Forms.VlcRincewindControl();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.vlcRincewindControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // vlcRincewindControl1
            // 
            this.vlcRincewindControl1.Location = new System.Drawing.Point(87, 45);
            this.vlcRincewindControl1.Name = "vlcRincewindControl1";
            this.vlcRincewindControl1.Size = new System.Drawing.Size(224, 180);
            this.vlcRincewindControl1.TabIndex = 0;
            this.vlcRincewindControl1.Text = "vlcRincewindControl1";
            this.vlcRincewindControl1.VlcLibDirectory = null;
            this.vlcRincewindControl1.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.OnVlcControlNeedLibDirectory);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(514, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Sample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 391);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.vlcRincewindControl1);
            this.Name = "Sample";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.vlcRincewindControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private VlcRincewindControl vlcRincewindControl1;
        private System.Windows.Forms.Button button1;
    }
}

