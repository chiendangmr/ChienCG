using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDCore;
using HDControl;
using DevExpress.XtraGrid.Views.Grid;

namespace HDCGStudio
{
    public partial class ManagePlayersForm : Form
    {
        string _giaidau = "";
        string _team = "";
        Dictionary<string, string> dicDanhsachdoi = new Dictionary<string, string>();
        public ManagePlayersForm(string GiaiDau, string team)
        {
            InitializeComponent();
            _giaidau = GiaiDau;
            _team = team;
        }
        string templatesXmlPath = "";
        string _danhsachdoiXmlPath = "";
        private void ManageTemplateForm_Shown(object sender, EventArgs e)
        {
            _danhsachdoiXmlPath = Path.Combine(Path.Combine(Application.StartupPath, "Data"), "Danhsachdoi" + _giaidau + ".xml");
            try
            {
                if (File.Exists(_danhsachdoiXmlPath))
                {
                    var lstTemplate = Utils.GetObject<List<Object.Team>>(_danhsachdoiXmlPath);
                    foreach (var temp in lstTemplate)
                    {
                        cboTeams.Properties.Items.Add(temp.Name);
                        dicDanhsachdoi.Add(temp.TeamCode, temp.Name);
                    }
                }
                else
                {
                    File.Create(_danhsachdoiXmlPath).Dispose();
                }
            }
            catch (Exception ex)
            {
                HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            for (int i = 0; i < cboTeams.Properties.Items.Count; i++)
            {
                if (cboTeams.Properties.Items[i].ToString() == dicDanhsachdoi[_team])
                {
                    cboTeams.SelectedIndex = i;
                    break;
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumber.Text.Trim().Length == 0 || txtNumber.Name.Trim().Length == 0 || cboTeams.Text.Trim().Length == 0)
                {
                    HDMessageBox.Show("Đội, Tên và số áo không được để trống!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bsManagePlayers.List.Add(new View.Player()
                    {
                        mObj = new Object.Player()
                        {
                            Number = int.Parse(txtNumber.Text),
                            Name = txtName.Text,
                            IsCaptain = ckIsCaptain.Checked,
                            IsNotSubstitution = ckIsNotSubstitution.Checked,
                            IsSubstitution = ckDubi.Checked,
                            IsGK = ckIsGK.Checked,
                            ShortName = txtShortName.Text,
                            Team = cboTeams.Text,
                            Index = (int)nIndex.Value
                        }
                    });

                    (bsManagePlayers.List as BindingList<View.Player>).OrderBy(a => a.mObj.Number).Select(v => v.mObj).ToList().SaveObject(templatesXmlPath);
                }
            }
            catch (Exception ex)
            {
                HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPlayers.FocusedRowHandle < 0)
                    HDMessageBox.Show("Chưa chọn cầu thủ để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    var temp = gvPlayers.GetFocusedRow() as View.Player;
                    if (HDMessageBox.Show("Bạn chắc chắn xóa " + temp.mObj.Name) == DialogResult.OK)
                    {
                        bsManagePlayers.List.Remove(gvPlayers.GetFocusedRow());

                        (bsManagePlayers.List as BindingList<View.Player>).Select(v => v.mObj).ToList().SaveObject(templatesXmlPath);
                    }
                }
            }
            catch (Exception ex)
            {
                HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManageTemplateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            HDMessageBox.Show("Bạn phải load lại danh sách cầu thủ để lấy được các cầu thủ mới!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Green;
                e.Appearance.ForeColor = Color.White;
            }
        }

        private void ManagePlayersForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        bool _isRowClick = false;
        private void cboTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isRowClick)
            {
                templatesXmlPath = Path.Combine(Path.Combine(Application.StartupPath, "Data"), "Danhsachcauthu" + dicDanhsachdoi.FirstOrDefault(x => x.Value == cboTeams.Text).Key + ".xml");
                try
                {
                    if (File.Exists(templatesXmlPath))
                    {
                        bsManagePlayers.Clear();
                        var lstTemplate = Utils.GetObject<List<Object.Player>>(templatesXmlPath);
                        foreach (var temp in lstTemplate)
                            bsManagePlayers.Add(new View.Player()
                            {
                                mObj = temp
                            });
                    }
                    else
                    {
                        File.Create(templatesXmlPath).Dispose();
                    }
                    _isRowClick = false;
                }
                catch (Exception ex)
                {
                    HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gvPlayers_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                _isRowClick = true;
                var temp = gvPlayers.GetFocusedRow() as View.Player;
                cboTeams.Text = temp.mObj.Team;
                txtNumber.Text = temp.mObj.Number.ToString();
                txtName.Text = temp.mObj.Name;
                txtShortName.Text = temp.mObj.ShortName;
                ckIsGK.Checked = temp.mObj.IsGK;
                ckIsCaptain.Checked = temp.mObj.IsCaptain;
                ckIsNotSubstitution.Checked = temp.mObj.IsNotSubstitution;
                ckDubi.Checked = temp.mObj.IsSubstitution;
                nIndex.Value = temp.mObj.Index;
            }
            catch { }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumber.Text.Trim().Length == 0 || txtNumber.Name.Trim().Length == 0 || cboTeams.Text.Trim().Length == 0)
                {
                    HDMessageBox.Show("Đội, Tên và số áo không được để trống!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var temp = gvPlayers.GetFocusedRow() as View.Player;
                    bsManagePlayers.List.Insert(bsManagePlayers.List.IndexOf(temp), new View.Player()
                    {
                        mObj = new Object.Player()
                        {
                            Number = int.Parse(txtNumber.Text),
                            Name = txtName.Text,
                            IsCaptain = ckIsCaptain.Checked,
                            IsNotSubstitution = ckIsNotSubstitution.Checked,
                            IsSubstitution = ckDubi.Checked,
                            IsGK = ckIsGK.Checked,
                            ShortName = txtShortName.Text,
                            Team = cboTeams.Text,
                            Index = (int)nIndex.Value
                        }
                    });
                    gvPlayers.FocusedRowHandle = bsManagePlayers.List.IndexOf(temp);
                    bsManagePlayers.List.Remove(temp);
                    (bsManagePlayers.List as BindingList<View.Player>).OrderBy(a => a.mObj.Number).Select(v => v.mObj).ToList().SaveObject(templatesXmlPath);
                    gvPlayers.RefreshData();
                    HDMessageBox.Show("Lưu thành công!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
