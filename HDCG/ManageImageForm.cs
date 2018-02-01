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
    public partial class ManageImageForm : Form
    {
        string _templateType = "";
        public ManageImageForm(string templateType)
        {
            InitializeComponent();
            _templateType = templateType;
        }
        string templatesXmlPath = "";
        private void ManageTemplateForm_Shown(object sender, EventArgs e)
        {
            if (_templateType == "Bóng đá")
            {
                templatesXmlPath = Path.Combine(Application.StartupPath, "BongdaTemplateList.xml");
            }
            else
                templatesXmlPath = Path.Combine(Application.StartupPath, "TemplateList.xml");
            try
            {
                if (File.Exists(templatesXmlPath))
                {
                    var lstTemplate = Utils.GetObject<List<Object.Template>>(templatesXmlPath);
                    foreach (var temp in lstTemplate)
                        bsManageTemplate.Add(new View.Template()
                        {
                            TempObj = temp
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
                if (txtName.Text.Trim().Length == 0 || txtFileName.Text.Trim().Length == 0)
                {
                    HDMessageBox.Show("Tên đại diện và Tên template không được để trống!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bsManageTemplate.List.Add(new View.Template()
                    {
                        TempObj = new Object.Template()
                        {
                            Name = txtName.Text,
                            FileName = txtFileName.Text
                        }
                    });

                    (bsManageTemplate.List as BindingList<View.Template>).Select(v => v.TempObj).ToList().SaveObject(templatesXmlPath);
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
                        bsManageTemplate.List.Remove(gridView1.GetFocusedRow());

                        (bsManageTemplate.List as BindingList<View.Template>).Select(v => v.TempObj).ToList().SaveObject(templatesXmlPath);
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
            HDMessageBox.Show("Bạn phải load lại danh sách template để lấy được các templates mới!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
