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
        string _danhsachgiaiTennisPath = "";
        string _TennisLeagueCode = "";
        List<Object.League> _lstLeagues = new List<Object.League>();
        List<Object.Tennis.League> _lstTennisLeagues = new List<Object.Tennis.League>();
        List<Object.Team> _lstTeams = new List<Object.Team>();
        List<Object.Tennis.Team> _lstTennisTeams = new List<Object.Tennis.Team>();
        Dictionary<string, string> dicTemplates = new Dictionary<string, string>();
        Dictionary<string, string> dicTemplateData = new Dictionary<string, string>();
        Dictionary<string, string> dicDanhsachgiaidau = new Dictionary<string, string>();
        Dictionary<string, string> dicDanhsachgiaidauTennis = new Dictionary<string, string>();
        Dictionary<string, string> dicDanhsachdoi = new Dictionary<string, string>();
        Dictionary<string, string> dicDanhsachdoiTennis = new Dictionary<string, string>();

        HDCGControler.CasparCG cgServer = null;
        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                cboFormat.EditValue = AppSetting.Default.Format;
                cboFormat.Caption = AppSetting.Default.Format;

                cboVideoLayer.SelectedIndex = 0;
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
                _danhsachgiaiTennisPath = Path.Combine(Path.Combine(Application.StartupPath, "Data/Tennis"), "Danhsachgiaidau.xml");
                try
                {
                    if (File.Exists(_danhsachgiaiTennisPath))
                    {
                        _lstTennisLeagues = Utils.GetObject<List<Object.Tennis.League>>(_danhsachgiaiTennisPath);
                        foreach (var temp in _lstTennisLeagues)
                        {
                            cboGiaiDauTennis.Properties.Items.Add(temp.Name);
                            dicDanhsachgiaidauTennis.Add(temp.LeagueCode, temp.Name);
                        }
                    }
                    else
                    {
                        File.Create(_danhsachgiaiTennisPath).Dispose();
                    }
                }
                catch
                {

                }
                cgServer = new HDCGControler.CasparCG();
                cgServer.Connect(AppSetting.Default.CGServerIP, AppSetting.Default.CGServerPort);
                cboGiaiDau.SelectedIndex = -1;
                cboGiaiDauTennis.SelectedIndex = -1;
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

        #region Video/Images
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
        #endregion

        #region Hàm xử lý chung
        public string ViewTemplate(string templateFileName, int fadeUpDuration = 0, bool isChu = true)
        {
            string templateFile = "HDTemplates\\" + templateFileName;

            try
            {
                int nTry = 0;

                TryHere:
                Clear();
                if (player.Add(1, templateFile))
                {
                    string xmlStr = "<Track_Property>" + GetAddXmlString(isChu) + "</Track_Property>";

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
                    //if (!cgServer.CutDown(layer))
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
            ViewTemplate(_tempName);
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
        #endregion

        #region Bóng đá
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

        private void btnLiveUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string xmlStr = "<Track_Property>" + GetAddXmlString() + "</Track_Property>";
                player.Update(1, xmlStr.Replace("\\n", "\n"));
                player.Refresh();
                cgServer.UpdateTemplate(120, xmlStr.Replace("\\", "\\\\"), 0);

                cgServer.UpdateTemplate(_layer, xmlStr.Replace("\\", "\\\\"), 0);

            }
            catch (Exception ex)
            {
                HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Các hàm get thông tin template
        public View.Player GetPlayingPlayer(bool isChu)
        {
            var player = new View.Player();
            if (isChu)
            {
                player = gvHomePlayer.GetFocusedRow() as View.Player;
            }
            else
            {
                player = gvAwayPlayer.GetFocusedRow() as View.Player;
            }
            return player;
        }
        public string GetTeamName(bool isChu)
        {
            var teamName = "";
            if (isChu)
            {
                teamName = cboDoiChuNha.Text;
            }
            else
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
        public string GetTennisTeamLogo(string teamName, bool logoNho = true)
        {
            string logoPath = "";
            foreach (var temp in _lstTennisTeams)
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
        public View.Player GetPlayerOut(bool isChu)
        {
            var player = new View.Player();
            if (isChu)
            {
                player = gvHomePlayer.GetFocusedRow() as View.Player;
            }
            else
            {
                player = gvAwayPlayer.GetFocusedRow() as View.Player;
            }
            return player;
        }

        public View.Player GetPlayerIn(bool isChu)
        {
            var player = new View.Player();
            if (isChu)
            {
                player = gvHomePlayerDuBi.GetFocusedRow() as View.Player;
            }
            else
            {
                player = gvAwayPlayerDuBi.GetFocusedRow() as View.Player;
            }
            return player;
        }
        #endregion
        public string GetAddXmlString(bool isChu = true)
        {
            var xmlAdd = "";
            if (xTabMain.SelectedTabPage.Equals(xTabPageBongda))
            {
                try
                {
                    xmlAdd += Add("doibong", GetTeamName(isChu));
                    xmlAdd += Add("doichuShort", txtHomeShortName.Text);
                    xmlAdd += Add("doikhachShort", txtAwayShortName.Text);
                    xmlAdd += Add("mauaoChu", String.Format("{0:X}", colorChu.Color.ToArgb()));
                    xmlAdd += Add("mauaoKhach", String.Format("{0:X}", colorKhach.Color.ToArgb()));
                    xmlAdd += Add("hiepdau", txtHiep.Text);
                    xmlAdd += Add("player1", GetPlayingPlayer(isChu).mObj.ShortName);
                    xmlAdd += Add("playerNumber1", GetPlayingPlayer(isChu).mObj.Number.ToString());
                    if (_tempName == "BongDa_CauThu.ft")
                    {
                        xmlAdd += Add("playerStr", GetPlayingPlayer(isChu).mObj.Number.ToString() + ". " + GetPlayingPlayer(isChu).mObj.ShortName);
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
                    if (_tempName == "BongDa_BarTen.ft")
                    {
                        xmlAdd += Add("dong1", txtLine1.Text);
                        xmlAdd += Add("dong2", txtLine2.Text);
                        xmlAdd += Add("iconBarTen", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons"), txtLogoBarTen.Text));
                    }
                    xmlAdd += Add("bugio", nBugio.Value.ToString());
                    if (_tempName == "BongDa_ThayNguoi.ft")
                    {
                        xmlAdd += Add("playerin", GetPlayerIn(isChu).mObj.Name);
                        xmlAdd += Add("playerout", GetPlayerOut(isChu).mObj.Name);
                        xmlAdd += Add("playerInNumber", GetPlayerIn(isChu).mObj.Number.ToString());
                        xmlAdd += Add("playerOutNumber", GetPlayerOut(isChu).mObj.Number.ToString());

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

                    if (_tempName == "BongDa_ThongSoCuoiTran.ft" || _tempName == "BongDa_BangCho.ft")
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
                        if (isChu)
                        {
                            xmlAdd += Add("icon1", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons"), GetTeamLogo(cboDoiChuNha.Text)));
                        }
                        else
                        {
                            xmlAdd += Add("icon1", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons"), GetTeamLogo(cboDoiKhach.Text)));
                        }
                    }
                    if (isChu)
                    {
                        xmlAdd += Add("hlv", txtHomeCoach.Text);
                        xmlAdd += Add("thongsocauthu", cboNoiDungChu.Text);
                    }
                    else
                    {
                        xmlAdd += Add("hlv", txtAwayCoach.Text);
                        xmlAdd += Add("thongsocauthu", cboNoiDungKhach.Text);

                    }
                    xmlAdd += Add("doiChu", cboDoiChuNha.Text);
                    xmlAdd += Add("doiKhach", cboDoiKhach.Text);
                    xmlAdd += Add("tyso", nTysoChu.Value.ToString() + " - " + nTysoKhach.Value.ToString());
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
                    string tempGhiBanChu = "";
                    foreach (var temp in bsGhibanChu.List as BindingList<Object.Goal>)
                    {
                        tempGhiBanChu += temp.Name + "   " + temp.StrMin + "\n";
                    }
                    string tempGhiBanKhach = "";
                    foreach (var temp in bsGhibanKhach.List as BindingList<Object.Goal>)
                    {
                        tempGhiBanKhach += temp.StrMin + "   " + temp.Name + "\n";
                    }
                    xmlAdd += Add("ghibanChu", tempGhiBanChu);
                    xmlAdd += Add("ghibanKhach", tempGhiBanKhach);

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
                catch //(Exception ex)
                {
                    //HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {

                    xmlAdd += Add("hatgiong1", nHatgiong1.Value.ToString());
                    xmlAdd += Add("hatgiong2", nHatgiong2.Value.ToString());

                    xmlAdd += Add("thongtinphu", cboThongtinphu.Text);
                    if (cbTiebreak.Checked)
                    {
                        xmlAdd += Add("livepoint1", nTiebreak1.Text);
                        xmlAdd += Add("livepoint2", nTiebreak2.Text);
                    }
                    else
                    {
                        xmlAdd += Add("livepoint1", cboPointTeam1.Text);
                        xmlAdd += Add("livepoint2", cboPointTeam2.Text);
                    }
                    xmlAdd += Add("team1", cboTeam1Player1.Text);
                    xmlAdd += Add("team2", cboTeam2Player1.Text);
                    xmlAdd += Add("team1short", txtShortNameTeam1.Text);
                    xmlAdd += Add("team2short", txtShortNameTeam2.Text);
                    xmlAdd += Add("set1time", txtSet1time.Text);
                    xmlAdd += Add("set2time", txtSet2time.Text);
                    xmlAdd += Add("set3time", txtSet3time.Text);
                    xmlAdd += Add("set4time", txtSet4time.Text);
                    xmlAdd += Add("set5time", txtSet5time.Text);
                    xmlAdd += Add("icon1", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons/Tennis"), GetTennisTeamLogo(cboTennisTeam1.Text)));
                    xmlAdd += Add("icon2", Path.Combine(Path.Combine(AppSetting.Default.MediaFolder, "Icons/Tennis"), GetTennisTeamLogo(cboTennisTeam2.Text)));
                    if (ckGiaobong1.Checked)
                    {
                        xmlAdd += Add("giaobong1", "true");
                        xmlAdd += Add("giaobong2", "false");
                    }
                    else
                    {
                        xmlAdd += Add("giaobong2", "true");
                        xmlAdd += Add("giaobong1", "false");
                    }

                    xmlAdd += Add("tyso1", nTySo1.Text);
                    xmlAdd += Add("tyso2", nTySo2.Text);

                    if (rSet1.Checked)
                    {
                        xmlAdd += Add("setpoint1", nDiemSet1Player1.Text);
                        xmlAdd += Add("setpoint2", nDiemSet1Player2.Text);

                        xmlAdd += Add("set1point1", nDiemSet1Player1.Value.ToString());
                        xmlAdd += Add("set1point2", nDiemSet1Player2.Value.ToString());
                        xmlAdd += Add("set2point1", "");
                        xmlAdd += Add("set2point2", "");
                        xmlAdd += Add("set3point1", "");
                        xmlAdd += Add("set3point2", "");
                        xmlAdd += Add("set4point1", "");
                        xmlAdd += Add("set4point2", "");
                        xmlAdd += Add("set5point1", "");
                        xmlAdd += Add("set5point2", "");
                    }
                    else if (rSet2.Checked)
                    {
                        xmlAdd += Add("setpoint1", nDiemSet2Player1.Text);
                        xmlAdd += Add("setpoint2", nDiemSet2Player2.Text);
                        xmlAdd += Add("set1point1", nDiemSet1Player1.Value.ToString());
                        xmlAdd += Add("set1point2", nDiemSet1Player2.Value.ToString());
                        xmlAdd += Add("set2point1", nDiemSet2Player1.Value.ToString());
                        xmlAdd += Add("set2point2", nDiemSet2Player2.Value.ToString());
                        xmlAdd += Add("set3point1", "");
                        xmlAdd += Add("set3point2", "");
                        xmlAdd += Add("set4point1", "");
                        xmlAdd += Add("set4point2", "");
                        xmlAdd += Add("set5point1", "");
                        xmlAdd += Add("set5point2", "");
                    }
                    else if (rSet3.Checked)
                    {
                        xmlAdd += Add("setpoint1", nDiemSet3Player1.Text);
                        xmlAdd += Add("setpoint2", nDiemSet3Player2.Text);
                        xmlAdd += Add("set1point1", nDiemSet1Player1.Value.ToString());
                        xmlAdd += Add("set1point2", nDiemSet1Player2.Value.ToString());
                        xmlAdd += Add("set2point1", nDiemSet2Player1.Value.ToString());
                        xmlAdd += Add("set2point2", nDiemSet2Player2.Value.ToString());
                        xmlAdd += Add("set3point1", nDiemSet3Player1.Value.ToString());
                        xmlAdd += Add("set3point2", nDiemSet3Player2.Value.ToString());
                        xmlAdd += Add("set4point1", "");
                        xmlAdd += Add("set4point2", "");
                        xmlAdd += Add("set5point1", "");
                        xmlAdd += Add("set5point2", "");
                    }
                    else if (rSet4.Checked)
                    {
                        xmlAdd += Add("setpoint1", nDiemSet4Player1.Text);
                        xmlAdd += Add("setpoint2", nDiemSet4Player2.Text);
                        xmlAdd += Add("set1point1", nDiemSet1Player1.Value.ToString());
                        xmlAdd += Add("set1point2", nDiemSet1Player2.Value.ToString());
                        xmlAdd += Add("set2point1", nDiemSet2Player1.Value.ToString());
                        xmlAdd += Add("set2point2", nDiemSet2Player2.Value.ToString());
                        xmlAdd += Add("set3point1", nDiemSet3Player1.Value.ToString());
                        xmlAdd += Add("set3point2", nDiemSet3Player2.Value.ToString());
                        xmlAdd += Add("set4point1", nDiemSet4Player1.Value.ToString());
                        xmlAdd += Add("set4point2", nDiemSet4Player2.Value.ToString());
                        xmlAdd += Add("set5point1", "");
                        xmlAdd += Add("set5point2", "");
                    }
                    else if (rSet5.Checked)
                    {
                        xmlAdd += Add("setpoint1", nDiemSet5Player1.Text);
                        xmlAdd += Add("setpoint2", nDiemSet5Player2.Text);
                        xmlAdd += Add("set1point1", nDiemSet1Player1.Value.ToString());
                        xmlAdd += Add("set1point2", nDiemSet1Player2.Value.ToString());
                        xmlAdd += Add("set2point1", nDiemSet2Player1.Value.ToString());
                        xmlAdd += Add("set2point2", nDiemSet2Player2.Value.ToString());
                        xmlAdd += Add("set3point1", nDiemSet3Player1.Value.ToString());
                        xmlAdd += Add("set3point2", nDiemSet3Player2.Value.ToString());
                        xmlAdd += Add("set4point1", nDiemSet4Player1.Value.ToString());
                        xmlAdd += Add("set4point2", nDiemSet4Player2.Value.ToString());
                        xmlAdd += Add("set5point1", nDiemSet5Player1.Value.ToString());
                        xmlAdd += Add("set5point2", nDiemSet5Player2.Value.ToString());
                    }
                    xmlAdd += Add("player1", cboTeam1Player1.Text);
                    xmlAdd += Add("player2", cboTeam2Player1.Text);
                    if (rServesIn.Checked)
                    {
                        xmlAdd += Add("thongso", txtServesIn.Text);
                        xmlAdd += Add("giatriThongso1", numericUpDown20.Value.ToString() + "%");
                        xmlAdd += Add("giatriThongso2", numericUpDown19.Value.ToString() + "%");
                    }
                    else if (rServesWon.Checked)
                    {
                        xmlAdd += Add("thongso", txtServesWon.Text);
                        xmlAdd += Add("giatriThongso1", numericUpDown18.Value.ToString() + "%");
                        xmlAdd += Add("giatriThongso2", numericUpDown17.Value.ToString() + "%");
                    }
                    else if (rAces.Checked)
                    {
                        xmlAdd += Add("thongso", txtAces.Text);
                        xmlAdd += Add("giatriThongso1", numericUpDown8.Value.ToString());
                        xmlAdd += Add("giatriThongso2", numericUpDown7.Value.ToString());
                    }
                    else if (rDoubleFaults.Checked)
                    {
                        xmlAdd += Add("thongso", txtDoubleF.Text);
                        xmlAdd += Add("giatriThongso1", numericUpDown10.Value.ToString());
                        xmlAdd += Add("giatriThongso2", numericUpDown9.Value.ToString());
                    }
                    else if (rForehand.Checked)
                    {
                        xmlAdd += Add("thongso", txtForehand.Text);
                        xmlAdd += Add("giatriThongso1", numericUpDown12.Value.ToString());
                        xmlAdd += Add("giatriThongso2", numericUpDown11.Value.ToString());
                    }
                    else if (rBackhand.Checked)
                    {
                        xmlAdd += Add("thongso", txtBackhand.Text);
                        xmlAdd += Add("giatriThongso1", numericUpDown14.Value.ToString());
                        xmlAdd += Add("giatriThongso2", numericUpDown13.Value.ToString());
                    }
                    else if (rPointWonAtnet.Checked)
                    {
                        xmlAdd += Add("thongso", txtPointWon.Text);
                        xmlAdd += Add("giatriThongso1", numericUpDown16.Value.ToString());
                        xmlAdd += Add("giatriThongso2", numericUpDown15.Value.ToString());
                    }
                    else if (rBreakPointsWon.Checked)
                    {
                        xmlAdd += Add("thongso", txtBreakpoint.Text);
                        xmlAdd += Add("giatriThongso1", numericUpDown2.Value.ToString());
                        xmlAdd += Add("giatriThongso2", numericUpDown1.Value.ToString());
                    }
                    else if (rUnforcedErrors.Checked)
                    {
                        xmlAdd += Add("thongso", txtUnforced.Text);
                        xmlAdd += Add("giatriThongso1", numericUpDown4.Value.ToString());
                        xmlAdd += Add("giatriThongso2", numericUpDown3.Value.ToString());
                    }
                }
                catch //(Exception ex)
                {
                    //HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return xmlAdd;
        }
        #endregion               

        private void btnQuanlyGiaiDau_Click(object sender, EventArgs e)
        {
            FormManageLeague frmManageLeague = new FormManageLeague();
            frmManageLeague.Show();
            frmManageLeague.Activate();
        }
        private void LamMoiBongDa()
        {
            try
            {
                _lstLeagues = Utils.GetObject<List<Object.League>>(_danhsachgiaidauXmlPath);
                cboGiaiDau.Properties.Items.Clear();
                dicDanhsachgiaidau.Clear();
                foreach (var temp in _lstLeagues)
                {
                    cboGiaiDau.Properties.Items.Add(temp.Name);
                    dicDanhsachgiaidau.Add(temp.LeagueCode, temp.Name);
                }
                cboGiaiDau.SelectedIndex = -1;
                cboDoiChuNha.SelectedIndex = -1;
                cboDoiKhach.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                HDMessageBox.Show("Lỗi trong làm mới dữ liệu bóng đá: " + ex.Message);
            }
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
                        dicDanhsachdoi.Clear();
                        cboDoiChuNha.Properties.Items.Clear();
                        cboDoiKhach.Properties.Items.Clear();
                        _lstTeams = Utils.GetObject<List<Object.Team>>(danhsachdoiPath);
                        foreach (var data in _lstTeams)
                        {
                            cboDoiChuNha.Properties.Items.Add(data.Name);
                            cboDoiKhach.Properties.Items.Add(data.Name);
                            dicDanhsachdoi.Add(data.TeamCode, data.Name);
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
                ManagePlayersForm frmPlayer = new ManagePlayersForm(dicDanhsachgiaidau.FirstOrDefault(x => x.Value == cboGiaiDau.Text).Key, dicDanhsachdoi.FirstOrDefault(x => x.Value == cboDoiChuNha.Text).Key);
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
            var templatesXmlPath = Path.Combine(Path.Combine(Application.StartupPath, "Data"), "Danhsachcauthu" + dicDanhsachdoi.FirstOrDefault(x => x.Value == cboDoiChuNha.Text).Key + ".xml");
            try
            {
                if (File.Exists(templatesXmlPath))
                {
                    bsHomePlayer.Clear();
                    bsHomePlayerDuBi.Clear();
                    bsGhibanChu.Clear();
                    cboGhibanChu.Properties.Items.Clear();
                    bsGhibanChu.List.Clear();
                    var lstTemplate = Utils.GetObject<List<Object.Player>>(templatesXmlPath).Where(a => a.IsNotSubstitution == true);
                    foreach (var temp in lstTemplate)
                    {
                        bsHomePlayer.Add(new View.Player()
                        {
                            mObj = temp
                        });
                        cboGhibanChu.Properties.Items.Add(temp.Name);
                    }
                    var lstDubi = Utils.GetObject<List<Object.Player>>(templatesXmlPath).Where(a => a.IsSubstitution == true);
                    foreach (var temp in lstDubi)
                    {
                        bsHomePlayerDuBi.Add(new View.Player()
                        {
                            mObj = temp
                        });
                        cboGhibanChu.Properties.Items.Add(temp.Name);
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
            var templatesXmlPath = Path.Combine(Path.Combine(Application.StartupPath, "Data"), "Danhsachcauthu" + dicDanhsachdoi.FirstOrDefault(x => x.Value == cboDoiKhach.Text).Key + ".xml");
            try
            {
                if (File.Exists(templatesXmlPath))
                {
                    bsAwayPlayer.Clear();
                    bsAwayPlayerDuBi.Clear();
                    bsGhibanKhach.Clear();
                    cboGhiBanKhach.Properties.Items.Clear();
                    bsGhibanKhach.List.Clear();
                    var lstTemplate = Utils.GetObject<List<Object.Player>>(templatesXmlPath).Where(a => a.IsNotSubstitution == true);
                    foreach (var temp in lstTemplate)
                    {
                        bsAwayPlayer.Add(new View.Player()
                        {
                            mObj = temp
                        });
                        cboGhiBanKhach.Properties.Items.Add(temp.Name);
                    }
                    var lstDuBi = Utils.GetObject<List<Object.Player>>(templatesXmlPath).Where(a => a.IsSubstitution == true);
                    foreach (var temp in lstDuBi)
                    {
                        bsAwayPlayerDuBi.Add(new View.Player()
                        {
                            mObj = temp
                        });
                        cboGhiBanKhach.Properties.Items.Add(temp.Name);
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
                ManagePlayersForm frmPlayer = new ManagePlayersForm(dicDanhsachgiaidau.FirstOrDefault(x => x.Value == cboGiaiDau.Text).Key, dicDanhsachdoi.FirstOrDefault(x => x.Value == cboDoiKhach.Text).Key);
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

        private void btnSetTime_Click(object sender, EventArgs e)
        {
            _thoigianTranPhut = (int)nPhut.Value;
            _thoigianTranGiay = (int)nGiay.Value;
        }
        bool isTySoGoc = false;
        bool _tySoGocOn = false;
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
                        _tySoGocOn = true;
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
                _tySoGocOn = false;
            }
            catch
            {
                //HDMessageBox.Show("404 - Template not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnOnHLVChu_Click(object sender, EventArgs e)
        {
            try
            {
                BatTemplate("BongDa_HLV.ft");
            }
            catch { }
        }

        private void btnOffHLVChu_Click(object sender, EventArgs e)
        {
            try
            {
                OffTemplate(105);
            }
            catch
            {
                HDMessageBox.Show("404 - Template not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnOnHLVKhach_Click(object sender, EventArgs e)
        {
            try
            {
                BatTemplate("BongDa_HLV.ft", false);
            }
            catch { }
        }

        private void btnOffHLVKhach_Click(object sender, EventArgs e)
        {
            try
            {
                OffTemplate(105);
            }
            catch
            {
                HDMessageBox.Show("404 - Template not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnOnNoiDungChu_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboNoiDungChu.Text == "Thay người")
                {
                    BatTemplate("BongDa_ThayNguoi.ft");
                    var playerIn = GetPlayerIn(true);
                    var playerOut = GetPlayerOut(true);
                    bsHomePlayer.List.Insert(bsHomePlayer.List.IndexOf(playerOut), playerIn);
                    bsHomePlayerDuBi.List.Insert(bsHomePlayerDuBi.List.IndexOf(playerIn), playerOut);
                    bsHomePlayer.List.Remove(playerOut);
                    bsHomePlayerDuBi.List.Remove(playerIn);

                }
                else if (cboNoiDungChu.Text == "Ghi bàn")
                {
                    BatTemplate("BongDa_CauThu.ft");
                }
                else if (cboNoiDungChu.Text == "Thẻ vàng")
                {
                    BatTemplate("BongDa_TheVang.ft");
                }
                else if (cboNoiDungChu.Text == "2 thẻ vàng")
                {
                    BatTemplate("BongDa_2TheVang.ft");
                    var playerOut = GetPlayerOut(true);
                    bsHomePlayer.List.Remove(playerOut);
                }
                else if (cboNoiDungChu.Text == "Thẻ đỏ")
                {
                    BatTemplate("BongDa_TheDo.ft");
                    var playerOut = GetPlayerOut(true);
                    bsHomePlayer.List.Remove(playerOut);
                }
            }
            catch (Exception ex)
            {
                HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnOnNoiDungKhach_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboNoiDungKhach.Text == "Thay người")
                {
                    BatTemplate("BongDa_ThayNguoi.ft", false);
                    var playerIn = GetPlayerIn(false);
                    var playerOut = GetPlayerOut(false);
                    bsAwayPlayer.List.Insert(bsAwayPlayer.List.IndexOf(playerOut), playerIn);
                    bsAwayPlayerDuBi.List.Insert(bsAwayPlayerDuBi.List.IndexOf(playerIn), playerOut);
                    bsAwayPlayer.List.Remove(playerOut);
                    bsAwayPlayerDuBi.List.Remove(playerIn);
                }
                else if (cboNoiDungKhach.Text == "Ghi bàn")
                {
                    BatTemplate("BongDa_CauThu.ft", false);
                }
                else if (cboNoiDungKhach.Text == "Thẻ vàng")
                {
                    BatTemplate("BongDa_TheVang.ft", false);
                }
                else if (cboNoiDungKhach.Text == "2 thẻ vàng")
                {
                    BatTemplate("BongDa_2TheVang.ft", false);
                    var playerOut = GetPlayerOut(false);
                    bsAwayPlayer.List.Remove(playerOut);
                }
                else if (cboNoiDungKhach.Text == "Thẻ đỏ")
                {
                    BatTemplate("BongDa_TheDo.ft", false);
                    var playerOut = GetPlayerOut(false);
                    bsAwayPlayer.List.Remove(playerOut);
                }
            }
            catch { }
        }

        private void btnOffNoiDungChu_Click(object sender, EventArgs e)
        {
            try
            {
                OffTemplate(105);
            }
            catch
            {
                HDMessageBox.Show("404 - Template not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnOffNoiDungKhach_Click(object sender, EventArgs e)
        {
            try
            {
                OffTemplate(105);
            }
            catch
            {
                HDMessageBox.Show("404 - Template not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnOnDanhsachchinhthuc_Click(object sender, EventArgs e)
        {
            try
            {
                BatTemplate("BongDa_DanhSachChinhThuc.ft");
            }
            catch { }
        }

        private void btnOffDanhsachchinhthuc_Click(object sender, EventArgs e)
        {
            OffTemplate(105);
        }

        private void btnOnDanhsachdubi_Click(object sender, EventArgs e)
        {
            try
            {
                BatTemplate("BongDa_DanhSachDuBi.ft");
            }
            catch { }
        }

        private void btnOffDanhsachdubi_Click(object sender, EventArgs e)
        {
            OffTemplate(105);
        }
        private void BatTemplate(string tempName, bool isChu = true, int layer = 105)
        {
            if (cboGiaiDauTennis.Text.Length > 0)
                try
                {
                    if (xTabMain.SelectedTabPage.Equals(xTabPageBongda))
                    {
                        _tempName = tempName;
                    }
                    else
                    {
                        _tempName = _TennisLeagueCode + "_" + tempName;
                    }
                    List<Object.Property> runtimeProperties = new List<Object.Property>();
                    runtimeProperties.Add(new Object.Property()
                    {
                        Name = "Loops",
                        Value = "false"
                    });
                    string xmlStr = "<Track_Property>" + GetAddXmlString(isChu) + "</Track_Property>";
                    OnTemplate(layer, _tempName, 1, null, runtimeProperties, xmlStr);
                    ViewTemplate(_tempName, 0, isChu);
                }
                catch { }
            else
                HDMessageBox.Show("Chọn Giải đấu trước!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                BatTemplate("BongDa_ThongSo_DutDiem.ft");
            }
            catch { }
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            BatTemplate("BongDa_ThongSo_DutDiemTrungDich.ft");
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            BatTemplate("BongDa_ThongSo_PhamLoi.ft");
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            BatTemplate("BongDa_ThongSo_TheVang.ft");
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            BatTemplate("BongDa_ThongSo_TheDo.ft");
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            BatTemplate("BongDa_ThongSo_VietVi.ft");
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            BatTemplate("BongDa_ThongSo_PhatGoc.ft");
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            BatTemplate("BongDa_ThongSo_KiemSoatBong.ft");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OffTemplate(105);
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            OffTemplate(105);
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            OffTemplate(105);
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            OffTemplate(105);
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            OffTemplate(105);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            OffTemplate(105);
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            OffTemplate(105);
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            OffTemplate(105);
        }
        private void simpleButton18_Click(object sender, EventArgs e)
        {
            switch (cboLoaiDoHoaTySo.Text)
            {
                case "Tỷ số không kèm danh sách ghi bàn":
                    BatTemplate("BongDa_TySo.ft");
                    break;
                case "Tỷ số kèm danh sách ghi bàn Chủ":
                    BatTemplate("BongDa_TySo_GhiBanChu.ft");
                    break;
                case "Tỷ số kèm danh sách ghi bàn Khách":
                    BatTemplate("BongDa_TySo_GhiBanKhach.ft");
                    break;
                case "Tỷ số kèm danh sách ghi bàn đẩy đủ":
                    BatTemplate("BongDa_TySo_GhiBan.ft");
                    break;
                case "Thông số cuối":
                    BatTemplate("BongDa_ThongSoCuoiTran.ft");
                    break;
            };
        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            OffTemplate(105);
        }

        private void simpleButton22_Click(object sender, EventArgs e)
        {
            BatTemplate("BongDa_TrongTai.ft");
        }

        private void simpleButton21_Click(object sender, EventArgs e)
        {
            OffTemplate(105);
        }

        private void simpleButton20_Click(object sender, EventArgs e)
        {
            BatTemplate("BongDa_BarTen.ft");
        }

        private void simpleButton19_Click(object sender, EventArgs e)
        {
            OffTemplate(105);
        }

        private void simpleButton24_Click(object sender, EventArgs e)
        {
            BatTemplate("BongDa_ThoiTiet.ft");
        }

        private void simpleButton23_Click(object sender, EventArgs e)
        {
            OffTemplate(105);
        }

        private void simpleButton26_Click(object sender, EventArgs e)
        {
            if (cboGhibanChu.Text.Length > 0 && txtPhutChu.Text.Length > 0)
            {
                bsGhibanChu.List.Add(new Object.Goal
                {
                    Name = cboGhibanChu.Text,
                    StrMin = txtPhutChu.Text
                });
            }
            else
            {
                HDMessageBox.Show("Thiếu thông tin cầu thủ/phút ghi bàn!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton27_Click(object sender, EventArgs e)
        {
            if (gridView2.FocusedRowHandle < 0)
            {
                HDMessageBox.Show("Chưa chọn cầu thủ để xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var temp = gridView2.GetFocusedRow() as Object.Goal;
                bsGhibanChu.List.Remove(temp);
            }
        }

        private void gridView2_RowClick(object sender, RowClickEventArgs e)
        {
            var temp = gridView2.GetFocusedRow() as Object.Goal;
            cboGhibanChu.Text = temp.Name;
            txtPhutChu.Text = temp.StrMin;
        }

        private void simpleButton25_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsGhibanChu.List.Count == 0)
                {
                    HDMessageBox.Show("Chưa chọn cầu thủ để lưu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                if (cboGhibanChu.Text.Length > 0 && txtPhutChu.Text.Length > 0)
                {
                    var temp = gridView2.GetFocusedRow() as Object.Goal;

                    bsGhibanChu.List.Insert(bsGhibanChu.List.IndexOf(temp), new Object.Goal()
                    {
                        Name = cboGhibanChu.Text,
                        StrMin = txtPhutChu.Text
                    });
                    bsGhibanChu.List.Remove(temp);
                }
                else
                {
                    HDMessageBox.Show("Chọn cầu thủ, phút trước!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView7_RowClick(object sender, RowClickEventArgs e)
        {
            var temp = gridView7.GetFocusedRow() as Object.Goal;
            cboGhiBanKhach.Text = temp.Name;
            txtPhutKhach.Text = temp.StrMin;
        }

        private void simpleButton30_Click(object sender, EventArgs e)
        {
            if (cboGhiBanKhach.Text.Length > 0 && txtPhutKhach.Text.Length > 0)
            {
                bsGhibanKhach.List.Add(new Object.Goal
                {
                    Name = cboGhiBanKhach.Text,
                    StrMin = txtPhutKhach.Text
                });
            }
            else
            {
                HDMessageBox.Show("Thiếu thông tin cầu thủ/phút ghi bàn!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton29_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsGhibanKhach.List.Count == 0)
                {
                    HDMessageBox.Show("Chưa chọn cầu thủ để lưu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                if (cboGhiBanKhach.Text.Length > 0 && txtPhutKhach.Text.Length > 0)
                {
                    var temp = gridView2.GetFocusedRow() as Object.Goal;

                    bsGhibanKhach.List.Insert(bsGhibanKhach.List.IndexOf(temp), new Object.Goal()
                    {
                        Name = cboGhiBanKhach.Text,
                        StrMin = txtPhutKhach.Text
                    });
                    bsGhibanKhach.List.Remove(temp);
                }
                else
                {
                    HDMessageBox.Show("Chọn cầu thủ, phút trước!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton28_Click(object sender, EventArgs e)
        {
            if (gridView7.FocusedRowHandle < 0)
            {
                HDMessageBox.Show("Chưa chọn cầu thủ để xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var temp = gridView7.GetFocusedRow() as Object.Goal;
                bsGhibanKhach.List.Remove(temp);
            }
        }

        private void btnBrowseLogoBarTen_Click(object sender, EventArgs e)
        {
            OpenFileInFolderDialog frm = new OpenFileInFolderDialog();
            frm.RootFolder = Path.Combine(AppSetting.Default.MediaFolder, "Icons");
            frm.FilterString = "*.tga;*.png;*.jpg";
            if (frm.ShowDialog() == DialogResult.OK)
                txtLogoBarTen.Text = frm.FileName;
        }
        bool isGatLen = true;
        private void btnGat_Click(object sender, EventArgs e)
        {
            if (isGatLen)
            {
                if (_tySoGocOn)
                {
                    btnOffTySoGoc.PerformClick();
                    Thread.Sleep(500);
                }
                BatTemplate("BongDa_Gat.ft");
                isGatLen = false;
                btnGat.ToolTip = "Lên Gạt và lên đồ họa khác";
            }
            else
            {
                BatTemplate("BongDa_Gat.ft");
                Thread.Sleep(1000);
                btnOnTySoGoc.PerformClick();
                isGatLen = true;
                btnGat.ToolTip = "Lên Gạt và xuống đồ họa khác";
            }
        }

        private void btnManageTemplates_Click(object sender, EventArgs e)
        {
            ManageTemplateForm mTemp = new ManageTemplateForm(cboTemplateType.Text);
            mTemp.Show();
            mTemp.Activate();
        }
        #endregion

        #region Tennis
        private void btnOnTySoLonTennis_Click(object sender, EventArgs e)
        {
            if (ck3set.Checked)
                BatTemplate("TySoLon3Set.ft");
            else if (ck5set.Checked)
                BatTemplate("TySoLon.ft");
        }

        private void btnManageLeagueTennis_Click(object sender, EventArgs e)
        {
            FormManageTennisLeague frmManageLeague = new FormManageTennisLeague();
            frmManageLeague.Show();
            frmManageLeague.Activate();
        }

        private void btnManageTeamTennis_Click(object sender, EventArgs e)
        {
            if (cboGiaiDauTennis.Text.Trim().Length == 0)
            {
                HDMessageBox.Show("Chọn giải đấu trước!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                FormManageTennisTeam formManageTeam = new FormManageTennisTeam(cboGiaiDauTennis.Text);
                formManageTeam.Show();
                formManageTeam.Activate();
            }
        }
        private void btnRefreshGiaiDau_Click(object sender, EventArgs e)
        {
            RefreshGiaiDau();
        }
        public void RefreshGiaiDau()
        {
            _danhsachgiaiTennisPath = Path.Combine(Path.Combine(Application.StartupPath, "Data/Tennis"), "Danhsachgiaidau.xml");
            try
            {
                if (File.Exists(_danhsachgiaiTennisPath))
                {
                    cboGiaiDauTennis.Properties.Items.Clear();
                    dicDanhsachgiaidauTennis.Clear();
                    _lstTennisLeagues = Utils.GetObject<List<Object.Tennis.League>>(_danhsachgiaiTennisPath);
                    foreach (var temp in _lstTennisLeagues)
                    {
                        cboGiaiDauTennis.Properties.Items.Add(temp.Name);
                        dicDanhsachgiaidauTennis.Add(temp.LeagueCode, temp.Name);
                    }
                    cboGiaiDauTennis.SelectedIndex = -1;
                    cboTennisTeam1.SelectedIndex = -1;
                    cboTennisTeam2.SelectedIndex = -1;
                }
                else
                {
                    File.Create(_danhsachgiaiTennisPath).Dispose();
                }
            }
            catch (Exception ex)
            {
                HDMessageBox.Show("Lỗi trong làm mới dữ liệu tennis: " + ex.Message);
            }

        }
        private void cboGiaiDauTennis_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _TennisLeagueCode = dicDanhsachgiaidauTennis.FirstOrDefault(x => x.Value == cboGiaiDauTennis.Text).Key;
                var danhsachdoiPath = Path.Combine(Path.Combine(Application.StartupPath, "Data/Tennis"), "Danhsachdoi" + dicDanhsachgiaidauTennis.FirstOrDefault(x => x.Value == cboGiaiDauTennis.Text).Key + ".xml");
                try
                {
                    if (File.Exists(danhsachdoiPath))
                    {
                        dicDanhsachdoiTennis.Clear();
                        cboTennisTeam1.Properties.Items.Clear();
                        cboTennisTeam2.Properties.Items.Clear();
                        _lstTennisTeams = Utils.GetObject<List<Object.Tennis.Team>>(danhsachdoiPath);
                        foreach (var data in _lstTennisTeams)
                        {
                            cboTennisTeam1.Properties.Items.Add(data.Name);
                            cboTennisTeam2.Properties.Items.Add(data.Name);
                            dicDanhsachdoiTennis.Add(data.TeamCode, data.Name);
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
        private void btnQuanlydanhsachTeam1_Click(object sender, EventArgs e)
        {
            if (cboGiaiDauTennis.Text.Trim().Length == 0 || cboTennisTeam1.Text.Trim().Length == 0)
            {
                HDMessageBox.Show("Chọn giải đấu và đội trước!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ManageTennisPlayersForm frmPlayer = new ManageTennisPlayersForm(dicDanhsachgiaidauTennis.FirstOrDefault(x => x.Value == cboGiaiDauTennis.Text).Key, dicDanhsachdoiTennis.FirstOrDefault(x => x.Value == cboTennisTeam1.Text).Key);
                frmPlayer.Show();
                frmPlayer.Activate();
            }
        }

        private void btnQuanlydanhsachTeam2_Click(object sender, EventArgs e)
        {
            if (cboGiaiDauTennis.Text.Trim().Length == 0 || cboTennisTeam2.Text.Trim().Length == 0)
            {
                HDMessageBox.Show("Chọn giải đấu và đội trước!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ManageTennisPlayersForm frmPlayer = new ManageTennisPlayersForm(dicDanhsachgiaidauTennis.FirstOrDefault(x => x.Value == cboGiaiDauTennis.Text).Key, dicDanhsachdoiTennis.FirstOrDefault(x => x.Value == cboTennisTeam2.Text).Key);
                frmPlayer.Show();
                frmPlayer.Activate();
            }
        }
        private void cboTennisTeam1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var temp in _lstTennisTeams)
            {
                if (temp.Name == cboTennisTeam1.Text)
                {
                    txtShortNameTeam1.Text = temp.ShortName;
                    txtHLVTennisTeam1.Text = temp.CoachName;
                    txtDonviTennisTeam1.Text = temp.City;
                    break;
                }
            }
            bsTennisPlayer1.List.Clear();            
            var templatesXmlPath = Path.Combine(Path.Combine(Application.StartupPath, "Data/Tennis"), "Danhsachcauthu" + dicDanhsachdoiTennis.FirstOrDefault(x => x.Value == cboTennisTeam1.Text).Key + ".xml");
            try
            {
                if (File.Exists(templatesXmlPath))
                {
                    cboTeam1Player1.Properties.Items.Clear();
                    cboTeam1Player2.Properties.Items.Clear();
                    var lstTemplate = Utils.GetObject<List<Object.Tennis.Player>>(templatesXmlPath);
                    foreach (var temp in lstTemplate)
                    {
                        cboTeam1Player1.Properties.Items.Add(temp.Name);
                        cboTeam1Player2.Properties.Items.Add(temp.Name);
                        bsTennisPlayer1.List.Add(temp);
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

        private void cboTennisTeam2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var temp in _lstTennisTeams)
            {
                if (temp.Name == cboTennisTeam2.Text)
                {
                    txtShortNameTeam2.Text = temp.ShortName;
                    txtHLVTennisTeam2.Text = temp.CoachName;
                    txtDonviTennisTeam2.Text = temp.City;
                    break;
                }
            }
            bsTennisPlayer2.List.Clear();
            var templatesXmlPath = Path.Combine(Path.Combine(Application.StartupPath, "Data/Tennis"), "Danhsachcauthu" + dicDanhsachdoiTennis.FirstOrDefault(x => x.Value == cboTennisTeam2.Text).Key + ".xml");
            try
            {
                if (File.Exists(templatesXmlPath))
                {
                    cboTeam2Player1.Properties.Items.Clear();
                    cboTeam2Player2.Properties.Items.Clear();
                    var lstTemplate = Utils.GetObject<List<Object.Tennis.Player>>(templatesXmlPath);
                    foreach (var temp in lstTemplate)
                    {
                        cboTeam2Player1.Properties.Items.Add(temp.Name);
                        cboTeam2Player2.Properties.Items.Add(temp.Name);
                        bsTennisPlayer2.List.Add(temp);
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
        private void AddTySoChungCuoc1(int val1, int val2)
        {
            if ((val1 >= 6 && val2 <= (val1 - 2)))
            {
                nTySo1.Value++;
            }
        }
        private void AddTySoChungCuoc2(int val1, int val2)
        {
            if ((val1 >= 6 && val2 <= (val1 - 2)))
            {
                nTySo2.Value++;
            }
        }
        private void btnDiemPlayer1_Click(object sender, EventArgs e)
        {
            if (cboPointTeam2.Text == "AD")
            {
                cboPointTeam1.SelectedIndex = 4;
                cboPointTeam2.SelectedIndex = 4;
            }
            else
            {
                if ((cboPointTeam1.Text == "40" && cboPointTeam2.Text != "40") || (cboPointTeam1.Text == "AD"))
                {
                    if (rSet1.Checked)
                    {
                        nDiemSet1Player1.Value++;
                        AddTySoChungCuoc1((int)nDiemSet1Player1.Value, (int)nDiemSet1Player2.Value);
                    }
                    else if (rSet2.Checked)
                    {
                        nDiemSet2Player1.Value++;
                        AddTySoChungCuoc1((int)nDiemSet2Player1.Value, (int)nDiemSet2Player2.Value);
                    }
                    else if (rSet3.Checked)
                    {
                        nDiemSet3Player1.Value++;
                        AddTySoChungCuoc1((int)nDiemSet3Player1.Value, (int)nDiemSet3Player2.Value);
                    }
                    else if (rSet4.Checked)
                    {
                        nDiemSet4Player1.Value++;
                        AddTySoChungCuoc1((int)nDiemSet4Player1.Value, (int)nDiemSet4Player2.Value);
                    }
                    else if (rSet5.Checked)
                    {
                        nDiemSet5Player1.Value++;
                        AddTySoChungCuoc1((int)nDiemSet5Player1.Value, (int)nDiemSet5Player2.Value);
                    }
                    cboPointTeam2.SelectedIndex = 1;
                    if (ckGiaobong1.Checked)
                    {
                        ckGiaobong2.Checked = true;
                    }
                    else ckGiaobong2.Checked = false;
                }
                if (cboPointTeam1.SelectedIndex < 5)
                {
                    if (cboPointTeam1.SelectedIndex == 4 && cboPointTeam2.SelectedIndex != 4)
                    {
                        cboPointTeam1.SelectedIndex = 1;
                        cboPointTeam2.SelectedIndex = 1;
                    }
                    else
                    {
                        cboPointTeam1.SelectedIndex++;
                        if (cboPointTeam1.SelectedIndex == 5)
                            cboPointTeam2.SelectedIndex = 0;
                    }
                }
                else
                {
                    cboPointTeam1.SelectedIndex = 1;
                }
            }
        }

        private void btnDiemPlayer2_Click(object sender, EventArgs e)
        {
            if (cboPointTeam1.Text == "AD")
            {
                cboPointTeam2.SelectedIndex = 4;
                cboPointTeam1.SelectedIndex = 4;
            }
            else
            {
                if ((cboPointTeam2.Text == "40" && cboPointTeam1.Text != "40") || (cboPointTeam2.Text == "AD"))
                {
                    if (rSet1.Checked)
                    {
                        nDiemSet1Player2.Value++;
                        AddTySoChungCuoc2((int)nDiemSet1Player2.Value, (int)nDiemSet1Player1.Value);
                    }
                    else if (rSet2.Checked)
                    {
                        nDiemSet2Player2.Value++; AddTySoChungCuoc2((int)nDiemSet2Player2.Value, (int)nDiemSet2Player1.Value);
                    }
                    else if (rSet3.Checked)
                    {
                        nDiemSet3Player2.Value++; AddTySoChungCuoc2((int)nDiemSet3Player2.Value, (int)nDiemSet3Player1.Value);
                    }
                    else if (rSet4.Checked)
                    {
                        nDiemSet4Player2.Value++; AddTySoChungCuoc2((int)nDiemSet4Player2.Value, (int)nDiemSet4Player1.Value);
                    }
                    else if (rSet5.Checked)
                    {
                        nDiemSet5Player2.Value++; AddTySoChungCuoc2((int)nDiemSet5Player2.Value, (int)nDiemSet5Player1.Value);
                    }
                    cboPointTeam1.SelectedIndex = 1;
                    if (ckGiaobong1.Checked)
                    {
                        ckGiaobong2.Checked = true;
                    }
                    else ckGiaobong2.Checked = false;
                }
                if (cboPointTeam2.SelectedIndex < 5)
                {
                    if (cboPointTeam2.SelectedIndex == 4 && cboPointTeam1.SelectedIndex != 4)
                    {
                        cboPointTeam2.SelectedIndex = 1;
                        cboPointTeam1.SelectedIndex = 1;
                    }
                    else
                    {
                        cboPointTeam2.SelectedIndex++;
                        if (cboPointTeam2.SelectedIndex == 5)
                            cboPointTeam1.SelectedIndex = 0;
                    }
                }
                else
                {
                    cboPointTeam2.SelectedIndex = 1;
                }
            }
        }

        private void simpleButton39_Click(object sender, EventArgs e)
        {
            if (ckWithThongTinPhu.Checked)
            {
                BatTemplate("TySoNho.ft");
                BatTemplate("TySoNho_GiaoBong.ft", true, 106);
                BatTemplate("ThongTinPhu.ft", true, 107);
            }
            else
            {
                BatTemplate("TySoNho.ft");
                BatTemplate("TySoNho_GiaoBong.ft", true, 106);
            }
        }
        private void btnLiveUpdateTennis_Click(object sender, EventArgs e)
        {
            try
            {
                string xmlStr = "<Track_Property>" + GetAddXmlString() + "</Track_Property>";
                player.Update(1, xmlStr.Replace("\\n", "\n"));
                player.Refresh();
                cgServer.UpdateTemplate(105, xmlStr.Replace("\\", "\\\\"), 0);
                cgServer.UpdateTemplate(106, xmlStr.Replace("\\", "\\\\"), 0);
                cgServer.UpdateTemplate(107, xmlStr.Replace("\\", "\\\\"), 0);

            }
            catch (Exception ex)
            {
                HDMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton31_Click(object sender, EventArgs e)
        {
            try
            {
                OffTemplate(105);
            }
            catch
            {
                HDMessageBox.Show("404 - Template not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ckGiaobong1_CheckedChanged(object sender, EventArgs e)
        {
            if (ckGiaobong1.Checked)
            {
                ckGiaobong2.Checked = false;
            }
            else
            {
                ckGiaobong2.Checked = true;
            }
        }

        private void ckGiaobong2_CheckedChanged(object sender, EventArgs e)
        {
            if (ckGiaobong2.Checked)
            {
                ckGiaobong1.Checked = false;
            }
            else
            {
                ckGiaobong1.Checked = true;
            }
        }
        private void simpleButton32_Click(object sender, EventArgs e)
        {
            BatTemplate("ThongTinPhu.ft", true, 107);
        }

        private void simpleButton40_Click(object sender, EventArgs e)
        {
            OffTemplate(107);
        }

        private void simpleButton41_Click(object sender, EventArgs e)
        {
            if (ckWithThongTinPhu.Checked)
            {
                OffTemplate(107);
                OffTemplate(106);
                OffTemplate(105);
            }
            else
            {
                OffTemplate(106);
                OffTemplate(105);
            }
        }

        private void simpleButton34_Click(object sender, EventArgs e)
        {
            BatTemplate("ThongSoNho.ft");
        }

        private void simpleButton42_Click(object sender, EventArgs e)
        {
            OffTemplate(105);
        }

        private void simpleButton33_Click(object sender, EventArgs e)
        {
            BatTemplate("ThongKeCuoi.ft");
        }
        #endregion

        private void btnLamMoiBongDa_Click(object sender, EventArgs e)
        {
            LamMoiBongDa();
        }

        private void xTabMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xTabMain.SelectedTabPage.Equals(xTabPageBongda))
            {
                cboTemplateType.SelectedIndex = 0;
            }
            else if (xTabMain.SelectedTabPage.Equals(xTabPageTennis))
            {
                cboTemplateType.SelectedIndex = 1;
            }
        }

        private void ck5set_CheckedChanged(object sender, EventArgs e)
        {
            if (ck5set.Checked)
                ck3set.Checked = false;            
        }

        private void ck3set_CheckedChanged(object sender, EventArgs e)
        {
            if (ck3set.Checked)
                ck5set.Checked = false;
        }
    }
}
