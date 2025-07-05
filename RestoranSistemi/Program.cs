using System;
using System.Windows.Forms;

namespace RestoranSistemi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Giriş ekranı
            var loginForm = new LoginForm();
            DialogResult result = loginForm.ShowDialog();
            string rol = loginForm.Rol;
            string kullaniciAdi = loginForm.KullaniciAdi;

            // Eğer giriş başarılıysa ana formu aç
            if (result == DialogResult.OK)
            {
                Application.Run(new Form1(rol, kullaniciAdi));
            }
            else
            {
                // Misafir (garson) girişi
                Application.Run(new Form1("misafir", "Garson"));
            }
        }
    }
}
