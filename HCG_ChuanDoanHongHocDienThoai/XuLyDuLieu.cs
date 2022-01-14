using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;


namespace HCG_ChuanDoanHongHocDienThoai
{
    
    class XuLyDuLieu
    {
        ConnectDB conDB = new ConnectDB();
        SqlConnection conn;
        public XuLyDuLieu()
        {
            conn = conDB.GetConnection();
            conn.Open();
        }
        
        public List<TapLuat> getAllTapLuat()
        {
            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            List<TapLuat> list = new List<TapLuat>();
            string sql = "select * from TapLuat";
            DataTable data = conDB.GetTable(sql);
            foreach(DataRow dr in data.Rows)
            {
                TapLuat tl = new TapLuat();
                tl.maLuat = dr["maLuat"].ToString();
                tl.veTrai = dr["veTrai"].ToString().Trim().Split(',');
                tl.vePhai = dr["vePhai"].ToString();
                list.Add(tl);
            }
            return list;
        }


        public List<SuKien> GetSuKien()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            List<SuKien> list = new List<SuKien>();
            string sql = "select * from SuKien";
            DataTable data = conDB.GetTable(sql);
            foreach (DataRow dr in data.Rows)
            {
                SuKien sk = new SuKien();
                sk.maSukien = dr["maSK"].ToString();
                sk.tenSukien = dr["moTa"].ToString();
                list.Add(sk);
            }
            return list;
        }

        public List<String> getVeTrai()
        {
            List<String> vt = new List<String>();
            foreach(TapLuat x in getAllTapLuat())
            {
                for(int i = 0; i < x.veTrai.Length; i++)
                {
                    vt.Add(x.veTrai[i]);
                }
            }
            List<String> newlist = vt.Distinct().ToList();
            return newlist;
        }

        public List<String> getTenSuKien()
        {
            List<String> tensk = new List<String>();
            List<String> vt = getVeTrai();
            foreach(String x in vt)
            {
                foreach(SuKien y in GetSuKien())
                {
                    if (String.Compare(x,y.maSukien,true) == 0)
                    {
                        tensk.Add(y.tenSukien);
                    }
                }
            }
            return tensk;

        }

    }
}
