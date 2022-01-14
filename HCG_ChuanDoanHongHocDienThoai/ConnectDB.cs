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
    class ConnectDB
    {
        public SqlConnection GetConnection()
        {
            string constring = @"Data Source=DESKTOP-ML7391T;Initial Catalog=TapLuatHCG;Integrated Security=True";
            try
            {
                SqlConnection conn = new SqlConnection(constring);
                return conn;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public DataTable GetTable(string sql)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, GetConnection());
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void doSQL(string sql)
        {
            try
            {
                SqlConnection conn = GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
