using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bonus_Proje1
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Tbl_DerslerTableAdapter ds = new DataSet1TableAdapters.Tbl_DerslerTableAdapter();

        private void FrmDersler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Ders_Listesi();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Ders_Listesi();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(txtdersid.Text);
            MessageBox.Show("Ders Ekleme İşlemi Yapılmıştır.");
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.Ders_Sil(byte.Parse(txtdersid.Text));
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.Ders_Güncelle(txtdersad.Text,byte.Parse(txtdersid.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtdersid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtdersad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
