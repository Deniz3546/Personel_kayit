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
namespace Personel_kayit
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DENIZ;Initial Catalog=PersonelVeriTabani;Integrated Security=True;");
        private void btnGiris_Click(object sender, EventArgs e)
        {
           baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBL_GİRİS where kullaniciadi=@p1 and sifre=@p2 ", baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
             SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                Form1 frm=new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş");
            }
        }   

    }
}
