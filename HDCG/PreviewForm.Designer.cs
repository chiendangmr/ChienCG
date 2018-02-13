namespace HDCGStudio
{
    partial class PreviewForm
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
            this.player = new CGPreviewControl.FlashTemplateHostControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.bsUpdateData = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsUpdateData)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.AspectControl = CGPreviewControl.FlashTemplateHostControl.Aspects.Aspect169;
            this.player.BackgroundColor = System.Drawing.Color.Empty;
            this.player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.player.Location = new System.Drawing.Point(2, 2);
            this.player.Margin = new System.Windows.Forms.Padding(5);
            this.player.Name = "player";
            this.player.ScaleMode = CGPreviewControl.FlashTemplateHostControl.ScaleModes.FullScreen;
            this.player.Size = new System.Drawing.Size(1166, 669);
            this.player.TabIndex = 2;
            this.player.TemplateFolder = "";
            this.player.TemplateHost = "";
            this.player.Valid = false;
            this.player.Version = CGPreviewControl.FlashTemplateHostControl.Versions.Version20;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.player);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1170, 673);
            this.panelControl1.TabIndex = 6;
            // 
            // bsUpdateData
            // 
            this.bsUpdateData.DataSource = typeof(HDCGStudio.Object.tempUpdating);
            // 
            // PreviewForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1170, 673);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "PreviewForm";
            this.Text = "Preview Template";            
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsUpdateData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public CGPreviewControl.FlashTemplateHostControl player;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.BindingSource bsUpdateData;
    }
}