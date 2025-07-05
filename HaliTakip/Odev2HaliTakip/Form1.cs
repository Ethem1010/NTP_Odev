using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Odev2HaliTakip
{
    public partial class Form1 : Form
    {
        List<Musteri> musteriler = new List<Musteri>();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // DataGridView sütunlarını ayarla
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Ad", "Ad");
            dataGridView1.Columns.Add("Ucret", "Ücret");
            dataGridView1.Columns.Add("Soyad", "Soyad");
            dataGridView1.Columns.Add("Metrekare", "Metrekare");
            dataGridView1.Columns.Add("AlinmaTarihi", "AlınmaTarihi");
            dataGridView1.Columns.Add("Durum", "Durum");
            dataGridView1.AutoGenerateColumns = false;
            comboBox1.DisplayMember = "ToString";
        }

        private void buttonMusteriEkle_Click(object sender, EventArgs e)
        {
            var musteri = new Musteri
            {
                Ad = textBoxAd.Text,
                Soyad = textBoxSoyad.Text,
                Telefon = textBoxTelefon.Text,
                Adres = textBoxAdres.Text
            };
            musteriler.Add(musteri);
            comboBox1.Items.Add(musteri);
            MessageBox.Show("Müşteri başarıyla eklendi.");
            textBoxAd.Clear();
            textBoxSoyad.Clear();
            textBoxTelefon.Clear();
            textBoxAdres.Clear();
        }

        private void buttonHaliEkle_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is Musteri seciliMusteri)
            {
                if (double.TryParse(textBoxMetrekare.Text, out double metrekare))
                {
                    var hali = new Hali_
                    {
                        Metrekare = metrekare,
                        AlinmaTarihi = dateTimePickerAlinma.Value,
                        TahminiTeslimTarihi = dateTimePickerTeslim.Value
                    };
                    seciliMusteri.Halilar.Add(hali);
                    MessageBox.Show("Halı başarıyla eklendi.");
                    textBoxMetrekare.Clear();
                }
                else
                {
                    MessageBox.Show("Lütfen geçerli bir metrekare girin.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir müşteri seçin.");
            }
        }

        private void buttonTeslimEdilenleriListele_Click(object sender, EventArgs e)
        {
            Listele("Teslim Edildi");
        }

        private void buttonYikamdaOlanlariListele_Click(object sender, EventArgs e)
        {
            Listele("Yıkamada");
        }

        private void buttonDurumuTeslimEdildiYap_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is Musteri seciliMusteri)
            {
                foreach (var h in seciliMusteri.Halilar)
                {
                    if (h.Durum == "Yıkamada")
                    {
                        h.Durum = "Teslim Edildi";
                    }
                }
                MessageBox.Show("Durumlar güncellendi.");
            }
        }

        private void Listele(string durum)
        {
            dataGridView1.Rows.Clear();
            foreach (var m in musteriler)
            {
                foreach (var h in m.Halilar)
                {
                    if (h.Durum == durum)
                    {
                        dataGridView1.Rows.Add(
                            m.Ad,
                            h.Ucret,
                            m.Soyad,
                            h.Metrekare,
                            h.AlinmaTarihi.ToShortDateString(),
                            h.Durum
                        );
                    }
                }
            }
        }
    }

    public class Musteri
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public List<Hali_> Halilar { get; set; } = new List<Hali_>();
        public override string ToString()
        {
            return Ad + " " + Soyad;
        }
    }

    public class Hali_
    {
        public double Metrekare { get; set; }
        public DateTime AlinmaTarihi { get; set; }
        public DateTime TahminiTeslimTarihi { get; set; }
        public string Durum { get; set; } = "Yıkamada";
        public double Ucret => Metrekare * 20;
    }
}
