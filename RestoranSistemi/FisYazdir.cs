using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using RestoranSistemi;
using System.Linq;
using System.Collections.Generic;

public partial class FisYazdir : Form
{
    private Database db;
    private int masaNo;
    private ListView? siparislerListView;
    private Label? toplamLabel;
    private Button? yazdirButton;
    private Button? iptalButton;
    private List<Siparis> _siparisler;

    public FisYazdir(int masaNo, List<Siparis> siparisler)
    {
        InitializeComponent();
        this.masaNo = masaNo;
        db = new Database();
        _siparisler = siparisler;
        SiparisleriListele(siparisler);
    }

    private void InitializeComponent()
    {
        this.Text = $"Masa {masaNo} - Fiş Yazdır";
        this.Size = new Size(600, 500);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.FromArgb(240, 240, 240);
        this.Font = new Font("Segoe UI", 10F);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        // Siparişler ListView
        siparislerListView = new ListView();
        siparislerListView.Location = new Point(20, 20);
        siparislerListView.Size = new Size(540, 350);
        siparislerListView.View = View.Details;
        siparislerListView.FullRowSelect = true;
        siparislerListView.GridLines = true;
        siparislerListView.BackColor = Color.White;
        siparislerListView.Font = new Font("Segoe UI", 10F);
        siparislerListView.Columns.Add("Yemek", 200);
        siparislerListView.Columns.Add("Adet", 80);
        siparislerListView.Columns.Add("Birim Fiyat", 120);
        siparislerListView.Columns.Add("Toplam", 120);
        this.Controls.Add(siparislerListView);

        // Toplam Label
        toplamLabel = new Label
        {
            Text = "Toplam: 0,00 ₺",
            Location = new Point(20, 390),
            Size = new Size(540, 30),
            Font = new Font("Segoe UI", 12F, FontStyle.Bold),
            ForeColor = Color.FromArgb(44, 62, 80),
            TextAlign = ContentAlignment.MiddleRight
        };
        this.Controls.Add(toplamLabel);

        // Butonlar
        var buttonStyle = new ButtonStyle
        {
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            Size = new Size(120, 35),
            BackColor = Color.FromArgb(0, 150, 136),
            ForeColor = Color.White,
            Cursor = Cursors.Hand
        };

        yazdirButton = new Button();
        yazdirButton.Text = "🖨️ Yazdır";
        yazdirButton.Location = new Point(330, 440);
        ApplyButtonStyle(yazdirButton, buttonStyle);
        yazdirButton.Click += YazdirButton_Click;
        this.Controls.Add(yazdirButton);

        iptalButton = new Button();
        iptalButton.Text = "❌ İptal";
        iptalButton.Location = new Point(460, 440);
        ApplyButtonStyle(iptalButton, buttonStyle);
        iptalButton.Click += IptalButton_Click;
        this.Controls.Add(iptalButton);
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

    private void SiparisleriListele(List<Siparis> siparisler)
    {
        if (siparislerListView != null)
        {
            siparislerListView.Items.Clear();
            decimal toplam = 0;

            foreach (var siparis in siparisler)
            {
                var item = new ListViewItem(siparis.YemekAdi);
                item.SubItems.Add(siparis.Adet.ToString());
                item.SubItems.Add(siparis.Fiyat.ToString("C"));
                item.SubItems.Add((siparis.Fiyat * siparis.Adet).ToString("C"));
                siparislerListView.Items.Add(item);
                toplam += siparis.Fiyat * siparis.Adet;
            }

            toplamLabel.Text = $"Toplam: {toplam:C}";
        }
    }

    private void YazdirButton_Click(object sender, EventArgs e)
    {
        try
        {
            var printer = new PrintDocument();
            printer.PrintPage += Printer_PrintPage;
            printer.Print();
            MessageBox.Show("Fiş başarıyla yazdırıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Yazdırma hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void Printer_PrintPage(object sender, PrintPageEventArgs e)
    {
        if (siparislerListView == null) return;
        Graphics g = e.Graphics;
        Font baslikFont = new Font("Arial", 16, FontStyle.Bold);
        Font altBaslikFont = new Font("Arial", 12, FontStyle.Bold);
        Font normalFont = new Font("Arial", 10);
        Font toplamFont = new Font("Arial", 12, FontStyle.Bold);
        float y = 50;
        float x = 50;
        float maxWidth = e.PageBounds.Width - 100;

        // Restoran Başlığı
        string baslik = "LEZZET DURAĞI RESTORAN";
        SizeF baslikSize = g.MeasureString(baslik, baslikFont);
        g.DrawString(baslik, baslikFont, Brushes.Black, (maxWidth - baslikSize.Width) / 2 + x, y);
        y += baslikSize.Height + 10;

        // Tarih ve Saat
        string tarihSaat = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
        g.DrawString(tarihSaat, normalFont, Brushes.Black, x, y);
        y += 20;

        // Masa No
        g.DrawString($"Masa No: {masaNo}", altBaslikFont, Brushes.Black, x, y);
        y += 30;

        // Ayırıcı Çizgi
        g.DrawLine(Pens.Black, x, y, maxWidth + x, y);
        y += 20;

        // Siparişler Başlığı
        g.DrawString("Siparişler", altBaslikFont, Brushes.Black, x, y);
        y += 25;

        // Siparişler
        decimal toplam = 0;
        foreach (var siparis in _siparisler)
        {
            string yemekBilgisi = $"{siparis.YemekAdi} x {siparis.Adet}";
            string fiyatBilgisi = (siparis.Fiyat * siparis.Adet).ToString("C");
            
            g.DrawString(yemekBilgisi, normalFont, Brushes.Black, x, y);
            SizeF fiyatSize = g.MeasureString(fiyatBilgisi, normalFont);
            g.DrawString(fiyatBilgisi, normalFont, Brushes.Black, maxWidth + x - fiyatSize.Width, y);
            
            toplam += siparis.Fiyat * siparis.Adet;
            y += 20;
        }

        // Alt Ayırıcı Çizgi
        y += 10;
        g.DrawLine(Pens.Black, x, y, maxWidth + x, y);
        y += 20;

        // Toplam
        string toplamText = $"Toplam: {toplam:C}";
        SizeF toplamSize = g.MeasureString(toplamText, toplamFont);
        g.DrawString(toplamText, toplamFont, Brushes.Black, maxWidth + x - toplamSize.Width, y);
        y += 30;

        // Teşekkür Mesajı
        string tesekkur = "Bizi tercih ettiğiniz için teşekkür ederiz!";
        SizeF tesekkurSize = g.MeasureString(tesekkur, normalFont);
        g.DrawString(tesekkur, normalFont, Brushes.Black, (maxWidth - tesekkurSize.Width) / 2 + x, y);
        y += 20;

        // Alt Bilgi
        string altBilgi = "Afiyet Olsun!";
        SizeF altBilgiSize = g.MeasureString(altBilgi, normalFont);
        g.DrawString(altBilgi, normalFont, Brushes.Black, (maxWidth - altBilgiSize.Width) / 2 + x, y);
    }

    private void IptalButton_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
} 