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
    public partial class FormManageTennisTeam : Form
    {
        string _leagueName = "";
        public FormManageTennisTeam(string league)
        {
            InitializeComponent();
            _leagueName = league;
        }
        string _DanhsachdoiXmlPath = "";
        string _DanhsachgiaidauXmlPath = "";
        Dictionary<string, string> dicDanhsachgiaidau = new Dictionary<string, string>();
        private void ManageTemplateForm_Shown(object sender, EventArgs e)
        {
            _DanhsachgiaidauXmlPath = Path.Combine(Path.Combine(Application.StartupPath, "Data/Tennis"), "Danhsachgiaidau.xml");
            try
            {
                if (File.Exists(_DanhsachgiaidauXmlPath))
                {
                    var lstTemplate = Utils.GetObject<List<Object.Tennis.League>>(_DanhsachgiaidauXmlPath);
                    foreach (var temp in lstTemplate)
                    {
                        cboLeague.Properties.Items.Add(temp.Name);
                        dicDanhsachgiaidau.Add(temp.LeagueCode, temp.Name);
                    }
                }
                else
                {
                    File.Create(_DanhsachgiaidauXmlPath).Dispose();
                }
                cboLeague.Text = _leagueName;
            }
            catch //(Exception ex)
            {
                //HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _DanhsachdoiXmlPath = Path.Combine(Path.Combine(Application.StartupPath, "Data/Tennis"), "Danhsachdoi" + dicDanhsachgiaidau.FirstOrDefault(x => x.Value == _leagueName).Key + ".xml");
            try
            {
                if (File.Exists(_DanhsachdoiXmlPath))
                {
                    var lstTemplate = Utils.GetObject<List<Object.Tennis.Team>>(_DanhsachdoiXmlPath);
                    foreach (var temp in lstTemplate)
                        bsManageTeam.Add(temp);
                }
                else
                {
                    File.Create(_DanhsachdoiXmlPath).Dispose();
                }
            }
            catch //(Exception ex)
            {
                //HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaDoi.Text.Trim().Length == 0 || txtName.Text.Trim().Length == 0 || txtCoach.Text.Trim().Length == 0 || txtShortName.Text.Trim().Length == 0 || cboLeague.Text.Trim().Length == 0)
                {
                    HDMessageBox.Show("Phải chọn đủ Giải đấu, Mã đội, Tên, Tên viết tắt và HLV để khởi tạo một đội!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bsManageTeam.List.Add(new Object.Tennis.Team()
                    {
                        Name = txtName.Text,
                        ShortName = txtShortName.Text,
                        CoachName = txtCoach.Text,
                        LeagueCode = dicDanhsachgiaidau.FirstOrDefault(x => x.Value == cboLeague.Text).Key,
                        LogoPath = txtLogoPath.Text,
                        City = txtDonVi.Text,
                        HatGiong = (int)nHatGiong.Value,
                        TeamCode = txtMaDoi.Text,
                        Played = (int)nPlayed.Value,
                        Points = txtPoints.Text,
                        Position = (int)nPosition.Value,
                        Previous = (int)nPrevious.Value
                    });

                    (bsManageTeam.List as BindingList<Object.Tennis.Team>).OrderBy(a => a.HatGiong).ToList().SaveObject(_DanhsachdoiXmlPath);
                    gvTeams.RefreshData();
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
                if (gvTeams.FocusedRowHandle < 0)
                    HDMessageBox.Show("Chưa chọn đội để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    var temp = gvTeams.GetFocusedRow() as Object.Tennis.Team;
                    if (HDMessageBox.Show("Bạn chắc chắn xóa " + temp.Name) == DialogResult.OK)
                    {
                        bsManageTeam.List.Remove(gvTeams.GetFocusedRow());

                        (bsManageTeam.List as BindingList<Object.Tennis.Team>).ToList().SaveObject(_DanhsachdoiXmlPath);
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
            HDMessageBox.Show("Bạn phải Làm mới dữ liệu để lấy các dữ liệu mới!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnChooseLogo_Click(object sender, EventArgs e)
        {
            OpenFileInFolderDialog frm = new OpenFileInFolderDialog();
            frm.RootFolder = Path.Combine(AppSetting.Default.MediaFolder, "Icons/Tennis");
            frm.FilterString = "*.tga;*.png;*.jpg";
            if (frm.ShowDialog() == DialogResult.OK)
                txtLogoPath.Text = frm.FileName;
        }

        private void gvTeams_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                var temp = gvTeams.GetFocusedRow() as Object.Tennis.Team;
                cboLeague.Text = dicDanhsachgiaidau[temp.LeagueCode];
                txtCoach.Text = temp.CoachName;
                txtName.Text = temp.Name;
                txtShortName.Text = temp.ShortName;
                txtLogoPath.Text = temp.LogoPath;
                txtDonVi.Text = temp.City;
                nHatGiong.Value = temp.HatGiong;
                txtMaDoi.Text = temp.TeamCode;
                nPrevious.Value = temp.Previous;
                nPosition.Value = temp.Position;
                txtPoints.Text = temp.Points;
                nPlayed.Value = temp.Played;
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaDoi.Text.Trim().Length == 0 || txtName.Text.Trim().Length == 0 || txtCoach.Text.Trim().Length == 0 || txtShortName.Text.Trim().Length == 0 || cboLeague.Text.Trim().Length == 0)
                {
                    HDMessageBox.Show("Phải chọn đủ Giải đấu, Mã đội, Tên, Tên viết tắt và HLV!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var temp = gvTeams.GetFocusedRow() as Object.Tennis.Team;
                    bsManageTeam.List.Insert(bsManageTeam.List.IndexOf(temp), new Object.Tennis.Team()
                    {
                        Name = txtName.Text,
                        ShortName = txtShortName.Text,
                        CoachName = txtCoach.Text,
                        LeagueCode = dicDanhsachgiaidau.FirstOrDefault(x => x.Value == cboLeague.Text).Key,
                        LogoPath = txtLogoPath.Text,
                        City = txtDonVi.Text,
                        HatGiong = (int)nHatGiong.Value,
                        TeamCode = txtMaDoi.Text,
                        Played = (int)nPlayed.Value,
                        Points = txtPoints.Text,
                        Position = (int)nPosition.Value,
                        Previous = (int)nPrevious.Value

                    });
                    gvTeams.FocusedRowHandle = bsManageTeam.List.IndexOf(temp);
                    bsManageTeam.List.Remove(temp);
                    (bsManageTeam.List as BindingList<Object.Tennis.Team>).OrderBy(a => a.HatGiong).ToList().SaveObject(_DanhsachdoiXmlPath);

                    gvTeams.RefreshData();
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
