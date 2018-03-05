using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Svt.Caspar;

namespace HDCGControler
{
    public class CasparCG
    {
        private CasparDevice caspar_;
        private int timeOut_ = 10000;

        private List<CGLayer> layers = new List<CGLayer>();
        private object _lockServer = new object();

        public CasparCG()
        {

        }

        public bool Connect(string cgIp, int port)
        {
            if (caspar_ == null || caspar_.Settings.Hostname != cgIp || caspar_.Settings.Port != port)
            {
                if (caspar_ != null)
                    caspar_.Disconnect();

                caspar_ = new CasparDevice();
                caspar_.CGRetrieved += caspar__CGRetrieved;
                caspar_.Cleared += caspar__Cleared;
                caspar_.Played += caspar__Played;
                caspar_.Loadbged += caspar__Loadbged;
                caspar_.Swaped += caspar__Swaped;
                caspar_.Mixered += caspar__Mixered;

                caspar_.Connect(cgIp, port, true);
                caspar_.Settings.Hostname = cgIp;
                caspar_.Settings.Port = port;

                Thread.Sleep(1000);
            }
            return caspar_.IsConnected;
        }

        public CasparDevice Caspar
        {
            get { return caspar_; }
        }

        public List<Channel> Channels
        {
            get
            {
                if (caspar_ != null)
                    return caspar_.Channels;

                return null;
            }
        }

        bool casparMixerOK = false;
        void caspar__Mixered(object sender, EventArgs e)
        {
            casparMixerOK = true;
        }

        bool casparSwapOK = false;
        void caspar__Swaped(object sender, EventArgs e)
        {
            casparSwapOK = true;
        }

        bool casparLoadBGOK = false;
        void caspar__Loadbged(object sender, EventArgs e)
        {
            casparLoadBGOK = true;
        }

        bool casparPlayed = false;
        void caspar__Played(object sender, EventArgs e)
        {
            casparPlayed = true;
        }

        bool casparClearedOK = false;
        void caspar__Cleared(object sender, DataEventArgs e)
        {
            casparClearedOK = true;
        }

        bool casparRetrieved = false;
        void caspar__CGRetrieved(object sender, DataEventArgs e)
        {
            casparRetrieved = true;
        }

        public bool Connect()
        {
            if (caspar_ != null && caspar_.IsConnected)
                return true;

            return false;
        }

        public bool Disconnect()
        {
            if (caspar_ != null)
                try
                {
                    caspar_.Disconnect();
                }
                catch { }
            caspar_ = null;
            return true;
        }

        public bool LoadCG(string cgName, int layer)
        {
            return LoadCG(0, cgName, layer);
        }

        public bool LoadCG(int channel, string cgName, int layer)
        {
            if (caspar_ == null || !caspar_.IsConnected)
                return false;

            lock (this._lockServer)
            {
                try
                {
                    var layerLoad = layer * 2;

                    CGType cgtype = CGType.NoSuport;

                    if (cgName.ToLower() == "playvideo")
                        cgtype = CGType.Video;
                    else if (cgName.ToLower().EndsWith(".ft"))
                    {
                        cgtype = CGType.Template;
                        cgName = cgName.Remove(cgName.Length - 3);
                    }

                    if (cgtype != CGType.NoSuport)
                    {
                        try
                        {
                            caspar_.Channels[channel].Clear(layerLoad);
                        }
                        catch { }

                        caspar_.Channels[channel].SetOpacity(layerLoad, 0, 0, Easing.None);
                        caspar_.Channels[channel].SetVolume(layerLoad, 0, 0, Easing.None);

                        bool ok = false;
                        if (cgtype == CGType.Video)
                            ok = true;
                        else
                        {
                            casparRetrieved = false;
                            cgName = Path.Combine(Path.GetDirectoryName(cgName), Path.GetFileNameWithoutExtension(cgName)).Replace("\\", "/");
                            caspar_.Channels[channel].CG.Add(layerLoad, 1, cgName, true);
                            for (int time = 0; !casparRetrieved && caspar_.IsConnected && time < timeOut_; time += 100)
                                Thread.Sleep(100);
                            if (casparRetrieved)
                                ok = true;
                        }

                        if (ok)
                        {
                            var cglayer = layers.Where(o => o.Layer == layerLoad).FirstOrDefault();
                            if (cglayer != null)
                                cglayer.Type = cgtype;
                            else
                                layers.Add(new CGLayer() { Layer = layerLoad, Type = cgtype });

                            return true;
                        }
                    }
                }
                catch { }

                return false;
            }
        }

