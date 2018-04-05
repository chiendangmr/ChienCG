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
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckCaptain = new DevExpress.XtraEditors.CheckEdit();
            this.nRank = new System.Windows.Forms.NumericUpDown();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
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
            this.txtNation = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.nAge = new System.Windows.Forms.NumericUpDown();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtHeight = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtWeight = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.nWorldRanking = new System.Windows.Forms.NumericUpDown();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.nAppearances = new System.Windows.Forms.NumericUpDown();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.nSingleWin = new System.Windows.Forms.NumericUpDown();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.nSingleLose = new System.Windows.Forms.NumericUpDown();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.txtDebut = new DevExpress.XtraEditors.TextEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsManagePlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCaptain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeams.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckIsNotSubstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nWorldRanking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAppearances)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSingleWin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSingleLose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebut.Properties)).BeginInit();
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
            this.splitContainerControl1.Panel2.Controls.Add(this.txtDebut);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl14);
            this.splitContainerControl1.Panel2.Controls.Add(this.nSingleLose);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl13);
            this.splitContainerControl1.Panel2.Controls.Add(this.nSingleWin);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl12);
            this.splitContainerControl1.Panel2.Controls.Add(this.nAppearances);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl11);
            this.splitContainerControl1.Panel2.Controls.Add(this.nWorldRanking);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl10);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtWeight);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl9);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtHeight);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl8);
            this.splitContainerControl1.Panel2.Controls.Add(this.nAge);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl7);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtNation);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl6);
            this.splitContainerControl1.Panel2.Controls.Add(this.ckCaptain);
            this.splitContainerControl1.Panel2.Controls.Add(this.nRank);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl1);
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
            this.splitContainerControl1.Size = new System.Drawing.Size(912, 813);
            this.splitContainerControl1.SplitterPosition = 400;
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
            this.gridPlayers.Size = new System.Drawing.Size(912, 400);
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
            this.colIsSubstitution,
            this.gridColumn4,
            this.gridColumn5});
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
            this.colName.Width = 219;
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
            this.gridColumn2.Width = 168;
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
            this.gridColumn1.Width = 83;
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
            this.colIsCaptain.Width = 207;
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
            this.colIsSubstitution.Width = 74;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Rank";
            this.gridColumn4.FieldName = "Rank";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 68;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Đội trưởng";
            this.gridColumn5.FieldName = "isCaptain";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            this.gridColumn5.Width = 73;
            // 
            // ckCaptain
            // 
            this.ckCaptain.Location = new System.Drawing.Point(505, 122);
            this.ckCaptain.Name = "ckCaptain";
            this.ckCaptain.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ckCaptain.Properties.Appearance.Options.UseFont = true;
            this.ckCaptain.Properties.Caption = "Đội trưởng";
            this.ckCaptain.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ckCaptain.Size = new System.Drawing.Size(140, 28);
            this.ckCaptain.TabIndex = 27;
            // 
            // nRank
            // 
            this.nRank.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.nRank.Location = new System.Drawing.Point(747, 126);
            this.nRank.Name = "nRank";
            this.nRank.Size = new System.Drawing.Size(86, 27);
            this.nRank.TabIndex = 25;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(677, 124);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 24);
            this.labelControl1.TabIndex = 26;
            this.labelControl1.Text = "Rank:";
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
            this.txtShortName.Size = new System.Drawing.Size(208, 30);
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
            this.simpleButton1.Location = new System.Drawing.Point(394, 309);
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
            this.ckIsNotSubstitution.Location = new System.Drawing.Point(385, 122);
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
            this.btnRemove.Location = new System.Drawing.Point(552, 309);
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
            this.btnAdd.Location = new System.Drawing.Point(247, 309);
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
            // txtNation
            // 
            this.txtNation.Location = new System.Drawing.Point(137, 169);
            this.txtNation.Name = "txtNation";
            this.txtNation.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtNation.Properties.Appearance.Options.UseFont = true;
            this.txtNation.Size = new System.Drawing.Size(208, 30);
            this.txtNation.TabIndex = 28;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(34, 172);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(85, 24);
            this.labelControl6.TabIndex = 29;
            this.labelControl6.Text = "Quốc gia:";
            // 
            // nAge
            // 
            this.nAge.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.nAge.Location = new System.Drawing.Point(467, 170);
            this.nAge.Name = "nAge";
            this.nAge.Size = new System.Drawing.Size(75, 27);
            this.nAge.TabIndex = 30;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(415, 170);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(46, 24);
            this.labelControl7.TabIndex = 31;
            this.labelControl7.Text = "Tuổi:";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(137, 218);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtHeight.Properties.Appearance.Options.UseFont = true;
            this.txtHeight.Size = new System.Drawing.Size(136, 30);
            this.txtHeight.TabIndex = 32;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(25, 221);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(94, 24);
            this.labelControl8.TabIndex = 33;
            this.labelControl8.Text = "Chiều cao:";
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(424, 218);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtWeight.Properties.Appearance.Options.UseFont = true;
            this.txtWeight.Size = new System.Drawing.Size(132, 30);
            this.txtWeight.TabIndex = 34;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(327, 221);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(91, 24);
            this.labelControl9.TabIndex = 35;
            this.labelControl9.Text = "Cân nặng:";
            // 
            // nWorldRanking
            // 
            this.nWorldRanking.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.nWorldRanking.Location = new System.Drawing.Point(747, 169);
            this.nWorldRanking.Name = "nWorldRanking";
            this.nWorldRanking.Size = new System.Drawing.Size(86, 27);
            this.nWorldRanking.TabIndex = 36;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(597, 172);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(131, 24);
            this.labelControl10.TabIndex = 37;
            this.labelControl10.Text = "World ranking:";
            // 
            // nAppearances
            // 
            this.nAppearances.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.nAppearances.Location = new System.Drawing.Point(139, 265);
            this.nAppearances.Name = "nAppearances";
            this.nAppearances.Size = new System.Drawing.Size(86, 27);
            this.nAppearances.TabIndex = 38;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(12, 265);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(121, 24);
            this.labelControl11.TabIndex = 39;
            this.labelControl11.Text = "Appearances:";
            // 
            // nSingleWin
            // 
            this.nSingleWin.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.nSingleWin.Location = new System.Drawing.Point(424, 265);
            this.nSingleWin.Name = "nSingleWin";
            this.nSingleWin.Size = new System.Drawing.Size(86, 27);
            this.nSingleWin.TabIndex = 40;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(297, 265);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(116, 24);
            this.labelControl12.TabIndex = 41;
            this.labelControl12.Text = "Singles wins:";
            // 
            // nSingleLose
            // 
            this.nSingleLose.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.nSingleLose.Location = new System.Drawing.Point(747, 263);
            this.nSingleLose.Name = "nSingleLose";
            this.nSingleLose.Size = new System.Drawing.Size(86, 27);
            this.nSingleLose.TabIndex = 42;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(598, 263);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(130, 24);
            this.labelControl13.TabIndex = 43;
            this.labelControl13.Text = "Singles losses:";
            // 
            // txtDebut
            // 
            this.txtDebut.Location = new System.Drawing.Point(701, 215);
            this.txtDebut.Name = "txtDebut";
            this.txtDebut.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtDebut.Properties.Appearance.Options.UseFont = true;
            this.txtDebut.Size = new System.Drawing.Size(132, 30);
            this.txtDebut.TabIndex = 44;
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Location = new System.Drawing.Point(628, 218);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(61, 24);
            this.labelControl14.TabIndex = 45;
            this.labelControl14.Text = "Debut:";
            // 
            // ManageTennisPlayersForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(912, 813);
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
            ((System.ComponentModel.ISupportInitialize)(this.ckCaptain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeams.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckIsNotSubstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nWorldRanking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAppearances)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSingleWin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSingleLose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebut.Properties)).EndInit();
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
        private DevExpress.XtraEditors.CheckEdit ckCaptain;
        private System.Windows.Forms.NumericUpDown nRank;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.NumericUpDown nAge;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtNation;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtDebut;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private System.Windows.Forms.NumericUpDown nSingleLose;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private System.Windows.Forms.NumericUpDown nSingleWin;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private System.Windows.Forms.NumericUpDown nAppearances;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private System.Windows.Forms.NumericUpDown nWorldRanking;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit txtWeight;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtHeight;
        private DevExpress.XtraEditors.LabelControl labelControl8;
    }
}