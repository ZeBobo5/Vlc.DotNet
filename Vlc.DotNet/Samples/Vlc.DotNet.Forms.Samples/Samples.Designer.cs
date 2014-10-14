namespace Vlc.DotNet.Forms.Samples
{
    partial class Samples
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Samples));
            this.vlcRincewindControl1 = new Vlc.DotNet.Forms.VlcRincewindControl();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vlcRincewindControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // vlcRincewindControl1
            // 
            this.vlcRincewindControl1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.vlcRincewindControl1.Location = new System.Drawing.Point(12, 12);
            this.vlcRincewindControl1.Name = "vlcRincewindControl1";
            this.vlcRincewindControl1.Size = new System.Drawing.Size(374, 238);
            this.vlcRincewindControl1.TabIndex = 0;
            this.vlcRincewindControl1.Text = "vlcRincewindControl1";
            this.vlcRincewindControl1.VlcLibDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("vlcRincewindControl1.VlcLibDirectory")));
            this.vlcRincewindControl1.PositionChanged += new System.EventHandler<Vlc.DotNet.Core.Rincewind.VlcMediaPlayerPositionChangedEventArgs>(this.vlcRincewindControl1_PositionChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(464, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(433, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Samples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 391);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.vlcRincewindControl1);
            this.Name = "Samples";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.vlcRincewindControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VlcRincewindControl vlcRincewindControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

