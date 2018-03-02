namespace HDCGStudio
{
    partial class ManagePlayersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagePlayersForm));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridPlayers = new DevExpress.XtraGrid.GridControl();
            this.bsManagePlayers = new System.Windows.Forms.BindingSource(this.components);
            this.gvPlayers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsCaptain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsSubstitution = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboTeams = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.ckIsGK = new DevExpress.XtraEditors.CheckEdit();
            this.ckIsNotSubstitution = new DevExpress.XtraEditors.CheckEdit();
            this.ckIsCaptain = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtNumber = new DevExpress.XtraEditors.TextEdit();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsManagePlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeams.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckIsGK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckIsNotSubstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckIsCaptain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).BeginInit();
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
            this.splitContainerControl1.Panel2.Controls.Add(this.cboTeams);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel2.Controls.Add(this.ckIsGK);
            this.splitContainerControl1.Panel2.Controls.Add(this.ckIsNotSubstitution);
            this.splitContainerControl1.Panel2.Controls.Add(this.ckIsCaptain);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtName);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtNumber);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnRemove);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnAdd);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(754, 772);
            this.splitContainerControl1.SplitterPosition = 518;
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
            this.gridPlayers.Size = new System.Drawing.Size(754, 518);
            this.gridPlayers.TabIndex = 0;
            this.gridPlayers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPlayers});
            // 
            // bsManagePlayers
            // 
            this.bsManagePlayers.DataSource = typeof(HDCGStudio.View.Player);
            // 
            // gvPlayers
            // 
            this.gvPlayers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNumber,
            this.colName,
            this.gridColumn1,
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
            this.colNumber.Caption = "Số";
            this.colNumber.FieldName = "mObj.Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.OptionsColumn.AllowEdit = false;
            this.colNumber.Visible = true;
            this.colNumber.VisibleIndex = 0;
            this.colNumber.Width = 51;
            // 
            // colName
            // 
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colName.Caption = "Tên";
            this.colName.FieldName = "mObj.Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 226;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Thủ môn";
            this.gridColumn1.FieldName = "mObj.IsGK";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 80;
            // 
            // colIsCaptain
            // 
            this.colIsCaptain.AppearanceCell.Options.UseTextOptions = true;
            this.colIsCaptain.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsCaptain.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colIsCaptain.AppearanceHeader.Options.UseFont = true;
            this.colIsCaptain.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsCaptain.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsCaptain.Caption = "Đội trưởng";
            this.colIsCaptain.FieldName = "mObj.IsCaptain";
            this.colIsCaptain.Name = "colIsCaptain";
            this.colIsCaptain.Visible = true;
            this.colIsCaptain.VisibleIndex = 3;
            this.colIsCaptain.Width = 213;
            // 
            // colIsSubstitution
            // 
            this.colIsSubstitution.AppearanceCell.Options.UseTextOptions = true;
            this.colIsSubstitution.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsSubstitution.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colIsSubstitution.AppearanceHeader.Options.UseFont = true;
            this.colIsSubstitution.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsSubstitution.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsSubstitution.Caption = "Đá chính";
            this.colIsSubstitution.FieldName = "mObj.IsNotSubstitution";
            this.colIsSubstitution.Name = "colIsSubstitution";
            this.colIsSubstitution.Visible = true;
            this.colIsSubstitution.VisibleIndex = 4;
            this.colIsSubstitution.Width = 164;
            // 
            // cboTeams
            // 
            this.cboTeams.Location = new System.Drawing.Point(114, 21);
            this.cboTeams.Name = "cboTeams";
            this.cboTeams.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.cboTeams.Properties.Appearance.Options.UseFont = true;
            this.cboTeams.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTeams.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTeams.Size = new System.Drawing.Size(607, 26);
            this.cboTeams.TabIndex = 13;
            this.cboTeams.SelectedIndexChanged += new System.EventHandler(this.cboTeams_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(42, 23);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(37, 24);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Đội:";
            // 
            // ckIsGK
            // 
            this.ckIsGK.Location = new System.Drawing.Point(40, 114);
            this.ckIsGK.Name = "ckIsGK";
            this.ckIsGK.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ckIsGK.Properties.Appearance.Options.UseFont = true;
            this.ckIsGK.Properties.Caption = "Thủ môn:";
            this.ckIsGK.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ckIsGK.Size = new System.Drawing.Size(170, 28);
            this.ckIsGK.TabIndex = 7;
            // 
            // ckIsNotSubstitution
            // 
            this.ckIsNotSubstitution.EditValue = true;
            this.ckIsNotSubstitution.Location = new System.Drawing.Point(551, 114);
            this.ckIsNotSubstitution.Name = "ckIsNotSubstitution";
            this.ckIsNotSubstitution.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ckIsNotSubstitution.Properties.Appearance.Options.UseFont = true;
            this.ckIsNotSubstitution.Properties.Caption = "Đá chính:";
            this.ckIsNotSubstitution.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ckIsNotSubstitution.Size = new System.Drawing.Size(170, 28);
            this.ckIsNotSubstitution.TabIndex = 9;
            // 
            // ckIsCaptain
            // 
            this.ckIsCaptain.Location = new System.Drawing.Point(321, 114);
            this.ckIsCaptain.Name = "ckIsCaptain";
            this.ckIsCaptain.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ckIsCaptain.Properties.Appearance.Options.UseFont = true;
            this.ckIsCaptain.Properties.Caption = "Đội trưởng:";
            this.ckIsCaptain.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ckIsCaptain.Size = new System.Drawing.Size(170, 28);
            this.ckIsCaptain.TabIndex = 8;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(351, 71);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 24);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Tên:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(42, 71);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 24);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Số áo:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(398, 68);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Size = new System.Drawing.Size(323, 30);
            this.txtName.TabIndex = 3;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(114, 65);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtNumber.Properties.Appearance.Options.UseFont = true;
            this.txtNumber.Size = new System.Drawing.Size(98, 30);
            this.txtNumber.TabIndex = 2;
            // 
            // btnRemove
            // 
            this.btnRemove.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.ImageOptions.Image")));
            this.btnRemove.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRemove.Location = new System.Drawing.Point(411, 161);
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
            this.btnAdd.Location = new System.Drawing.Point(188, 161);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 57);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.ToolTip = "Thêm template";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ManagePlayersForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 772);
            this.Controls.Add(this.splitContainerControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManagePlayersForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.cboTeams.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckIsGK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckIsNotSubstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckIsCaptain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtNumber;
        private System.Windows.Forms.BindingSource bsManagePlayers;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCaptain;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSubstitution;
        private DevExpress.XtraEditors.CheckEdit ckIsNotSubstitution;
        private DevExpress.XtraEditors.CheckEdit ckIsCaptain;
        private DevExpress.XtraEditors.CheckEdit ckIsGK;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cboTeams;
    }
}