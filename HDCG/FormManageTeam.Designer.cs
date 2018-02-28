﻿namespace HDCGStudio
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
            this.gridTeams = new DevExpress.XtraGrid.GridControl();
            this.bsManageTeam = new System.Windows.Forms.BindingSource(this.components);
            this.gvTeams = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsCaptain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsSubstitution = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnChooseLogo = new DevExpress.XtraEditors.SimpleButton();
            this.cboLeagues = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtLogoPath = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtCoach = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtShortName = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsManageTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTeams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLeagues.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogoPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridTeams);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.btnChooseLogo);
            this.splitContainerControl1.Panel2.Controls.Add(this.cboLeagues);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl5);
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
            this.splitContainerControl1.Size = new System.Drawing.Size(923, 772);
            this.splitContainerControl1.SplitterPosition = 552;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridTeams
            // 
            this.gridTeams.DataSource = this.bsManageTeam;
            this.gridTeams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTeams.Location = new System.Drawing.Point(0, 0);
            this.gridTeams.MainView = this.gvTeams;
            this.gridTeams.Name = "gridTeams";
            this.gridTeams.Size = new System.Drawing.Size(923, 552);
            this.gridTeams.TabIndex = 0;
            this.gridTeams.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTeams});
            // 
            // bsManageTeam
            // 
            this.bsManageTeam.DataSource = typeof(HDCGStudio.View.Team);
            // 
            // gvTeams
            // 
            this.gvTeams.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNumber,
            this.colName,
            this.colIsCaptain,
            this.colIsSubstitution,
            this.gridColumn1});
            this.gvTeams.GridControl = this.gridTeams;
            this.gvTeams.Name = "gvTeams";
            this.gvTeams.OptionsView.ShowGroupPanel = false;
            this.gvTeams.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
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
            this.colNumber.Width = 183;
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
            this.colName.Width = 104;
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
            this.colIsCaptain.Width = 210;
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
            this.colIsSubstitution.Width = 145;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Giải đấu";
            this.gridColumn1.FieldName = "tObj.League";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 261;
            // 
            // btnChooseLogo
            // 
            this.btnChooseLogo.Location = new System.Drawing.Point(806, 89);
            this.btnChooseLogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChooseLogo.Name = "btnChooseLogo";
            this.btnChooseLogo.Size = new System.Drawing.Size(35, 26);
            this.btnChooseLogo.TabIndex = 131;
            this.btnChooseLogo.Text = "...";
            this.btnChooseLogo.Click += new System.EventHandler(this.btnChooseLogo_Click);
            // 
            // cboLeagues
            // 
            this.cboLeagues.Location = new System.Drawing.Point(224, 12);
            this.cboLeagues.Name = "cboLeagues";
            this.cboLeagues.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.cboLeagues.Properties.Appearance.Options.UseFont = true;
            this.cboLeagues.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLeagues.Size = new System.Drawing.Size(617, 26);
            this.cboLeagues.TabIndex = 12;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(100, 11);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(80, 24);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Giải đấu:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(514, 91);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(50, 24);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Logo:";
            // 
            // txtLogoPath
            // 
            this.txtLogoPath.Location = new System.Drawing.Point(588, 88);
            this.txtLogoPath.Name = "txtLogoPath";
            this.txtLogoPath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtLogoPath.Properties.Appearance.Options.UseFont = true;
            this.txtLogoPath.Size = new System.Drawing.Size(201, 30);
            this.txtLogoPath.TabIndex = 8;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(100, 91);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(108, 24);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "HLV trưởng:";
            // 
            // txtCoach
            // 
            this.txtCoach.Location = new System.Drawing.Point(224, 88);
            this.txtCoach.Name = "txtCoach";
            this.txtCoach.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtCoach.Properties.Appearance.Options.UseFont = true;
            this.txtCoach.Size = new System.Drawing.Size(214, 30);
            this.txtCoach.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(514, 52);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(111, 24);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Tên viết tắt:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(100, 52);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(74, 24);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Tên đội:";
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(690, 49);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtShortName.Properties.Appearance.Options.UseFont = true;
            this.txtShortName.Size = new System.Drawing.Size(151, 30);
            this.txtShortName.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(224, 49);
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
            this.btnRemove.Location = new System.Drawing.Point(514, 135);
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
            this.btnAdd.Location = new System.Drawing.Point(264, 135);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 57);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.ToolTip = "Thêm template";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FormManageTeam
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 772);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridTeams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsManageTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTeams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLeagues.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogoPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridTeams;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTeams;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.ComboBoxEdit cboLeagues;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnChooseLogo;
    }
}