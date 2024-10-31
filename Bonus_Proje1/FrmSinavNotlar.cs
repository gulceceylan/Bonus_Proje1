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
using System.Data.SqlClient;

namespace Bonus_Proje1
{
    public partial class FrmSinavNotlar : Form
    {
        private SqlBaglantisi bgl;
        public FrmSinavNotlar()
        {
            InitializeComponent();
            bgl = new SqlBaglantisi();

        }

        DataSet1TableAdapters.Tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.Tbl_NotlarTableAdapter();
        private void btnara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtid.Text));


        }

        private void FrmSinavNotlar_Load(object sender, EventArgs e)
        {
            
            SqlCommand komut = new SqlCommand("Select * From Tbl_Dersler", bgl.baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbders.DisplayMember = "Dersad";
            cmbders.ValueMember = "Dersid";
            cmbders.DataSource = dt;
            
        }
        int notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid =int.Parse( dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtsinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtproje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtort.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtdurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }
        int sinav1, sinav2, sinav3, proje;
        double ortalama;
        string durum;
        private void btnhesapla_Click(object sender, EventArgs e)
        {
            

            sinav1 = Convert.ToInt16(txtsinav1.Text);
            sinav2 = Convert.ToInt16(txtsinav2.Text);
            if (string.IsNullOrEmpty(txtsinav3.Text))
            {
                sinav3 = 0;
            }
            else
            {
                sinav3 = Convert.ToInt16(txtsinav3.Text);
            }

            
            if (string.IsNullOrEmpty(txtproje.Text))
            { 
                proje = 0; 
            }
            else
            {
                proje = Convert.ToInt16(txtproje.Text);
            }

            ortalama = (sinav1 + sinav2 + sinav3+proje) / 4.00;
            txtort.Text = ortalama.ToString();

            if (ortalama >= 50)
            {
                txtdurum.Text = "True";
            }
            else
            {
                txtdurum.Text = "False";
            }
           
        }

        private void txtproje_TextChanged(object sender, EventArgs e)
        {
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(cmbders.SelectedValue.ToString()), int.Parse(txtid.Text), byte.Parse(txtsinav1.Text), byte.Parse(txtsinav2.Text), byte.Parse(txtsinav3.Text), byte.Parse(txtproje.Text), decimal.Parse(txtort.Text), bool.Parse(txtdurum.Text), notid);
        }
    }
}
