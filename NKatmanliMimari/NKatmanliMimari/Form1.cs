using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Referans aldığımız kütüphaneleri ekliyoruz
using EntityLayer;
using DataAccessLayer;
using LogicLayer;

namespace NKatmanliMimari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void temizle()
        {
            txt_AD.Text = "";
            txt_GOREV.Text = "";
            txt_ID.Text = "";
            txt_MAAS.Text = "";
            txt_SEHIR.Text = "";
            txt_SOYAD.Text = "";
        }

        private void btn_Listele_Click(object sender, EventArgs e)
        {

            List<EntityPersonel> PerList = LogicPersonel.LLPersonelListesi();
            dataGridView1.DataSource = PerList;
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            EntityPersonel personel = new EntityPersonel();
            personel.Ad = txt_AD.Text;
            personel.Soyad = txt_GOREV.Text;
            personel.Maas = short.Parse(txt_MAAS.Text);
            personel.Sehir = txt_SEHIR.Text;
            personel.Gorev = txt_GOREV.Text;
            LogicPersonel.LLPersonelEkle(personel);
            MessageBox.Show("Personel Listeye Eklendi!");
            temizle();
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            EntityPersonel personel = new EntityPersonel();
            personel.Id = int.Parse(txt_ID.Text);
            LogicPersonel.LLPersonelSil(personel.Id);
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            EntityPersonel personel = new EntityPersonel();
            personel.Id = int.Parse(txt_ID.Text);
            personel.Ad = txt_AD.Text;
            personel.Soyad = txt_SOYAD.Text;
            personel.Gorev = txt_GOREV.Text;
            personel.Maas = short.Parse(txt_MAAS.Text);
            personel.Sehir = txt_SEHIR.Text;
            LogicPersonel.LLPersonelGuncelle(personel);
        }
    }
}
