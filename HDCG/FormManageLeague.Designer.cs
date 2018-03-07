namespace HDCGStudio
{
    partial class FormManageLeague
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManageLeague));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridLeagues = new DevExpress.XtraGrid.GridControl();
            this.bsManageLeague = new System.Windows.Forms.BindingSource(this.components);
            this.gvLeagues = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsSubstitution = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnChooseLogo = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtLogoPath = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaGiai = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.bsUpdateNotifier = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLeagues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsManageLeague)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLeagues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogoPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaGiai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUpdateNotifier)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridLeagues);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl5);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnSave);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnChooseLogo);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtLogoPath);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtMaGiai);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtName);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnRemove);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnAdd);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(754, 772);
            this.splitContainerControl1.SplitterPosition = 521;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridLeagues
            // 
            this.gridLeagues.DataSource = this.bsManageLeague;
            this.gridLeagues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLeagues.Location = new System.Drawing.Point(0, 0);
            this.gridLeagues.MainView = this.gvLeagues;
            this.gridLeagues.Name = "gridLeagues";
            this.gridLeagues.Size = new System.Drawing.Size(754, 521);
            this.gridLeagues.TabIndex = 0;
            this.gridLeagues.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLeagues});
            // 
            // bsManageLeague
            // 
            this.bsManageLeague.DataSource = typeof(HDCGStudio.View.League);
            // 
            // gvLeagues
            // 
            this.gvLeagues.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNumber,
            this.colName,
            this.colIsSubstitution});
            this.gvLeagues.GridControl = this.gridLeagues;
            this.gvLeagues.Name = "gvLeagues";
            this.gvLeagues.OptionsView.ShowGroupPanel = false;
            this.gvLeagues.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvLeagues_RowClick);
            this.gvLeagues.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // colNumber
            // 
            this.colNumber.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colNumber.AppearanceHeader.Options.UseFont = true;
            this.colNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.colNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNumber.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNumber.Caption = "Tên giải đấu";
            this.colNumber.FieldName = "lObj.Name";
            this.colNumber.Name = "colNumber";
            this.colNumber.OptionsColumn.AllowEdit = false;
            this.colNumber.Visible = true;
            this.colNumber.VisibleIndex = 0;
            this.colNumber.Width = 206;
            // 
            // colName
            // 
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colName.Caption = "Mã giải";
            this.colName.FieldName = "lObj.LeagueCode";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 89;
            // 
            // colIsSubstitution
            // 
            this.colIsSubstitution.AppearanceCell.Options.UseTextOptions = true;
            this.colIsSubstitution.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsSubstitution.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colIsSubstitution.AppearanceHeader.Options.UseFont = true;
            this.colIsSubstitution.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsSubstitution.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsSubstitution.Caption = "Logo";
            this.colIsSubstitution.FieldName = "lObj.LogoPath";
            this.colIsSubstitution.Name = "colIsSubstitution";
            this.colIsSubstitution.OptionsColumn.AllowEdit = false;
            this.colIsSubstitution.Visible = true;
            this.colIsSubstitution.VisibleIndex = 2;
            this.colIsSubstitution.Width = 187;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(127, 95);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(478, 24);
            this.labelControl5.TabIndex = 133;
            this.labelControl5.Text = "(*): Mã giải đấu dùng để định danh, phải là duy nhất!";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(270, 49);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(27, 24);
            this.labelControl3.TabIndex = 132;
            this.labelControl3.Text = "(*)";
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSave.Location = new System.Drawing.Point(319, 148);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 57);
            this.btnSave.TabIndex = 6;
            this.btnSave.ToolTip = "Lưu thông tin giải";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnChooseLogo
            // 
            this.btnChooseLogo.Location = new System.Drawing.Point(679, 47);
            this.btnChooseLogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChooseLogo.Name = "btnChooseLogo";
            this.btnChooseLogo.Size = new System.Drawing.Size(35, 26);
            this.btnChooseLogo.TabIndex = 4;
            this.btnChooseLogo.Text = "...";
            this.btnChooseLogo.Click += new System.EventHandler(this.btnChooseLogo_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(340, 49);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(50, 24);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Logo:";
            // 
            // txtLogoPath
            // 
            this.txtLogoPath.Location = new System.Drawing.Point(396, 46);
            this.txtLogoPath.Name = "txtLogoPath";
            this.txtLogoPath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtLogoPath.Properties.Appearance.Options.UseFont = true;
            this.txtLogoPath.Size = new System.Drawing.Size(277, 30);
            this.txtLogoPath.TabIndex = 8;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(44, 49);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(110, 24);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Mã giải đấu:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(36, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(118, 24);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Tên giải đấu:";
            // 
            // txtMaGiai
            // 
            this.txtMaGiai.Location = new System.Drawing.Point(165, 46);
            this.txtMaGiai.Name = "txtMaGiai";
            this.txtMaGiai.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMaGiai.Properties.Appearance.Options.UseFont = true;
            this.txtMaGiai.Size = new System.Drawing.Size(99, 30);
            this.txtMaGiai.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(165, 10);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Size = new System.Drawing.Size(549, 30);
            this.txtName.TabIndex = 2;
            // 
            // btnRemove
            // 
            this.btnRemove.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.ImageOptions.Image")));
            this.btnRemove.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRemove.Location = new System.Drawing.Point(459, 148);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(93, 57);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.ToolTip = "Xóa giải";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAdd.Location = new System.Drawing.Point(165, 148);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 57);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.ToolTip = "Thêm giải";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // bsUpdateNotifier
            // 
            this.bsUpdateNotifier.DataSource = typeof(HDCGStudio.Object.UpdateNotifier);
            // 
            // FormManageLeague
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 772);
            this.Controls.Add(this.splitContainerControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormManageLeague";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý giải đấu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageTemplateForm_FormClosing);
            this.Shown += new System.EventHandler(this.ManageTemplateForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManagePlayersForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLeagues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsManageLeague)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLeagues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogoPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaGiai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUpdateNotifier)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridLeagues;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLeagues;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtMaGiai;
        private DevExpress.XtraEditors.TextEdit txtName;
        private System.Windows.Forms.BindingSource bsManageLeague;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSubstitution;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtLogoPath;
        private DevExpress.XtraEditors.SimpleButton btnChooseLogo;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.BindingSource bsUpdateNotifier;
    }
}