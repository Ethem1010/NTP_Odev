using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace RestoranSistemi
{
    public partial class MenuYonetimi : Form
    {
        private Database db;
        private ListView? listView1;
        private ComboBox? kategoriComboBox;
        private TextBox? yemekAdiTextBox;
        private TextBox? fiyatTextBox;
        private TextBox? aciklamaTextBox;
        private Button? ekleButton;
        private Button? duzenleButton;
        private Button? silButton;
        private Button? kategoriEkleButton;
        private CheckBox? anaYemekCheckBox;
        private Yemek? seciliYemek;

        public MenuYonetimi()
        {
            InitializeComponent();
            db = new Database();
            VerileriYukle();
        }

        private void InitializeComponent()
        {
            this.Text = "Menü Yönetimi";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Font = new Font("Segoe UI", 10F);

            // ListView
            listView1 = new ListView();
            listView1.Location = new Point(20, 20);
            listView1.Size = new Size(500, 400);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.BackColor = Color.White;
            listView1.Font = new Font("Segoe UI", 10F);
            listView1.Columns.Add("Yemek", 200);
            listView1.Columns.Add("Kategori", 100);
            listView1.Columns.Add("Fiyat", 100);
            listView1.Columns.Add("Açıklama", 200);
            this.Controls.Add(listView1);

            // Form elemanları
            var labelStyle = new LabelStyle
            {
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80)
            };

            var textBoxStyle = new TextBoxStyle
            {
                Font = new Font("Segoe UI", 10F),
                Size = new Size(200, 30),
                BackColor = Color.White
            };

            var buttonStyle = new ButtonStyle
            {
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };

            // Kategori ComboBox
            var kategoriLabel = new Label { Text = "Kategori:", Location = new Point(540, 20) };
            ApplyLabelStyle(kategoriLabel, labelStyle);
            this.Controls.Add(kategoriLabel);

            kategoriComboBox = new ComboBox();
            kategoriComboBox.Location = new Point(540, 50);
            kategoriComboBox.Size = new Size(200, 30);
            kategoriComboBox.Font = new Font("Segoe UI", 10F);
            this.Controls.Add(kategoriComboBox);

            // Yemek Adı TextBox
            var yemekAdiLabel = new Label { Text = "Yemek Adı:", Location = new Point(540, 90) };
            ApplyLabelStyle(yemekAdiLabel, labelStyle);
            this.Controls.Add(yemekAdiLabel);

            yemekAdiTextBox = new TextBox();
            yemekAdiTextBox.Location = new Point(540, 120);
            ApplyTextBoxStyle(yemekAdiTextBox, textBoxStyle);
            this.Controls.Add(yemekAdiTextBox);

            // Fiyat TextBox
            var fiyatLabel = new Label { Text = "Fiyat:", Location = new Point(540, 160) };
            ApplyLabelStyle(fiyatLabel, labelStyle);
            this.Controls.Add(fiyatLabel);

            fiyatTextBox = new TextBox();
            fiyatTextBox.Location = new Point(540, 190);
            ApplyTextBoxStyle(fiyatTextBox, textBoxStyle);
            this.Controls.Add(fiyatTextBox);

            // Açıklama TextBox
            var aciklamaLabel = new Label { Text = "Açıklama:", Location = new Point(540, 230) };
            ApplyLabelStyle(aciklamaLabel, labelStyle);
            this.Controls.Add(aciklamaLabel);

            aciklamaTextBox = new TextBox();
            aciklamaTextBox.Location = new Point(540, 260);
            aciklamaTextBox.Size = new Size(200, 60);
            aciklamaTextBox.Multiline = true;
            ApplyTextBoxStyle(aciklamaTextBox, textBoxStyle);
            this.Controls.Add(aciklamaTextBox);

            // Ana Yemek CheckBox
            anaYemekCheckBox = new CheckBox();
            anaYemekCheckBox.Text = "Ana Yemek";
            anaYemekCheckBox.Location = new Point(540, 330);
            this.Controls.Add(anaYemekCheckBox);

            // Butonlar
            ekleButton = new Button();
            ekleButton.Text = "➕ Ekle";
            ekleButton.Location = new Point(540, 340);
            ApplyButtonStyle(ekleButton, buttonStyle);
            ekleButton.Click += EkleButton_Click;
            this.Controls.Add(ekleButton);

            duzenleButton = new Button();
            duzenleButton.Text = "✏️ Düzenle";
            duzenleButton.Location = new Point(670, 340);
            ApplyButtonStyle(duzenleButton, buttonStyle);
            duzenleButton.Click += DuzenleButton_Click;
            this.Controls.Add(duzenleButton);

            silButton = new Button();
            silButton.Text = "🗑️ Sil";
            silButton.Location = new Point(540, 390);
            ApplyButtonStyle(silButton, buttonStyle);
            silButton.Click += SilButton_Click;
            this.Controls.Add(silButton);

            kategoriEkleButton = new Button();
            kategoriEkleButton.Text = "📋 Kategori Ekle";
            kategoriEkleButton.Location = new Point(670, 390);
            ApplyButtonStyle(kategoriEkleButton, buttonStyle);
            kategoriEkleButton.Click += KategoriEkleButton_Click;
            this.Controls.Add(kategoriEkleButton);
        }

        private void ApplyLabelStyle(Label label, LabelStyle style)
        {
            label.Font = style.Font;
            label.ForeColor = style.ForeColor;
        }

        private void ApplyTextBoxStyle(TextBox textBox, TextBoxStyle style)
        {
            textBox.Font = style.Font;
            textBox.Size = style.Size;
            textBox.BackColor = style.BackColor;
        }

        private void ApplyButtonStyle(Button button, ButtonStyle style)
        {
            button.FlatStyle = style.FlatStyle;
            button.Font = style.Font;
            button.Size = style.Size;
            button.BackColor = style.BackColor;
            button.ForeColor = style.ForeColor;
            button.Cursor = style.Cursor;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 130, 116);
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 110, 96);
        }

        private class LabelStyle
        {
            public Font Font { get; set; }
            public Color ForeColor { get; set; }
        }

        private class TextBoxStyle
        {
            public Font Font { get; set; }
            public Size Size { get; set; }
            public Color BackColor { get; set; }
        }

        private class ButtonStyle
        {
            public FlatStyle FlatStyle { get; set; }
            public Font Font { get; set; }
            public Size Size { get; set; }
            public Color BackColor { get; set; }
            public Color ForeColor { get; set; }
            public Cursor Cursor { get; set; }
        }

        private void VerileriYukle()
        {
            try
            {
                // Kategorileri yükle
                var kategoriler = db.GetKategoriler();
                if (kategoriComboBox != null)
                {
                    kategoriComboBox.Items.Clear();
                    kategoriComboBox.Items.Add("Kategori Seçiniz");
                    foreach (var kategori in kategoriler)
                    {
                        kategoriComboBox.Items.Add(kategori);
                    }
                    kategoriComboBox.SelectedIndex = 0;
                }

                // Yemekleri listele
                YemekleriListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void YemekleriListele()
        {
            if (listView1 != null)
            {
                listView1.Items.Clear();
                var yemekler = db.GetYemekler();
                foreach (var yemek in yemekler)
                {
                    if (yemek != null && yemek.Ad != null)
                    {
                        var item = new ListViewItem(yemek.Ad);
                        item.SubItems.Add(yemek.KategoriAdi ?? "");
                        item.SubItems.Add(yemek.Fiyat.ToString("C"));
                        item.SubItems.Add(yemek.Aciklama ?? "");
                        item.Tag = yemek;
                        listView1.Items.Add(item);
                    }
                }
            }
        }

        private void EkleButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(yemekAdiTextBox.Text) || string.IsNullOrWhiteSpace(fiyatTextBox.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var yemek = new Yemek(
                    0,
                    yemekAdiTextBox.Text,
                    aciklamaTextBox.Text,
                    decimal.Parse(fiyatTextBox.Text),
                    kategoriComboBox.Text,
                    anaYemekCheckBox.Checked,
                    kategoriComboBox.SelectedIndex + 1
                );

                if (db.YemekEkle(yemek))
                {
                    MessageBox.Show("Yemek başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    YemekleriListele();
                    FormuTemizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DuzenleButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(yemekAdiTextBox.Text) || string.IsNullOrWhiteSpace(fiyatTextBox.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var yemek = new Yemek(
                    seciliYemek != null ? seciliYemek.ID : 0,
                    yemekAdiTextBox.Text,
                    aciklamaTextBox.Text,
                    decimal.Parse(fiyatTextBox.Text),
                    kategoriComboBox.Text,
                    anaYemekCheckBox.Checked,
                    kategoriComboBox.SelectedIndex + 1
                );

                if (db.YemekGuncelle(yemek))
                {
                    MessageBox.Show("Yemek başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    YemekleriListele();
                    FormuTemizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SilButton_Click(object sender, EventArgs e)
        {
            if (seciliYemek == null)
            {
                MessageBox.Show("Lütfen silinecek yemeği seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Seçili yemeği silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (db.YemekSil(seciliYemek.ID))
                    {
                        MessageBox.Show("Yemek başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        YemekleriListele();
                        FormuTemizle();
                    }
                    else
                    {
                        MessageBox.Show("Yemek silinirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void KategoriEkleButton_Click(object sender, EventArgs e)
        {
            var form = new KategoriEkle();
            if (form.ShowDialog() == DialogResult.OK)
            {
                VerileriYukle();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                seciliYemek = (Yemek)listView1.SelectedItems[0].Tag;
                yemekAdiTextBox.Text = seciliYemek.Ad;
                fiyatTextBox.Text = seciliYemek.Fiyat.ToString();
                aciklamaTextBox.Text = seciliYemek.Aciklama;
                anaYemekCheckBox.Checked = seciliYemek.AnaYemek;

                // Kategoriyi seç
                if (seciliYemek.KategoriID > 0)
                {
                    for (int i = 0; i < kategoriComboBox.Items.Count; i++)
                    {
                        if (kategoriComboBox.Items[i] is Kategori kategori && kategori.KategoriID == seciliYemek.KategoriID)
                        {
                            kategoriComboBox.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    kategoriComboBox.SelectedIndex = 0;
                }
            }
            else
            {
                FormuTemizle();
            }
        }

        private void FormuTemizle()
        {
            seciliYemek = null;
            yemekAdiTextBox.Clear();
            fiyatTextBox.Clear();
            aciklamaTextBox.Clear();
            anaYemekCheckBox.Checked = true;
            kategoriComboBox.SelectedIndex = 0;
            listView1.SelectedItems.Clear();
        }
    }
} 