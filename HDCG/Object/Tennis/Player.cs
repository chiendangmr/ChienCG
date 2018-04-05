using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDCGStudio.Object.Tennis
{
    public class Player
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int HatGiong { get; set; }
        public string Team { get; set; }
        public bool IsMale { get; set; }
        public int Rank { get; set; }
        public bool isCaptain { get; set; }
        public string Nation { get; set; }
        public int Age { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public int WorldRanking { get; set; }
        public int Appearances { get; set; }
        public int SingleWin { get; set; }
        public int SingleLose { get; set; }
        public string Debut { get; set; }

    }
}
