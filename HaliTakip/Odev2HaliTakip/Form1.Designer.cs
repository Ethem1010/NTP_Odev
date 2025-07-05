namespace Odev2HaliTakip;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.TextBox textBoxAd;
    private System.Windows.Forms.TextBox textBoxSoyad;
    private System.Windows.Forms.TextBox textBoxTelefon;
    private System.Windows.Forms.TextBox textBoxAdres;
    private System.Windows.Forms.TextBox textBoxMetrekare;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.DateTimePicker dateTimePickerAlinma;
    private System.Windows.Forms.DateTimePicker dateTimePickerTeslim;
    private System.Windows.Forms.Button buttonMusteriEkle;
    private System.Windows.Forms.Button buttonHaliEkle;
    private System.Windows.Forms.Button buttonTeslimEdilenleriListele;
    private System.Windows.Forms.Button buttonYikamdaOlanlariListele;
    private System.Windows.Forms.Button buttonDurumuTeslimEdildiYap;
    private System.Windows.Forms.Label labelMusteriBilgi;
    private System.Windows.Forms.Label labelAd;
    private System.Windows.Forms.Label labelSoyad;
    private System.Windows.Forms.Label labelTelefon;
    private System.Windows.Forms.Label labelAdres;
    private System.Windows.Forms.Label labelHaliBilgi;
    private System.Windows.Forms.Label labelMetrekare;
    private System.Windows.Forms.Label labelAlinmaTarihi;
    private System.Windows.Forms.Label labelTahminiTeslim;
    private System.Windows.Forms.Label labelMusteriSecin;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.textBoxAd = new System.Windows.Forms.TextBox();
        this.textBoxSoyad = new System.Windows.Forms.TextBox();
        this.textBoxTelefon = new System.Windows.Forms.TextBox();
        this.textBoxAdres = new System.Windows.Forms.TextBox();
        this.textBoxMetrekare = new System.Windows.Forms.TextBox();
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.dataGridView1 = new System.Windows.Forms.DataGridView();
        this.dateTimePickerAlinma = new System.Windows.Forms.DateTimePicker();
        this.dateTimePickerTeslim = new System.Windows.Forms.DateTimePicker();
        this.buttonMusteriEkle = new System.Windows.Forms.Button();
        this.buttonHaliEkle = new System.Windows.Forms.Button();
        this.buttonTeslimEdilenleriListele = new System.Windows.Forms.Button();
        this.buttonYikamdaOlanlariListele = new System.Windows.Forms.Button();
        this.buttonDurumuTeslimEdildiYap = new System.Windows.Forms.Button();
        this.labelMusteriBilgi = new System.Windows.Forms.Label();
        this.labelAd = new System.Windows.Forms.Label();
        this.labelSoyad = new System.Windows.Forms.Label();
        this.labelTelefon = new System.Windows.Forms.Label();
        this.labelAdres = new System.Windows.Forms.Label();
        this.labelHaliBilgi = new System.Windows.Forms.Label();
        this.labelMetrekare = new System.Windows.Forms.Label();
        this.labelAlinmaTarihi = new System.Windows.Forms.Label();
        this.labelTahminiTeslim = new System.Windows.Forms.Label();
        this.labelMusteriSecin = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
        this.SuspendLayout();
        // 
        // labelMusteriBilgi
        // 
        this.labelMusteriBilgi.Text = "Müşteri Bilgileri";
        this.labelMusteriBilgi.Location = new System.Drawing.Point(60, 60);
        this.labelMusteriBilgi.Size = new System.Drawing.Size(120, 20);
        // 
        // labelAd
        // 
        this.labelAd.Text = "Ad:";
        this.labelAd.Location = new System.Drawing.Point(40, 100);
        this.labelAd.Size = new System.Drawing.Size(60, 20);
        // 
        // textBoxAd
        // 
        this.textBoxAd.Location = new System.Drawing.Point(120, 100);
        this.textBoxAd.Size = new System.Drawing.Size(120, 23);
        // 
        // labelSoyad
        // 
        this.labelSoyad.Text = "Soyad:";
        this.labelSoyad.Location = new System.Drawing.Point(40, 140);
        this.labelSoyad.Size = new System.Drawing.Size(60, 20);
        // 
        // textBoxSoyad
        // 
        this.textBoxSoyad.Location = new System.Drawing.Point(120, 140);
        this.textBoxSoyad.Size = new System.Drawing.Size(120, 23);
        // 
        // labelTelefon
        // 
        this.labelTelefon.Text = "Telefon:";
        this.labelTelefon.Location = new System.Drawing.Point(40, 180);
        this.labelTelefon.Size = new System.Drawing.Size(60, 20);
        // 
        // textBoxTelefon
        // 
        this.textBoxTelefon.Location = new System.Drawing.Point(120, 180);
        this.textBoxTelefon.Size = new System.Drawing.Size(120, 23);
        // 
        // labelAdres
        // 
        this.labelAdres.Text = "Adres:";
        this.labelAdres.Location = new System.Drawing.Point(40, 220);
        this.labelAdres.Size = new System.Drawing.Size(60, 20);
        // 
        // textBoxAdres
        // 
        this.textBoxAdres.Location = new System.Drawing.Point(120, 220);
        this.textBoxAdres.Size = new System.Drawing.Size(120, 23);
        // 
        // buttonMusteriEkle
        // 
        this.buttonMusteriEkle.Location = new System.Drawing.Point(90, 260);
        this.buttonMusteriEkle.Size = new System.Drawing.Size(120, 30);
        this.buttonMusteriEkle.Text = "Müşteri Ekle";
        this.buttonMusteriEkle.BackColor = System.Drawing.Color.MediumPurple;
        this.buttonMusteriEkle.ForeColor = System.Drawing.Color.White;
        this.buttonMusteriEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.buttonMusteriEkle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.buttonMusteriEkle.Click += new System.EventHandler(this.buttonMusteriEkle_Click);
        // 
        // labelHaliBilgi
        // 
        this.labelHaliBilgi.Text = "Halı Bilgileri:";
        this.labelHaliBilgi.Location = new System.Drawing.Point(600, 60);
        this.labelHaliBilgi.Size = new System.Drawing.Size(120, 20);
        // 
        // labelMetrekare
        // 
        this.labelMetrekare.Text = "Metrekare:";
        this.labelMetrekare.Location = new System.Drawing.Point(540, 100);
        this.labelMetrekare.Size = new System.Drawing.Size(80, 20);
        // 
        // textBoxMetrekare
        // 
        this.textBoxMetrekare.Location = new System.Drawing.Point(630, 100);
        this.textBoxMetrekare.Size = new System.Drawing.Size(120, 23);
        // 
        // labelAlinmaTarihi
        // 
        this.labelAlinmaTarihi.Text = "Alınma Tarihi:";
        this.labelAlinmaTarihi.Location = new System.Drawing.Point(540, 140);
        this.labelAlinmaTarihi.Size = new System.Drawing.Size(90, 20);
        // 
        // dateTimePickerAlinma
        // 
        this.dateTimePickerAlinma.Location = new System.Drawing.Point(630, 140);
        this.dateTimePickerAlinma.Size = new System.Drawing.Size(180, 23);
        // 
        // labelTahminiTeslim
        // 
        this.labelTahminiTeslim.Text = "Tahmini Teslim Tarihi:";
        this.labelTahminiTeslim.Location = new System.Drawing.Point(500, 180);
        this.labelTahminiTeslim.Size = new System.Drawing.Size(130, 20);
        // 
        // dateTimePickerTeslim
        // 
        this.dateTimePickerTeslim.Location = new System.Drawing.Point(630, 180);
        this.dateTimePickerTeslim.Size = new System.Drawing.Size(180, 23);
        // 
        // labelMusteriSecin
        // 
        this.labelMusteriSecin.Text = "Müşteri Seçin:";
        this.labelMusteriSecin.Location = new System.Drawing.Point(540, 220);
        this.labelMusteriSecin.Size = new System.Drawing.Size(90, 20);
        // 
        // comboBox1
        // 
        this.comboBox1.Location = new System.Drawing.Point(630, 220);
        this.comboBox1.Size = new System.Drawing.Size(180, 23);
        // 
        // buttonHaliEkle
        // 
        this.buttonHaliEkle.Location = new System.Drawing.Point(630, 260);
        this.buttonHaliEkle.Size = new System.Drawing.Size(120, 30);
        this.buttonHaliEkle.Text = "Halı Ekle";
        this.buttonHaliEkle.BackColor = System.Drawing.Color.Turquoise;
        this.buttonHaliEkle.ForeColor = System.Drawing.Color.White;
        this.buttonHaliEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.buttonHaliEkle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.buttonHaliEkle.Click += new System.EventHandler(this.buttonHaliEkle_Click);
        // 
        // buttonTeslimEdilenleriListele
        // 
        this.buttonTeslimEdilenleriListele.Location = new System.Drawing.Point(320, 110);
        this.buttonTeslimEdilenleriListele.Size = new System.Drawing.Size(160, 32);
        this.buttonTeslimEdilenleriListele.Text = "Teslim Edilenleri Listele";
        this.buttonTeslimEdilenleriListele.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.buttonTeslimEdilenleriListele.BackColor = System.Drawing.Color.Gold;
        this.buttonTeslimEdilenleriListele.ForeColor = System.Drawing.Color.White;
        this.buttonTeslimEdilenleriListele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.buttonTeslimEdilenleriListele.FlatAppearance.BorderSize = 0;
        this.buttonTeslimEdilenleriListele.Paint += (s, e) => {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, 20, 20, 180, 90);
            path.AddArc(this.buttonTeslimEdilenleriListele.Width - 20, 0, 20, 20, 270, 90);
            path.AddArc(this.buttonTeslimEdilenleriListele.Width - 20, this.buttonTeslimEdilenleriListele.Height - 20, 20, 20, 0, 90);
            path.AddArc(0, this.buttonTeslimEdilenleriListele.Height - 20, 20, 20, 90, 90);
            path.CloseAllFigures();
            this.buttonTeslimEdilenleriListele.Region = new System.Drawing.Region(path);
        };
        this.buttonTeslimEdilenleriListele.Click += new System.EventHandler(this.buttonTeslimEdilenleriListele_Click);
        // 
        // buttonYikamdaOlanlariListele
        // 
        this.buttonYikamdaOlanlariListele.Location = new System.Drawing.Point(320, 165);
        this.buttonYikamdaOlanlariListele.Size = new System.Drawing.Size(160, 32);
        this.buttonYikamdaOlanlariListele.Text = "Yıkamada Olanları Listele";
        this.buttonYikamdaOlanlariListele.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.buttonYikamdaOlanlariListele.BackColor = System.Drawing.Color.LightSkyBlue;
        this.buttonYikamdaOlanlariListele.ForeColor = System.Drawing.Color.White;
        this.buttonYikamdaOlanlariListele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.buttonYikamdaOlanlariListele.FlatAppearance.BorderSize = 0;
        this.buttonYikamdaOlanlariListele.Paint += (s, e) => {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, 20, 20, 180, 90);
            path.AddArc(this.buttonYikamdaOlanlariListele.Width - 20, 0, 20, 20, 270, 90);
            path.AddArc(this.buttonYikamdaOlanlariListele.Width - 20, this.buttonYikamdaOlanlariListele.Height - 20, 20, 20, 0, 90);
            path.AddArc(0, this.buttonYikamdaOlanlariListele.Height - 20, 20, 20, 90, 90);
            path.CloseAllFigures();
            this.buttonYikamdaOlanlariListele.Region = new System.Drawing.Region(path);
        };
        this.buttonYikamdaOlanlariListele.Click += new System.EventHandler(this.buttonYikamdaOlanlariListele_Click);
        // 
        // buttonDurumuTeslimEdildiYap
        // 
        this.buttonDurumuTeslimEdildiYap.Location = new System.Drawing.Point(320, 220);
        this.buttonDurumuTeslimEdildiYap.Size = new System.Drawing.Size(160, 32);
        this.buttonDurumuTeslimEdildiYap.Text = "Durumu Teslim Edildi Yap";
        this.buttonDurumuTeslimEdildiYap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.buttonDurumuTeslimEdildiYap.BackColor = System.Drawing.Color.MediumSeaGreen;
        this.buttonDurumuTeslimEdildiYap.ForeColor = System.Drawing.Color.White;
        this.buttonDurumuTeslimEdildiYap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.buttonDurumuTeslimEdildiYap.FlatAppearance.BorderSize = 0;
        this.buttonDurumuTeslimEdildiYap.Paint += (s, e) => {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, 20, 20, 180, 90);
            path.AddArc(this.buttonDurumuTeslimEdildiYap.Width - 20, 0, 20, 20, 270, 90);
            path.AddArc(this.buttonDurumuTeslimEdildiYap.Width - 20, this.buttonDurumuTeslimEdildiYap.Height - 20, 20, 20, 0, 90);
            path.AddArc(0, this.buttonDurumuTeslimEdildiYap.Height - 20, 20, 20, 90, 90);
            path.CloseAllFigures();
            this.buttonDurumuTeslimEdildiYap.Region = new System.Drawing.Region(path);
        };
        this.buttonDurumuTeslimEdildiYap.Click += new System.EventHandler(this.buttonDurumuTeslimEdildiYap_Click);
        // 
        // dataGridView1
        // 
        this.dataGridView1.Location = new System.Drawing.Point(30, 320);
        this.dataGridView1.Size = new System.Drawing.Size(800, 200);
        this.dataGridView1.Name = "dataGridView1";
        this.dataGridView1.TabIndex = 0;
        this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
        this.dataGridView1.RowsDefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro;
        this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(860, 550);
        this.Controls.Add(this.labelMusteriBilgi);
        this.Controls.Add(this.labelAd);
        this.Controls.Add(this.textBoxAd);
        this.Controls.Add(this.labelSoyad);
        this.Controls.Add(this.textBoxSoyad);
        this.Controls.Add(this.labelTelefon);
        this.Controls.Add(this.textBoxTelefon);
        this.Controls.Add(this.labelAdres);
        this.Controls.Add(this.textBoxAdres);
        this.Controls.Add(this.buttonMusteriEkle);
        this.Controls.Add(this.labelHaliBilgi);
        this.Controls.Add(this.labelMetrekare);
        this.Controls.Add(this.textBoxMetrekare);
        this.Controls.Add(this.labelAlinmaTarihi);
        this.Controls.Add(this.dateTimePickerAlinma);
        this.Controls.Add(this.labelTahminiTeslim);
        this.Controls.Add(this.dateTimePickerTeslim);
        this.Controls.Add(this.labelMusteriSecin);
        this.Controls.Add(this.comboBox1);
        this.Controls.Add(this.buttonHaliEkle);
        this.Controls.Add(this.buttonTeslimEdilenleriListele);
        this.Controls.Add(this.buttonYikamdaOlanlariListele);
        this.Controls.Add(this.buttonDurumuTeslimEdildiYap);
        this.Controls.Add(this.dataGridView1);
        this.Name = "Form1";
        this.Text = "Halı Takip Otomasyonu";
        ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion
}
