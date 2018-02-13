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
    public partial class PreviewForm : HDForm
    {
        public PreviewForm(string path)
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
        string xmlAdd = "";
        private string Add(string str, string val)
        {
            return "<" + str + " id=\"" + str + "\"><data value=\"" + val + "\"/></" + str + ">";
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

        }        
    }
}
