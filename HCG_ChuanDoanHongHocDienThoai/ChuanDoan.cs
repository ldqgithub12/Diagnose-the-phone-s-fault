using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HCG_ChuanDoanHongHocDienThoai
{
    public partial class ChuanDoan : Form
    {
        List<String> TG = new List<String>();
        XuLyDuLieu xldl = new XuLyDuLieu();
        private List<SuKien> listSK;
        private List<TapLuat> listTL;
        private List<TapLuat> SAT = new List<TapLuat>();
        List<String> kq = new List<string>();
        public ChuanDoan()
        {
            InitializeComponent();
            listSK = xldl.GetSuKien();
            listTL = xldl.getAllTapLuat();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                foreach (SuKien x in xldl.GetSuKien())
                {
                    if (listBox2.Items[i].ToString() == x.tenSukien)
                    {
                        TG.Add(x.maSukien.Trim().ToString());
                    }
                }
            }
            KetQua();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = -1;
            n = listBox1.SelectedIndex;
            if (n >= 0)
            {
                listBox2.Items.Add(listBox1.SelectedItem.ToString());
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = -1;
            n = listBox2.SelectedIndex;
            if (n >= 0)
            {
                listBox1.Items.Add(listBox2.SelectedItem.ToString());
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
        }

        private void ChuanDoan_Load(object sender, EventArgs e)
        {

            List<SuKien> sk = xldl.GetSuKien();
            foreach (SuKien x in sk)
            {
                if (!x.maSukien.Contains('E'))
                    listBox1.Items.Add(x.tenSukien);
            }

        }

        private void btnChuanDoan_Click(object sender, EventArgs e)
        {

            listBox3.Items.Clear();
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                foreach (SuKien x in xldl.GetSuKien())
                {
                    if (listBox2.Items[i].ToString() == x.tenSukien)
                    {
                        TG.Add(x.maSukien.Trim().ToString());
                    }
                }
            }
            KetQuaAll();
        }

        public void KetQuaAll()
        {
            getSAT();
            while (SAT.Count > 0)
            {
                if (!TG.Contains(SAT[0].vePhai))
                    TG.Add(SAT[0].vePhai);
                if (SAT[0].vePhai.Contains('E'))
                {
                    kq.Add(SAT[0].vePhai);
                }
                listTL.Remove(SAT[0]);
                SAT.RemoveAt(0);
                getSAT();
            }
            kq = kq.Distinct().ToList();
            listBox3.Items.Add("Kết quả chuẩn đoán :");
            if (kq.Count == 0)
            { 
                listBox3.Items.Add("Tri thức chưa được nạp hoặc điện thoại không bị lỗi");
            } 
            else
            {
                foreach (String k in kq)
                {
                    listBox3.Items.Add(k);
                    //SuKien suKien = new SuKien(k);
                    //foreach (SuKien sk in xldl.GetSuKien())
                    //{
                    //if (k == sk.maSukien)
                    //if(suKien.Equals(sk)
                    //{
                    //    listBox3.Items.Add(sk.tenSukien);
                    //}
                    //}
                }
            }
        }

        public void KetQua()
        {
            String kq = "";
            getSAT();
            while (SAT.Count > 0)
            {
                if (!TG.Contains(SAT[0].vePhai))
                    TG.Add(SAT[0].vePhai);
                if (SAT[0].vePhai.Contains('E'))
                {
                    kq = SAT[0].vePhai;
                }
                listTL.Remove(SAT[0]);
                SAT.RemoveAt(0);
                getSAT();
            }
            listBox3.Items.Add("Kết quả chuẩn đoán :");
            if (kq== "" )
            {
                listBox3.Items.Add("Tri thức chưa được nạp hoặc điện thoại không bị lỗi");
            }
            else
            {
  //                  SuKien suKien = new SuKien(kq);
 //                   foreach (SuKien sk in xldl.GetSuKien())
  //                  {
  //                      if (suKien.Equals(sk))
  //                      {
                            listBox3.Items.Add(kq);
  //                      }
 //                   }
                    
            }
        }


        private bool checkRule(TapLuat r)
            {

                int i = 0;
                string[] x = r.veTrai;
                foreach (string e in x)
                {
                    foreach (string h in TG)
                    {

                        if (e == h)
                        {
                            i++;
                        }
                    }
                }
                if (i == x.Length) return true;
                return false;


            }

            private void getSAT()
            {
                foreach (TapLuat r in listTL)
                {
                    if (!SAT.Contains(r) && checkRule(r) == true)
                    {
                        SAT.Add(r);
                    }
                }
            }

        private void button4_Click(object sender, EventArgs e)
        {
            new ViewLSK().Show();
        }
    }
}

