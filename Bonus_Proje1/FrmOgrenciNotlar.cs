using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bonus_Proje1
{
    public partial class FrmOgrenciNotlar : Form
    {
        private SqlBaglantisi bgl;

        public FrmOgrenciNotlar()
        {
            InitializeComponent();
            bgl = new SqlBaglantisi();

        }
        public string numara;
        
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select Dersad,Sinav1,Sinav2,Sinav3,Proje, Ortalama,Durum From Tbl_Notlar Inner JOIN Tbl_Dersler on Tbl_Notlar.Dersid=Tbl_Dersler.Dersid Where Ogrid=@p1", bgl.baglan);
            komut.Parameters.AddWithValue("@p1", numara);
            // this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlCommand komut2 = new SqlCommand("Select Ograd,Ogrsoyad From Tbl_Ogrenciler where Ogrid=@a1",bgl.baglan);
            komut2.Parameters.AddWithValue("@a1", numara);
            SqlDataReader dr1 = komut2.ExecuteReader();
            while (dr1.Read())
            {
                this.Text = dr1[0] + " " + dr1[1].ToString();
            }
        }
    }
}
