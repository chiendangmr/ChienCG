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
            _danhsachdoiXmlPath = Path.Combine(Application.StartupPath, "Danhsachdoi" + Utils.ConvertToVietnameseNonSign(_giaidau).Replace(" ", "_") + ".xml");
            try
            {
                if (File.Exists(_danhsachdoiXmlPath))
                {
                    var lstTemplate = Utils.GetObject<List<Object.Team>>(_danhsachdoiXmlPath);
                    foreach (var temp in lstTemplate)
                        cboTeams.Properties.Items.Add(temp.Name);
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
            cboTeams.Text = _team;            
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumber.Text.Trim().Length == 0 || txtNumber.Name.Trim().Length == 0 || cboTeams.Text.Trim().Length==0)
                {
                    HDMessageBox.Show("Đội, Tên và số áo không được để trống!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            IsNotSubstitution = ckIsNotSubstitution.Checked,
                            IsGK = ckIsGK.Checked
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

        private void cboTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            templatesXmlPath = Path.Combine(Application.StartupPath, "Danhsachcauthu" + Utils.ConvertToVietnameseNonSign(cboTeams.Text).Replace(" ", "_") + ".xml");
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
            }
            catch (Exception ex)
            {
                HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
