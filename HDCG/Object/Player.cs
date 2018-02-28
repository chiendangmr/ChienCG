using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDCGStudio.Object
{
    public class Player
    {        
        public string Name { get; set; }
        public string Number { get; set; }        
        public bool IsNotSubstitution { get; set; }
        public bool IsCaptain { get; set; }
        public bool IsGK { get; set; }
        public string Team { get; set; }
        
    }
}
