using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Linq;

namespace RestoranSistemi
{
    public partial class Form1 : Form
    {
        private readonly Database db;
        private List<Masa> masalar;
        private Masa? seciliMasa;
        private readonly Color masaBosRenk = Color.FromArgb(144, 238, 144); // Açık yeşil
        private readonly Color masaDoluRenk = Color.FromArgb(220, 20, 60); // Koyu kırmızı
        private readonly Color masaSeciliRenk = Color.FromArgb(255, 215, 0); // Altın sarısı
        private List<Yemek> menu;
        private string rol;
        private string kullaniciAdi;
        private Label toplamLabel;
        private Panel masaPanel;
        private Panel menuPanel;
        private Panel siparisPanel;
        private Button button2;
        private FlowLayoutPanel menuFlowLayoutPanel;
        private FlowLayoutPanel siparisItemsFlowPanel;
        private FlowLayoutPanel masaFlowLayoutPanel;

        public Form1(string rol, string kullaniciAdi)
        {
            this.rol = rol;
            this.kullaniciAdi = kullaniciAdi;
            this.Text = $"🍽️ Lezzet Durağı Restoran Sistemi - {kullaniciAdi} ({rol})";
            this.Size = new Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(236, 240, 241);
            
            db = new Database();
            masalar = new List<Masa>();
            menu = new List<Yemek>();
            
            // Ana düzenleyici TableLayoutPanel oluştur
            TableLayoutPanel mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
                Padding = new Padding(10)
            };
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250)); // Masalar
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100)); // Menü
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300)); // Siparişler
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            this.Controls.Add(mainLayout);

            // Sadece 3 ana panel
            masaPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10)
            };
            mainLayout.Controls.Add(masaPanel, 0, 0);

            menuPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10)
            };
            mainLayout.Controls.Add(menuPanel, 1, 0);

            siparisPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10)
            };
            mainLayout.Controls.Add(siparisPanel, 2, 0);

            // Masalar için FlowLayoutPanel
            masaFlowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                AutoScroll = true,
                Padding = new Padding(10),
                BackColor = Color.White
            };
            masaPanel.Controls.Add(masaFlowLayoutPanel);

            // Menü için FlowLayoutPanel
            menuFlowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown, // Yukarıdan aşağıya akış
                WrapContents = true,
                AutoScroll = true,
                Padding = new Padding(10),
                BackColor = Color.White
            };
            menuPanel.Controls.Add(menuFlowLayoutPanel);

            // İçerik ve alt kısım için ana TableLayoutPanel
            TableLayoutPanel siparisContentLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(0) // İç dolgu, siparisPanel dış dolguyu halleder
            };
            siparisContentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // Sipariş listesi için
            siparisContentLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Toplam ve butonlar için
            siparisPanel.Controls.Add(siparisContentLayout); // Bu layoutu siparisPanel'e ekle

            // Sipariş itemleri için FlowLayoutPanel (üst kısım)
            siparisItemsFlowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown, // Öğeler yukarıdan aşağıya akar
                WrapContents = false, // Sonraki sütuna geçme
                AutoScroll = true,
                Padding = new Padding(0), // Burada dolgu yok, siparisPanel halleder
                BackColor = Color.White
            };
            siparisContentLayout.Controls.Add(siparisItemsFlowPanel, 0, 0); // (0,0) konumuna ekle

            // Alt kısım için TableLayoutPanel (Toplam ve Butonlar)
            TableLayoutPanel bottomLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1, // Sadece bir sütun
                RowCount = 2,    // İki satır: biri butonlar için, biri toplam için
                AutoSize = true,
                Padding = new Padding(5)
            };
            bottomLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Butonlar için satır
            bottomLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Toplam etiketi için satır
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100)); // Tek sütun, tam genişlik

            siparisContentLayout.Controls.Add(bottomLayout, 0, 1); // Ana layout'a ekle

            // Butonlar için FlowLayoutPanel (üstte)
            FlowLayoutPanel buttonsInBottomPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft, // Butonlar sağdan sola akar
                AutoSize = true,
                WrapContents = false,
                Dock = DockStyle.Fill,
                Padding = new Padding(0)
            };
            bottomLayout.Controls.Add(buttonsInBottomPanel, 0, 0); // bottomLayout içinde Sütun 0, Satır 0

            // Fiş Yazdır Butonu
            button2 = new Button
            {
                Text = "🖨️ Fiş Yazdır",
                Size = new Size(130, 45),
                Margin = new Padding(5) // Butonlar arasında boşluk
            };
            ApplyButtonStyle(button2, new ButtonStyle
            {
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(130, 45),
                BackColor = Color.FromArgb(52, 152, 219), // Belirgin mavi
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            });
            button2.Click += button2_Click;
            buttonsInBottomPanel.Controls.Add(button2);

            // Sipariş Al Butonu
            Button confirmOrderButton = new Button
            {
                Text = "✅ Sipariş Al",
                Size = new Size(130, 45),
                Margin = new Padding(5) // Butonlar arasında boşluk
            };
            ApplyButtonStyle(confirmOrderButton, new ButtonStyle
            {
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(130, 45),
                BackColor = Color.FromArgb(46, 204, 113), // Yeşil renk
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            });
            confirmOrderButton.Click += ConfirmOrderButton_Click;
            buttonsInBottomPanel.Controls.Add(confirmOrderButton);

            // Toplam Label (altta)
            toplamLabel = new Label
            {
                Text = "Toplam: 0.00 TL",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                Anchor = AnchorStyles.Left, // Kendi hücresinde sola hizalı
                AutoSize = true
            };
            bottomLayout.Controls.Add(toplamLabel, 0, 1); // bottomLayout içinde Sütun 0, Satır 1

            this.Load += Form1_Load;
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

        private class ButtonStyle
        {
            public FlatStyle FlatStyle { get; set; }
            public Font Font { get; set; }
            public Size Size { get; set; }
            public Color BackColor { get; set; }
            public Color ForeColor { get; set; }
            public Cursor Cursor { get; set; }
        }

        private void MasalariOlustur()
        {
            masaFlowLayoutPanel.Controls.Clear(); // Clear existing buttons
            
            if (masaFlowLayoutPanel == null) return; // Artık null olmamalı ama yine de kontrol iyi

            foreach (var masa in masalar)
            {
                var masaButton = new Button
                {
                    Text = $"Masa {masa.MasaNo}",
                    Size = new Size(80, 80),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = masa.Dolu ? masaDoluRenk : masaBosRenk,
                    Tag = masa
                };
                masaButton.Click += MasaButton_Click;
                masaFlowLayoutPanel.Controls.Add(masaButton);
            }

            masaFlowLayoutPanel.Location = new Point(masaPanel.Padding.Left, masaPanel.Padding.Top);
            masaFlowLayoutPanel.Size = new Size(masaPanel.ClientSize.Width - masaPanel.Padding.Horizontal, 
                                                masaPanel.ClientSize.Height - masaPanel.Padding.Bottom - 10);
        }

        private void MasaButton_Click(object sender, EventArgs e)
        {
            if (sender is Button masaButton && masaButton.Tag is Masa masa)
            {
                if (seciliMasa != null)
                {
                    var eskiMasaButton = masaFlowLayoutPanel.Controls.OfType<Button>().FirstOrDefault(b => b.Tag == seciliMasa);
                    if (eskiMasaButton != null)
                    {
                        eskiMasaButton.BackColor = seciliMasa.Dolu ? masaDoluRenk : masaBosRenk;
                    }
                }

                seciliMasa = masa;
                masaButton.BackColor = masaSeciliRenk;

                // Seçili masanın siparişlerini göster
                SiparisleriGoster(masa.MasaNo);
            }
        }

        private void SiparisleriGoster(int masaNo)
        {
            siparisItemsFlowPanel.Controls.Clear(); // Mevcut sipariş etiketlerini temizle

            var baslik = new Label
            {
                Text = $"Masa {masaNo} Siparişleri",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 10) // Alt kenar boşluğu ekle
            };
            siparisItemsFlowPanel.Controls.Add(baslik);

            var siparisler = db.SiparisleriGetir(masaNo);
            decimal toplam = 0;

            foreach (var siparis in siparisler)
            {
                var siparisLabel = new Label
                {
                    Text = $"{siparis.YemekAdi} - {siparis.Fiyat:C}",
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.FromArgb(44, 62, 80),
                    AutoSize = true,
                    Margin = new Padding(0, 0, 0, 5) // Alt kenar boşluğu ekle
                };
                siparisItemsFlowPanel.Controls.Add(siparisLabel);
                toplam += siparis.Fiyat;
            }

            toplamLabel.Text = $"Toplam: {toplam:C}";
            // ToplamLabel'ın konumu artık bottomLayout tarafından yönetiliyor
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            MasalariYukle();
            MasalariOlustur();
            LoadMenuFromDatabase();

            // Ensure all controls are added and visible.
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void LoadMenuFromDatabase()
        {
            menuFlowLayoutPanel.Controls.Clear(); // FlowLayoutPanel temizlendi
            try
            {
                menu = db.GetYemekler();
                if (menu != null && menu.Any())
                {
                    // Yemekleri kategoriye göre grupla
                    var groupedMenu = menu.GroupBy(y => y.KategoriAdi ?? "Diğer").OrderBy(g => g.Key);

                    foreach (var group in groupedMenu)
                    {
                        // Kategori Başlığı
                        Label kategoriHeader = new Label
                        {
                            Text = group.Key.ToUpper(), // Kategori adını büyük harflerle yaz
                            Font = new Font("Segoe UI", 12, FontStyle.Bold), // Daha büyük ve kalın font
                            ForeColor = Color.FromArgb(44, 62, 80), // Koyu gri renk
                            AutoSize = true,
                            Margin = new Padding(5, 10, 5, 5),
                            Dock = DockStyle.Top // Başlığın tüm genişliği kaplamasını sağla
                        };
                        menuFlowLayoutPanel.Controls.Add(kategoriHeader);

                        // Her kategori için ayrı bir FlowLayoutPanel oluştur
                        FlowLayoutPanel categoryItemsFlowPanel = new FlowLayoutPanel
                        {
                            FlowDirection = FlowDirection.LeftToRight, // Yemekler yatayda sıralanacak
                            WrapContents = true, // Sığmazsa alt satıra geç
                            AutoSize = true, // İçeriğine göre boyutlanacak
                            Padding = new Padding(0),
                            Dock = DockStyle.Top // Üstten alta sıralama için ve tam genişliği kaplaması için
                        };
                        menuFlowLayoutPanel.Controls.Add(categoryItemsFlowPanel); // Ana panele ekle

                        // Her kategori altındaki yemekleri ekle
                        foreach (var yemek in group.OrderBy(y => y.Ad))
                        {
                            Button yemekButton = new Button
                            {
                                Text = $"{yemek.Ad}{Environment.NewLine}{yemek.Fiyat:C}",
                                Tag = yemek, // Yemeği butonun Tag'ine sakla
                                Size = new Size(150, 80),
                                Margin = new Padding(5) // Butonlar arasında boşluk
                            };

                            Color buttonColor;
                            switch (yemek.KategoriAdi)
                            {
                                case "Ana Yemekler":
                                    buttonColor = Color.FromArgb(0, 150, 136);
                                    break;
                                case "İçecekler":
                                    buttonColor = Color.FromArgb(100, 181, 246); // Açık mavi
                                    break;
                                case "Tatlılar":
                                    buttonColor = Color.FromArgb(255, 152, 0); // Turuncu
                                    break;
                                default:
                                    buttonColor = Color.FromArgb(0, 150, 136); // Varsayılan
                                    break;
                            }

                            ApplyButtonStyle(yemekButton, new ButtonStyle // Ortak stil uygulandı
                            {
                                FlatStyle = FlatStyle.Flat,
                                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                Size = new Size(150, 80),
                                BackColor = buttonColor,
                                ForeColor = Color.White,
                                Cursor = Cursors.Hand
                            });
                            yemekButton.Click += YemekButton_Click; // Yeni olay işleyici eklendi
                            categoryItemsFlowPanel.Controls.Add(yemekButton); // Kategori paneline eklendi
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Menüde yemek bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Menü yüklenirken hata oluştu: {ex.Message}");
            }
        }

        private void MasalariYukle()
        {
            masalar = db.MasalariGetir();
            MasalariOlustur();
        }

        private void button2_Click(object? sender, EventArgs e)
        {
            if (seciliMasa == null)
            {
                MessageBox.Show("Lütfen önce bir masa seçin.");
                return;
            }

            List<Siparis> masaSiparisleri = db.SiparisleriGetir(seciliMasa.MasaNo);
            if (masaSiparisleri == null || !masaSiparisleri.Any())
            {
                MessageBox.Show("Bu masada aktif sipariş bulunmamaktadır.");
                return;
            }

            FisYazdir fisYazdirForm = new FisYazdir(seciliMasa.MasaNo, masaSiparisleri);
            fisYazdirForm.ShowDialog();
        }

        private void YemekButton_Click(object? sender, EventArgs e)
        {
            if (seciliMasa == null)
            {
                MessageBox.Show("Lütfen önce bir masa seçin.");
                return;
            }

            Button clickedButton = (Button)sender!;
            Yemek? secilenYemek = clickedButton.Tag as Yemek;

            if (secilenYemek == null)
            {
                MessageBox.Show("Seçilen yemek bilgisi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Siparişi oluştur ve ekle
            db.SiparisEkle(seciliMasa.MasaNo, secilenYemek);
            
            // Masanın siparişlerini güncelle ve UI'yı yenile
            SiparisleriGoster(seciliMasa.MasaNo);
        }

        private void ConfirmOrderButton_Click(object? sender, EventArgs e)
        {
            if (seciliMasa == null)
            {
                MessageBox.Show("Lütfen önce bir masa seçin.");
                return;
            }

            // Masa dolu değilse dolu olarak işaretle
            if (!seciliMasa.Dolu)
            {
                db.MasaDurumunuGuncelle(seciliMasa.MasaNo, true);
                seciliMasa.Dolu = true; // Yerel durumu güncelle
                MasalariOlustur(); // Masa butonlarının durumunu güncellemek için yeniden oluştur
            }

            MessageBox.Show($"Masa {seciliMasa.MasaNo} için siparişler onaylandı.", "Sipariş Onaylandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // Sipariş panelini temizle ve toplamı sıfırla
            siparisItemsFlowPanel.Controls.Clear();
            toplamLabel.Text = "Toplam: 0.00 TL";
            seciliMasa = null; // Seçili masayı temizle
        }
    }
} 