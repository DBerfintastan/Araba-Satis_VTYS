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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            satici Satici = new satici();
            Satici.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            musteri Musteri = new musteri();
            Musteri.Show();
            this.Hide();
        }
    }
}
