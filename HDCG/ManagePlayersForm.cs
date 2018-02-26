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
        public ManagePlayersForm()
        {
            InitializeComponent();            
        }
        string templatesXmlPath = "";
        private void ManageTemplateForm_Shown(object sender, EventArgs e)
        {            
            templatesXmlPath = Path.Combine(Application.StartupPath, "Danhsachcauthu.xml");
            try
            {
                if (File.Exists(templatesXmlPath))
                {
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
                if (txtNumber.Text.Trim().Length == 0 || txtNumber.Name.Trim().Length == 0)
                {
                    HDMessageBox.Show("Tên và số áo không được để trống!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bsManagePlayers.List.Add(new View.Player()
                    {
                        mObj = new Object.Player()
                        {
                            Number = txtNumber.Text,
                            Name = txtName.Text,
                            IsCaptain = ckIsCaptain.Checked,
                            IsSubstitute= ckIsSubstitution.Checked
                        }
                    });

                    (bsManagePlayers.List as BindingList<View.Player>).Select(v => v.mObj).ToList().SaveObject(templatesXmlPath);
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
    }
}
