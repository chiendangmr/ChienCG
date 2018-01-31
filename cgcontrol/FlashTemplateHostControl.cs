using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Svt.Caspar;
using System.IO;

namespace CGPreviewControl
{
    public partial class FlashTemplateHostControl : UserControl
    {
        private const string AddRequestTemplate20 = "<invoke name=\"Add\" returntype=\"xml\"><arguments><number>$LAYER$</number><string>$TEMPLATE$</string>$PLAY$<string>$LABEL$</string><string><![CDATA[$DATA$]]></string></arguments></invoke>";
        private const string RemoveRequestTemplate20 = "<invoke name=\"Delete\" returntype=\"xml\"><arguments><array><property id=\"0\"><number>$LAYER$</number></property></array></arguments></invoke>";
        private const string PlayRequestTemplate20 = "<invoke name=\"Play\" returntype=\"xml\"><arguments><array><property id=\"0\"><number>$LAYER$</number></property></array></arguments></invoke>";
        private const string StopRequestTemplate20 = "<invoke name=\"Stop\" returntype=\"xml\"><arguments><array><property id=\"0\"><number>$LAYER$</number></property></array><number>$MIXDURATION$</number></arguments></invoke>";
        private const string NextRequestTemplate20 = "<invoke name=\"Next\" returntype=\"xml\"><arguments><array><property id=\"0\"><number>$LAYER$</number></property></array></arguments></invoke>";
        private const string UpdateRequestTemplate20 = "<invoke name=\"SetData\" returntype=\"xml\"><arguments><array><property id=\"0\"><number>$LAYER$</number></property></array><string><![CDATA[$DATA$]]></string></arguments></invoke>";
        private const string GotoRequestTemplate20 = "<invoke name=\"Goto\" returntype=\"xml\"><arguments><array><property id=\"0\"><number>$LAYER$</number></property></array><string>$LABEL$</string></arguments></invoke>";
        private const string InvokeRequestTemplate20 = "<invoke name=\"Invoke\" returntype=\"xml\"><arguments><array><property id=\"0\"><number>$LAYER$</number></property></array><string>$METHOD$</string></arguments></invoke>";
        private const string GetPropertiesTemplate20 = "<invoke name=\"GetProperties\" returntype=\"xml\"><arguments><string><![CDATA[$DATA$]]></string></arguments></invoke>";
        public FlashTemplateHostControl()
        {
            InitializeComponent();

            PrepareNewFlash();

            TemplateFolder = Environment.CurrentDirectory;
            AspectControl = Aspects.Aspect169;
            myDelegate = new updatePlayer(Update);
        }
        public delegate void updatePlayer(int layer, string xml);
        public updatePlayer myDelegate;

        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return shockwaveFlashControl1.FlashActiveX.ContextMenuStrip;
            }
            set
            {
                shockwaveFlashControl1.FlashActiveX.ContextMenuStrip = value;
            }
        }

        public void PrepareNewFlash()
        {
            this.Controls.Remove(this.shockwaveFlashControl1);
            this.shockwaveFlashControl1 = new ShockwaveFlashControl();
            this.Controls.Add(this.shockwaveFlashControl1);
            this.shockwaveFlashControl1.FlashActiveX.BackgroundColor = Color.FromArgb(0, bgColor).ToArgb();
            if (!string.IsNullOrEmpty(templateHost_) && System.IO.File.Exists(templateHost_))
            {
                this.shockwaveFlashControl1.FlashActiveX.Movie = templateHost_;
            }

            control_Resize(this, EventArgs.Empty);
        }

        private Color bgColor;
        public Color BackgroundColor
        {
            set { bgColor = value; shockwaveFlashControl1.FlashActiveX.BackgroundColor = Color.FromArgb(0, bgColor).ToArgb(); }
            get { return bgColor; }
        }

        string templateHost_ = string.Empty;
        [Browsable(false)]
        public string TemplateHost
        {
            get { return templateHost_; }
            set
            {
                templateHost_ = value;
                if (!string.IsNullOrEmpty(value) && System.IO.File.Exists(templateHost_))
                {
                    templateFolder_ = System.IO.Path.GetDirectoryName(templateHost_);
                    shockwaveFlashControl1.FlashActiveX.Movie = templateHost_;

                    var cgVersion = System.IO.Path.GetFileNameWithoutExtension(templateHost_);

                    if (cgVersion.StartsWith("cg20"))
                        Version = Versions.Version20;

                    Valid = true;
                }
                else
                    Valid = false;
            }
        }

        string templateFolder_ = string.Empty;
        [Browsable(false)]
        public string TemplateFolder
        {
            get
            {
                return templateFolder_;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    try
                    {
                        string[] files = System.IO.Directory.GetFiles(value, "cg20.fth*");
                        if (files != null && files.Length > 0)
                        {
                            for (int i = 0; i < files.Length; ++i)
                                files[i] = files[i].ToUpper();

                            Array.Sort<string>(files);

                            for (int i = files.Length - 1; i >= 0; i--)
                            {
                                TemplateHost = files[i];
                                break;
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        public void Clear()
        {
            PrepareNewFlash();
        }

        [Obsolete("use ICGDataContainer for CGData instead", false)]
        public bool Add(Svt.Caspar.CasparCGItem item)
        {
            if (item != null)
                return Add(item, item.Layer);
            return false;
        }

        [Obsolete("use ICGDataContainer for CGData instead", false)]
        public bool Add(CasparCGItem item, int layer)
        {
            if (item != null)
            {
                string fullFilename = System.IO.Path.GetFullPath(System.IO.Path.Combine(TemplateFolder, item.TemplateIdentifier));

                if (System.IO.File.Exists(fullFilename + ".ft"))
                {
                    string dataxml = Svt.Caspar.CGDataPair.ToXml(item.Data);
                    string template = item.TemplateIdentifier;

                    string addRequest = AddRequestTemplate20;
                    StringBuilder request = new StringBuilder(addRequest, dataxml.Length + addRequest.Length);
                    request.Replace("$LAYER$", layer.ToString());
                    request.Replace("$TEMPLATE$", template);
                    request.Replace("$MIXDURATION$", "0");
                    request.Replace("$PLAY$", "<true />");
                    request.Replace("$LABEL$", string.Empty);
                    request.Replace("$DATA$", dataxml);

                    InvokeFlashCall(request.ToString());
                    return true;
                }
            }
            return false;
        }
        public bool Add(int layer, string template)
        {
            return Add(layer, template, false, string.Empty);
        }
        public bool Add(int layer, string template, bool bPlayOnLoad)
        {
            return Add(layer, template, bPlayOnLoad, string.Empty);
        }
        public bool Add(int layer, string template, ICGDataContainer data)
        {
            return Add(layer, template, false, (data != null) ? data.ToXml() : string.Empty);
        }
        public bool Add(int layer, string template, bool bPlayOnLoad, ICGDataContainer data)
        {
            return Add(layer, template, bPlayOnLoad, (data != null) ? data.ToXml() : string.Empty);
        }
        public bool Add(int layer, string template, string data)
        {
            return Add(layer, template, false, data);
        }
        public bool Add(int layer, string template, bool bPlayOnLoad, string data)
        {
            if (Path.GetExtension(template).ToLower() != ".ft")
                template += ".ft";

            string fullFilename = Path.GetFullPath(Path.Combine(TemplateFolder, template));

            if (File.Exists(fullFilename))
            {
                string addRequest = AddRequestTemplate20;
                StringBuilder request = new StringBuilder(addRequest, data.Length + addRequest.Length);

                request.Replace("$LAYER$", layer.ToString());
                request.Replace("$TEMPLATE$", template);
                request.Replace("$MIXDURATION$", "0");
                request.Replace("$PLAY$", "<true />");
                request.Replace("$LABEL$", string.Empty);
                request.Replace("$DATA$", data);

                InvokeFlashCall(request.ToString());
                return true;
            }
            return false;
        }

        public void Remove(int layer)
        {
            string removeRequest = RemoveRequestTemplate20;
            StringBuilder request = new StringBuilder(removeRequest);
            request.Replace("$LAYER$", layer.ToString());

            InvokeFlashCall(request.ToString());
        }

        public void Play(int layer)
        {
            string playRequest = PlayRequestTemplate20;
            StringBuilder request = new StringBuilder(playRequest);
            request.Replace("$LAYER$", layer.ToString());

            InvokeFlashCall(request.ToString());
        }
        public void Play()
        {
            shockwaveFlashControl1.FlashActiveX.Play();
        }
        public string GetProperties()
        {
            string kq = "";
            kq = shockwaveFlashControl1.FlashActiveX.CallFunction("<invoke name=\"GetProperties\" returntype=\"xml\"></invoke>");
            return kq;
        }

        public void Stop(int layer)
        {
            Stop(layer, 0);
        }

        public void Stop(int layer, int mixDuration)
        {
            string stopRequest = StopRequestTemplate20;
            StringBuilder request = new StringBuilder(stopRequest);
            request.Replace("$LAYER$", layer.ToString());
            request.Replace("$MIXDURATION$", mixDuration.ToString());

            InvokeFlashCall(request.ToString());
        }

        public void Next(int layer)
        {
            string nextRequest = NextRequestTemplate20;
            StringBuilder request = new StringBuilder(nextRequest);
            request.Replace("$LAYER$", layer.ToString());

            InvokeFlashCall(request.ToString());
        }

        [Obsolete("use ICGDataContainer for CGData instead", false)]
        public void Update(CasparCGItem item)
        {
            if (item != null)
            {
                string dataxml = CGDataPair.ToXml(item.Data);
                string updateRequest = UpdateRequestTemplate20;
                StringBuilder request = new StringBuilder(updateRequest, dataxml.Length + updateRequest.Length);
                request.Replace("$LAYER$", item.Layer.ToString());
                request.Replace("$DATA$", dataxml);

                InvokeFlashCall(request.ToString());
            }
        }

        public void Update(int layer, ICGDataContainer data)
        {
            string dataxml = data.ToXml();

            string updateRequest = UpdateRequestTemplate20;
            StringBuilder request = new StringBuilder(updateRequest, dataxml.Length + updateRequest.Length);
            request.Replace("$LAYER$", layer.ToString());
            request.Replace("$DATA$", dataxml);

            InvokeFlashCall(request.ToString());
        }

        public void Update(int layer, string xml)
        {
            string updateRequest = UpdateRequestTemplate20;
            StringBuilder request = new StringBuilder(updateRequest, xml.Length + updateRequest.Length);
            request.Replace("$LAYER$", layer.ToString());
            request.Replace("$DATA$", xml);

            InvokeFlashCall(request.ToString());
        }
        public void Update(string xml)
        {
            var result = shockwaveFlashControl1.FlashActiveX.CallFunction("<invoke name=\"SetData\" returntype=\"xml\"><arguments><string>" + xml + "</string></arguments></invoke>");
        }

        public void Goto(int layer, string label)
        {
            string gotoRequest = GotoRequestTemplate20;
            StringBuilder request = new StringBuilder(gotoRequest);
            request.Replace("$LAYER$", layer.ToString());
            request.Replace("$LABEL$", label);

            InvokeFlashCall(request.ToString());
        }

        public void InvokeMethod(int layer, string method)
        {
            string invokeRequest = InvokeRequestTemplate20;
            StringBuilder request = new StringBuilder(invokeRequest);
            request.Replace("$LAYER$", layer.ToString());
            request.Replace("$METHOD$", method);

            InvokeFlashCall(request.ToString());
        }

        public bool Valid { get; set; }

        private void InvokeFlashCall(string request)
        {            
            try
            {
                if (Valid)
                {
                    var result = shockwaveFlashControl1.FlashActiveX.CallFunction(request);
                                        
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public Versions Version
        {
            get;
            set;
        }

        public static string GetVersionString(Versions v)
        {
            if (v == Versions.Version20) return "v2.0";
            return "unknown";
        }

        public enum Versions
        {
            Version20
        }

        public enum ScaleModes
        {
            FullScreen,
            Unknown1,
            Fit
        }

        public ScaleModes ScaleMode
        {
            set
            {
                shockwaveFlashControl1.FlashActiveX.ScaleMode = (int)value;
            }

            get
            {
                return (ScaleModes)shockwaveFlashControl1.FlashActiveX.ScaleMode;
            }
        }

        public enum Aspects
        {
            None,
            Aspect169,
            Aspect43
        }

        Aspects aspect;
        public Aspects AspectControl
        {
            get { return aspect; }
            set
            {
                aspect = value;
                control_Resize(this, EventArgs.Empty);
            }
        }

        public Control FlashControl
        {
            get { return shockwaveFlashControl1; }
        }
        #region Aspectcontrol

        private void control_Resize(object sender, EventArgs e)
        {
            Control container = (Control)sender;
            Size bounds = container.Size;

            Size finalSize = new Size(0, 0);

            //Calculate largest aspect-correct rect for the flashcontrol
            if (AspectControl == Aspects.Aspect169)
                finalSize = GetLargestAspectCorrectRect(bounds, new Size(16, 9));
            else if (AspectControl == Aspects.Aspect43)
                finalSize = GetLargestAspectCorrectRect(bounds, new Size(4, 3));
            else
                finalSize = bounds;

            //Position the control
            Point position = new Point();
            position.X = bounds.Width / 2 - finalSize.Width / 2;
            position.Y = bounds.Height / 2 - finalSize.Height / 2;

            shockwaveFlashControl1.Size = finalSize;
            shockwaveFlashControl1.Location = position;
        }

        private Size GetLargestAspectCorrectRect(Size bounds, Size aspect)
        {
            Size finalSize = new Size();
            if (bounds.Width / aspect.Width < bounds.Height / aspect.Height)
            {
                finalSize.Width = (bounds.Width / aspect.Width) * aspect.Width;
                finalSize.Height = (bounds.Width / aspect.Width) * aspect.Height;
            }
            else
            {
                finalSize.Height = (bounds.Height / aspect.Height) * aspect.Height;
                finalSize.Width = (bounds.Height / aspect.Height) * aspect.Width;
            }

            return finalSize;
        }
        #endregion
    }
}
