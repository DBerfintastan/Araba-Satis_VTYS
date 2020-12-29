using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace satis_uygulamasi
{
    public partial class minivan : Form
    {
        public minivan()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=satis_uygulamasi; user Id=postgres; password=031199");
        private void listele_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from minivan";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void ekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand ekle = new NpgsqlCommand("insert into minivan(marka,model,yakit,vites,renk,sasi,durum,fiyat,yil,kasatipi,saticiid,koltuksayisi) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)", baglanti);
            ekle.Parameters.AddWithValue("@p1", mnvnMarka.Text);
            ekle.Parameters.AddWithValue("@p2", mnvnModel.Text);
            ekle.Parameters.AddWithValue("@p3", mnvnYakit.Text);
            ekle.Parameters.AddWithValue("@p4", mnvnVites.Text);
            ekle.Parameters.AddWithValue("@p5", mnvnRenk.Text);
            ekle.Parameters.AddWithValue("@p6", mnvnSasi.Text);
            ekle.Parameters.AddWithValue("@p7", mnvnDurum.Text);
            ekle.Parameters.AddWithValue("@p8", int.Parse(mnvnFiyat.Text));
            ekle.Parameters.AddWithValue("@p9", int.Parse(mnvnYil.Text));
            ekle.Parameters.AddWithValue("@p10", mnvnKasa.Text);
            ekle.Parameters.AddWithValue("@p11", int.Parse(mnvnSatici.Text));
            ekle.Parameters.AddWithValue("@p12", int.Parse(mnvnKoltuk.Text));
            ekle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ekleme Başarılı");
        }

        private void sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand sil1 = new NpgsqlCommand("delete from minivan where aracid=@p1", baglanti);
            sil1.Parameters.AddWithValue("@p1", int.Parse(aracId.Text));
            sil1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Arac Silindi");
        }

        private void guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand guncelle1 = new NpgsqlCommand("update minivan set fiyat=@p1 where aracid=@p2", baglanti);
            guncelle1.Parameters.AddWithValue("@p1", int.Parse(mnvnFiyat.Text));
            guncelle1.Parameters.AddWithValue("@p2", int.Parse(aracId.Text));
            guncelle1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Fiyat Güncellendi");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            satici Satici = new satici();
            Satici.Show();
            this.Close();
        }
    }
}
