using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;


namespace XuLyData
{
    
    class SuyDien
    {
        ConnectDB conDB = new ConnectDB();
        
        SqlConnection conn;
        public SuyDien()
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
            DataTable dataTable = new DataTable();
            dataTable = conDB.GetTable(sql);
            foreach(DataRow dr in dataTable.Rows)
            {
                TapLuat tl = new TapLuat();
                tl.maLuat = dr["maLuat"].ToString();
                tl.veTrai = dr["veTrai"].ToString().Trim().Split(',');
                tl.vePhai = dr["vePhai"].ToString();
                list.Add(tl);
            }    
                
            return list;
        }

        public List<String> getAllHT()
        {
            List<String> list = new List<String>();

            foreach(TapLuat x in getAllTapLuat())
            {
                for(int i = 0; i < x.veTrai.Length; i++)
                {
                    list.Add(x.veTrai[i].ToString());
                }
            }
            List<String> distinct = list.Distinct().ToList();

            return distinct;
        }


        
    }
}