        public bool UnLoadCG(int layer)
        {
            return UnLoadCG(0, layer);
        }

        public bool UnLoadCG(int channel, int layer)
        {
            if (caspar_ == null || !caspar_.IsConnected)
                return false;

            lock (this._lockServer)
            {
                try
                {
                    var layerLoad = layer * 2;
                    var layerMain = layerLoad + 1;
                    casparClearedOK = false;
                    caspar_.Channels[channel].Clear(layerMain);
                    for (int time = 0; !casparClearedOK && caspar_.IsConnected && time < timeOut_; time += 100)
                        Thread.Sleep(100);
                    if (casparClearedOK)
                    {
                        caspar_.Channels[channel].Clear(layerLoad);
                        var cglayerLoad = layers.Where(o => o.Layer == layerLoad).FirstOrDefault();
                        var cglayerMain = layers.Where(o => o.Layer == layerMain).FirstOrDefault();
                        if (cglayerLoad != null)
                            layers.Remove(cglayerLoad);
                        if (cglayerMain != null)
                            layers.Remove(cglayerMain);
                        return true;
                    }
                }
                catch { }

                return false;
            }
        }

        public bool UnloadAll()
        {
            return UnloadAll(0);
        }

        public bool UnloadAll(int channel)
        {
            if (caspar_ == null || !caspar_.IsConnected)
                return false;

            lock (this._lockServer)
            {
                try
                {
                    casparClearedOK = false;
                    caspar_.Channels[channel].Clear();
                    for (int time = 0; !casparClearedOK && caspar_.IsConnected && time < timeOut_; time += 100)
                        Thread.Sleep(100);
                    if (casparClearedOK)
                    {
                        layers.Clear();
                        return true;
                    }
                }
                catch { }

                return false;
            }
        }

