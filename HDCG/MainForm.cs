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
using DevExpress.XtraGrid.Views.Grid;
using System.Management;
using System.Diagnostics;

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
            frm.lbSoftware.Text = "HDCG Studio 3.2.0";
            frm.ShowDialog();
        }

        string _videoXmlPath = "";
        string _tempInfoXmlPath = "";
        string _templateXmlPath = "";
        string _updateDataXml = "";
        string _TemplateHost = "";
        string _danhsachgiaidauXmlPath = "";
        List<Object.League> _lstLeagues = new List<Object.League>();
        List<Object.Team> _lstTeams = new List<Object.Team>();
        Dictionary<string, string> dicTemplates = new Dictionary<string, string>();
        Dictionary<string, string> dicTemplateData = new Dictionary<string, string>();
        Dictionary<string, string> dicDanhsachcauthuHome = new Dictionary<string, string>();
        Dictionary<string, string> dicDanhsachcauthuAway = new Dictionary<string, string>();

        HDCGControler.CasparCG cgServer = null;
        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                cboFormat.EditValue = AppSetting.Default.Format;
                cboFormat.Caption = AppSetting.Default.Format;

                cboVideoLayer.SelectedIndex = 0;
                cboTempLayer.SelectedIndex = 5;
                cboTemplateType.SelectedIndex = 0;
                cboGiaiDau.SelectedIndex = 0;

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

                //Load danh sách giải đấu
                _danhsachgiaidauXmlPath = Path.Combine(Application.StartupPath, "Danhsachgiaidau.xml");
                try
                {
                    if (File.Exists(_danhsachgiaidauXmlPath))
                    {
                        _lstLeagues = Utils.GetObject<List<Object.League>>(_danhsachgiaidauXmlPath);
                        foreach (var temp in _lstLeagues)
                            cboGiaiDau.Properties.Items.Add(temp.Name);
                    }
                    else
                    {
                        File.Create(_danhsachgiaidauXmlPath).Dispose();
                    }
                }
                catch (Exception ex)
                {
                    HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                cgServer = new HDCGControler.CasparCG();
                cgServer.Connect(AppSetting.Default.CGServerIP, AppSetting.Default.CGServerPort);

                this.WindowState = FormWindowState.Maximized;
                LoadTemplateHost(Path.Combine(AppSetting.Default.TemplateFolder, "cg20.fth.1080i5000"));
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
            frm.RootFolder = AppSetting.Default.MediaFolder;
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

        public string ViewTemplate(string templateFileName, int fadeUpDuration = 0)
        {
            string templateFile = "HDTemplates\\" + templateFileName;

            try
            {
                int nTry = 0;

                TryHere:
                Clear();
                if (player.Add(1, templateFile))
                {
                    string xmlStr = "<Track_Property>" + GetAddXmlString() + "</Track_Property>";
                    UpdateDataFile(xmlStr);

                    player.Update(1, xmlStr.Replace("\\n", "\n"));
                    player.Refresh();
                    player.InvokeMethod(1, "fadeUp");
                }
                else
                {
                    nTry++;
                    if (nTry < 1)
                    {
                        Clear();
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
        public string UpdateTemplate(PreviewForm frmInput, string templateFileName, int fadeUpDuration = 0)
        {
            string templateFile = "HDTemplates\\" + templateFileName;
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
                        frmInput.player.Update(1, dicTemplateData["HDTemplates\\" + templateFileName].Replace("\\n", "\n"));
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

                try
                {
                    string xmlStr = "<Track_Property>" + GetAddXmlString() + "</Track_Property>";
                    if (templateFile == "HDTemplates\\ThongBao_ThongBaoChung.ft")
                    {
                        upOK = cgServer.FadeUp(layer, fadeUpDuration, xmlStr.Replace("\\n", "\n"));
                    }
                    else
                        upOK = cgServer.FadeUp(layer, fadeUpDuration, xmlStr.Replace("\\", "\\\\"));

                }
                catch (Exception ex)
                {
                    HDMessageBox.Show("Không thể lấy thông tin update! - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                var tempInfoView = gvTempInfo.GetFocusedRow() as View.tempInfo;

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
                    if (!cgServer.CutDown(layer))
                        //if (!cgServer.UnLoadCG(layer))
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
                    List<Object.Property> runtimeProperties = new List<Object.Property>();
                    runtimeProperties.Add(new Object.Property()
                    {
                        Name = "Loops",
                        Value = "false"
                    });
                    System.Threading.Timer timer = null;
                    timer = new System.Threading.Timer((obj) =>
                        {
                            OnTemplate(_layer, _tempName, 1, null, runtimeProperties);
                            timer.Dispose();
                        },
                    null, _delay, Timeout.Infinite);
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

        string _tempName = "";
        int _layer = 0;
        int _delay = 0;
        int _duration = 0;
        private void btnPreviewTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                var templateName = "HDTemplates\\" + GetTemplateName(_tempName);
                var frmInput = new PreviewForm(templateName);

                frmInput.LoadTemplateHost(Path.Combine(AppSetting.Default.TemplateFolder, "cg20.fth.1080i5000"));

                UpdateTemplate(frmInput, _tempName);

            }
            catch (Exception ex)
            {
                HDMessageBox.Show("404 NOT FOUND: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gvTempInfo_RowClick(object sender, RowClickEventArgs e)
        {
            if (cboGiaiDau.Text.Length > 0 && cboDoiChuNha.Text.Length > 0 && cboDoiKhach.Text.Length > 0)
                ViewTemplate(_tempName);
            else
                HDMessageBox.Show("Bạn chưa chọn thông tin Giải đấu, Đội chủ/khách!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            var temp = gvTempInfo.GetFocusedRow() as View.tempInfo;
            cboTempLayer.Text = temp.tempObj.Layer.ToString();
            nDelayTime.Value = temp.tempObj.Delay;
            nDurationTime.Value = temp.tempObj.Duration;
        }
        private void gvTempInfo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvTempInfo.FocusedRowHandle >= 0)
            {
                var tempInfoView = gvTempInfo.GetFocusedRow() as View.tempInfo;
                _tempName = GetTemplateName(tempInfoView.tempObj.TemplateName.ToString());
                _layer = tempInfoView.tempObj.Layer;
                _delay = tempInfoView.tempObj.Delay;
                _duration = tempInfoView.tempObj.Duration;
            }
        }
        private string Add(string xmlStr, string id, string val)
        {
            xmlStr = "<" + id + " id=\"" + id + "\"><data value=\"" + val + "\"/></" + id + ">";
            return xmlStr;
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

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnPreviewTemplate.PerformClick();
            }
            else if (e.KeyCode == Keys.Space)
            {
                btnPlay.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnStop.PerformClick();
            }
        }

        private void gridTempInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnPreviewTemplate.PerformClick();
            }
            else if (e.KeyCode == Keys.Space)
            {
                btnPlay.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnStop.PerformClick();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!Debugger.IsAttached)
            {
                LogProcess.AddLog("Kích hoạt phần mềm");

                Process currentProcess = Process.GetCurrentProcess();
                string currentProcessName = currentProcess.ProcessName;

                string cpuId = CryptorEngine.GetCPUID() + "_" + currentProcessName;
                string keyId = CryptorEngine.GetMD5String(CryptorEngine.GetMD5String(cpuId));

                string licenseFile = Path.Combine(Application.StartupPath, "license.hd");

                CheckActive:
                string license = "";
                if (File.Exists(licenseFile))
                {
                    try
                    {
                        StreamReader read = new StreamReader(licenseFile);
                        license = read.ReadLine();
                        read.Close();
                    }
                    catch { }
                }
                else
                {
                    File.Create(licenseFile).Dispose();
                }

                if (keyId != license)
                {
                    LogProcess.AddLog("Chưa kích hoạt");

                    if (XtraMessageBox.Show("Phần mềm chưa được kích hoạt!\nBạn có muốn kích hoạt ngay bây giờ?",
                        "Kích hoạt phần mềm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                    {
                        LogProcess.AddLog("Không kích hoạt");
                        Process.GetCurrentProcess().Kill();
                        Application.Exit();
                        return;
                    }
                    else
                    {
                        if (new ActivateForm().ShowDialog() == DialogResult.OK)
                        {
                            goto CheckActive;
                        }
                        else
                        {
                            LogProcess.AddLog("Không kích hoạt");
                            Process.GetCurrentProcess().Kill();
                            Application.Exit();
                            return;
                        }
                    }
                }
                else
                    LogProcess.AddLog("Đã kích hoạt");
            }
        }

        private string Add(string str, string val)
        {
            return "<" + str + " id=\"" + str + "\"><data value=\"" + val + "\"/></" + str + ">";
        }
        private void btnUpdateAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (tempInfoBindingSource.List.Count == 0)
                {
                    HDMessageBox.Show("Chưa chọn template để lưu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                if (cboTempLayer.Text.Length > 0)
                {
                    var temp = gvTempInfo.GetFocusedRow() as View.tempInfo;

                    tempInfoBindingSource.List.Insert(tempInfoBindingSource.List.IndexOf(temp), new View.tempInfo()
                    {
                        tempObj = new Object.tempInfo()
                        {
                            TemplateName = temp.tempObj.TemplateName,
                            Layer = int.Parse(cboTempLayer.Text),
                            Delay = (int)nDelayTime.Value,
                            Duration = (int)nDurationTime.Value
                        }
                    });
                    tempInfoBindingSource.List.Remove(temp);
                }
                else
                {
                    HDMessageBox.Show("Chọn Layer trước!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (temp.Name == _tempName)
                        {
                            dataCount++;
                            temp.Data = data;
                            (bsUpdateData.List as BindingList<Object.tempUpdating>).ToList().SaveObject(_updateDataXml);
                        }
                    }
                    if (dataCount == 0)
                    {
                        bsUpdateData.List.Add(new Object.tempUpdating()
                        {
                            Name = _tempName,
                            Data = data

                        });

                        (bsUpdateData.List as BindingList<Object.tempUpdating>).ToList().SaveObject(_updateDataXml);
                    }
                }
                else
                {
                    bsUpdateData.List.Add(new Object.tempUpdating()
                    {
                        Name = _tempName,
                        Data = data

                    });

                    (bsUpdateData.List as BindingList<Object.tempUpdating>).ToList().SaveObject(_updateDataXml);

                }
            }
            catch (Exception ex)
            {
                HDMessageBox.Show("UpdateDataFile lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        bool _forUpdate = false;
        private void btnLiveUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _forUpdate = true;
                string xmlStr = "<Track_Property>" + GetAddXmlString() + "</Track_Property>";
                player.Update(1, xmlStr.Replace("\\n", "\n"));
                player.Refresh();
                cgServer.UpdateTemplate(_layer, xmlStr, 0);
                _forUpdate = false;
            }
            catch (Exception ex)
            {
                HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Các hàm get thông tin template
        public View.Player GetPlayingPlayer()
        {
            var player = new View.Player();
            if (ckChu.Checked)
            {
                player = gvHomePlayer.GetFocusedRow() as View.Player;
            }
            else if (ckKhach.Checked)
            {
                player = gvAwayPlayer.GetFocusedRow() as View.Player;
            }
            return player;
        }
        public string GetTeamName()
        {
            var teamName = "";
            if (ckChu.Checked)
            {
                teamName = cboDoiChuNha.Text;
            }
            else if (ckKhach.Checked)
            {
                teamName = cboDoiKhach.Text;
            }
            return teamName;
        }
        public string GetTeamLogo(string teamName, bool logoNho = true)
        {
            string logoPath = "";
            foreach (var temp in _lstTeams)
            {
                if (temp.Name == teamName)
                {
                    if (logoNho)
                        logoPath = temp.LogoPath;
                    else
                        logoPath = temp.LogoPath.Replace(".png", "_to.png");
                    break;
                }
            }
            return logoPath;
        }
        private string GetTemplateName(string templateName)
        {
            try
            {
                return dicTemplates[templateName];
            }
            catch { return ""; }
        }
        public List<View.Player> GetTeamChinhThuc()
        {
            var lstChinhthuc = new List<View.Player>();
            if (ckChu.Checked)
                lstChinhthuc = (bsHomePlayer.List as BindingList<View.Player>).OrderBy(a => a.mObj.Number).ToList();
            else if (ckKhach.Checked)
                lstChinhthuc = (bsAwayPlayer.List as BindingList<View.Player>).OrderBy(a => a.mObj.Number).ToList();
            return lstChinhthuc;
        }
        public List<View.Player> GetTeamDuBi()
        {
            var lstChinhthuc = new List<View.Player>();
            if (ckChu.Checked)
                lstChinhthuc = (bsHomePlayerDuBi.List as BindingList<View.Player>).OrderBy(a => a.mObj.Number).ToList();
            else if (ckKhach.Checked)
                lstChinhthuc = (bsAwayPlayerDuBi.List as BindingList<View.Player>).OrderBy(a => a.mObj.Number).ToList();
            return lstChinhthuc;
        }
        public string GetPlayerName(string playerStr)
        {
            return playerStr.Substring(playerStr.IndexOf("-") + 1).Trim();
        }
        public string GetPlayerNumber(string playerStr)
        {
            return playerStr.Substring(0, playerStr.IndexOf("-")).Trim();
        }
        #region Get cầu thủ vào sân, ra sân
        public View.Player GetPlayerOut()
        {
            var player = new View.Player();
            if (ckChu.Checked)
            {
                player = gvHomePlayer.GetFocusedRow() as View.Player;
            }
            else if (ckKhach.Checked)
            {
                player = gvAwayPlayer.GetFocusedRow() as View.Player;
            }
            return player;
        }
        public View.Player GetPlayerIn()
        {
            var player = new View.Player();
            if (ckChu.Checked)
            {
                player = gvHomePlayerDuBi.GetFocusedRow() as View.Player;
            }
            else if (ckKhach.Checked)
            {
                player = gvAwayPlayerDuBi.GetFocusedRow() as View.Player;
            }
            return player;
        }
        #endregion
        public string GetAddXmlString()
        {
            var xmlAdd = "";
            if (xTabMain.SelectedTabPage.Equals(xTabPageBongda))
            {
                try
                {
                    xmlAdd += Add("doibong", GetTeamName());
                    xmlAdd += Add("hiepdau", "Hiệp " + txtHiep.Text);
                    xmlAdd += Add("player1", GetPlayingPlayer().mObj.Name);
                    xmlAdd += Add("playerNumber1", GetPlayingPlayer().mObj.Number.ToString());
                    if (_tempName == "BongDa_CauThu.ft")
                    {
                        xmlAdd += Add("playerStr", GetPlayingPlayer().mObj.Number.ToString() + ". " + GetPlayingPlayer().mObj.Name);
                    }

                    xmlAdd += Add("trongtaichinh", txtTrongtaiChinh.Text);
                    xmlAdd += Add("troly1", txtTroly1.Text);
                    xmlAdd += Add("troly2", txtTroly2.Text);
                    xmlAdd += Add("trongtaiban", txtTrongtaiban.Text);

                    xmlAdd += Add("blv", txtBLV.Text);
                    xmlAdd += Add("stadium", txtStadium.Text);
                    xmlAdd += Add("thoitiet", txtThoiTiet.Text);
                    xmlAdd += Add("nhietdo", txtNhietdo.Text);
                    xmlAdd += Add("sucgio", txtSucgio.Text);
                    xmlAdd += Add("blv", txtBLV.Text);
                    xmlAdd += Add("pv", txtPV.Text);
                    xmlAdd += Add("donviPV", txtDonviPV.Text);

                    xmlAdd += Add("playerin", GetPlayerIn().mObj.Name);
                    xmlAdd += Add("playerout", GetPlayerOut().mObj.Name);
                    xmlAdd += Add("playerInNumber", GetPlayerIn().mObj.Number.ToString());
                    xmlAdd += Add("playerOutNumber", GetPlayerOut().mObj.Number.ToString());
                    xmlAdd += Add("dongho", lbThoigianTran.Text);
                    if (_tempName == "BongDa_ThongKeNho.ft")
                    {
                        xmlAdd += Add("icon1", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons"), GetTeamLogo(cboDoiChuNha.Text)));
                        xmlAdd += Add("icon2", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons"), GetTeamLogo(cboDoiKhach.Text)));
                    }
                    else if (_tempName == "BongDa_ThongKeCuoi.ft" || _tempName == "BongDa_TySoChinh.ft")
                    {
                        xmlAdd += Add("icon1", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons"), GetTeamLogo(cboDoiChuNha.Text, false)));
                        xmlAdd += Add("icon2", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons"), GetTeamLogo(cboDoiKhach.Text, false)));
                    }
                    else
                    {
                        if (ckChu.Checked)
                        {
                            if (_tempName == "BongDa_DanhSachCauThu.ft")
                            {
                                xmlAdd += Add("icon1", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons"), GetTeamLogo(cboDoiChuNha.Text, false)));
                            }
                            else
                                xmlAdd += Add("icon1", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons"), GetTeamLogo(cboDoiChuNha.Text)));
                        }
                        else if (ckKhach.Checked)
                        {
                            if (_tempName == "BongDa_DanhSachCauThu.ft")
                            {
                                xmlAdd += Add("icon1", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons"), GetTeamLogo(cboDoiKhach.Text, false)));
                            }
                            else
                                xmlAdd += Add("icon1", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons"), GetTeamLogo(cboDoiKhach.Text)));
                        }
                    }
                    if (ckChu.Checked)
                    {
                        xmlAdd += Add("hlv", txtHomeCoach.Text);
                        if (!_forUpdate)
                        {
                            //xmlAdd += Add("icon1", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons"), GetTeamLogo(cboDoiChuNha.Text)));
                            //xmlAdd += Add("image", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "DoiHinh"), txtMauAoChu.Text));
                        }
                        xmlAdd += Add("thongsocauthu", txtThongsocauthuChu.Text);
                        if (ckKhach.Checked)
                        {
                            xmlAdd += Add("hlv", txtAwayCoach.Text);
                            if (!_forUpdate)
                            {
                                //xmlAdd += Add("icon1", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons"), GetTeamLogo(cboDoiKhach.Text)));
                                //xmlAdd += Add("image", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "DoiHinh"), txtMauAoKhach.Text));
                            }
                            xmlAdd += Add("thongsocauthu", txtThongsocauthuKhach.Text);

                        }
                        xmlAdd += Add("doiChu", cboDoiChuNha.Text);
                        xmlAdd += Add("doiKhach", cboDoiKhach.Text);
                        xmlAdd += Add("tyso", nTysoChu.Value.ToString() + " - " + nTysoKhach.Value.ToString());
                        var lstChinhthuc = GetTeamChinhThuc();
                        if (lstChinhthuc.Count > 0)
                            for (var i = 0; i < lstChinhthuc.Count(); i++)
                            {
                                xmlAdd += Add("chinhthucName" + (i + 1).ToString(), lstChinhthuc[i].mObj.Name);
                                xmlAdd += Add("chinhthucNumber" + (i + 1).ToString(), lstChinhthuc[i].mObj.Number.ToString());
                            }
                        var lstDuBi = GetTeamDuBi();
                        if (lstDuBi.Count > 0)
                            for (var i = 0; i < lstDuBi.Count(); i++)
                            {
                                xmlAdd += Add("dubiName" + (i + 1).ToString(), lstDuBi[i].mObj.Name);
                                xmlAdd += Add("dubiNumber" + (i + 1).ToString(), lstDuBi[i].mObj.Number.ToString());
                            }
                        //Danh sách ghi bàn
                        if (bsGhibanChu.List.Count > 0)
                        {
                            for (var i = 0; i < bsGhibanChu.List.Count; i++)
                            {
                                var temp = gvGhibanChu.GetRow(i) as View.Goal;
                                xmlAdd += Add("ghibanChu" + (i + 1).ToString(), temp.gObj.Name + "     " + temp.gObj.StrMin);
                            }
                        }
                        if (bsGhibanKhach.List.Count > 0)
                        {
                            for (var i = 0; i < bsGhibanKhach.List.Count; i++)
                            {
                                var temp = gvGhibanKhach.GetRow(i) as View.Goal;
                                xmlAdd += Add("ghibanKhach" + (i + 1).ToString(), temp.gObj.StrMin + "     " + temp.gObj.Name);
                            }
                        }

                        if (_tempName == "BongDa_ThongKeCuoi.ft")
                        {
                            xmlAdd += Add("dutdiemChu", nDutdiemChu.Text);
                            xmlAdd += Add("dutdiemKhach", nDutdiemKhach.Text);
                            xmlAdd += Add("trungdichChu", nTrungdichChu.Text);
                            xmlAdd += Add("trungdichKhach", nTrungdichKhach.Text);
                            xmlAdd += Add("phamloiChu", nPhamloiChu.Text);
                            xmlAdd += Add("phamloiKhach", nPhamloiKhach.Text);
                            xmlAdd += Add("thevangChu", nThevangChu.Text);
                            xmlAdd += Add("thevangKhach", nThevangKhach.Text);
                            xmlAdd += Add("thedoChu", nThedoChu.Text);
                            xmlAdd += Add("thedoKhach", nThedoKhach.Text);
                            xmlAdd += Add("vietviChu", nVietviChu.Text);
                            xmlAdd += Add("vietviKhach", nVietviKhach.Text);
                            xmlAdd += Add("phatgocChu", nPhatgocChu.Text);
                            xmlAdd += Add("phatgocKhach", nPhatgocKhach.Text);
                            xmlAdd += Add("kiemsoatbongChu", nKiemsoatbongChu.Text + "%");
                            xmlAdd += Add("kiemsoatbongKhach", nKiemsoatbongKhach.Text + "%");
                        }
                        else if (_tempName == "BongDa_ThongKeNho.ft")
                        {
                            if (ckDutdiem.Checked)
                            {
                                xmlAdd += Add("thongsonho", "Dứt điểm");
                                xmlAdd += Add("thongsonhoChu", nDutdiemChu.Text);
                                xmlAdd += Add("thongsonhoKhach", nDutdiemKhach.Text);
                            }
                            else if (ckTrungdich.Checked)
                            {
                                xmlAdd += Add("thongsonho", "Dứt điểm trúng đích");
                                xmlAdd += Add("thongsonhoChu", nTrungdichChu.Text);
                                xmlAdd += Add("thongsonhoKhach", nTrungdichKhach.Text);
                            }
                            else if (ckPhamloi.Checked)
                            {
                                xmlAdd += Add("thongsonho", "Phạm lỗi");
                                xmlAdd += Add("thongsonhoChu", nPhamloiChu.Text);
                                xmlAdd += Add("thongsonhoKhach", nPhamloiKhach.Text);
                            }
                            else if (ckThevang.Checked)
                            {
                                xmlAdd += Add("thongsonho", "Thẻ vàng");
                                xmlAdd += Add("thongsonhoChu", nThevangChu.Text);
                                xmlAdd += Add("thongsonhoKhach", nThevangKhach.Text);
                            }
                            else if (ckThedo.Checked)
                            {
                                xmlAdd += Add("thongsonho", "Thẻ đỏ");
                                xmlAdd += Add("thongsonhoChu", nThedoChu.Text);
                                xmlAdd += Add("thongsonhoKhach", nThedoKhach.Text);
                            }
                            else if (ckVietvi.Checked)
                            {
                                xmlAdd += Add("thongsonho", "Việt vị");
                                xmlAdd += Add("thongsonhoChu", nVietviChu.Text);
                                xmlAdd += Add("thongsonhoKhach", nVietviKhach.Text);
                            }
                            else if (ckPhatgoc.Checked)
                            {
                                xmlAdd += Add("thongsonho", "Phạt góc");
                                xmlAdd += Add("thongsonhoChu", nPhatgocChu.Text);
                                xmlAdd += Add("thongsonhoKhach", nPhatgocKhach.Text);
                            }
                            else if (ckKiemsoatbong.Checked)
                            {
                                xmlAdd += Add("thongsonho", "Kiếm soát bóng");
                                xmlAdd += Add("thongsonhoChu", nKiemsoatbongChu.Text + "%");
                                xmlAdd += Add("thongsonhoKhach", nKiemsoatbongKhach.Text + "%");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    if (txtPlayer1.Text.Length > 0)
                        xmlAdd += Add("player1", txtPlayer1.Text);
                    if (txtPlayer2.Text.Length > 0)
                        xmlAdd += Add("player2", txtPlayer1.Text);
                    if (txtPlayer3.Text.Length > 0)
                        xmlAdd += Add("player3", txtPlayer1.Text);
                    if (txtPlayer4.Text.Length > 0)
                        xmlAdd += Add("player4", txtPlayer4.Text);
                    xmlAdd += Add("hatgiong1", nHatgiong1.Value.ToString());
                    xmlAdd += Add("hatgiong2", nHatgiong2.Value.ToString());
                    xmlAdd += Add("player1set1point", nDiemSet1Player1.Value.ToString());
                    xmlAdd += Add("player2set1point", nDiemSet1Player2.Value.ToString());
                    xmlAdd += Add("player1set2point", nDiemSet2Player1.Value.ToString());
                    xmlAdd += Add("player2set2point", nDiemSet2Player2.Value.ToString());
                    xmlAdd += Add("player1set3point", nDiemSet3Player1.Value.ToString());
                    xmlAdd += Add("player2set3point", nDiemSet3Player2.Value.ToString());
                    xmlAdd += Add("player1livePoint", txtDiemHientaiPlayer1.Text);
                    xmlAdd += Add("player2livePoint", txtDiemHientaiPlayer2.Text);
                }
                catch (Exception ex)
                {
                    HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return xmlAdd;
        }
        #endregion       

        private void ckCauthuChu_CheckedChanged(object sender, EventArgs e)
        {
            if (ckChu.Checked)
            {
                ckKhach.Checked = false;
            }
        }

        private void ckCauthuKhach_CheckedChanged(object sender, EventArgs e)
        {
            if (ckKhach.Checked)
            {
                ckChu.Checked = false;
            }
        }

        private void btnQuanlyGiaiDau_Click(object sender, EventArgs e)
        {
            FormManageLeague frmManageLeague = new FormManageLeague();
            frmManageLeague.Show();
            frmManageLeague.Activate();
        }

        private void cboGiaiDau_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var danhsachdoiPath = Path.Combine(Application.StartupPath, "Danhsachdoi" + Utils.ConvertToVietnameseNonSign(cboGiaiDau.Text).Replace(" ", "_") + ".xml");
                try
                {
                    if (File.Exists(danhsachdoiPath))
                    {
                        _lstTeams = Utils.GetObject<List<Object.Team>>(danhsachdoiPath);
                        foreach (var data in _lstTeams)
                        {
                            cboDoiChuNha.Properties.Items.Add(data.Name);
                            cboDoiKhach.Properties.Items.Add(data.Name);
                        }
                    }
                    else
                    {
                        File.Create(danhsachdoiPath).Dispose();
                    }
                }
                catch { }
            }
            catch { }
        }

        private void btnQuanlycauthuHome_Click(object sender, EventArgs e)
        {
            if (cboGiaiDau.Text.Trim().Length == 0)
            {
                HDMessageBox.Show("Chọn giải đấu trước!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                FormManageTeam formManageTeam = new FormManageTeam(cboGiaiDau.Text);
                formManageTeam.Show();
                formManageTeam.Activate();
            }
        }

        private void btnQuanlyDangky_Click(object sender, EventArgs e)
        {
            if (cboGiaiDau.Text.Trim().Length == 0 || cboDoiChuNha.Text.Trim().Length == 0)
            {
                HDMessageBox.Show("Chọn giải đấu và đội trước!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ManagePlayersForm frmPlayer = new ManagePlayersForm(cboGiaiDau.Text, cboDoiChuNha.Text);
                frmPlayer.Show();
                frmPlayer.Activate();
            }
        }

        private void cboDoiChuNha_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var temp in _lstTeams)
            {
                if (temp.Name == cboDoiChuNha.Text)
                {
                    txtHomeShortName.Text = temp.ShortName;
                    txtHomeCoach.Text = temp.CoachName;
                    break;
                }
            }
            var templatesXmlPath = Path.Combine(Application.StartupPath, "Danhsachcauthu" + Utils.ConvertToVietnameseNonSign(cboDoiChuNha.Text).Replace(" ", "_") + ".xml");
            try
            {
                if (File.Exists(templatesXmlPath))
                {
                    bsHomePlayer.Clear();
                    bsHomePlayerDuBi.Clear();
                    cboCauthuChu.Properties.Items.Clear();
                    bsGhibanChu.Clear();
                    var lstTemplate = Utils.GetObject<List<Object.Player>>(templatesXmlPath).Where(a => a.IsNotSubstitution == true);
                    foreach (var temp in lstTemplate)
                    {
                        bsHomePlayer.Add(new View.Player()
                        {
                            mObj = temp
                        });
                        cboCauthuChu.Properties.Items.Add(temp.Name);
                    }
                    var lstDubi = Utils.GetObject<List<Object.Player>>(templatesXmlPath).Where(a => a.IsNotSubstitution == false);
                    foreach (var temp in lstDubi)
                    {
                        bsHomePlayerDuBi.Add(new View.Player()
                        {
                            mObj = temp
                        });
                        cboCauthuChu.Properties.Items.Add(temp.Name);
                    }
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

        private void cboDoiKhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var temp in _lstTeams)
            {
                if (temp.Name == cboDoiKhach.Text)
                {
                    txtAwayShortName.Text = temp.ShortName;
                    txtAwayCoach.Text = temp.CoachName;
                    break;
                }
            }
            var templatesXmlPath = Path.Combine(Application.StartupPath, "Danhsachcauthu" + Utils.ConvertToVietnameseNonSign(cboDoiKhach.Text).Replace(" ", "_") + ".xml");
            try
            {
                if (File.Exists(templatesXmlPath))
                {
                    bsAwayPlayer.Clear();
                    bsAwayPlayerDuBi.Clear();
                    cboCauthuKhach.Properties.Items.Clear();
                    bsGhibanKhach.Clear();
                    var lstTemplate = Utils.GetObject<List<Object.Player>>(templatesXmlPath).Where(a => a.IsNotSubstitution == true);
                    foreach (var temp in lstTemplate)
                    {
                        bsAwayPlayer.Add(new View.Player()
                        {
                            mObj = temp
                        });
                        cboCauthuKhach.Properties.Items.Add(temp.Name);
                    }
                    var lstDuBi = Utils.GetObject<List<Object.Player>>(templatesXmlPath).Where(a => a.IsNotSubstitution == false);
                    foreach (var temp in lstDuBi)
                    {
                        bsAwayPlayerDuBi.Add(new View.Player()
                        {
                            mObj = temp
                        });
                        cboCauthuKhach.Properties.Items.Add(temp.Name);
                    }
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

        private void btnQuanlyDangkyAway_Click(object sender, EventArgs e)
        {
            if (cboGiaiDau.Text.Trim().Length == 0 || cboDoiKhach.Text.Trim().Length == 0)
            {
                HDMessageBox.Show("Chọn giải đấu và đội trước!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ManagePlayersForm frmPlayer = new ManagePlayersForm(cboGiaiDau.Text, cboDoiKhach.Text);
                frmPlayer.Show();
                frmPlayer.Activate();
            }
        }

        #region RowCellStyle for GridView
        private void gvVideo_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Green;
                e.Appearance.ForeColor = Color.White;
            }
        }
        private void gvTempInfo_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Green;
                e.Appearance.ForeColor = Color.White;
            }
        }

        private void gvHomePlayer_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.OrangeRed;
                e.Appearance.ForeColor = Color.White;
            }
        }

        private void gvHomePlayerDuBi_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.DarkBlue;
                e.Appearance.ForeColor = Color.White;
            }
        }

        private void gvAwayPlayer_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.OrangeRed;
                e.Appearance.ForeColor = Color.White;
            }
        }

        private void gvAwayPlayerDuBi_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.DarkBlue;
                e.Appearance.ForeColor = Color.White;
            }
        }
        #endregion

        #region Xử lý phần ghi bàn
        private void btnThemGhibanChu_Click(object sender, EventArgs e)
        {
            if (cboCauthuChu.Text.Length > 0 && txtPhutGhibanChu.Text.Length > 0)
            {
                bsGhibanChu.List.Add(new View.Goal()
                {
                    gObj = new Object.Goal()
                    {
                        Name = cboCauthuChu.Text,
                        StrMin = txtPhutGhibanChu.Text
                    }
                });

            }
            else
            {
                HDMessageBox.Show("Chọn cầu thủ và phút ghi bàn trước!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemGhibanKhach_Click(object sender, EventArgs e)
        {
            if (cboCauthuKhach.Text.Length > 0 && txtPhutGhibanKhach.Text.Length > 0)
            {
                bsGhibanKhach.List.Add(new View.Goal()
                {
                    gObj = new Object.Goal()
                    {
                        Name = cboCauthuKhach.Text,
                        StrMin = txtPhutGhibanKhach.Text
                    }
                });
            }
            else
            {
                HDMessageBox.Show("Chọn cầu thủ và phút ghi bàn trước!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvGhibanChu_RowClick(object sender, RowClickEventArgs e)
        {
            var temp = gvGhibanChu.GetFocusedRow() as View.Goal;
            cboCauthuChu.Text = temp.gObj.Name;
            txtPhutGhibanChu.Text = temp.gObj.StrMin;
        }

        private void gvGhibanKhach_RowClick(object sender, RowClickEventArgs e)
        {
            var temp = gvGhibanKhach.GetFocusedRow() as View.Goal;
            cboCauthuKhach.Text = temp.gObj.Name;
            txtPhutGhibanKhach.Text = temp.gObj.StrMin;
        }

        private void btnLuuGhibanChu_Click(object sender, EventArgs e)
        {
            if (bsGhibanChu.List.Count == 0)
            {
                HDMessageBox.Show("Chưa chọn cầu thủ ghi bàn để lưu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            if (cboCauthuChu.Text.Length > 0 && txtPhutGhibanChu.Text.Length > 0)
            {
                var temp = gvGhibanChu.GetFocusedRow() as View.Goal;

                bsGhibanChu.List.Insert(bsGhibanChu.List.IndexOf(temp), new View.Goal()
                {
                    gObj = new Object.Goal()
                    {
                        Name = cboCauthuChu.Text,
                        StrMin = txtPhutGhibanChu.Text
                    }
                });
                bsGhibanChu.List.Remove(temp);
            }
            else
            {
                HDMessageBox.Show("Chọn cầu thủ và phút ghi bàn trước!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLuuGhibanKhach_Click(object sender, EventArgs e)
        {
            if (bsGhibanKhach.List.Count == 0)
            {
                HDMessageBox.Show("Chưa chọn cầu thủ ghi bàn để lưu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            if (cboCauthuKhach.Text.Length > 0 && txtPhutGhibanKhach.Text.Length > 0)
            {
                var temp = gvGhibanKhach.GetFocusedRow() as View.Goal;

                bsGhibanKhach.List.Insert(bsGhibanKhach.List.IndexOf(temp), new View.Goal()
                {
                    gObj = new Object.Goal()
                    {
                        Name = cboCauthuKhach.Text,
                        StrMin = txtPhutGhibanKhach.Text
                    }
                });
                bsGhibanKhach.List.Remove(temp);
            }
            else
            {
                HDMessageBox.Show("Chọn cầu thủ và phút ghi bàn trước!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        int _thoigianTranGiay = 0;
        int _thoigianTranPhut = 0;
        int _thoigianThucGiay = 0;
        int _thoigianThucPhut = 0;
        bool _isEndPoint = false;
        #region Đồng hồ/Thời gian
        //DateTime _startTime = new DateTime();
        private void timer1_Tick(object sender, EventArgs e)
        {
            //var thoigianThuc = DateTime.Now - _startTime;
            //var strThoigianThucPhut = thoigianThuc.Minutes < 10 ? "0" + thoigianThuc.Minutes : thoigianThuc.Minutes.ToString();
            //var strThoigianThucGiay = thoigianThuc.Seconds < 10 ? "0" + thoigianThuc.Seconds : thoigianThuc.Seconds.ToString();
            //lbThoigianThuc.Text = strThoigianThucPhut + ":" + strThoigianThucGiay;
            if (!_isEndPoint)
            {
                _thoigianTranGiay++;
                if (_thoigianTranGiay == 60)
                {
                    _thoigianTranGiay = 0;
                    _thoigianTranPhut++;
                }
            }
            if ((_thoigianTranPhut == 45 || _thoigianTranPhut == 90 || _thoigianTranPhut == 105 || _thoigianTranPhut == 120) && _thoigianTranGiay == 0)
            {
                _thoigianTranGiay = 0;
                _isEndPoint = true;
            }
            if (_thoigianTranPhut < 45 || (_thoigianTranPhut == 45 && _thoigianTranGiay == 0))
            {
                txtHiep.Text = "1";
            }
            else
                if (_thoigianTranPhut >= 45 && _thoigianTranPhut < 90 || (_thoigianTranPhut == 90 && _thoigianTranGiay == 0))
            {
                txtHiep.Text = "2";
            }
            else if (_thoigianTranPhut >= 90 && _thoigianTranPhut < 105 || (_thoigianTranPhut == 105 && _thoigianTranGiay == 0))
            {
                txtHiep.Text = "phụ 1";
            }
            else
                txtHiep.Text = "phụ 2";
            var strThoigiantranPhut = _thoigianTranPhut < 10 ? "0" + _thoigianTranPhut : _thoigianTranPhut.ToString();
            var strThoigiantranGiay = _thoigianTranGiay < 10 ? "0" + _thoigianTranGiay : _thoigianTranGiay.ToString();
            lbThoigianTran.Text = strThoigiantranPhut + ":" + strThoigiantranGiay;

            _thoigianThucGiay++;
            if (_thoigianThucGiay == 60)
            {
                _thoigianThucGiay = 0;
                _thoigianThucPhut++;
            }
            var strThoigianThucPhut = _thoigianThucPhut < 10 ? "0" + _thoigianThucPhut : _thoigianThucPhut.ToString();
            var strThoigianThucGiay = _thoigianThucGiay < 10 ? "0" + _thoigianThucGiay : _thoigianThucGiay.ToString();
            lbThoigianThuc.Text = strThoigianThucPhut + ":" + strThoigianThucGiay;
        }

        private void btnBatdautrandau_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void btnDungthoigiantran_Click(object sender, EventArgs e)
        {
            if (_isEndPoint == true)
            {
                _isEndPoint = false;
                btnDungthoigiantran.Text = "Dừng";
            }
            else
            {
                _isEndPoint = true;
                btnDungthoigiantran.Text = "Tiếp tục";
            }
        }
        #endregion

    }
}
