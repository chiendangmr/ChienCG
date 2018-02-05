namespace HDCGStudio
{
    partial class EditForm
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnChooseColor = new DevExpress.XtraEditors.SimpleButton();
            this.btnChooseIcon2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnChooseIcon1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtColor = new DevExpress.XtraEditors.TextEdit();
            this.txtIcon2 = new DevExpress.XtraEditors.TextEdit();
            this.txtIcon1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.bsUpdateData = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIcon2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIcon1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
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
            this.player.Size = new System.Drawing.Size(1256, 824);
            this.player.TabIndex = 2;
            this.player.TemplateFolder = "";
            this.player.TemplateHost = "";
            this.player.Valid = false;
            this.player.Version = CGPreviewControl.FlashTemplateHostControl.Versions.Version20;
            // 
            // groupControl1
            // 
            this.groupControl1.AutoSize = true;
            this.groupControl1.Controls.Add(this.btnChooseColor);
            this.groupControl1.Controls.Add(this.btnChooseIcon2);
            this.groupControl1.Controls.Add(this.btnChooseIcon1);
            this.groupControl1.Controls.Add(this.txtColor);
            this.groupControl1.Controls.Add(this.txtIcon2);
            this.groupControl1.Controls.Add(this.txtIcon1);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btnUpdate);
            this.groupControl1.Controls.Add(this.btnClose);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(1258, 123);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "groupControl1";
            // 
            // btnChooseColor
            // 
            this.btnChooseColor.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnChooseColor.Location = new System.Drawing.Point(1167, 23);
            this.btnChooseColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChooseColor.Name = "btnChooseColor";
            this.btnChooseColor.Size = new System.Drawing.Size(81, 26);
            this.btnChooseColor.TabIndex = 13;
            this.btnChooseColor.Text = "Chọn...";
            this.btnChooseColor.Click += new System.EventHandler(this.btnChooseColor_Click);
            // 
            // btnChooseIcon2
            // 
            this.btnChooseIcon2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnChooseIcon2.Location = new System.Drawing.Point(685, 21);
            this.btnChooseIcon2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChooseIcon2.Name = "btnChooseIcon2";
            this.btnChooseIcon2.Size = new System.Drawing.Size(81, 30);
            this.btnChooseIcon2.TabIndex = 12;
            this.btnChooseIcon2.Text = "Chọn...";
            this.btnChooseIcon2.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnChooseIcon1
            // 
            this.btnChooseIcon1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnChooseIcon1.Location = new System.Drawing.Point(282, 16);
            this.btnChooseIcon1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChooseIcon1.Name = "btnChooseIcon1";
            this.btnChooseIcon1.Size = new System.Drawing.Size(81, 33);
            this.btnChooseIcon1.TabIndex = 11;
            this.btnChooseIcon1.Text = "Chọn...";
            this.btnChooseIcon1.Click += new System.EventHandler(this.btnChooseIcon1_Click);
            // 
            // txtColor
            // 
            this.txtColor.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtColor.Enabled = false;
            this.txtColor.Location = new System.Drawing.Point(951, 25);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(210, 22);
            this.txtColor.TabIndex = 10;
            // 
            // txtIcon2
            // 
            this.txtIcon2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtIcon2.Enabled = false;
            this.txtIcon2.Location = new System.Drawing.Point(462, 25);
            this.txtIcon2.Name = "txtIcon2";
            this.txtIcon2.Size = new System.Drawing.Size(217, 22);
            this.txtIcon2.TabIndex = 9;
            // 
            // txtIcon1
            // 
            this.txtIcon1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtIcon1.Enabled = false;
            this.txtIcon1.Location = new System.Drawing.Point(67, 22);
            this.txtIcon1.Name = "txtIcon1";
            this.txtIcon1.Size = new System.Drawing.Size(209, 22);
            this.txtIcon1.TabIndex = 8;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(405, 25);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(51, 19);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Icon 2:";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(806, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(139, 21);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Chọn ảnh đội hình:";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(10, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 19);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Icon 1:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.Location = new System.Drawing.Point(412, 62);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(147, 55);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(645, 62);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(147, 55);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.player);
            this.panelControl1.Location = new System.Drawing.Point(2, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1260, 828);
            this.panelControl1.TabIndex = 6;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.groupControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 826);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1262, 127);
            this.panelControl2.TabIndex = 7;
            // 
            // bsUpdateData
            // 
            this.bsUpdateData.DataSource = typeof(HDCGStudio.Object.tempUpdating);
            // 
            // EditForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1262, 953);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "EditForm";
            this.Text = "Preview and Update Template";            
            this.Shown += new System.EventHandler(this.EditForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIcon2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIcon1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsUpdateData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public CGPreviewControl.FlashTemplateHostControl player;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtIcon1;
        private DevExpress.XtraEditors.SimpleButton btnChooseIcon1;
        private DevExpress.XtraEditors.TextEdit txtColor;
        private DevExpress.XtraEditors.TextEdit txtIcon2;
        private DevExpress.XtraEditors.SimpleButton btnChooseColor;
        private DevExpress.XtraEditors.SimpleButton btnChooseIcon2;
        private System.Windows.Forms.BindingSource bsUpdateData;
    }
}