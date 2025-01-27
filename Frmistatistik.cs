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
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DENIZ;Initial Catalog=PersonelVeriTabani;Integrated Security=True;");
        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            //personel sayisi
            SqlCommand komut1 = new SqlCommand("Select Count(*) From Tbl_personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblpersayisi.Text = dr1[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            //Evli personel sayisi
            SqlCommand komut2 = new SqlCommand("Select Count(*) From Tbl_personel where Durum=1", baglanti);

            SqlDataReader dr2 = komut2.ExecuteReader();
            
                while (dr2.Read())
            {
                lblEvli.Text = dr2[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            //bekar personel sayisi
            SqlCommand komut3 = new SqlCommand("Select Count(*) From Tbl_personel where Durum=0", baglanti);

            SqlDataReader dr3 = komut3.ExecuteReader();

            while (dr3.Read())
            {
                lblBekar.Text = dr3[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            //farklı sehir sayisi
            SqlCommand komut4 = new SqlCommand("Select Count(distinct(Persehir)) From Tbl_personel", baglanti);

            SqlDataReader dr4 = komut4.ExecuteReader();

            while (dr4.Read())
            {
                lblsehir.Text = dr4[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            //Toplam maas
            SqlCommand komut5 = new SqlCommand("Select Sum(Maas) From Tbl_personel", baglanti);

            SqlDataReader dr5 = komut5.ExecuteReader();

            while (dr5.Read())
            {
                lblmaas.Text = dr5[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            //ortalama maas
            SqlCommand komut6 = new SqlCommand("Select Avg(Maas) From Tbl_personel", baglanti);

            SqlDataReader dr6 = komut6.ExecuteReader();

            while (dr6.Read())
            {
                lblOrtalama.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }
    }
}
