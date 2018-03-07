﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDCGStudio.Object
{
    public class Player
    {        
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int Number { get; set; }        
        public bool IsNotSubstitution { get; set; }
        public bool IsSubstitution { get; set; }
        public bool IsCaptain { get; set; }
        public bool IsGK { get; set; }
        public string Team { get; set; }
        
    }
}
