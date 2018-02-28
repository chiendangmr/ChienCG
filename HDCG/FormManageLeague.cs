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
    public partial class FormManageLeague : Form
    {        
        public FormManageLeague()
        {
            InitializeComponent();            
        }
        string DanhsachgiaidauXmlPath = "";
        private void ManageTemplateForm_Shown(object sender, EventArgs e)
        {
            DanhsachgiaidauXmlPath = Path.Combine(Application.StartupPath, "Danhsachgiaidau.xml");
            try
            {
                if (File.Exists(DanhsachgiaidauXmlPath))
                {
                    var lstTemplate = Utils.GetObject<List<Object.League>>(DanhsachgiaidauXmlPath);
                    foreach (var temp in lstTemplate)
                        bsManageLeague.Add(new View.League()
                        {
                            lObj = temp
                        });
                }
                else
                {
                    File.Create(DanhsachgiaidauXmlPath).Dispose();
                }
            }
            catch (Exception ex)
            {
                HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Trim().Length == 0 || txtShortName.Name.Trim().Length == 0)
                {
                    HDMessageBox.Show("Tên và tên viết tắt không được để trống!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bsManageLeague.List.Add(new View.League()
                    {
                        lObj = new Object.League()
                        {
                            Name = txtName.Text,
                            ShortName = txtShortName.Text,
                            LogoPath = txtLogoPath.Text
                        }
                    });

                    (bsManageLeague.List as BindingList<View.League>).Select(v => v.lObj).ToList().SaveObject(DanhsachgiaidauXmlPath);
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
                    HDMessageBox.Show("Chưa chọn cầu thủ để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    var temp = gvLeagues.GetFocusedRow() as View.League;
                    if (HDMessageBox.Show("Bạn chắc chắn xóa " + temp.lObj.Name) == DialogResult.OK)
                    {
                        bsManageLeague.List.Remove(gvLeagues.GetFocusedRow());

                        (bsManageLeague.List as BindingList<View.League>).Select(v => v.lObj).ToList().SaveObject(DanhsachgiaidauXmlPath);
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
            HDMessageBox.Show("Bạn phải load lại danh sách giải đấu để lấy được các giải đấu mới!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
