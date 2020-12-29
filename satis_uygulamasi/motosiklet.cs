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
    public partial class motosiklet : Form
    {
        public motosiklet()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=satis_uygulamasi; user Id=postgres; password=031199");
        private void otoListe_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from motosiklet";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void otoEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand ekle1 = new NpgsqlCommand("insert into motosiklet(marka,model,yakit,vites,renk,sogutma,durum,fiyat,yil,silindirsayisi,zamanlamatipi,saticiid) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)", baglanti);
            ekle1.Parameters.AddWithValue("@p1", motoMarka.Text);
            ekle1.Parameters.AddWithValue("@p2", motoModel.Text);
            ekle1.Parameters.AddWithValue("@p3", motoYakit.Text);
            ekle1.Parameters.AddWithValue("@p4", motoVites.Text);
            ekle1.Parameters.AddWithValue("@p5", motoRenk.Text);
            ekle1.Parameters.AddWithValue("@p6", motoSogutma.Text);
            ekle1.Parameters.AddWithValue("@p7", motoDurum.Text);
            ekle1.Parameters.AddWithValue("@p8", int.Parse(motoFiyat.Text));
            ekle1.Parameters.AddWithValue("@p9", int.Parse(motoYil.Text));
            ekle1.Parameters.AddWithValue("@p10", int.Parse(motoSilindir.Text));
            ekle1.Parameters.AddWithValue("@p11", int.Parse(motoZamanlama.Text));
            ekle1.Parameters.AddWithValue("@p12", int.Parse(motoSatici.Text));
            ekle1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ekleme Başarılı");
        }

        private void otoSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand sil1 = new NpgsqlCommand("delete from motosiklet where aracid=@p1", baglanti);
            sil1.Parameters.AddWithValue("@p1", int.Parse(aracId.Text));
            sil1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Arac Silindi");
        }

        private void otoGüncel_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand guncelle1 = new NpgsqlCommand("update motosiklet set fiyat=@p1 where aracid=@p2", baglanti);
            guncelle1.Parameters.AddWithValue("@p1", int.Parse(motoFiyat.Text));
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
