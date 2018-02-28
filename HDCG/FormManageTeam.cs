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
        string _teamType = "";
        public FormManageTeam(string team)
        {
            InitializeComponent();
            _teamType = team;
        }
        string templatesXmlPath = "";
        private void ManageTemplateForm_Shown(object sender, EventArgs e)
        {
            templatesXmlPath = Path.Combine(Application.StartupPath, "Danhsachcauthu" + _teamType + ".xml");
            try
            {
                if (File.Exists(templatesXmlPath))
                {
                    var lstTemplate = Utils.GetObject<List<Object.Player>>(templatesXmlPath);
                    foreach (var temp in lstTemplate)
                        bsManageTeam.Add(new View.Player()
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
                if (txtName.Text.Trim().Length == 0 || txtName.Name.Trim().Length == 0)
                {
                    HDMessageBox.Show("Tên và số áo không được để trống!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bsManageTeam.List.Add(new View.Player()
                    {
                        mObj = new Object.Player()
                        {
                            Number = txtName.Text,
                            Name = txtShortName.Text                            
                        }
                    });

                    (bsManageTeam.List as BindingList<View.Player>).Select(v => v.mObj).ToList().SaveObject(templatesXmlPath);
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
                        bsManageTeam.List.Remove(gvPlayers.GetFocusedRow());

                        (bsManageTeam.List as BindingList<View.Player>).Select(v => v.mObj).ToList().SaveObject(templatesXmlPath);
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
