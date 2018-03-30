using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDCGStudio.Object.Tennis
{
    public class Team
    {        
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string TeamCode { get; set; }
        public string LogoPath { get; set; }
        public string CoachName { get; set; }        
        public string LeagueCode { get; set; }
        public string City { get; set; }
        public int HatGiong { get; set; }
    }
}
