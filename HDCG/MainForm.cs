using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using HDControl;
using HDCore;
using System.IO;
using Svt.Caspar;
using System.Net;
using System.Xml;
using System.Threading;

namespace HDCGStudio
{
    public partial class MainForm : HDForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void mnuAbout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AboutFormEnglish frm = new AboutFormEnglish();
            frm.lbSoftware.Text = "HDCGStudio";
            frm.ShowDialog();
        }

        string _videoXmlPath = "";
        string _tempInfoXmlPath = "";
        string _templateXmlPath = "";
        string _updateDataXml = "";


        Dictionary<string, string> dicTemplates = new Dictionary<string, string>();
        Dictionary<string, string> dicTemplateData = new Dictionary<string, string>();
        //EditForm frmInput = null;

        HDCGControler.CasparCG cgServer = null;
        bool isRunning = false;
        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                isRunning = true;

                this.btnStart.Enabled = false;
                cboFormat.EditValue = AppSetting.Default.Format;
                cboFormat.Caption = AppSetting.Default.Format;

                cboVideoLayer.SelectedIndex = 0;
                cboTempLayer.SelectedIndex = 5;
                cboTemplateType.SelectedIndex = 0;

                _videoXmlPath = Path.Combine(Application.StartupPath, "Video.xml");
                try
                {
                    if (File.Exists(_videoXmlPath))
                    {
                        var lstVideo = Utils.GetObject<List<Object.Video>>(_videoXmlPath);
                        foreach (var video in lstVideo)
                            videoBindingSource.Add(new View.Video()
                            {
                                VideoObj = video
                            });
                    }
                    else
                    {
                        File.Create(_videoXmlPath).Dispose();
                    }
                }
                catch { }

                _updateDataXml = Path.Combine(Application.StartupPath, "UpdateData.xml");
                try
                {
                    if (File.Exists(_updateDataXml))
                    {
                        var lstData = Utils.GetObject<List<Object.tempUpdating>>(_updateDataXml);
                        foreach (var data in lstData)
                            dicTemplateData.Add(data.Name, data.Data);
                    }
                    else
                    {
                        File.Create(_updateDataXml).Dispose();
                    }
                }
                catch { }

                cgServer = new HDCGControler.CasparCG();
                cgServer.Connect(AppSetting.Default.CGServerIP, AppSetting.Default.CGServerPort);

                this.WindowState = FormWindowState.Maximized;
                for (int i = 0; i < gvTempInfo.DataRowCount; i++)
                {
                    var tempOther = gvTempInfo.GetRow(i) as View.tempInfo;
                    tempOther.tempObj.Status = "Waiting";
                    gvTempInfo.RefreshData();
                }
            }
            catch (Exception ex)
            {
                HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tServer_Tick(object sender, EventArgs e)
        {
            if (cgServer != null && cgServer.Caspar.IsConnected)
            {
                if (lbCGServerStatus.Caption != "Connected")
                {
                    lbCGServerStatus.Caption = "Connected";
                    lbCGServerStatus.Appearance.BackColor = lbServer.Appearance.BackColor;
                    lbCGServerStatus.Appearance.Options.UseBackColor = false;
                }
            }
            else
            {
                if (lbCGServerStatus.Caption != "Disconnected")
                {
                    lbCGServerStatus.Caption = "Disconnected";
                    lbCGServerStatus.Appearance.BackColor = Color.Red;
                    lbCGServerStatus.Appearance.Options.UseBackColor = true;
                }
            }
        }

        private void cboFormat_EditValueChanged(object sender, EventArgs e)
        {
            cboFormat.Caption = cboFormat.EditValue as string;

            AppSetting.Default.Format = cboFormat.EditValue as string;
            AppSetting.Default.Save();
        }

        private void btnBrowseVideo_Click(object sender, EventArgs e)
        {
            OpenFileInFolderDialog frm = new OpenFileInFolderDialog();
            frm.RootFolder = AppSetting.Default.VideoFolder;
            frm.FilterString = "*.mov;*.flv;*.avi;*.mp4;*.wmv;*.mpg;*.tga;*.png;*.jpg";
            if (frm.ShowDialog() == DialogResult.OK)
                txtVideo.Text = frm.FileName;
        }

        private void btnVideoAdd_Click(object sender, EventArgs e)
        {
            if (cboVideoLayer.SelectedIndex < 0)
                HDMessageBox.Show("Please selected one layer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtVideo.Text == "")
                HDMessageBox.Show("Please browse one file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                videoBindingSource.List.Add(new View.Video()
                {
                    VideoObj = new Object.Video()
                    {
                        Layer = int.Parse(cboVideoLayer.Text),
                        VideoPath = txtVideo.Text,
                        Loop = ckVideoLoop.Checked
                    }
                });

                (videoBindingSource.List as BindingList<View.Video>).Select(v => v.VideoObj).ToList().SaveObject(_videoXmlPath);
            }
        }

        private void btnVideoRemove_Click(object sender, EventArgs e)
        {
            if (gvVideo.FocusedRowHandle < 0)
                HDMessageBox.Show("Selected file need remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                videoBindingSource.List.Remove(gvVideo.GetFocusedRow());

                (videoBindingSource.List as BindingList<View.Video>).Select(v => v.VideoObj).ToList().SaveObject(_videoXmlPath);
            }
        }

        private void btnVideoSave_Click(object sender, EventArgs e)
        {
            if (gvVideo.FocusedRowHandle < 0)
                HDMessageBox.Show("Selected file need override!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (cboVideoLayer.SelectedIndex < 0)
                HDMessageBox.Show("Selected layer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtVideo.Text == "")
                HDMessageBox.Show("Browse one file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                var videoView = gvVideo.GetFocusedRow() as View.Video;

                videoView.VideoObj.Layer = int.Parse(cboVideoLayer.Text);
                videoView.VideoObj.VideoPath = txtVideo.Text;
                videoView.VideoObj.Loop = ckVideoLoop.Checked;

                grdVideo.RefreshDataSource();

                (videoBindingSource.List as BindingList<View.Video>).Select(v => v.VideoObj).ToList().SaveObject(_videoXmlPath);
            }
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRunning = false;
            Application.Exit();
        }

        private void gvVideo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gvVideo.FocusedRowHandle >= 0)
            {
                var videoView = gvVideo.GetFocusedRow() as View.Video;

                cboVideoLayer.Text = videoView.VideoObj.Layer.ToString();
                txtVideo.Text = videoView.VideoObj.VideoPath;
                ckVideoLoop.Checked = videoView.VideoObj.Loop;
            }
        }

        public string UpdateTemplate(EditForm frmInput, string templateFileName, int fadeUpDuration = 0)
        {
            string templateFile = "HDTemplates\\Update\\" + templateFileName;
            var lstData = Utils.GetObject<List<Object.tempUpdating>>(_updateDataXml);
            dicTemplateData.Clear();
            foreach (var data in lstData)
                dicTemplateData.Add(data.Name, data.Data);
            try
            {
                int nTry = 0;

                TryHere:

                if (frmInput.player.Add(1, templateFile))
                {
                    if (dicTemplateData.ContainsKey("HDTemplates\\" + templateFileName))
                        frmInput.player.Update(1, dicTemplateData["HDTemplates\\" + templateFileName]);
                    frmInput.player.Refresh();
                    frmInput.player.InvokeMethod(1, "fadeUp");

                    frmInput.Show();
                    frmInput.Activate();
                }
                else
                {
                    nTry++;
                    if (nTry < 1)
                    {
                        frmInput.Clear();
                        goto TryHere;
                    }
                    throw new Exception("Can not cue graphics!");
                }

            }
            catch
            {
                HDMessageBox.Show("Can't edit this template!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return templateFile;
        }

        string cgParameter = "";
        private void OnTemplate(int layer, string templateFileName, int fadeUpDuration = 3, List<Object.Property> DesignProperties = null,
        List<Object.Property> RuntimeProperties = null)
        {
            string templateFile = templateFileName;
            if (templateFileName != "PlayVideo")
                templateFile = "HDTemplates\\" + templateFileName;

            #region Parameter
            if ((DesignProperties != null && DesignProperties.Count > 0) || (RuntimeProperties != null && RuntimeProperties.Count > 0))
            {
                CasparCGDataCollection cgData = new CasparCGDataCollection();
                cgData.Clear();

                if (DesignProperties != null)
                    foreach (var property in DesignProperties)
                        cgData.SetData(property.Name, property.Value);

                if (RuntimeProperties != null)
                    foreach (var property in RuntimeProperties)
                        cgData.SetData(property.Name, property.Value);

                cgParameter = cgData.ToAMCPEscapedXml();
            }
            #endregion
            if (!cgServer.Connect())
                HDMessageBox.Show("Not connect to cg server!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (!cgServer.LoadCG(templateFile, layer))
                {
                    HDMessageBox.Show("Can't load cg template", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cgParameter != "")
                {
                    if (!cgServer.SetParameters(layer, cgParameter))
                    {
                        HDMessageBox.Show("Can't send parameter to cg server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                bool upOK = false;
                var tempInfoView = gvTempInfo.GetFocusedRow() as View.tempInfo;
                isPlaying = true;

                try
                {
                    //Đảm bảo data được update mới nhất
                    var lstData = Utils.GetObject<List<Object.tempUpdating>>(_updateDataXml);
                    dicTemplateData.Clear();
                    foreach (var data in lstData)
                        dicTemplateData.Add(data.Name, data.Data);

                    if (dicTemplateData.ContainsKey(templateFile))
                    {
                        upOK = cgServer.FadeUp(layer, fadeUpDuration, dicTemplateData[templateFile].Replace("\\", "\\\\"));
                    }
                    else
                        upOK = cgServer.CutUp(layer);
                }
                catch (Exception ex)
                {
                    HDMessageBox.Show("Không thể lấy thông tin update! - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                System.Threading.Timer timer = null;
                if (tempInfoView.tempObj.Duration > 0)
                {
                    timer = new System.Threading.Timer((obj) =>
                    {
                        OffTemplate(tempInfoView.tempObj.Layer);
                        timer.Dispose();
                    },
                null, tempInfoView.tempObj.Delay + tempInfoView.tempObj.Duration, Timeout.Infinite);

                }
            }
        }
        bool isUpdated = false;
        private void UpdateTemplate(int layer, string cgParameter)
        {
            try
            {
                if (!cgServer.Connect())
                    MessageBox.Show("Disconnect to cg server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (cgParameter != "")
                    {
                        if (!cgServer.SetParameters(layer, cgParameter, 1))
                            throw new Exception("Can't update cg server");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update cg error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DownTemplate(int layer, int fadeDownDuration = 0)
        {
            try
            {
                if (!cgServer.Connect())
                    MessageBox.Show("Disconnect to cg server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    bool downOK = false;
                    if (fadeDownDuration > 0)
                        downOK = cgServer.FadeDown(layer, fadeDownDuration);
                    else
                        downOK = cgServer.CutDown(layer);

                    if (!downOK)
                        throw new Exception("Can't down cg");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Down cg error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OffTemplate(int layer)
        {
            try
            {
                if (!cgServer.Connect())
                    MessageBox.Show("Disconnect to cg serer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    var tempInfoView = gvTempInfo.GetFocusedRow() as View.tempInfo;
                    tempInfoView.tempObj.Status = "Stopped";
                    gvTempInfo.RefreshData();

                    if (!cgServer.UnLoadCG(layer))
                        MessageBox.Show("Can't off cg", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Off cg error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOnVideo_Click(object sender, EventArgs e)
        {
            if (cboVideoLayer.SelectedIndex < 0)
                HDMessageBox.Show("Please select one layer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtVideo.Text == "")
                HDMessageBox.Show("Please select file to play", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                CasparCGDataCollection cgData = new CasparCGDataCollection();
                List<Object.Property> runtimeProperties = new List<Object.Property>();
                runtimeProperties.Add(new Object.Property()
                {
                    Name = "VideoPath",
                    Value = txtVideo.Text
                });

                runtimeProperties.Add(new Object.Property()
                {
                    Name = "Loops",
                    Value = ckVideoLoop.Checked ? "true" : "false"
                });

                OnTemplate(int.Parse(cboVideoLayer.Text), "PlayVideo", 0, null, runtimeProperties);
            }
        }

        private void btnOffVideo_Click(object sender, EventArgs e)
        {
            if (cboVideoLayer.SelectedIndex < 0)
                HDMessageBox.Show("Please select one layer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                OffTemplate(int.Parse(cboVideoLayer.Text));
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cgServer.Connect())
                    HDMessageBox.Show("Not connect to cg server!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    for (int i = 0; i < gvTempInfo.DataRowCount; i++)
                    {
                        var tempOther = gvTempInfo.GetRow(i) as View.tempInfo;
                        if (tempOther.tempObj.Status == "Playing")
                            tempOther.tempObj.Status = "Waiting";

                    }
                    var tempInfoView = gvTempInfo.GetFocusedRow() as View.tempInfo;
                    tempInfoView.tempObj.Status = "Playing";
                    gvTempInfo.RefreshData();

                    List<Object.Property> runtimeProperties = new List<Object.Property>();
                    runtimeProperties.Add(new Object.Property()
                    {
                        Name = "Loops",
                        Value = "false"
                    });
                    tempName = getTemplateName(tempInfoView.tempObj.TemplateName.ToString());
                    System.Threading.Timer timer = null;
                    timer = new System.Threading.Timer((obj) =>
                        {
                            OnTemplate(tempInfoView.tempObj.Layer, tempName, 1, null, runtimeProperties);
                            timer.Dispose();
                        },
                    null, tempInfoView.tempObj.Delay, Timeout.Infinite);
                }
            }
            catch
            {
                HDMessageBox.Show("Please add a Template!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                var tempInfoView = gvTempInfo.GetFocusedRow() as View.tempInfo;
                OffTemplate(tempInfoView.tempObj.Layer);
            }
            catch
            {
                HDMessageBox.Show("404 - Template not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        string tempName = "";
        private void btnEditTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                var tempInfoView = gvTempInfo.GetFocusedRow() as View.tempInfo;
                var templateName = "HDTemplates\\" + getTemplateName(tempInfoView.tempObj.TemplateName.ToString());
                var frmInput = new EditForm(templateName);

                frmInput.LoadTemplateHost(Path.Combine(AppSetting.Default.TemplateFolder, "cg20.fth.1080i5000"));

                isUpdated = true;

                tempName = getTemplateName(tempInfoView.tempObj.TemplateName.ToString());

                UpdateTemplate(frmInput, tempName, tempInfoView.tempObj.Layer);

            }
            catch
            {
                HDMessageBox.Show("404 NOT FOUND", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboTempLayer.SelectedIndex < 0)
                    HDMessageBox.Show("Please selected one layer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    tempInfoBindingSource.List.Add(new View.tempInfo()
                    {
                        tempObj = new Object.tempInfo()
                        {
                            Layer = int.Parse(cboTempLayer.Text),
                            TemplateName = listBoxTemplates.SelectedValue.ToString(),
                            Duration = int.Parse(numericUpDown1.Text),
                            Delay = int.Parse(numericUpDown2.Text),
                            Status = "Waiting"
                        }
                    });

                    (tempInfoBindingSource.List as BindingList<View.tempInfo>).Select(v => v.tempObj).ToList().SaveObject(_tempInfoXmlPath);
                }
            }
            catch
            {
                HDMessageBox.Show("Please select a Template!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnRemoveTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvTempInfo.FocusedRowHandle < 0)
                    HDMessageBox.Show("404 - Not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    tempInfoBindingSource.List.Remove(gvTempInfo.GetFocusedRow());

                    (tempInfoBindingSource.List as BindingList<View.tempInfo>).Select(v => v.tempObj).ToList().SaveObject(_tempInfoXmlPath);
                }
            }
            catch { }
        }
        private string getTemplateName(string templateName)
        {
            try
            {
                return dicTemplates[templateName];
            }
            catch { return ""; }
        }
        private void gvTempInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gvTempInfo.FocusedRowHandle >= 0)
            {
                var tempInfoView = gvTempInfo.GetFocusedRow() as View.tempInfo;
                tempName = getTemplateName(tempInfoView.tempObj.TemplateName.ToString());

            }
        }
        bool autoPlay = false;
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cgServer.Connect())
                    HDMessageBox.Show("Not connect to cg server!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    isUpdated = true;
                    isPlaying = true;
                    for (int i = 0; i < gvTempInfo.DataRowCount; i++)
                    {
                        var tempOther = gvTempInfo.GetRow(i) as View.tempInfo;
                        if (tempOther.tempObj.Status == "Playing")
                            tempOther.tempObj.Status = "Waiting";

                    }
                    var tempInfoView = gvTempInfo.GetFocusedRow() as View.tempInfo;
                    tempInfoView.tempObj.Status = "Playing";
                    gvTempInfo.RefreshData();
                    CasparCGDataCollection cgData = new CasparCGDataCollection();
                    List<Object.Property> runtimeProperties = new List<Object.Property>();
                    tempName = getTemplateName(tempInfoView.tempObj.TemplateName.ToString());
                    System.Threading.Timer timer = null;
                    timer = new System.Threading.Timer((obj) =>
                    {
                        OnTemplate(tempInfoView.tempObj.Layer, tempName, 1, null, runtimeProperties);
                    },
                    null, tempInfoView.tempObj.Delay, System.Threading.Timeout.Infinite);
                }
            }
            catch
            {
                HDMessageBox.Show("404 - Not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gvTempInfo.DataRowCount; i++)
            {
                var tempOther = gvTempInfo.GetRow(i) as View.tempInfo;
                tempOther.tempObj.Status = "Waiting";
                gvTempInfo.RefreshData();
            }
            if (this.cbAutoMode.Checked)
            {
                this.btnStart.Enabled = true;
                autoPlay = true;
                this.btnEditTemplate.Enabled = false;
                this.btnPlay.Enabled = false;
                this.btnStop.Enabled = false;
            }
            else
            {
                this.btnStart.Enabled = false;
                autoPlay = false;
                this.btnEditTemplate.Enabled = true;
                this.btnPlay.Enabled = true;
                this.btnStop.Enabled = true;
            }
        }

        private void gridTempInfo_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            if (gvTempInfo.FocusedRowHandle >= 0)
            {

                var tempInfoView = gvTempInfo.GetFocusedRow() as View.tempInfo;

                tempName = getTemplateName(tempInfoView.tempObj.TemplateName.ToString());
            }
        }
        bool isPlaying = false;
        private void setStatus(string status)
        {
            var tempInfoView = gvTempInfo.GetFocusedRow() as View.tempInfo;
            tempInfoView.tempObj.Status = status;
            gvTempInfo.RefreshData();
        }

        public bool GetIsRunning()
        {
            return isRunning;
        }

        private string Add(string xmlStr, string id, string val)
        {
            xmlStr = "<" + id + " id=\"" + id + "\"><data value=\"" + val + "\"/></" + id + ">";
            return xmlStr;
        }
        private String PrintXML(String XML)
        {
            String Result = "";

            MemoryStream mStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
            XmlDocument document = new XmlDocument();

            try
            {
                // Load the XmlDocument with the XML.
                document.LoadXml(XML);

                writer.Formatting = Formatting.Indented;

                // Write the XML into a formatting XmlTextWriter
                document.WriteContentTo(writer);
                writer.Flush();
                mStream.Flush();

                // Have to rewind the MemoryStream in order to read
                // its contents.
                mStream.Position = 0;

                // Read MemoryStream contents into a StreamReader.
                StreamReader sReader = new StreamReader(mStream);

                // Extract the text from the StreamReader.
                String FormattedXML = sReader.ReadToEnd();

                Result = FormattedXML;
            }
            catch (XmlException)
            {
            }

            mStream.Close();
            writer.Close();

            return Result;
        }

        private void barBtnManageTemplate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ManageTemplateForm mTemp = new ManageTemplateForm(cboTemplateType.Text);
            mTemp.Show();
            mTemp.Activate();
        }

        private void cboTemplateType_SelectedValueChanged(object sender, EventArgs e)
        {
            dicTemplates.Clear();
            listBoxTemplates.Items.Clear();
            var xmlTemplate = "template_" + Utils.ConvertToVietnameseNonSign(cboTemplateType.Text).Replace(" ", "").ToLower() + "_list.xml";
            var xmlPlaylist = "playlist_" + Utils.ConvertToVietnameseNonSign(cboTemplateType.Text).Replace(" ", "").ToLower() + "_list.xml";
            _templateXmlPath = Path.Combine(Application.StartupPath, xmlTemplate);
            _tempInfoXmlPath = Path.Combine(Application.StartupPath, xmlPlaylist);

            try
            {
                if (File.Exists(_templateXmlPath))
                {
                    var lstTemplate = Utils.GetObject<List<Object.Template>>(_templateXmlPath).OrderBy(a => a.Name);
                    foreach (var temp in lstTemplate)
                    {
                        dicTemplates.Add(temp.Name, temp.FileName);
                        listBoxTemplates.Items.Add(temp.Name);
                    }
                }
                else
                {
                    File.Create(_templateXmlPath).Dispose();
                }
            }
            catch (Exception ex)
            {
                HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tempInfoBindingSource.List.Clear();
            try
            {
                if (File.Exists(_tempInfoXmlPath))
                {
                    var lstBarMC = Utils.GetObject<List<Object.tempInfo>>(_tempInfoXmlPath);
                    foreach (var barMC in lstBarMC)
                        tempInfoBindingSource.List.Add(new View.tempInfo()
                        {
                            tempObj = barMC
                        });
                }
                else
                {
                    File.Create(_tempInfoXmlPath).Dispose();
                }
            }
            catch (Exception ex)
            {
                HDMessageBox.Show(ex.Message, "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}