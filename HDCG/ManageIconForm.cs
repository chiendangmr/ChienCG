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

namespace HDCGStudio
{
    public partial class ManageIconForm : Form
    {
        string _templateType = "";
        public ManageIconForm(string templateType)
        {
            InitializeComponent();
            _templateType = templateType;
        }
        string iconXmlPath = "";
        private void ManageTemplateForm_Shown(object sender, EventArgs e)
        {
            var xmlFileName = "icon_"+ Utils.ConvertToVietnameseNonSign(_templateType).Replace(" ","").ToLower() + "_list.xml";
            iconXmlPath = Path.Combine(Application.StartupPath, xmlFileName);

            try
            {
                if (File.Exists(iconXmlPath))
                {
                    var lstTemplate = Utils.GetObject<List<Object.Template>>(iconXmlPath);
                    foreach (var temp in lstTemplate)
                        bsManageIcon.Add(new View.Template()
                        {
                            TempObj = temp
                        });
                }
                else
                {
                    File.Create(iconXmlPath).Dispose();
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
                if (txtName.Text.Trim().Length == 0 || txtFileName.Text.Trim().Length == 0)
                {
                    HDMessageBox.Show("Tên đại diện và Tên icon không được để trống!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bsManageIcon.List.Add(new View.Template()
                    {
                        TempObj = new Object.Template()
                        {
                            Name = txtName.Text,
                            FileName = txtFileName.Text
                        }
                    });

                    (bsManageIcon.List as BindingList<View.Template>).Select(v => v.TempObj).ToList().SaveObject(iconXmlPath);
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
                if (gridView1.FocusedRowHandle < 0)
                    HDMessageBox.Show("Chưa chọn template để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    var temp = gridView1.GetFocusedRow() as View.Template;
                    if (HDMessageBox.Show("Bạn chắc chắn xóa " + temp.TempObj.Name) == DialogResult.OK)
                    {
                        bsManageIcon.List.Remove(gridView1.GetFocusedRow());

                        (bsManageIcon.List as BindingList<View.Template>).Select(v => v.TempObj).ToList().SaveObject(iconXmlPath);
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
            HDMessageBox.Show("Bạn phải load lại danh sách Icons để lấy được các Icons mới!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
