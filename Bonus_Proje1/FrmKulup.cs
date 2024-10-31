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
using System.Net.WebSockets;

namespace Bonus_Proje1
{
    public partial class FrmKulup : Form
    {
        private SqlBaglantisi bgl;

        public FrmKulup()
        {
            InitializeComponent();
            bgl = new SqlBaglantisi();

        }

        void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Kulupler", bgl.baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void FrmKulup_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Kulupler (Kulupad) values (@p1)", bgl.baglan);
            komut.Parameters.AddWithValue("@p1", txtkulupad.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kulüp Listeye Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bgl.baglan.Close();
            liste();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.LightPink;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkulupid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtkulupad.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From Tbl_Kulupler where Kulupid=@p1", bgl.baglan);
            komut.Parameters.AddWithValue("@p", txtkulupid.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kulüp Silme İşlemi Gerçekleştirildi");
            liste();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Kulupler set Kulupad=@p1 where Kulupid=@p2", bgl.baglan);
            komut.Parameters.AddWithValue("@p1", txtkulupad.Text);
            komut.Parameters.AddWithValue("@p2", txtkulupid.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kulüp Güncelleme İşlemi Gerçekleştirildi");
            liste();

        }
    }
}
