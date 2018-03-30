namespace HDCGStudio
{
    partial class ManageTennisPlayersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageTennisPlayersForm));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridPlayers = new DevExpress.XtraGrid.GridControl();
            this.bsManagePlayers = new System.Windows.Forms.BindingSource(this.components);
            this.gvPlayers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsCaptain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsSubstitution = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nIndex = new System.Windows.Forms.NumericUpDown();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtShortName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.cboTeams = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.ckIsNotSubstitution = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsManagePlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeams.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckIsNotSubstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
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
            this.splitContainerControl1.Panel2.Controls.Add(this.nIndex);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl5);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtShortName);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel2.Controls.Add(this.simpleButton1);
            this.splitContainerControl1.Panel2.Controls.Add(this.cboTeams);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel2.Controls.Add(this.ckIsNotSubstitution);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtName);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnRemove);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnAdd);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(912, 759);
            this.splitContainerControl1.SplitterPosition = 481;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridPlayers
            // 
            this.gridPlayers.DataSource = this.bsManagePlayers;
            this.gridPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPlayers.Location = new System.Drawing.Point(0, 0);
            this.gridPlayers.MainView = this.gvPlayers;
            this.gridPlayers.Name = "gridPlayers";
            this.gridPlayers.Size = new System.Drawing.Size(912, 481);
            this.gridPlayers.TabIndex = 0;
            this.gridPlayers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPlayers});
            // 
            // bsManagePlayers
            // 
            this.bsManagePlayers.DataSource = typeof(HDCGStudio.Object.Tennis.Player);
            // 
            // gvPlayers
            // 
            this.gvPlayers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.gridColumn2,
            this.gridColumn1,
            this.colIsCaptain,
            this.colIsSubstitution});
            this.gvPlayers.GridControl = this.gridPlayers;
            this.gvPlayers.Name = "gvPlayers";
            this.gvPlayers.OptionsView.ShowGroupPanel = false;
            this.gvPlayers.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvPlayers_RowClick);
            this.gvPlayers.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // colName
            // 
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colName.Caption = "Tên dầy đủ";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 256;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Tên rút gọn";
            this.gridColumn2.FieldName = "ShortName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 197;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Là Nam";
            this.gridColumn1.FieldName = "isMale";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 98;
            // 
            // colIsCaptain
            // 
            this.colIsCaptain.AppearanceCell.Options.UseTextOptions = true;
            this.colIsCaptain.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsCaptain.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colIsCaptain.AppearanceHeader.Options.UseFont = true;
            this.colIsCaptain.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsCaptain.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsCaptain.Caption = "Đội";
            this.colIsCaptain.FieldName = "Team";
            this.colIsCaptain.Name = "colIsCaptain";
            this.colIsCaptain.OptionsColumn.AllowEdit = false;
            this.colIsCaptain.Visible = true;
            this.colIsCaptain.VisibleIndex = 3;
            this.colIsCaptain.Width = 242;
            // 
            // colIsSubstitution
            // 
            this.colIsSubstitution.AppearanceCell.Options.UseTextOptions = true;
            this.colIsSubstitution.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsSubstitution.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colIsSubstitution.AppearanceHeader.Options.UseFont = true;
            this.colIsSubstitution.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsSubstitution.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsSubstitution.Caption = "Hạt giống";
            this.colIsSubstitution.FieldName = "HatGiong";
            this.colIsSubstitution.Name = "colIsSubstitution";
            this.colIsSubstitution.OptionsColumn.AllowEdit = false;
            this.colIsSubstitution.Visible = true;
            this.colIsSubstitution.VisibleIndex = 4;
            this.colIsSubstitution.Width = 99;
            // 
            // nIndex
            // 
            this.nIndex.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.nIndex.Location = new System.Drawing.Point(747, 68);
            this.nIndex.Name = "nIndex";
            this.nIndex.Size = new System.Drawing.Size(86, 27);
            this.nIndex.TabIndex = 16;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(648, 68);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(94, 24);
            this.labelControl5.TabIndex = 24;
            this.labelControl5.Text = "Hạt giống:";
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(137, 121);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtShortName.Properties.Appearance.Options.UseFont = true;
            this.txtShortName.Size = new System.Drawing.Size(405, 30);
            this.txtShortName.TabIndex = 15;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(8, 124);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(111, 24);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "Tên rút gọn:";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton1.Location = new System.Drawing.Point(401, 191);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(98, 57);
            this.simpleButton1.TabIndex = 21;
            this.simpleButton1.ToolTip = "Lưu thông tin cầu thủ";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // cboTeams
            // 
            this.cboTeams.Location = new System.Drawing.Point(137, 20);
            this.cboTeams.Name = "cboTeams";
            this.cboTeams.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.cboTeams.Properties.Appearance.Options.UseFont = true;
            this.cboTeams.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTeams.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTeams.Size = new System.Drawing.Size(696, 26);
            this.cboTeams.TabIndex = 13;
            this.cboTeams.SelectedIndexChanged += new System.EventHandler(this.cboTeams_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(82, 23);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(37, 24);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Đội:";
            // 
            // ckIsNotSubstitution
            // 
            this.ckIsNotSubstitution.EditValue = true;
            this.ckIsNotSubstitution.Location = new System.Drawing.Point(648, 123);
            this.ckIsNotSubstitution.Name = "ckIsNotSubstitution";
            this.ckIsNotSubstitution.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ckIsNotSubstitution.Properties.Appearance.Options.UseFont = true;
            this.ckIsNotSubstitution.Properties.Caption = "Nam";
            this.ckIsNotSubstitution.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ckIsNotSubstitution.Size = new System.Drawing.Size(76, 28);
            this.ckIsNotSubstitution.TabIndex = 17;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 71);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(107, 24);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Tên đầy đủ:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(137, 65);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Size = new System.Drawing.Size(405, 30);
            this.txtName.TabIndex = 14;
            // 
            // btnRemove
            // 
            this.btnRemove.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.ImageOptions.Image")));
            this.btnRemove.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRemove.Location = new System.Drawing.Point(559, 191);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(93, 57);
            this.btnRemove.TabIndex = 22;
            this.btnRemove.ToolTip = "Xóa cầu thủ";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAdd.Location = new System.Drawing.Point(254, 191);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 57);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.ToolTip = "Thêm cầu thủ";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Đá chính";
            this.gridColumn3.FieldName = "mObj.IsNotSubstitution";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 101;
            // 
            // ManageTennisPlayersForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(912, 759);
            this.Controls.Add(this.splitContainerControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManageTennisPlayersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý cầu thủ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageTemplateForm_FormClosing);
            this.Shown += new System.EventHandler(this.ManageTemplateForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManagePlayersForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsManagePlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeams.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckIsNotSubstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridPlayers;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPlayers;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtName;
        private System.Windows.Forms.BindingSource bsManagePlayers;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCaptain;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSubstitution;
        private DevExpress.XtraEditors.CheckEdit ckIsNotSubstitution;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cboTeams;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit txtShortName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.NumericUpDown nIndex;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}