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
            tempPath = path;
        }
        string tempPath = "";
        string TemplateHost = "";
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

                TemplateHost = path;
            }
        }
        public void Clear()
        {
            if (TemplateHost != "")
            {
                player.Clear();

                if (TemplateHost.Contains("43"))
                    player.AspectControl = CGPreviewControl.FlashTemplateHostControl.Aspects.Aspect43;
                else
                    player.AspectControl = CGPreviewControl.FlashTemplateHostControl.Aspects.Aspect169;

                player.TemplateHost = TemplateHost;
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
                xmlAdd += Add("icon1", Path.Combine(AppSetting.Default.IconFolder, txtIcon1.Text));
                xmlAdd += Add("icon2", Path.Combine(AppSetting.Default.IconFolder, txtIcon2.Text));
                xmlAdd += Add("image", Path.Combine(AppSetting.Default.ImageFolder, txtColor.Text));
                xml = player.GetProperties();
                fieldName = xml.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", "\"").Replace("<string>", "").Replace("</string>", "").Replace("~", "");
                string xmlStr = "<Track_Property>" + xmlAdd + fieldName.Replace("<Track_Property>", "");

                this.Clear();
                if (player.Add(1, tempPath))
                {
                    player.Update(1, xmlStr);
                    player.Refresh();
                    this.Show();
                    this.Activate();
                }
                this.btnUpdate.Text = "Updated";
                this.btnUpdate.Enabled = false;

            }
            catch
            {
                HDMessageBox.Show("Data not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string getXml()
        {
            xml = player.GetProperties();
            return "<Track_Property>"+ xmlAdd + xml.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", "\"").Replace("<string>", "").Replace("</string>", "").Replace("<Track_Property>", "").Replace("~", "");
        }

        private void EditForm_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void btnChooseIcon1_Click(object sender, EventArgs e)
        {
            OpenFileInFolderDialog frm = new OpenFileInFolderDialog();
            frm.RootFolder = AppSetting.Default.IconFolder;
            frm.FilterString = "*.tga;*.png;*.jpg";
            if (frm.ShowDialog() == DialogResult.OK)
                txtIcon1.Text = frm.FileName;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileInFolderDialog frm = new OpenFileInFolderDialog();
            frm.RootFolder = AppSetting.Default.IconFolder;
            frm.FilterString = "*.tga;*.png;*.jpg";
            if (frm.ShowDialog() == DialogResult.OK)
                txtIcon2.Text = frm.FileName;
        }

        private void btnChooseColor_Click(object sender, EventArgs e)
        {
            OpenFileInFolderDialog frm = new OpenFileInFolderDialog();
            frm.RootFolder = AppSetting.Default.ImageFolder;
            frm.FilterString = "*.tga;*.png;*.jpg";
            if (frm.ShowDialog() == DialogResult.OK)
                txtColor.Text = frm.FileName;
        }
    }
}
