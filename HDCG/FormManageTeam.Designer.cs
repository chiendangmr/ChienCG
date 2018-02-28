namespace HDCGStudio
{
    partial class FormManageTeam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManageTeam));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridPlayers = new DevExpress.XtraGrid.GridControl();
            this.bsManageTeam = new System.Windows.Forms.BindingSource(this.components);
            this.gvPlayers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsCaptain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsSubstitution = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtShortName = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtCoach = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtLogoPath = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsManageTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogoPath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridPlayers);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtLogoPath);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtCoach);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtShortName);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtName);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnRemove);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnAdd);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(754, 772);
            this.splitContainerControl1.SplitterPosition = 591;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridPlayers
            // 
            this.gridPlayers.DataSource = this.bsManageTeam;
            this.gridPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPlayers.Location = new System.Drawing.Point(0, 0);
            this.gridPlayers.MainView = this.gvPlayers;
            this.gridPlayers.Name = "gridPlayers";
            this.gridPlayers.Size = new System.Drawing.Size(754, 591);
            this.gridPlayers.TabIndex = 0;
            this.gridPlayers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPlayers});
            // 
            // bsManageTeam
            // 
            this.bsManageTeam.DataSource = typeof(HDCGStudio.View.Team);
            // 
            // gvPlayers
            // 
            this.gvPlayers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNumber,
            this.colName,
            this.colIsCaptain,
            this.colIsSubstitution});
            this.gvPlayers.GridControl = this.gridPlayers;
            this.gvPlayers.Name = "gvPlayers";
            this.gvPlayers.OptionsView.ShowGroupPanel = false;
            this.gvPlayers.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // colNumber
            // 
            this.colNumber.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colNumber.AppearanceHeader.Options.UseFont = true;
            this.colNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.colNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNumber.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNumber.Caption = "Tên đội";
            this.colNumber.FieldName = "tObj.Name";
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
            this.colName.Caption = "Tên viết tắt";
            this.colName.FieldName = "tObj.ShortName";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 89;
            // 
            // colIsCaptain
            // 
            this.colIsCaptain.AppearanceCell.Options.UseTextOptions = true;
            this.colIsCaptain.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsCaptain.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colIsCaptain.AppearanceHeader.Options.UseFont = true;
            this.colIsCaptain.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsCaptain.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsCaptain.Caption = "HLV trưởng";
            this.colIsCaptain.FieldName = "tObj.CoachName";
            this.colIsCaptain.Name = "colIsCaptain";
            this.colIsCaptain.Visible = true;
            this.colIsCaptain.VisibleIndex = 2;
            this.colIsCaptain.Width = 252;
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
            this.colIsSubstitution.FieldName = "tObj.LogoPath";
            this.colIsSubstitution.Name = "colIsSubstitution";
            this.colIsSubstitution.Visible = true;
            this.colIsSubstitution.VisibleIndex = 3;
            this.colIsSubstitution.Width = 187;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(438, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(111, 24);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Tên viết tắt:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(34, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(74, 24);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Tên đội:";
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(614, 3);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtShortName.Properties.Appearance.Options.UseFont = true;
            this.txtShortName.Size = new System.Drawing.Size(99, 30);
            this.txtShortName.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(148, 3);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Size = new System.Drawing.Size(214, 30);
            this.txtName.TabIndex = 2;
            // 
            // btnRemove
            // 
            this.btnRemove.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.ImageOptions.Image")));
            this.btnRemove.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRemove.Location = new System.Drawing.Point(438, 96);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(93, 57);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.ToolTip = "Xóa template";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAdd.Location = new System.Drawing.Point(264, 96);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 57);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.ToolTip = "Thêm template";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(34, 45);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(108, 24);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "HLV trưởng:";
            // 
            // txtCoach
            // 
            this.txtCoach.Location = new System.Drawing.Point(148, 42);
            this.txtCoach.Name = "txtCoach";
            this.txtCoach.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtCoach.Properties.Appearance.Options.UseFont = true;
            this.txtCoach.Size = new System.Drawing.Size(214, 30);
            this.txtCoach.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(438, 45);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(50, 24);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Logo:";
            // 
            // txtLogoPath
            // 
            this.txtLogoPath.Location = new System.Drawing.Point(512, 42);
            this.txtLogoPath.Name = "txtLogoPath";
            this.txtLogoPath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtLogoPath.Properties.Appearance.Options.UseFont = true;
            this.txtLogoPath.Size = new System.Drawing.Size(201, 30);
            this.txtLogoPath.TabIndex = 8;
            // 
            // FormManageTeam
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 772);
            this.Controls.Add(this.splitContainerControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormManageTeam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý đội";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageTemplateForm_FormClosing);
            this.Shown += new System.EventHandler(this.ManageTemplateForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManagePlayersForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsManageTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogoPath.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridPlayers;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPlayers;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtShortName;
        private DevExpress.XtraEditors.TextEdit txtName;
        private System.Windows.Forms.BindingSource bsManageTeam;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCaptain;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSubstitution;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtLogoPath;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtCoach;
    }
}