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
    public partial class FrmOgretmen : Form
    {
        private SqlBaglantisi bgl;

        public FrmOgretmen()
        {
            InitializeComponent();
            bgl = new SqlBaglantisi();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulup fr = new FrmKulup();
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDersler fr = new FrmDersler();
            fr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Frm_Ogrenci fr = new Frm_Ogrenci();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSinavNotlar fr = new FrmSinavNotlar();
            fr.Show();
        }

        private void FrmOgretmen_Load(object sender, EventArgs e)
        {

        }
    }
}
