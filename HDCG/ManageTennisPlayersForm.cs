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
    public partial class ManageTennisPlayersForm : Form
    {
        string _giaidau = "";
        string _team = "";
        Dictionary<string, string> dicDanhsachdoi = new Dictionary<string, string>();
        public ManageTennisPlayersForm(string GiaiDau, string team)
        {
            InitializeComponent();
            _giaidau = GiaiDau;
            _team = team;
        }
        string templatesXmlPath = "";
        string _danhsachdoiXmlPath = "";
        private void ManageTemplateForm_Shown(object sender, EventArgs e)
        {
            _danhsachdoiXmlPath = Path.Combine(Path.Combine(Application.StartupPath, "Data/Tennis"), "Danhsachdoi" + _giaidau + ".xml");
            try
            {
                if (File.Exists(_danhsachdoiXmlPath))
                {
                    var lstTemplate = Utils.GetObject<List<Object.Tennis.Team>>(_danhsachdoiXmlPath);
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
                if (txtName.Text.Trim().Length == 0 || cboTeams.Text.Trim().Length == 0)
                {
                    HDMessageBox.Show("Đội, Tên không được để trống!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bsManagePlayers.List.Add(
                        new Object.Tennis.Player()
                        {
                            Name = txtName.Text,
                            IsMale = ckIsNotSubstitution.Checked,
                            ShortName = txtShortName.Text,
                            Team = cboTeams.Text,
                            HatGiong = (int)nIndex.Value,
                            Rank = (int)nRank.Value,
                            isCaptain = ckCaptain.Checked,
                            Nation = txtNation.Text,
                            Age = (int)nAge.Value,
                            Height = txtHeight.Text,
                            Weight = txtWeight.Text,
                            WorldRanking = (int)nWorldRanking.Value,
                            Appearances = (int)nAppearances.Value,
                            SingleWin = (int)nSingleWin.Value,
                            SingleLose = (int)nSingleLose.Value,
                            Debut = txtDebut.Text
                        });

                    (bsManagePlayers.List as BindingList<Object.Tennis.Player>).OrderBy(a => a.HatGiong).ToList().SaveObject(templatesXmlPath);
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
                    var temp = gvPlayers.GetFocusedRow() as Object.Tennis.Player;
                    if (HDMessageBox.Show("Bạn chắc chắn xóa " + temp.Name) == DialogResult.OK)
                    {
                        bsManagePlayers.List.Remove(gvPlayers.GetFocusedRow());

                        (bsManagePlayers.List as BindingList<Object.Tennis.Player>).ToList().SaveObject(templatesXmlPath);
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
                templatesXmlPath = Path.Combine(Path.Combine(Application.StartupPath, "Data/Tennis"), "Danhsachcauthu" + dicDanhsachdoi.FirstOrDefault(x => x.Value == cboTeams.Text).Key + ".xml");
                try
                {
                    if (File.Exists(templatesXmlPath))
                    {
                        bsManagePlayers.Clear();
                        var lstTemplate = Utils.GetObject<List<Object.Tennis.Player>>(templatesXmlPath);
                        foreach (var temp in lstTemplate)
                            bsManagePlayers.Add(temp);
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
                var temp = gvPlayers.GetFocusedRow() as Object.Tennis.Player;
                cboTeams.Text = temp.Team;
                txtName.Text = temp.Name;
                txtShortName.Text = temp.ShortName;
                ckIsNotSubstitution.Checked = temp.IsMale;
                nIndex.Value = temp.HatGiong;
                ckCaptain.Checked = temp.isCaptain;
                nRank.Value = temp.Rank;
                txtNation.Text = temp.Nation;
                nAge.Value = temp.Age;
                txtHeight.Text = temp.Height;
                txtWeight.Text = temp.Weight;
                nWorldRanking.Value = temp.WorldRanking;
                nAppearances.Value = temp.Appearances;
                nSingleWin.Value = temp.SingleWin;
                nSingleLose.Value = temp.SingleLose;
                txtDebut.Text = temp.Debut;
            }
            catch { }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Trim().Length == 0 || cboTeams.Text.Trim().Length == 0)
                {
                    HDMessageBox.Show("Đội, Tên không được để trống!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var temp = gvPlayers.GetFocusedRow() as Object.Tennis.Player;
                    bsManagePlayers.List.Insert(bsManagePlayers.List.IndexOf(temp), new Object.Tennis.Player
                    {
                        Name = txtName.Text,
                        IsMale = ckIsNotSubstitution.Checked,
                        ShortName = txtShortName.Text,
                        Team = cboTeams.Text,
                        HatGiong = (int)nIndex.Value,
                        Rank = (int)nRank.Value,
                        isCaptain = ckCaptain.Checked,
                        Nation = txtNation.Text,
                        Age = (int)nAge.Value,
                        Height = txtHeight.Text,
                        Weight = txtWeight.Text,
                        WorldRanking = (int)nWorldRanking.Value,
                        Appearances = (int)nAppearances.Value,
                        SingleWin = (int)nSingleWin.Value,
                        SingleLose = (int)nSingleLose.Value,
                        Debut = txtDebut.Text
                    });
                    gvPlayers.FocusedRowHandle = bsManagePlayers.List.IndexOf(temp);
                    bsManagePlayers.List.Remove(temp);
                    (bsManagePlayers.List as BindingList<Object.Tennis.Player>).OrderBy(a => a.HatGiong).ToList().SaveObject(templatesXmlPath);
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
