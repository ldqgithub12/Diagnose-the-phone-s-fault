using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HCG_ChuanDoanHongHocDienThoai
{
    class TapLuat
    {
        public string maLuat { get; set; }
        public string[]  veTrai { get; set; }
        public string vePhai { get; set; }

        public TapLuat() { }
        public TapLuat(String maLuat)
        {
            this.maLuat = maLuat;
        }
        public TapLuat(string maLuat,string[] vt,string vp)
        {
            this.maLuat = maLuat;
            this.veTrai = vt;
            this.vePhai = vp;
        }
        public override bool Equals(object obj)
        {
            return this.maLuat == ((TapLuat)obj).maLuat;
        }

        public override string ToString()
        {
            string k = "";
           for(int i = 0; i< veTrai.Length; i++)
            {
                k += veTrai[i] + " ";
            }
            return maLuat + " " + k + " " + vePhai;
        }
    }
}
