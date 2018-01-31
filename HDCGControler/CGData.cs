using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Svt.Caspar;

namespace HDCGControler
{
    public class CGComponentCollection : ICGDataContainer
    {
        private List<CGComponent> Components;
        public CGComponentCollection()
        {
            Components = new List<CGComponent>();
        }

        public void Clear()
        {
            Components.Clear();
        }

        public CGComponent GetComponent(string name)
        {
            return Components.Where(c => c.Name.Trim().ToLower() == name.Trim().ToLower()).FirstOrDefault();
        }

        public void RemoveComponent(string name)
        {
            foreach (var component in Components.Where(c => c.Name.Trim().ToLower() == name.Trim().ToLower()).ToList())
                Components.Remove(component);
        }

        public void AddComponent(CGComponent component)
        {
            Components.Add(component);
        }
        
        public void AddComponent(string name, string value)
        {
            CGComponent component = new CGComponent(name);
            component.SetData(value);
            AddComponent(component);
        }

        public string ToAMCPEscapedXml()
        {
            string result = "<templateData>";
            foreach (var component in Components)
            {
                result += "<componentData id=\\\"" + component.Name + "\\\">";
                foreach (var data in component.Datas)
                    result += "<data id=\\\"" + data.Name + "\\\" value=\\\"" + data.Value.Replace("<", "&lt;").Replace(">", "&gt;").Replace("\r\n", "\n")
                        .Replace("\"", "&quot;").Replace(@"\", @"\\") + "\\\" />";
                result += "</componentData>";
            }
            result += "</templateData>";
            return result;
        }

        public string ToXml()
        {
            string result = "<templateData>";
            foreach (var component in Components)
            {
                result += "<componentData id=\"" + component.Name + "\">";
                foreach (var data in component.Datas)
                    result += "<data id=\"" + data.Name + "\" value=\"" + data.Value.Replace("<", "&lt;").Replace(">", "&gt;").Replace("\r\n", "\n")
                        .Replace("\"", "&quot;").Replace(@"\", @"\\") + "\" />";
                result += "</componentData>";
            }
            result += "</templateData>";
            return result;
        }
        
    }

    public class CGParameter : ICGDataContainer
    {
        public string XmlParameters { get; set; }

        public string ToAMCPEscapedXml()
        {
            return XmlParameters;
        }

        public string ToXml()
        {
            return XmlParameters.Replace("\\n", Environment.NewLine).Replace("\\\"", "\"");
        }
    }

    public class CGComponent
    {
        private string _name;
        private List<CGComponentData> _datas;

        public CGComponent()
        {
            _name = "";
            _datas = new List<CGComponentData>();
        }

        public CGComponent(string name)
        {
            _name = name;
            _datas = new List<CGComponentData>();
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<CGComponentData> Datas
        {
            get { return _datas; }
        }

        public void Clear()
        {
            _datas.Clear();
        }

        public CGComponentData GetData(string name)
        {
            return _datas.Where(d => d.Name.Trim().ToLower() == name.Trim().ToLower()).FirstOrDefault();
        }

        public void RemoveData(string name)
        {
            foreach (var data in _datas.Where(d => d.Name.Trim().ToLower() == name.Trim().ToLower()).ToList())
                _datas.Remove(data);
        }

        public void SetData(CGComponentData data)
        {
            _datas.Add(data);
        }
        public void SetData(string xmlStr)
        {
            _datas.Add(new CGComponentData(xmlStr));
        }

        public void SetData(string name, string value)
        {
            _datas.Add(new CGComponentData(name, value));
        }
    }

    public class CGComponentData
    {
        private string _name;
        private string _value;

        public CGComponentData()
        {
            _name = "text";
            _value = "";
        }
        public CGComponentData(string xmlStr)
        {
            _value = xmlStr;
        }
        //public CGComponentData(string name)
        //{
        //    _name = name;
        //    _value = "";
        //}

        public CGComponentData(string name, string value)
        {
            _name = name;
            _value = value;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
