using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace RestoranSistemi
{
    public class LoginForm : Form
    {
        private Label? lblKullaniciAdi;
        private Label? lblSifre;
        private TextBox? txtKullaniciAdi;
        private TextBox? txtSifre;
        private Button? btnGiris;
        private Database db;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string KullaniciAdi { get; private set; } = string.Empty;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Rol { get; private set; } = string.Empty;

        public LoginForm()
        {
            db = new Database();
            db.KullaniciTablosuOlustur();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Restoran Sistemi - Giriş";
            this.Size = new Size(350, 250);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            lblKullaniciAdi = new Label { Text = "Kullanıcı Adı:", Location = new Point(30, 40), AutoSize = true, Font = new Font("Segoe UI", 10) };
            txtKullaniciAdi = new TextBox { Location = new Point(140, 35), Width = 150, Font = new Font("Segoe UI", 10) };

            lblSifre = new Label { Text = "Şifre:", Location = new Point(30, 90), AutoSize = true, Font = new Font("Segoe UI", 10) };
            txtSifre = new TextBox { Location = new Point(140, 85), Width = 150, Font = new Font("Segoe UI", 10), UseSystemPasswordChar = true };

            btnGiris = new Button
            {
                Text = "Giriş Yap",
                Location = new Point(110, 140),
                Size = new Size(120, 40),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnGiris.Click += BtnGiris_Click;

            this.Controls.Add(lblKullaniciAdi);
            this.Controls.Add(txtKullaniciAdi);
            this.Controls.Add(lblSifre);
            this.Controls.Add(txtSifre);
            this.Controls.Add(btnGiris);
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi?.Text.Trim() ?? string.Empty;
            string sifre = txtSifre?.Text ?? string.Empty;
            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifre giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (db.KullaniciGiris(kullaniciAdi, sifre, out string rol))
            {
                KullaniciAdi = kullaniciAdi;
                Rol = rol;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 