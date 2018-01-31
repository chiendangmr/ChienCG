using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDCGControler
{
    public class CGLayer
    {
        public int Layer { get; set; }
        public CGType Type { get; set; }
    }

    public enum CGType
    {
        NoSuport = 0,
        Template = 1,
        Video = 2
    }
}
