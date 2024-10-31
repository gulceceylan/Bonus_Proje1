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

namespace Bonus_Proje1
{
    public partial class Frm_Ogrenci : Form
    {
        private SqlBaglantisi bgl;
        public Frm_Ogrenci()
        {
            InitializeComponent();
            bgl = new SqlBaglantisi();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void Frm_Ogrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Ogrenci_Listesi();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Kulupler", bgl.baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbkulup.DisplayMember = "Kulupad";
            cmbkulup.ValueMember = "Kulupid";
            cmbkulup.DataSource = dt;
            

        }
        string c="";

        private void btnekle_Click(object sender, EventArgs e)
        {
            
            
            
            ds.Ogrenci_Ekle(txtograd.Text, txtogrsoyad.Text,byte.Parse(cmbkulup.SelectedValue.ToString()), c);
            MessageBox.Show("Öğrenci Ekleme İşlemi Yapıldı");
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Ogrenci_Listesi();

        }

        private void cmbkulupid_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtogrid.Text = cmbkulup.SelectedValue.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.Ogrenci_sil(int.Parse(txtogrid.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtogrid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtograd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtogrsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbkulup.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            string cinsiyet = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            
            rbuttonerkek.Checked = cinsiyet == "Erkek";
            rbuttonkız.Checked = cinsiyet == "Kiz";
            

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.Ogrenci_Güncelle(txtograd.Text, txtogrsoyad.Text,byte.Parse(cmbkulup.SelectedValue.ToString()),c,int.Parse( txtogrid.Text));
        }

        private void rbuttonkız_CheckedChanged(object sender, EventArgs e)
        {
            if (rbuttonkız.Checked == true)
            {
                c = "Kız";
            }
           
        }

        private void rbuttonerkek_CheckedChanged(object sender, EventArgs e)
        {
            
            if (rbuttonerkek.Checked == true)
            {
                c = "Erkek";
            }
        }
    }
}
