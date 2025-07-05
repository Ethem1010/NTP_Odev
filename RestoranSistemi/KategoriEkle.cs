using System;
using System.Drawing;
using System.Windows.Forms;
using RestoranSistemi;

public partial class KategoriEkle : Form
{
    private Database db;
    private TextBox? kategoriAdiTextBox;
    private Button? ekleButton;
    private Button? iptalButton;

    public KategoriEkle()
    {
        InitializeComponent();
        db = new Database();
    }

    private void InitializeComponent()
    {
        this.Text = "Kategori Ekle";
        this.Size = new Size(400, 200);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.FromArgb(240, 240, 240);
        this.Font = new Font("Segoe UI", 10F);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        // Kategori Adı Label
        var kategoriAdiLabel = new Label
        {
            Text = "Kategori Adı:",
            Location = new Point(20, 20),
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            ForeColor = Color.FromArgb(44, 62, 80)
        };
        this.Controls.Add(kategoriAdiLabel);

        // Kategori Adı TextBox
        kategoriAdiTextBox = new TextBox
        {
            Location = new Point(20, 50),
            Size = new Size(340, 30),
            Font = new Font("Segoe UI", 10F),
            BackColor = Color.White
        };
        this.Controls.Add(kategoriAdiTextBox);

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

        ekleButton = new Button();
        ekleButton.Text = "➕ Ekle";
        ekleButton.Location = new Point(140, 100);
        ApplyButtonStyle(ekleButton, buttonStyle);
        ekleButton.Click += EkleButton_Click;
        this.Controls.Add(ekleButton);

        iptalButton = new Button();
        iptalButton.Text = "❌ İptal";
        iptalButton.Location = new Point(270, 100);
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

    private void EkleButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(kategoriAdiTextBox?.Text))
        {
            MessageBox.Show("Lütfen kategori adını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        db.KategoriEkle(kategoriAdiTextBox.Text);
        MessageBox.Show("Kategori başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void IptalButton_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
} 