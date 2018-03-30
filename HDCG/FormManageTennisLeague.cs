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
    public partial class FormManageTennisLeague : Form
    {
        public FormManageTennisLeague()
        {
            InitializeComponent();
        }
        string DanhsachgiaidauXmlPath = "";
        
        private void ManageTemplateForm_Shown(object sender, EventArgs e)
        {
            DanhsachgiaidauXmlPath = Path.Combine(Path.Combine(Application.StartupPath, "Data/Tennis"), "Danhsachgiaidau.xml");
            try
            {
                if (File.Exists(DanhsachgiaidauXmlPath))
                {
                    var lstTemplate = Utils.GetObject<List<Object.League>>(DanhsachgiaidauXmlPath);
                    foreach (var temp in lstTemplate)
                        bsManageLeague.Add(new Object.Tennis.League()
                        {
                            Name = temp.Name,
                            LeagueCode = temp.LeagueCode,
                            LogoPath = temp.LogoPath
                        });
                }
                else
                {
                    File.Create(DanhsachgiaidauXmlPath).Dispose();
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
                if (txtName.Text.Trim().Length == 0 || txtMaGiai.Name.Trim().Length == 0)
                {
                    HDMessageBox.Show("Tên và mã giải không được để trống!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bsManageLeague.List.Add(new Object.Tennis.League()
                    {
                        Name = txtName.Text,
                        LeagueCode = txtMaGiai.Text,
                        LogoPath = txtLogoPath.Text

                    });

                    (bsManageLeague.List as BindingList<Object.Tennis.League>).ToList().SaveObject(DanhsachgiaidauXmlPath);
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
                if (gvLeagues.FocusedRowHandle < 0)
                    HDMessageBox.Show("Chưa chọn giải để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    var temp = gvLeagues.GetFocusedRow() as Object.Tennis.League;
                    if (HDMessageBox.Show("Bạn chắc chắn xóa " + temp.Name) == DialogResult.OK)
                    {
                        bsManageLeague.List.Remove(gvLeagues.GetFocusedRow());

                        (bsManageLeague.List as BindingList<Object.Tennis.League>).ToList().SaveObject(DanhsachgiaidauXmlPath);
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
            frm.RootFolder = Path.Combine(AppSetting.Default.MediaFolder, "Icons");
            frm.FilterString = "*.tga;*.png;*.jpg";
            if (frm.ShowDialog() == DialogResult.OK)
                txtLogoPath.Text = frm.FileName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Trim().Length == 0 || txtMaGiai.Name.Trim().Length == 0)
                {
                    HDMessageBox.Show("Tên và mã giải không được để trống!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    {
                        var temp = gvLeagues.GetFocusedRow() as Object.Tennis.League;
                        bsManageLeague.List.Insert(bsManageLeague.List.IndexOf(temp), new Object.Tennis.League()
                        {                           
                                Name = txtName.Text,
                                LeagueCode = txtMaGiai.Text,
                                LogoPath = txtLogoPath.Text                            
                        });
                        gvLeagues.FocusedRowHandle = bsManageLeague.List.IndexOf(temp);
                        bsManageLeague.List.Remove(temp);
                        (bsManageLeague.List as BindingList<Object.Tennis.League>).OrderBy(a => a.LeagueCode).ToList().SaveObject(DanhsachgiaidauXmlPath);
                        gvLeagues.RefreshData();
                        HDMessageBox.Show("Lưu thành công!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvLeagues_RowClick(object sender, RowClickEventArgs e)
        {
            var temp = gvLeagues.GetFocusedRow() as Object.Tennis.League;
            txtName.Text = temp.Name;
            txtMaGiai.Text = temp.LeagueCode;
            txtLogoPath.Text = temp.LogoPath;
        }        
    }
}
