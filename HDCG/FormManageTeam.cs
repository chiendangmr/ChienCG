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
    public partial class FormManageTeam : Form
    {
        string _leagueName = "";
        public FormManageTeam(string league)
        {
            InitializeComponent();
            _leagueName = league;
        }
        string DanhsachdoiXmlPath = "";
        string DanhsachgiaidauXmlPath = "";
        string _updateNotifier = "";
        Dictionary<string, string> dicDanhsachgiaidau = new Dictionary<string, string>();
        private void ManageTemplateForm_Shown(object sender, EventArgs e)
        {
            DanhsachgiaidauXmlPath = Path.Combine(Path.Combine(Application.StartupPath, "Data"), "Danhsachgiaidau.xml");
            try
            {
                if (File.Exists(DanhsachgiaidauXmlPath))
                {
                    var lstTemplate = Utils.GetObject<List<Object.League>>(DanhsachgiaidauXmlPath);
                    foreach (var temp in lstTemplate)
                    {
                        cboLeague.Properties.Items.Add(temp.Name);
                        dicDanhsachgiaidau.Add(temp.LeagueCode, temp.Name);
                    }
                }
                else
                {
                    File.Create(DanhsachgiaidauXmlPath).Dispose();
                }
                cboLeague.Text = _leagueName;
            }
            catch //(Exception ex)
            {
                //HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DanhsachdoiXmlPath = Path.Combine(Path.Combine(Application.StartupPath, "Data"), "Danhsachdoi" + dicDanhsachgiaidau.FirstOrDefault(x => x.Value == _leagueName).Key + ".xml");
            try
            {
                if (File.Exists(DanhsachdoiXmlPath))
                {
                    var lstTemplate = Utils.GetObject<List<Object.Team>>(DanhsachdoiXmlPath);
                    foreach (var temp in lstTemplate)
                        bsManageTeam.Add(new View.Team()
                        {
                            tObj = temp
                        });
                }
                else
                {
                    File.Create(DanhsachdoiXmlPath).Dispose();
                }
            }
            catch //(Exception ex)
            {
                //HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _updateNotifier = Path.Combine(Path.Combine(Application.StartupPath, "Data"), "UpdateNotifier.xml");
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaDoi.Text.Trim().Length == 0 || txtName.Text.Trim().Length == 0 || txtCoach.Text.Trim().Length == 0 || txtShortName.Text.Trim().Length == 0 || cboLeague.Text.Trim().Length == 0)
                {
                    HDMessageBox.Show("Phải chọn đủ Giải đấu, Mã đội, Tên, Tên viết tắt và HLV để khởi tạo một đội bóng!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bsManageTeam.List.Add(new View.Team()
                    {
                        tObj = new Object.Team()
                        {
                            Name = txtName.Text,
                            ShortName = txtShortName.Text,
                            CoachName = txtCoach.Text,
                            LeagueCode = dicDanhsachgiaidau.FirstOrDefault(x => x.Value == cboLeague.Text).Key,
                            LogoPath = txtLogoPath.Text,
                            Stadium = txtSanNha.Text,
                            Position = (int)nPosition.Value,
                            TeamCode = txtMaDoi.Text
                        }
                    });

                    (bsManageTeam.List as BindingList<View.Team>).OrderBy(a => a.tObj.Position).Select(v => v.tObj).ToList().SaveObject(DanhsachdoiXmlPath);
                    gvTeams.RefreshData();
                    UpdateNotifier();
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
                    var temp = gvTeams.GetFocusedRow() as View.Team;
                    if (HDMessageBox.Show("Bạn chắc chắn xóa " + temp.tObj.Name) == DialogResult.OK)
                    {
                        bsManageTeam.List.Remove(gvTeams.GetFocusedRow());

                        (bsManageTeam.List as BindingList<View.Team>).Select(v => v.tObj).ToList().SaveObject(DanhsachdoiXmlPath);
                    }
                    UpdateNotifier();
                }
            }
            catch (Exception ex)
            {
                HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManageTemplateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateNotifier();
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
            frm.RootFolder = Path.Combine(AppSetting.Default.MediaFolder, "Icons");
            frm.FilterString = "*.tga;*.png;*.jpg";
            if (frm.ShowDialog() == DialogResult.OK)
                txtLogoPath.Text = frm.FileName;
        }

        private void gvTeams_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                var temp = gvTeams.GetFocusedRow() as View.Team;
                cboLeague.Text = dicDanhsachgiaidau[temp.tObj.LeagueCode];
                txtCoach.Text = temp.tObj.CoachName;
                txtName.Text = temp.tObj.Name;
                txtShortName.Text = temp.tObj.ShortName;
                txtLogoPath.Text = temp.tObj.LogoPath;
                txtSanNha.Text = temp.tObj.Stadium;
                nPosition.Value = temp.tObj.Position;
                txtMaDoi.Text = temp.tObj.TeamCode;
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
                    var temp = gvTeams.GetFocusedRow() as View.Team;
                    bsManageTeam.List.Insert(bsManageTeam.List.IndexOf(temp), new View.Team()
                    {
                        tObj = new Object.Team()
                        {
                            Name = txtName.Text,
                            ShortName = txtShortName.Text,
                            CoachName = txtCoach.Text,
                            LeagueCode = dicDanhsachgiaidau.FirstOrDefault(x => x.Value == cboLeague.Text).Key,
                            LogoPath = txtLogoPath.Text,
                            Stadium = txtSanNha.Text,
                            Position = (int)nPosition.Value,
                            TeamCode = txtMaDoi.Text
                        }
                    });
                    gvTeams.FocusedRowHandle = bsManageTeam.List.IndexOf(temp);
                    bsManageTeam.List.Remove(temp);
                    (bsManageTeam.List as BindingList<View.Team>).OrderBy(a => a.tObj.Position).Select(v => v.tObj).ToList().SaveObject(DanhsachdoiXmlPath);

                    gvTeams.RefreshData();
                    HDMessageBox.Show("Lưu thành công!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateNotifier();
                }
            }
            catch (Exception ex)
            {
                HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateNotifier()
        {
            bsUpdateNotifier.List.Clear();
            bsUpdateNotifier.List.Add(new Object.UpdateNotifier
            {
                IsUpdateDanhsachcauthu = false,
                IsUpdateDanhsachdoibong = true,
                IsUpdateDanhsachgiaidau = false
            });
            (bsUpdateNotifier.List as BindingList<Object.UpdateNotifier>).Select(v => v).ToList().SaveObject(_updateNotifier);
        }
    }
}
