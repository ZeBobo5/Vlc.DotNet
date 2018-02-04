namespace Samples.WinForms.Minimal
{
    partial class Sample
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.vlcControl = new Vlc.DotNet.Forms.VlcControl();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl)).BeginInit();
            this.SuspendLayout();
            // 
            // vlcControl
            // 
            this.vlcControl.BackColor = System.Drawing.Color.Black;
            this.vlcControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcControl.Location = new System.Drawing.Point(0, 0);
            this.vlcControl.Name = "vlcControl";
            this.vlcControl.Size = new System.Drawing.Size(944, 501);
            this.vlcControl.Spu = -1;
            this.vlcControl.TabIndex = 0;
            this.vlcControl.Text = "vlcControl1";
            this.vlcControl.VlcLibDirectory = null;
            this.vlcControl.VlcMediaplayerOptions = null;
            this.vlcControl.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl_VlcLibDirectoryNeeded);
            // 
            // Sample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.vlcControl);
            this.Name = "Sample";
            this.Text = "WinForms sample";
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Vlc.DotNet.Forms.VlcControl vlcControl;
    }
}

