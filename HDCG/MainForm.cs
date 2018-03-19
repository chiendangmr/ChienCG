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
        string _updateNotifier = "";
        List<Object.League> _lstLeagues = new List<Object.League>();
        List<Object.Team> _lstTeams = new List<Object.Team>();
        Dictionary<string, string> dicTemplates = new Dictionary<string, string>();
        Dictionary<string, string> dicTemplateData = new Dictionary<string, string>();
        Dictionary<string, string> dicDanhsachgiaidau = new Dictionary<string, string>();

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

                _videoXmlPath = Path.Combine(Path.Combine(Application.StartupPath, "Data"), "Video.xml");
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

                _updateDataXml = Path.Combine(Path.Combine(Application.StartupPath, "Data"), "UpdateData.xml");
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
                _updateNotifier = Path.Combine(Path.Combine(Application.StartupPath, "Data"), "UpdateNotifier.xml");
                try
                {
                    if (File.Exists(_updateNotifier))
                    {
                        var lstData = Utils.GetObject<List<Object.UpdateNotifier>>(_updateNotifier);
                        foreach (var data in lstData)
                            bsUpdateNotifier.Add(data);
                    }
                    else
                    {
                        File.Create(_updateNotifier).Dispose();
                    }
                }
                catch { }
                //Load danh sách giải đấu
                _danhsachgiaidauXmlPath = Path.Combine(Path.Combine(Application.StartupPath, "Data"), "Danhsachgiaidau.xml");
                try
                {
                    if (File.Exists(_danhsachgiaidauXmlPath))
                    {
                        _lstLeagues = Utils.GetObject<List<Object.League>>(_danhsachgiaidauXmlPath);
                        foreach (var temp in _lstLeagues)
                        {
                            cboGiaiDau.Properties.Items.Add(temp.Name);
                            dicDanhsachgiaidau.Add(temp.LeagueCode, temp.Name);
                        }
                    }
                    else
                    {
                        File.Create(_danhsachgiaidauXmlPath).Dispose();
                    }
                }
                catch
                {

                }

                cgServer = new HDCGControler.CasparCG();
                cgServer.Connect(AppSetting.Default.CGServerIP, AppSetting.Default.CGServerPort);
                cboGiaiDau.SelectedIndex = 0;
                tUpdateData.Enabled = true;
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
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (HDMessageBox.Show("Bạn có chắc chắn thoát?", "Chú ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    e.Cancel = false;
                }
                else
                    e.Cancel = true;
            }
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

            try
            {
                int nTry = 0;

                TryHere:

                if (frmInput.player.Add(1, templateFile))
                {
                    string xmlStr = "<Track_Property>" + GetAddXmlString() + "</Track_Property>";

                    frmInput.player.Update(1, xmlStr.Replace("\\n", "\n"));
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
        List<Object.Property> RuntimeProperties = null, string xmlStr = "")
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
                if (!isTySoGoc)
                {
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
                    isTySoGoc = false;
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
                    string xmlStr = "<Track_Property>" + GetAddXmlString() + "</Track_Property>";
                    if (_tempName == "BongDa_ThayNguoi.ft")
                    {
                        if (ckChu.Checked)
                        {
                            var playerIn = GetPlayerIn();
                            var playerOut = GetPlayerOut();
                            bsHomePlayer.List.Insert(bsHomePlayer.List.IndexOf(playerOut), playerIn);
                            bsHomePlayerDuBi.List.Insert(bsHomePlayer.List.IndexOf(playerIn), playerOut);
                            bsHomePlayer.List.Remove(playerOut);
                            bsHomePlayerDuBi.List.Remove(playerIn);
                        }
                        if (ckKhach.Checked)
                        {
                            var playerIn = GetPlayerIn();
                            var playerOut = GetPlayerOut();
                            bsAwayPlayer.List.Insert(bsAwayPlayer.List.IndexOf(playerOut), playerIn);
                            bsAwayPlayerDuBi.List.Insert(bsAwayPlayer.List.IndexOf(playerIn), playerOut);
                            bsAwayPlayer.List.Remove(playerOut);
                            bsAwayPlayerDuBi.List.Remove(playerIn);
                        }
                    }

                    System.Threading.Timer timer = null;
                    timer = new System.Threading.Timer((obj) =>
                        {
                            OnTemplate(_layer, _tempName, 1, null, runtimeProperties, xmlStr);
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
            _templateXmlPath = Path.Combine(Path.Combine(Application.StartupPath, "Data"), xmlTemplate);
            _tempInfoXmlPath = Path.Combine(Path.Combine(Application.StartupPath, "Data"), xmlPlaylist);

            try
            {
                if (File.Exists(_templateXmlPath))
                {
                    tempInfoBindingSource.List.Clear();
                    var lstTemplate = Utils.GetObject<List<Object.Template>>(_templateXmlPath).OrderBy(a => a.Name);
                    foreach (var temp in lstTemplate)
                    {
                        dicTemplates.Add(temp.Name, temp.FileName);
                        tempInfoBindingSource.List.Add(new View.tempInfo()
                        {
                            tempObj = new Object.tempInfo
                            {
                                TemplateName = temp.Name,
                                Layer = 105,
                                Duration = 0,
                                Delay = 0
                            }
                        });
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

            //try
            //{
            //    if (File.Exists(_tempInfoXmlPath))
            //    {
            //        var lstBarMC = Utils.GetObject<List<Object.tempInfo>>(_tempInfoXmlPath);
            //        foreach (var barMC in lstBarMC)
            //            tempInfoBindingSource.List.Add(new View.tempInfo()
            //            {
            //                tempObj = barMC
            //            });
            //    }
            //    else
            //    {
            //        File.Create(_tempInfoXmlPath).Dispose();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    HDMessageBox.Show(ex.Message, "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
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
                cgServer.UpdateTemplate(120, xmlStr, 0);

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
        public List<View.Player> GetTeamChinhThuc(string team)
        {
            var lstChinhthuc = new List<View.Player>();
            if (team == "home")
                lstChinhthuc = (bsHomePlayer.List as BindingList<View.Player>).OrderBy(a => a.mObj.Index).ToList();
            else if (team == "away")
                lstChinhthuc = (bsAwayPlayer.List as BindingList<View.Player>).OrderBy(a => a.mObj.Index).ToList();
            return lstChinhthuc;
        }
        public List<View.Player> GetTeamDuBi(string team)
        {
            var lstChinhthuc = new List<View.Player>();
            if (team == "home")
                lstChinhthuc = (bsHomePlayerDuBi.List as BindingList<View.Player>).OrderBy(a => a.mObj.Index).ToList();
            else if (team == "away")
                lstChinhthuc = (bsAwayPlayerDuBi.List as BindingList<View.Player>).OrderBy(a => a.mObj.Index).ToList();
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
                    xmlAdd += Add("doichuShort", txtHomeShortName.Text);
                    xmlAdd += Add("doikhachShort", txtAwayShortName.Text);
                    xmlAdd += Add("hiepdau", txtHiep.Text);
                    xmlAdd += Add("player1", GetPlayingPlayer().mObj.ShortName);
                    xmlAdd += Add("playerNumber1", GetPlayingPlayer().mObj.Number.ToString());
                    if (_tempName == "BongDa_CauThu.ft")
                    {
                        xmlAdd += Add("playerStr", GetPlayingPlayer().mObj.Number.ToString() + ". " + GetPlayingPlayer().mObj.ShortName);
                    }

                    xmlAdd += Add("trongtaichinh", txtTrongtaiChinh.Text);
                    xmlAdd += Add("troly1", txtTroly1.Text);
                    xmlAdd += Add("troly2", txtTroly2.Text);
                    xmlAdd += Add("trongtaiban", txtTrongtaiban.Text);

                    xmlAdd += Add("giaidauVongdau", cboGiaiDau.Text + " - VÒNG " + nVongDau.Text);
                    xmlAdd += Add("stadium", txtStadium.Text);
                    xmlAdd += Add("txtThoitiet", txtThoiTiet.Text);
                    xmlAdd += Add("nhietdo", txtNhietdo.Text);
                    xmlAdd += Add("sucgio", txtSucgio.Text);
                    xmlAdd += Add("doam", txtDoam.Text);

                    xmlAdd += Add("dong1", txtLine1.Text);
                    xmlAdd += Add("dong2", txtLine2.Text);
                    xmlAdd += Add("bugio", nBugio.Value.ToString());
                    if (_tempName == "BongDa_ThayNguoi.ft")
                    {
                        xmlAdd += Add("playerin", GetPlayerIn().mObj.Name);
                        xmlAdd += Add("playerout", GetPlayerOut().mObj.Name);
                        xmlAdd += Add("playerInNumber", GetPlayerIn().mObj.Number.ToString());
                        xmlAdd += Add("playerOutNumber", GetPlayerOut().mObj.Number.ToString());

                    }
                    if (rbHiep1.Checked)
                    {
                        xmlAdd += Add("dongho", lbThoigianHiep1.Text);
                    }
                    else if (rbHiep2.Checked)
                    {
                        xmlAdd += Add("dongho", lbThoigianHiep2.Text);
                    }
                    else if (rbHiepPhu1.Checked)
                    {
                        xmlAdd += Add("dongho", lbThoigianHiepPhu1.Text);
                    }
                    else if (rbHiepPhu2.Checked)
                    {
                        xmlAdd += Add("dongho", lbThoigianHiepPhu2.Text);
                    }

                    if (_tempName == "BongDa_TySoChinh.ft" || _tempName == "BongDa_BangCho.ft")
                    {
                        xmlAdd += Add("icon1", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons"), GetTeamLogo(cboDoiChuNha.Text, false)));
                        xmlAdd += Add("icon2", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons"), GetTeamLogo(cboDoiKhach.Text, false)));
                    }
                    else if (_tempName == "BongDa_DanhSachChinhThuc.ft" || _tempName == "BongDa_DanhSachDuBi.ft" || _tempName.Contains("BongDa_TySo"))
                    {
                        xmlAdd += Add("icon1", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons"), GetTeamLogo(cboDoiChuNha.Text)));
                        xmlAdd += Add("icon2", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons"), GetTeamLogo(cboDoiKhach.Text)));
                    }
                    else
                    {
                        if (ckChu.Checked)
                        {
                            xmlAdd += Add("icon1", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons"), GetTeamLogo(cboDoiChuNha.Text)));
                        }
                        else if (ckKhach.Checked)
                        {
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
                    }
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
                    xmlAdd += Add("tyso", nTysoChu.Value.ToString() + "-" + nTysoKhach.Value.ToString());
                    xmlAdd += Add("goalChu", nTysoChu.Value.ToString());
                    xmlAdd += Add("goalKhach", nTysoKhach.Value.ToString());
                    if (_tempName == "BongDa_DanhSachChinhThuc.ft")
                    {
                        var lstChinhthucChu = GetTeamChinhThuc("home");
                        var lstChinhthucKhach = GetTeamChinhThuc("away");
                        if (lstChinhthucChu.Count > 0)
                            for (var i = 0; i < lstChinhthucChu.Count(); i++)
                            {
                                xmlAdd += Add("chinhthucChuName" + (i + 1).ToString(), lstChinhthucChu[i].mObj.Name);
                                xmlAdd += Add("chinhthucChuNumber" + (i + 1).ToString(), lstChinhthucChu[i].mObj.Number.ToString());
                            }
                        if (lstChinhthucKhach.Count > 0)
                            for (var i = 0; i < lstChinhthucKhach.Count(); i++)
                            {
                                xmlAdd += Add("chinhthucKhachName" + (i + 1).ToString(), lstChinhthucKhach[i].mObj.Name);
                                xmlAdd += Add("chinhthucKhachNumber" + (i + 1).ToString(), lstChinhthucKhach[i].mObj.Number.ToString());
                            }
                    }
                    if (_tempName == "BongDa_DanhSachDuBi.ft")
                    {
                        var lstDuBiChu = GetTeamDuBi("home");
                        if (lstDuBiChu.Count > 0)
                            for (var i = 0; i < lstDuBiChu.Count(); i++)
                            {
                                xmlAdd += Add("dubiChuName" + (i + 1).ToString(), lstDuBiChu[i].mObj.Name);
                                xmlAdd += Add("dubiChuNumber" + (i + 1).ToString(), lstDuBiChu[i].mObj.Number.ToString());
                            }
                        var lstDuBiKhach = GetTeamDuBi("away");
                        if (lstDuBiKhach.Count > 0)
                            for (var i = 0; i < lstDuBiKhach.Count(); i++)
                            {
                                xmlAdd += Add("dubiKhachName" + (i + 1).ToString(), lstDuBiKhach[i].mObj.Name);
                                xmlAdd += Add("dubiKhachNumber" + (i + 1).ToString(), lstDuBiKhach[i].mObj.Number.ToString());
                            }
                    }
                    //Danh sách ghi bàn

                    xmlAdd += Add("ghibanChu", rtbGhiBanChu.Text);
                    xmlAdd += Add("ghibanKhach", rtbGhiBanKhach.Text);

                    if (_tempName == "BongDa_ThongSoCuoiTran.ft")
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
                    else if (_tempName.Contains("BongDa_ThongSo"))
                    {
                        if (_tempName == "BongDa_ThongSo_DutDiem.ft")
                        {
                            xmlAdd += Add("thongsonhoChu", nDutdiemChu.Text);
                            xmlAdd += Add("thongsonhoKhach", nDutdiemKhach.Text);
                        }
                        else if (_tempName == "BongDa_ThongSo_DutDiemTrungDich.ft")
                        {
                            xmlAdd += Add("thongsonhoChu", nTrungdichChu.Text);
                            xmlAdd += Add("thongsonhoKhach", nTrungdichKhach.Text);
                        }
                        else if (_tempName == "BongDa_ThongSo_PhamLoi.ft")
                        {
                            xmlAdd += Add("thongsonhoChu", nPhamloiChu.Text);
                            xmlAdd += Add("thongsonhoKhach", nPhamloiKhach.Text);
                        }
                        else if (_tempName == "BongDa_ThongSo_TheVang.ft")
                        {
                            xmlAdd += Add("thongsonhoChu", nThevangChu.Text);
                            xmlAdd += Add("thongsonhoKhach", nThevangKhach.Text);
                        }
                        else if (_tempName == "BongDa_ThongSo_TheDo.ft")
                        {
                            xmlAdd += Add("thongsonhoChu", nThedoChu.Text);
                            xmlAdd += Add("thongsonhoKhach", nThedoKhach.Text);
                        }
                        else if (_tempName == "BongDa_ThongSo_VietVi.ft")
                        {
                            xmlAdd += Add("thongsonhoChu", nVietviChu.Text);
                            xmlAdd += Add("thongsonhoKhach", nVietviKhach.Text);
                        }
                        else if (_tempName == "BongDa_ThongSo_PhatGoc.ft")
                        {
                            xmlAdd += Add("thongsonhoChu", nPhatgocChu.Text);
                            xmlAdd += Add("thongsonhoKhach", nPhatgocKhach.Text);
                        }
                        else if (_tempName == "BongDa_ThongSo_KiemSoatBong.ft")
                        {
                            xmlAdd += Add("thongsonhoChu", nKiemsoatbongChu.Text);
                            xmlAdd += Add("thongsonhoKhach", nKiemsoatbongKhach.Text);
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
                var danhsachdoiPath = Path.Combine(Path.Combine(Application.StartupPath, "Data"), "Danhsachdoi" + dicDanhsachgiaidau.FirstOrDefault(x => x.Value == cboGiaiDau.Text).Key + ".xml");
                try
                {
                    if (File.Exists(danhsachdoiPath))
                    {
                        cboDoiChuNha.Properties.Items.Clear();
                        cboDoiKhach.Properties.Items.Clear();
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
                ManagePlayersForm frmPlayer = new ManagePlayersForm(dicDanhsachgiaidau.FirstOrDefault(x => x.Value == cboGiaiDau.Text).Key, cboDoiChuNha.Text);
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
            var templatesXmlPath = Path.Combine(Path.Combine(Application.StartupPath, "Data"), "Danhsachcauthu" + Utils.ConvertToVietnameseNonSign(cboDoiChuNha.Text).Replace(" ", "_") + ".xml");
            try
            {
                if (File.Exists(templatesXmlPath))
                {
                    bsHomePlayer.Clear();
                    bsHomePlayerDuBi.Clear();
                    bsGhibanChu.Clear();
                    var lstTemplate = Utils.GetObject<List<Object.Player>>(templatesXmlPath).Where(a => a.IsNotSubstitution == true);
                    foreach (var temp in lstTemplate)
                    {
                        bsHomePlayer.Add(new View.Player()
                        {
                            mObj = temp
                        });
                    }
                    var lstDubi = Utils.GetObject<List<Object.Player>>(templatesXmlPath).Where(a => a.IsSubstitution == true);
                    foreach (var temp in lstDubi)
                    {
                        bsHomePlayerDuBi.Add(new View.Player()
                        {
                            mObj = temp
                        });
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
            var templatesXmlPath = Path.Combine(Path.Combine(Application.StartupPath, "Data"), "Danhsachcauthu" + Utils.ConvertToVietnameseNonSign(cboDoiKhach.Text).Replace(" ", "_") + ".xml");
            try
            {
                if (File.Exists(templatesXmlPath))
                {
                    bsAwayPlayer.Clear();
                    bsAwayPlayerDuBi.Clear();
                    bsGhibanKhach.Clear();
                    var lstTemplate = Utils.GetObject<List<Object.Player>>(templatesXmlPath).Where(a => a.IsNotSubstitution == true);
                    foreach (var temp in lstTemplate)
                    {
                        bsAwayPlayer.Add(new View.Player()
                        {
                            mObj = temp
                        });
                    }
                    var lstDuBi = Utils.GetObject<List<Object.Player>>(templatesXmlPath).Where(a => a.IsSubstitution == true);
                    foreach (var temp in lstDuBi)
                    {
                        bsAwayPlayerDuBi.Add(new View.Player()
                        {
                            mObj = temp
                        });
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
                ManagePlayersForm frmPlayer = new ManagePlayersForm(dicDanhsachgiaidau.FirstOrDefault(x => x.Value == cboGiaiDau.Text).Key, cboDoiKhach.Text);
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
                var strThoigiantranPhut = _thoigianTranPhut < 10 ? "0" + _thoigianTranPhut : _thoigianTranPhut.ToString();
                var strThoigiantranGiay = _thoigianTranGiay < 10 ? "0" + _thoigianTranGiay : _thoigianTranGiay.ToString();
                if (rbHiep1.Checked)
                {
                    lbThoigianHiep1.Text = strThoigiantranPhut + ":" + strThoigiantranGiay;
                }
                else if (rbHiep2.Checked)
                {
                    lbThoigianHiep2.Text = strThoigiantranPhut + ":" + strThoigiantranGiay;
                }
                else if (rbHiepPhu1.Checked)
                {
                    lbThoigianHiepPhu1.Text = strThoigiantranPhut + ":" + strThoigiantranGiay;
                }
                else if (rbHiepPhu2.Checked)
                {
                    lbThoigianHiepPhu2.Text = strThoigiantranPhut + ":" + strThoigiantranGiay;
                }
            }
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
            _isEndPoint = false;
            if (rbHiep1.Checked)
            {
                _thoigianTranPhut = 0;
            }
            else if (rbHiep2.Checked)
            {
                _thoigianTranPhut = 45;
            }
            else if (rbHiepPhu1.Checked)
            {
                _thoigianTranPhut = 90;
            }
            else if (rbHiepPhu2.Checked)
            {
                _thoigianTranPhut = 105;
            }
            _thoigianTranGiay = 0;
            timer1.Enabled = true;
        }
        private void btnDungthoigiantran_Click(object sender, EventArgs e)
        {
            _isEndPoint = true;
        }
        #endregion

        private void tUpdateData_Tick(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(_updateNotifier))
                {
                    var lstData = Utils.GetObject<List<Object.UpdateNotifier>>(_updateNotifier);
                    if (lstData[0].IsUpdateDanhsachgiaidau)
                    {
                        _lstLeagues = Utils.GetObject<List<Object.League>>(_danhsachgiaidauXmlPath);
                        cboGiaiDau.Properties.Items.Clear();
                        dicDanhsachgiaidau.Clear();
                        foreach (var temp in _lstLeagues)
                        {
                            cboGiaiDau.Properties.Items.Add(temp.Name);
                            dicDanhsachgiaidau.Add(temp.LeagueCode, temp.Name);
                        }
                        UpdateNotifier();
                        cboGiaiDau.SelectedIndex = 0;
                    }
                    if (lstData[0].IsUpdateDanhsachdoibong)
                    {
                        var tempIndex = cboGiaiDau.SelectedIndex;
                        cboGiaiDau.SelectedIndex = -1;
                        UpdateNotifier();
                        cboGiaiDau.SelectedIndex = 0;
                    }
                    if (lstData[0].IsUpdateDanhsachcauthu)
                    {
                        var tempIndex = cboGiaiDau.SelectedIndex;
                        cboGiaiDau.SelectedIndex = -1;
                        UpdateNotifier();
                        cboGiaiDau.SelectedIndex = 0;
                    }
                }
                else
                {
                    File.Create(_updateNotifier).Dispose();
                }
            }
            catch { }
        }
        private void UpdateNotifier()
        {
            bsUpdateNotifier.List.Clear();
            bsUpdateNotifier.List.Add(new Object.UpdateNotifier
            {
                IsUpdateDanhsachcauthu = false,
                IsUpdateDanhsachdoibong = false,
                IsUpdateDanhsachgiaidau = false
            });
            (bsUpdateNotifier.List as BindingList<Object.UpdateNotifier>).Select(v => v).ToList().SaveObject(_updateNotifier);
        }

        private void btnSetTime_Click(object sender, EventArgs e)
        {
            _thoigianTranPhut = (int)nPhut.Value;
            _thoigianTranGiay = (int)nGiay.Value;
        }
        bool isTySoGoc = false;
        private void btnOnTySoGoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cgServer.Connect())
                    HDMessageBox.Show("Not connect to cg server!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (cboGiaiDau.Text.Length > 0 && cboDoiChuNha.Text.Length > 0 && cboDoiKhach.Text.Length > 0)
                    {
                        isTySoGoc = true;
                        List<Object.Property> runtimeProperties = new List<Object.Property>();
                        runtimeProperties.Add(new Object.Property()
                        {
                            Name = "Loops",
                            Value = "false"
                        });
                        string xmlStr = "<Track_Property>" + GetAddXmlString() + "</Track_Property>";
                        var tempTySoGocName = "";
                        var tempBuGioGocName = "";
                        if (cboTysogocType.Text == "Trái")
                        {
                            tempTySoGocName = "BongDa_TySoGocTrai.ft";
                            tempBuGioGocName = "BongDa_BuGioGocTrai.ft";
                        }
                        else
                        {
                            tempTySoGocName = "BongDa_TySoGocPhai.ft";
                            tempBuGioGocName = "BongDa_BuGioGocPhai.ft";
                        }
                        if (ckTysogocVaBugioOn.Checked)
                        {
                            OnTemplate(120, tempTySoGocName, 1, null, runtimeProperties, xmlStr);
                            OnTemplate(121, tempBuGioGocName, 1, null, runtimeProperties, xmlStr);
                        }
                        else
                        {
                            OnTemplate(120, tempTySoGocName, 1, null, runtimeProperties, xmlStr);
                        }
                    }

                    else
                        HDMessageBox.Show("Bạn chưa chọn thông tin Giải đấu, Đội chủ/khách!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                HDMessageBox.Show("Please add a Template!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnOffTySoGoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (ckTysogocVaBugioOff.Checked)
                {
                    OffTemplate(120);
                    OffTemplate(121);
                }
                else
                {
                    OffTemplate(120);
                }
            }
            catch
            {
                HDMessageBox.Show("404 - Template not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnOnBugio_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cgServer.Connect())
                    HDMessageBox.Show("Not connect to cg server!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (cboGiaiDau.Text.Length > 0 && cboDoiChuNha.Text.Length > 0 && cboDoiKhach.Text.Length > 0)
                    {
                        isTySoGoc = true;
                        List<Object.Property> runtimeProperties = new List<Object.Property>();
                        runtimeProperties.Add(new Object.Property()
                        {
                            Name = "Loops",
                            Value = "false"
                        });
                        string xmlStr = "<Track_Property>" + GetAddXmlString() + "</Track_Property>";
                        var tempBuGioGocName = "";
                        if (cboTysogocType.Text == "Trái")
                        {
                            tempBuGioGocName = "BongDa_BuGioGocTrai.ft";
                        }
                        else
                        {
                            tempBuGioGocName = "BongDa_BuGioGocPhai.ft";
                        }
                        OnTemplate(121, tempBuGioGocName, 1, null, runtimeProperties, xmlStr);

                    }

                    else
                        HDMessageBox.Show("Bạn chưa chọn thông tin Giải đấu, Đội chủ/khách!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                HDMessageBox.Show("Please add a Template!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnOffBugio_Click(object sender, EventArgs e)
        {
            try
            {
                OffTemplate(121);

            }
            catch
            {
                HDMessageBox.Show("404 - Template not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
