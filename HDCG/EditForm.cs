using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HDControl;
using System.IO;
using HDCore;

namespace HDCGStudio
{
    public partial class EditForm : HDForm
    {
        public EditForm(string path)
        {
            InitializeComponent();
            _tempPath = path;
        }
        string _tempPath = "";
        string _TemplateHost = "";
        public bool Exit = false;
        private void InputForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Exit)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
        public void LoadTemplateHost(string path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                HDMessageBox.Show("Template folder does not exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!File.Exists(path))
            {
                HDMessageBox.Show("Template host file does not exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                player.Clear();

                if (path.Contains("43"))
                    player.AspectControl = CGPreviewControl.FlashTemplateHostControl.Aspects.Aspect43;
                else
                    player.AspectControl = CGPreviewControl.FlashTemplateHostControl.Aspects.Aspect169;

                player.TemplateHost = path;
                player.Add(0, "HDTemplates/HDVietNam.ft", true);

                _TemplateHost = path;
            }
        }
        public void Clear()
        {
            if (_TemplateHost != "")
            {
                player.Clear();

                if (_TemplateHost.Contains("43"))
                    player.AspectControl = CGPreviewControl.FlashTemplateHostControl.Aspects.Aspect43;
                else
                    player.AspectControl = CGPreviewControl.FlashTemplateHostControl.Aspects.Aspect169;

                player.TemplateHost = _TemplateHost;
                player.Add(0, "HDTemplates/HDVietNam.ft", true);
            }
        }

        string xml = "";
        string fieldName = "";
        string xmlAdd = "";
        private string Add(string str, string val)
        {
            return "<" + str + " id=\"" + str + "\"><data value=\"" + val + "\"/></" + str + ">";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIcon1.Text.Length > 0)
                    xmlAdd += Add("icon1", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons"), txtIcon1.Text));
                if (txtIcon2.Text.Length > 0)
                    xmlAdd += Add("icon2", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons"), txtIcon2.Text));
                if (txtColor.Text.Length > 0)
                    xmlAdd += Add("image", Path.Combine(AppSetting.Default.MediaFolder, txtColor.Text));
                xml = player.GetProperties();
                fieldName = xml.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", "\"").Replace("<string>", "").Replace("</string>", "").Replace("~", "");
                string xmlStr = "<Track_Property>" + xmlAdd + fieldName.Replace("<Track_Property>", "");
                UpdateDataFile(xmlStr);
                this.Clear();
                if (player.Add(1, _tempPath))
                {
                    player.Update(1, xmlStr.Replace("\\n", "\n"));
                    player.Refresh();
                    this.Show();
                    this.Activate();
                }
                this.btnUpdate.Text = "Updated";
                //this.btnUpdate.Enabled = false;

            }
            catch
            {
                HDMessageBox.Show("Data not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateDataFile(string data)
        {
            try
            {
                if (bsUpdateData.List.Count > 0)
                {
                    int dataCount = 0;
                    foreach (var temp in bsUpdateData.List as BindingList<Object.tempUpdating>)
                    {
                        if (temp.Name == _tempPath)
                        {
                            dataCount++;
                            temp.Data = data;
                            (bsUpdateData.List as BindingList<Object.tempUpdating>).ToList().SaveObject(_updateDataXmlPath);
                        }
                    }
                    if (dataCount == 0)
                    {
                        bsUpdateData.List.Add(new Object.tempUpdating()
                        {
                            Name = _tempPath,
                            Data = data

                        });

                        (bsUpdateData.List as BindingList<Object.tempUpdating>).ToList().SaveObject(_updateDataXmlPath);
                    }
                }
                else
                {
                    bsUpdateData.List.Add(new Object.tempUpdating()
                    {
                        Name = _tempPath,
                        Data = data

                    });

                    (bsUpdateData.List as BindingList<Object.tempUpdating>).ToList().SaveObject(_updateDataXmlPath);

                }
            }
            catch (Exception ex)
            {
                HDMessageBox.Show("UpdateDataFile lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string getXml()
        {
            xml = player.GetProperties();
            return "<Track_Property>" + xmlAdd + xml.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", "\"").Replace("<string>", "").Replace("</string>", "").Replace("<Track_Property>", "").Replace("~", "");
        }
        string _updateDataXmlPath = "";
        private void EditForm_Shown(object sender, EventArgs e)
        {
            _updateDataXmlPath = Path.Combine(Application.StartupPath, "UpdateData.xml");
            try
            {
                if (File.Exists(_updateDataXmlPath))
                {
                    var lstData = Utils.GetObject<List<Object.tempUpdating>>(_updateDataXmlPath);
                    foreach (var data in lstData)
                        bsUpdateData.List.Add(new Object.tempUpdating()
                        {
                            Name = data.Name,
                            Data = data.Data
                        });
                }
                else
                {
                    File.Create(_updateDataXmlPath).Dispose();
                }
            }
            catch { }
            this.WindowState = FormWindowState.Maximized;

        }

        private void btnChooseIcon1_Click(object sender, EventArgs e)
        {
            OpenFileInFolderDialog frm = new OpenFileInFolderDialog();
            frm.RootFolder = Path.Combine(AppSetting.Default.MediaFolder, "Icons");
            frm.FilterString = "*.tga;*.png;*.jpg";
            if (frm.ShowDialog() == DialogResult.OK)
                txtIcon1.Text = frm.FileName;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileInFolderDialog frm = new OpenFileInFolderDialog();
            frm.RootFolder = Path.Combine(AppSetting.Default.MediaFolder, "Icons");
            frm.FilterString = "*.tga;*.png;*.jpg";
            if (frm.ShowDialog() == DialogResult.OK)
                txtIcon2.Text = frm.FileName;
        }

        private void btnChooseColor_Click(object sender, EventArgs e)
        {
            OpenFileInFolderDialog frm = new OpenFileInFolderDialog();
            frm.RootFolder = AppSetting.Default.MediaFolder;
            frm.FilterString = "*.tga;*.png;*.jpg";
            if (frm.ShowDialog() == DialogResult.OK)
                txtColor.Text = frm.FileName;
        }
    }
}
