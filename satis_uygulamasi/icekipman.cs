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
    public partial class icekipman : Form
    {
        public icekipman()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=satis_uygulamasi; user Id=postgres; password=031199");
        private void listele_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from icekipman";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void ekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand ekle1 = new NpgsqlCommand("insert into icekipman(parcamarka,parcamodel,urunadi,ozellik,uretimtarihi,aracid) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            ekle1.Parameters.AddWithValue("@p1", ieMarka.Text);
            ekle1.Parameters.AddWithValue("@p2", ieModel.Text);
            ekle1.Parameters.AddWithValue("@p3", urunAdi.Text);
            ekle1.Parameters.AddWithValue("@p4", urunOzel.Text);
            ekle1.Parameters.AddWithValue("@p5", int.Parse(ieTarih.Text));
            ekle1.Parameters.AddWithValue("@p6", int.Parse(aracID.Text));
            ekle1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ekleme Başarılı");
        }

        private void sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand sil1 = new NpgsqlCommand("delete from icekipman where aracparcaid=@p1", baglanti);
            sil1.Parameters.AddWithValue("@p1", int.Parse(aracParca.Text));
            sil1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Parça Silindi");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            satici Satici = new satici();
            Satici.Show();
            this.Close();
        }
    }
}
