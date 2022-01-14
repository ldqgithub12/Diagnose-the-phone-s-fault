using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace XuLyData
{
    class TapLuat
    {
        public string maLuat { get; set; }
        public string[]  veTrai { get; set; }
        public string vePhai { get; set; }

        public override bool Equals(object obj)
        {
            return this.maLuat == ((TapLuat)obj).maLuat;
        }
    }
}