        public bool FadeUp(int layer, int duration, string xmlStr)
        {
            return FadeUp(0, layer, duration, xmlStr);
        }        
        public bool FadeUp(int channel, int layer, int duration, string xmlStr)
        {
            if (caspar_ == null || !caspar_.IsConnected)
                return false;

            lock (this._lockServer)
            {
                var layerLoad = layer * 2;
                var layerMain = layerLoad + 1;

                var cglayer = layers.Where(o => o.Layer == layerLoad).FirstOrDefault();

                if (cglayer != null)
                {
                    caspar_.Channels[channel].Clear(layerMain);
                    var cglayerOld = layers.Where(o => o.Layer == layerMain).FirstOrDefault();
                    if (cglayerOld != null)
                        layers.Remove(cglayerOld);
                    caspar_.Channels[channel].SetOpacity(layerMain, 0, 0, Easing.None);
                    caspar_.Channels[channel].SetVolume(layerMain, 0, 0, Easing.None);

                    bool fadeOk = false;

                    if (cglayer.Type == CGType.Template)
                    {
                        try
                        {
                            
                            CGComponentCollection components = new CGComponentCollection();
                            components.AddComponent("FadeUp", duration.ToString());
                            casparRetrieved = false;                            
                            caspar_.Channels[channel].CG.Update(layerLoad, 1, toStandarXml(xmlStr));
                            for (int time = 0; !casparRetrieved && caspar_.IsConnected && time < timeOut_; time += 100)
                                Thread.Sleep(100);
                            if (casparRetrieved)
                            {
                                casparRetrieved = false;
                                caspar_.Channels[channel].CG.Invoke(layerLoad, 1, "fadeUp");
                                for (int time = 0; !casparRetrieved && caspar_.IsConnected && time < timeOut_; time += 100)
                                    Thread.Sleep(100);
                                if (casparRetrieved)
                                    fadeOk = true;
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        try
                        {
                            casparPlayed = false;
                            caspar_.Channels[channel].Play(layerLoad);
                            for (int time = 0; !casparPlayed && caspar_.IsConnected && time < timeOut_; timeOut_ += 100)
                                Thread.Sleep(100);
                            if (casparPlayed)
                                fadeOk = true;
                        }
                        catch { }
                    }

                    if (fadeOk)
                    {
                        var channelID = caspar_.Channels[channel].ID;
                        casparSwapOK = false;
                        caspar_.SendString("SWAP " + channelID + "-" + layerLoad + " " + channelID + "-" + layerMain);
                        for (int time = 0; !casparSwapOK && caspar_.IsConnected && time < timeOut_; timeOut_ += 100)
                            Thread.Sleep(100);
                        if (casparSwapOK)
                        {
                            if (cglayer.Type == CGType.Template)
                                caspar_.Channels[channel].SetOpacity(layerMain, 1, 0, Easing.None);
                            else
                                caspar_.Channels[channel].SetOpacity(layerMain, 1, duration / 40, Easing.None);
                            caspar_.Channels[channel].SetVolume(layerMain, 1, duration / 40, Easing.None);
                            caspar_.Channels[channel].SetVolume(layerMain, 1, duration / 40, Easing.None);

                            cglayer.Layer = layerMain;
                            caspar_.Channels[channel].Clear(layerLoad);
                            return true;
                        }
                    }
                }

                return false;
            }
        }
        private string toStandarXml(string str)
        {
            return str.Replace("\"", "\\\"");
        }

        public bool FadeDown(int layer, int duration)
        {
            return FadeDown(0, layer, duration);
        }

        public bool FadeDown(int channel, int layer, int duration)
        {
            if (caspar_ == null || !caspar_.IsConnected)
                return false;

            lock (this._lockServer)
            {
                var layerLoad = layer * 2;
                var layerMain = layerLoad + 1;

                var cglayer = layers.Where(o => o.Layer == layerMain).FirstOrDefault();

                if (cglayer != null)
                {
                    if (cglayer.Type == CGType.Template)
                    {
                        try
                        {
                            CGComponentCollection components = new CGComponentCollection();
                            components.AddComponent("FadeDown", duration.ToString());
                            casparRetrieved = false;
                            caspar_.Channels[channel].CG.Update(layerMain, 1, components);
                            for (int time = 0; !casparRetrieved && caspar_.IsConnected && time < timeOut_; time += 100)
                                Thread.Sleep(100);
                            if (casparRetrieved)
                            {
                                casparRetrieved = false;
                                caspar_.Channels[channel].CG.Invoke(layerMain, 1, "fadeDown");
                                for (int time = 0; !casparRetrieved && caspar_.IsConnected && time < timeOut_; time += 100)
                                    Thread.Sleep(100);
                                if (casparRetrieved)
                                {
                                    caspar_.Channels[channel].SetVolume(layerMain, 0, duration / 40, Easing.None);
                                    caspar_.Channels[channel].SetVolume(layerMain, 0, duration / 40, Easing.None);
                                    return true;
                                }
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        try
                        {
                            casparMixerOK = false;
                            caspar_.Channels[channel].SetOpacity(layerMain, 0, duration / 40, Easing.None);
                            for (int time = 0; !casparMixerOK && caspar_.IsConnected && time < timeOut_; timeOut_ += 100)
                                Thread.Sleep(100);
                            if (casparMixerOK)
                            {
                                caspar_.Channels[channel].SetVolume(layerMain, 0, duration / 40, Easing.None);
                                caspar_.Channels[channel].SetVolume(layerMain, 0, duration / 40, Easing.None);
                                return true;
                            }
                        }
                        catch { }
                    }
                }

                return false;
            }
        }

        public bool CutUp(int layer)
        {
            return CutUp(0, layer);
        }

        public bool CutUp(int channel, int layer)
        {
            if (caspar_ == null || !caspar_.IsConnected)
                return false;

            lock (this._lockServer)
            {
                var layerLoad = layer * 2;
                var layerMain = layerLoad + 1;

                var cglayer = layers.Where(o => o.Layer == layerLoad).FirstOrDefault();

                if (cglayer != null)
                {
                    caspar_.Channels[channel].Clear(layerMain);
                    var cglayerOld = layers.Where(o => o.Layer == layerMain).FirstOrDefault();
                    if (cglayerOld != null)
                        layers.Remove(cglayerOld);
                    caspar_.Channels[channel].SetOpacity(layerMain, 0, 0, Easing.None);
                    caspar_.Channels[channel].SetVolume(layerMain, 0, 0, Easing.None);

                    bool cutUpOk = false;

                    if (cglayer.Type == CGType.Template)
                    {
                        try
                        {
                            casparRetrieved = false;
                            caspar_.Channels[channel].CG.Invoke(layerLoad, 1, "cutUp");
                            for (int time = 0; !casparRetrieved && caspar_.IsConnected && time < timeOut_; time += 100)
                                Thread.Sleep(100);
                            if (casparRetrieved)
                                cutUpOk = true;
                        }
                        catch { }
                    }
                    else
                    {
                        try
                        {
                            casparPlayed = false;
                            caspar_.Channels[channel].Play(layerLoad);
                            for (int time = 0; !casparPlayed && caspar_.IsConnected && time < timeOut_; timeOut_ += 100)
                                Thread.Sleep(100);
                            if (casparPlayed)
                                cutUpOk = true;
                        }
                        catch { }
                    }

                    if (cutUpOk)
                    {
                        var channelID = caspar_.Channels[channel].ID;
                        casparSwapOK = false;
                        caspar_.SendString("SWAP " + channelID + "-" + layerLoad + " " + channelID + "-" + layerMain);
                        for (int time = 0; !casparSwapOK && caspar_.IsConnected && time < timeOut_; timeOut_ += 100)
                            Thread.Sleep(100);
                        if (casparSwapOK)
                        {
                            caspar_.Channels[channel].SetOpacity(layerMain, 1, 0, Easing.None);
                            caspar_.Channels[channel].SetVolume(layerMain, 1, 0, Easing.None);
                            caspar_.Channels[channel].SetVolume(layerMain, 1, 0, Easing.None);

                            cglayer.Layer = layerMain;
                            caspar_.Channels[channel].Clear(layerLoad);
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        public bool CutDown(int layer)
        {
            return CutDown(0, layer);
        }

        public bool CutDown(int channel, int layer)
        {
            if (caspar_ == null || !caspar_.IsConnected)
                return false;

            lock (this._lockServer)
            {
                var layerLoad = layer * 2;
                var layerMain = layerLoad + 1;

                var cglayer = layers.Where(o => o.Layer == layerMain).FirstOrDefault();

                if (cglayer != null)
                {
                    if (cglayer.Type == CGType.Template)
                    {
                        try
                        {
                            casparRetrieved = false;
                            caspar_.Channels[channel].CG.Invoke(layerMain, 1, "Stop");
                            for (int time = 0; !casparRetrieved && caspar_.IsConnected && time < timeOut_; time += 100)
                                Thread.Sleep(100);
                            if (casparRetrieved)
                            {
                                caspar_.Channels[channel].SetVolume(layerMain, 0, 0, Easing.None);
                                caspar_.Channels[channel].SetVolume(layerMain, 0, 0, Easing.None);
                                return true;
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        try
                        {
                            casparMixerOK = false;
                            caspar_.Channels[channel].SetOpacity(layerMain, 0, 0, Easing.None);
                            for (int time = 0; !casparMixerOK && caspar_.IsConnected && time < timeOut_; timeOut_ += 100)
                                Thread.Sleep(100);
                            if (casparMixerOK)
                            {
                                caspar_.Channels[channel].SetVolume(layerMain, 0, 0, Easing.None);
                                caspar_.Channels[channel].SetVolume(layerMain, 0, 0, Easing.None);
                                return true;
                            }
                        }
                        catch { }
                    }
                }

                return false;
            }
        }
        public bool UpdateTemplate(int layer, string xmlStr, int flags)
        {
            return UpdateTemplate(0, layer, xmlStr, flags);
        }
        public bool UpdateTemplate(int channel, int layer, string xmlStr, int flags)
        {
            if (caspar_ == null || !caspar_.IsConnected)
                return false;

            lock (this._lockServer)
            {
                var layerLoad = layer * 2;
                var layerMain = layerLoad + 1;                

                var cglayer = layers.Where(o => o.Layer == layerMain).FirstOrDefault();

                if (cglayer != null)
                {
                    if (cglayer.Type == CGType.Template)
                    {
                        try
                        {
                            CGComponentCollection components = new CGComponentCollection();
                            if (flags > 0)
                                components.AddComponent("Append", "1");
                            components.AddComponent("text", xmlStr);
                            casparRetrieved = false;
                            //caspar_.Channels[channel].CG.Update(layerLoad, 1, toStandarXml(xmlStr));
                            caspar_.Channels[channel].CG.Update(cglayer.Layer, 1, toStandarXml(xmlStr));
                            for (int time = 0; !casparRetrieved && caspar_.IsConnected && time < timeOut_; time += 100)
                                Thread.Sleep(100);
                            if (casparRetrieved)
                                return true;
                        }
                        catch { }
                    }
                    
                }
                return false;
            }
        }
        public bool UpdateField(int layer, string fieldId, string value, int flags)
        {
            return UpdateField(0, layer, fieldId, value, flags);
        }

        public bool UpdateField(int channel, int layer, string fieldId, string value, int flags)
        {
            if (caspar_ == null || !caspar_.IsConnected)
                return false;

            lock (this._lockServer)
            {
                var layerLoad = layer * 2;
                var layerMain = layerLoad + 1;

                CGLayer cglayer = null;

                if (flags > 0)
                    cglayer = layers.Where(o => o.Layer == layerMain).FirstOrDefault();
                else
                    cglayer = layers.Where(o => o.Layer == layerLoad).FirstOrDefault();

                if (cglayer != null)
                {
                    if (cglayer.Type == CGType.Template)
                    {
                        try
                        {
                            CGComponentCollection components = new CGComponentCollection();
                            if (flags > 0)
                                components.AddComponent("Append", "1");
                            components.AddComponent(fieldId, value);
                            casparRetrieved = false;
                            caspar_.Channels[channel].CG.Update(cglayer.Layer, 1, components);
                            for (int time = 0; !casparRetrieved && caspar_.IsConnected && time < timeOut_; time += 100)
                                Thread.Sleep(100);
                            if (casparRetrieved)
                                return true;
                        }
                        catch { }
                    }
                    else
                    {
                        try
                        {
                            if (fieldId.ToLower() == "videopath")
                            {
                                casparLoadBGOK = false;
                                caspar_.Channels[channel].LoadBG(cglayer.Layer, value, false);
                                for (int time = 0; !casparLoadBGOK && caspar_.IsConnected && time < timeOut_; time += 100)
                                    Thread.Sleep(100);
                                if (casparLoadBGOK)
                                    return true;
                            }
                            else
                                return true;
                        }
                        catch { }
                    }
                }

                return false;
            }
        }

        public bool SetParameters(int layer, string xmlParameters, int flags = 0)
        {
            return SetParameters(0, layer, xmlParameters, flags);
        }

        public bool SetParameters(int channel, int layer, string xmlParameters, int flags = 0)
        {
            if (caspar_ == null || !caspar_.IsConnected)
                return false;

            lock (this._lockServer)
            {
                var layerLoad = layer * 2 + (flags > 0 ? 1 : 0);

                var cglayer = layers.Where(o => o.Layer == layerLoad).FirstOrDefault();

                if (cglayer != null)
                {
                    if (cglayer.Type == CGType.Template)
                    {
                        try
                        {
                            CGParameter paras = new CGParameter() { XmlParameters = xmlParameters };
                            casparRetrieved = false;
                            caspar_.Channels[channel].CG.Update(layerLoad, 1, toStandarXml(xmlParameters));
                            for (int time = 0; !casparRetrieved && caspar_.IsConnected && time < timeOut_; time += 100)
                                Thread.Sleep(100);
                            if (casparRetrieved)
                                return true;
                        }
                        catch { }
                    }
                    else
                    {
                        try
                        {
                            string videoPathNodeStart = "<componentData id=\\\"VideoPath\\\"><data id=\\\"text\\\" value=\\\"".ToLower();
                            string loopNodexStart = "<componentData id=\\\"Loops\\\"><data id=\\\"text\\\" value=\\\"".ToLower();
                            xmlParameters = xmlParameters.ToLower();
                            int videoPathIndex = xmlParameters.IndexOf(videoPathNodeStart);
                            if (videoPathIndex >= 0)
                            {
                                videoPathIndex += videoPathNodeStart.Length;
                                var videoPathEndIndex = xmlParameters.IndexOf("\\\" />", videoPathIndex);
                                if (videoPathEndIndex >= 0)
                                {
                                    string videoPath = xmlParameters.Substring(videoPathIndex, videoPathEndIndex - videoPathIndex);
                                    if (videoPath != "")
                                    {
                                        videoPath = videoPath.Replace(@"\\", @"\").Replace("&lt;", "<").Replace("&gt;", ">").Replace("\n", "\r\n").Replace("&quot;", "\"");

                                        bool loops = false;
                                        int loopIndex = xmlParameters.IndexOf(loopNodexStart);
                                        if (loopIndex >= 0)
                                        {
                                            loopIndex += loopNodexStart.Length;
                                            var loopEndIndex = xmlParameters.IndexOf("\\\" />", loopIndex);
                                            if (loopEndIndex >= 0)
                                            {
                                                string loopStr = xmlParameters.Substring(loopIndex, loopEndIndex - loopIndex);
                                                if (loopStr != "")
                                                {
                                                    if (loopStr == "true" || loopStr == "1")
                                                        loops = true;
                                                }
                                            }
                                        }

                                        casparLoadBGOK = false;
                                        caspar_.Channels[channel].LoadBG(layerLoad, videoPath, loops);
                                        for (int time = 0; !casparLoadBGOK && caspar_.IsConnected && time < timeOut_; time += 100)
                                            Thread.Sleep(100);
                                        if (casparLoadBGOK)
                                            return true;
                                    }
                                }
                            }
                        }
                        catch { }
                    }
                }

                return false;
            }
        }
    }
}
