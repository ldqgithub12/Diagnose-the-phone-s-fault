using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XuLyData
{
    class SuKien
    {
        public string maSukien { get; set; }
        public string tenSukien { get; set; }

        public SuKien() { }
        public SuKien(String mask)
        {
            maSukien = mask;
        }
    }


}
