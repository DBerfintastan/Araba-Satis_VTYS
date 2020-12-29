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
    public partial class arazi : Form
    {
        public arazi()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=satis_uygulamasi; user Id=postgres; password=031199");
        private void listele_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from arazi";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void ekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand ekle1 = new NpgsqlCommand("insert into arazi(marka,model,yakit,vites,renk,cekis,durum,fiyat,yil,kapi,saticiid) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", baglanti);
            ekle1.Parameters.AddWithValue("@p1", araziMarka.Text);
            ekle1.Parameters.AddWithValue("@p2", araziModel.Text);
            ekle1.Parameters.AddWithValue("@p3", araziYakit.Text);
            ekle1.Parameters.AddWithValue("@p4", araziVites.Text);
            ekle1.Parameters.AddWithValue("@p5", araziRenk.Text);
            ekle1.Parameters.AddWithValue("@p6", araziCekis.Text);
            ekle1.Parameters.AddWithValue("@p7", araziDurum.Text);
            ekle1.Parameters.AddWithValue("@p8", int.Parse(araziFiyat.Text));
            ekle1.Parameters.AddWithValue("@p9", int.Parse(araziYil.Text));
            ekle1.Parameters.AddWithValue("@p10", int.Parse(araziKapi.Text));
            ekle1.Parameters.AddWithValue("@p11", int.Parse(araziSatici.Text));
            ekle1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ekleme Başarılı");
        }

        private void sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand sil1 = new NpgsqlCommand("delete from arazi where aracid=@p1", baglanti);
            sil1.Parameters.AddWithValue("@p1", int.Parse(aracId.Text));
            sil1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Arac Silindi");
        }

        private void guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand guncelle1 = new NpgsqlCommand("update arazi set fiyat=@p1 where aracid=@p2", baglanti);
            guncelle1.Parameters.AddWithValue("@p1", int.Parse(araziFiyat.Text));
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
