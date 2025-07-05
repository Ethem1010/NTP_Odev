// Bu projede, bir buton ile txt dosyası seçilecek ve dosya içerisindeki metin bir textbox'a aktarılacaktır.
// Daha sonra, textbox'taki metin içerisindeki noktalama işaretleri ve diğer özel karakterlerin temizlenmiş hali
// diğer bir textbox içerisine yazılacaktır.
// (Hocam, aşağıda kodun ilgili kısımlarında da açıklama ekledim.)

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace guiler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Burada, bir buton ile txt dosyası seçiyorum ve içeriğini birinci textbox'a aktarıyorum.
        private void btnDosyaSec_Click(object sender, EventArgs e)
        {
            // Kullanıcıya dosya seçtirmek için OpenFileDialog oluşturuyorum.
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files|*.txt"; // Sadece .txt dosyalarını gösteriyorum.
            ofd.Title = "Bir metin dosyası seçiniz";

            // Kullanıcı bir dosya seçip 'Aç' derse
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Seçilen dosyanın içeriğini okuyorum.
                    string metin = File.ReadAllText(ofd.FileName);
                    // Okunan metni birinci TextBox'a yazıyorum.
                    txtOrijinal.Text = metin;
                    // Dosya başarıyla yüklendiğinde kullanıcıya bilgi veriyorum.
                    MessageBox.Show("Dosya başarıyla yüklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Eğer dosya okunurken hata olursa kullanıcıya gösteriyorum.
                    MessageBox.Show("Dosya okunurken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Burada, bir buton ile textbox'taki metnin içerisindeki noktalama işaretleri ve özel karakterleri temizliyorum.
        // Temizlenmiş metni ikinci textbox'a yazıyorum.
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            // Birinci TextBox'taki metni alıyorum.
            string orijinal = txtOrijinal.Text;

            // Eğer metin boşsa kullanıcıya uyarı veriyorum.
            if (string.IsNullOrWhiteSpace(orijinal))
            {
                MessageBox.Show("Lütfen önce bir dosya seçin veya metin girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Regex ile sadece harf, rakam ve boşluk bırakıyorum, diğer karakterleri temizliyorum.
            // Türkçe karakterleri de dahil ettim.
            string temiz = Regex.Replace(orijinal, "[^a-zA-Z0-9ğüşöçıİĞÜŞÖÇ\s]", "");

            // Temizlenmiş metni ikinci TextBox'a yazıyorum.
            txtTemiz.Text = temiz;
        }
    }
}
// Form tasarımında 2 adet TextBox (txtOrijinal, txtTemiz), 2 adet Button (btnDosyaSec, btnTemizle) ekledim.
// txtOrijinal: Dosya içeriği veya girilen metin, txtTemiz: Temizlenmiş metin gösterilecek.
// btnDosyaSec: Dosya seçmek için, btnTemizle: Temizleme işlemi için kullanılacak.
// Kodda hata kontrolü ve kullanıcıya bilgi mesajları da ekledim. 