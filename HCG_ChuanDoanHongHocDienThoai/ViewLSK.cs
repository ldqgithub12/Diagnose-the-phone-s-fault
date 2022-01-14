using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HCG_ChuanDoanHongHocDienThoai
{
    public partial class ViewLSK : Form
    {
        ConnectDB CD = new ConnectDB();
        public ViewLSK()
        {
            InitializeComponent();
        }

        private void ViewLSK_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con = CD.GetConnection();
            String sql="Select * from TapLuat";
            String sql2 = "Select * from SuKien";
            dataGridView1.DataSource = CD.GetTable(sql);
            dataGridView2.DataSource = CD.GetTable(sql2);
        }
    }
}
