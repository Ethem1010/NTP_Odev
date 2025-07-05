using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Linq;

namespace RestoranSistemi
{
    public class Database
    {
        private readonly string connectionString;

        public Database()
        {
            // MySQL bağlantı bilgileri
            string baseConnectionString = "Server=localhost;Uid=root;Pwd=root;";
            connectionString = "Server=localhost;Database=restoran_db;Uid=root;Pwd=root;";

            try
            {
                // Önce ana veritabanına bağlan
                using (MySqlConnection conn = new MySqlConnection(baseConnectionString))
                {
                    conn.Open();
                    // Mevcut veritabanını sil (Geliştirme aşamasında şema değişiklikleri için)
                    using (MySqlCommand cmd = new MySqlCommand("DROP DATABASE IF EXISTS restoran_db", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    // Veritabanını oluştur
                    using (MySqlCommand cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS restoran_db", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                // Sonra tabloları oluştur
                VeritabaniOlustur();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı bağlantı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void VeritabaniOlustur()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Tüm tabloları bağımlılık sırasına göre sil
                    using (MySqlCommand cmd = new MySqlCommand("DROP TABLE IF EXISTS siparisler", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (MySqlCommand cmd = new MySqlCommand("DROP TABLE IF EXISTS masalar", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (MySqlCommand cmd = new MySqlCommand("DROP TABLE IF EXISTS yemekler", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (MySqlCommand cmd = new MySqlCommand("DROP TABLE IF EXISTS kategoriler", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Kategoriler tablosunu oluştur
                    using (MySqlCommand cmd = new MySqlCommand(
                        "CREATE TABLE kategoriler (" +
                        "KategoriID INT AUTO_INCREMENT PRIMARY KEY, " +
                        "KategoriAdi VARCHAR(100) NOT NULL)", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Yemekler tablosunu oluştur
                    using (MySqlCommand cmd = new MySqlCommand(
                        "CREATE TABLE yemekler (" +
                        "YemekID INT AUTO_INCREMENT PRIMARY KEY, " +
                        "YemekAdi VARCHAR(100) NOT NULL, " +
                        "Fiyat DECIMAL(10,2) NOT NULL, " +
                        "Aciklama TEXT, " +
                        "AnaYemek BOOLEAN DEFAULT TRUE, " +
                        "KategoriID INT, " +
                        "Aktif BOOLEAN DEFAULT TRUE, " +
                        "FOREIGN KEY (KategoriID) REFERENCES kategoriler(KategoriID))", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Masalar tablosunu oluştur
                    using (MySqlCommand cmd = new MySqlCommand(
                        "CREATE TABLE masalar (" +
                        "MasaNo INT PRIMARY KEY, " +
                        "Dolu BOOLEAN DEFAULT FALSE)", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Siparisler tablosunu oluştur
                    using (MySqlCommand cmd = new MySqlCommand(
                        "CREATE TABLE siparisler (" +
                        "SiparisID INT AUTO_INCREMENT PRIMARY KEY, " +
                        "MasaNo INT, " +
                        "YemekID INT, " +
                        "YemekAdi VARCHAR(100), " +
                        "Adet INT, " +
                        "Fiyat DECIMAL(10,2), " +
                        "SiparisTarihi DATETIME DEFAULT CURRENT_TIMESTAMP, " +
                        "FisYazdirildi BOOLEAN DEFAULT FALSE, " +
                        "FOREIGN KEY (MasaNo) REFERENCES masalar(MasaNo), " +
                        "FOREIGN KEY (YemekID) REFERENCES yemekler(YemekID))", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Varsayılan kategorileri ekle (eğer yoksa)
                    using (MySqlCommand cmd = new MySqlCommand(
                        "INSERT IGNORE INTO kategoriler (KategoriAdi) VALUES " +
                        "('Ana Yemekler'), ('İçecekler'), ('Tatlılar')", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Varsayılan masaları ekle (eğer yoksa)
                    using (MySqlCommand cmd = new MySqlCommand(
                        "INSERT IGNORE INTO masalar (MasaNo, Dolu) VALUES " +
                        "(1, FALSE), (2, FALSE), (3, FALSE), (4, FALSE), " +
                        "(5, FALSE), (6, FALSE), (7, FALSE), (8, FALSE), " +
                        "(9, FALSE), (10, FALSE), (11, FALSE), (12, FALSE)", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Varsayılan yemekleri ekle (eğer yoksa)
                    using (MySqlCommand cmd = new MySqlCommand(
                        "INSERT IGNORE INTO yemekler (YemekID, YemekAdi, Fiyat, Aciklama, AnaYemek, KategoriID) VALUES " +
                        "(1, 'Köfte', 150.00, 'Izgara köfte', TRUE, 1), " +
                        "(2, 'Tavuk Şiş', 120.00, 'Izgara tavuk şiş', TRUE, 1), " +
                        "(3, 'Pide', 100.00, 'Kıymalı pide', TRUE, 1), " +
                        "(4, 'Lahmacun', 50.00, 'Geleneksel lahmacun', TRUE, 1), " +
                        "(5, 'İskender', 200.00, 'Tereyağlı iskender', TRUE, 1), " +
                        "(6, 'Ayran', 15.00, 'Soğuk ayran', FALSE, 2), " +
                        "(7, 'Kola', 20.00, 'Soğuk kola', FALSE, 2), " +
                        "(8, 'Künefe', 80.00, 'Şerbetli tatlı', FALSE, 3), " +
                        "(9, 'Adana Kebap', 180.00, 'Acılı adana kebap', TRUE, 1), " +
                        "(10, 'Mantı', 90.00, 'El açması mantı', TRUE, 1), " +
                        "(11, 'Çorba', 45.00, 'Günün çorbası', TRUE, 1), " +
                        "(12, 'Meyve Suyu', 25.00, 'Taze sıkılmış meyve suyu', FALSE, 2), " +
                        "(13, 'Türk Kahvesi', 30.00, 'Geleneksel Türk kahvesi', FALSE, 2), " +
                        "(14, 'Baklava', 70.00, 'Antep fıstıklı baklava', FALSE, 3), " +
                        "(15, 'Sütlaç', 60.00, 'Fırında sütlaç', FALSE, 3), " +
                        "(16, 'Harput Köfte', 160.00, 'Elazığ yöresine özgü köfte', TRUE, 1), " +
                        "(17, 'Kofik', 110.00, 'Haşlanmış içli köfte', TRUE, 1), " +
                        "(18, 'Dilim Börek', 75.00, 'Elazığ yöresine özgü börek', TRUE, 1), " +
                        "(19, 'Orcik', 50.00, 'Cevizli sucuk', FALSE, 3), " +
                        "(20, 'Palu Pekmezi', 40.00, 'Elazığ yöresine özgü pekmez', FALSE, 3)", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı tabloları oluşturulurken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Kategori> GetKategoriler()
        {
            var kategoriler = new List<Kategori>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM kategoriler", conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                kategoriler.Add(new Kategori
                                {
                                    KategoriID = reader.GetInt32(0),
                                    KategoriAdi = reader.GetString(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kategoriler alınamadı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return kategoriler;
        }

        public List<Yemek> GetYemekler()
        {
            var yemekler = new List<Yemek>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT y.YemekID, y.YemekAdi, y.Aciklama, y.Fiyat, k.KategoriAdi, y.AnaYemek, y.KategoriID " +
                        "FROM yemekler y LEFT JOIN kategoriler k ON y.KategoriID = k.KategoriID WHERE y.Aktif = TRUE", conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var yemek = new Yemek(
                                    reader.GetInt32(0), // YemekID
                                    reader.GetString(1), // YemekAdi
                                    reader.IsDBNull(2) ? null : reader.GetString(2), // Aciklama
                                    reader.GetDecimal(3), // Fiyat
                                    reader.IsDBNull(4) ? null : reader.GetString(4), // KategoriAdi
                                    reader.GetBoolean(5), // AnaYemek
                                    reader.IsDBNull(6) ? 0 : reader.GetInt32(6) // KategoriID
                                );
                                yemekler.Add(yemek);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yemekler getirilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return yemekler;
        }

        public bool YemekEkle(Yemek yemek)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(@"
                        INSERT INTO yemekler (YemekAdi, Fiyat, Aciklama, AnaYemek, KategoriID) 
                        VALUES (@Ad, @Fiyat, @Aciklama, @AnaYemek, @KategoriID)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Ad", yemek.Ad);
                        cmd.Parameters.AddWithValue("@Fiyat", yemek.Fiyat);
                        cmd.Parameters.AddWithValue("@Aciklama", yemek.Aciklama);
                        cmd.Parameters.AddWithValue("@AnaYemek", yemek.AnaYemek);
                        cmd.Parameters.AddWithValue("@KategoriID", yemek.KategoriID == 0 ? DBNull.Value : yemek.KategoriID);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yemek eklenemedi: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool YemekGuncelle(Yemek yemek)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(@"
                        UPDATE yemekler 
                        SET YemekAdi = @Ad, Fiyat = @Fiyat, Aciklama = @Aciklama, 
                            AnaYemek = @AnaYemek, KategoriID = @KategoriID 
                        WHERE YemekID = @ID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", yemek.ID);
                        cmd.Parameters.AddWithValue("@Ad", yemek.Ad);
                        cmd.Parameters.AddWithValue("@Fiyat", yemek.Fiyat);
                        cmd.Parameters.AddWithValue("@Aciklama", yemek.Aciklama);
                        cmd.Parameters.AddWithValue("@AnaYemek", yemek.AnaYemek);
                        cmd.Parameters.AddWithValue("@KategoriID", yemek.KategoriID == 0 ? DBNull.Value : yemek.KategoriID);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yemek güncellenemedi: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool YemekSil(int yemekID)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "UPDATE yemekler SET Aktif = FALSE WHERE YemekID = @ID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", yemekID);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yemek silinemedi: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void KategoriEkle(string kategoriAdi)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO kategoriler (KategoriAdi) VALUES (@KategoriAdi)", conn))
                    {
                        cmd.Parameters.AddWithValue("@KategoriAdi", kategoriAdi);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kategori eklenemedi: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Masa> MasalariGetir()
        {
            var masalar = new List<Masa>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT MasaNo, Dolu FROM masalar", conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var masa = new Masa(reader.GetInt32(0))
                                {
                                    Dolu = reader.GetBoolean(1)
                                };
                                masalar.Add(masa);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Masa bilgileri alınamadı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return masalar;
        }

        public void MasaDurumunuGuncelle(int masaNo, bool dolu)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "UPDATE masalar SET Dolu = @Dolu WHERE MasaNo = @MasaNo", conn))
                    {
                        cmd.Parameters.AddWithValue("@Dolu", dolu);
                        cmd.Parameters.AddWithValue("@MasaNo", masaNo);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Masa durumu güncellenemedi: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool SiparisEkle(int masaNo, Yemek yemek)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO siparisler (MasaNo, YemekAdi, YemekID, Adet, Fiyat) VALUES (@MasaNo, @YemekAdi, @YemekID, 1, @Fiyat)", conn))
                    {
                        cmd.Parameters.AddWithValue("@MasaNo", masaNo);
                        cmd.Parameters.AddWithValue("@YemekAdi", yemek.Ad);
                        cmd.Parameters.AddWithValue("@YemekID", yemek.ID);
                        cmd.Parameters.AddWithValue("@Fiyat", yemek.Fiyat);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sipariş eklenemedi: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<Yemek> MasaSiparisleriniGetir(int masaNo)
        {
            var siparisler = new List<Yemek>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT YemekID, YemekAdi, Aciklama, Fiyat, KategoriAdi, AnaYemek, KategoriID FROM siparisler WHERE MasaNo = @MasaNo AND FisYazdirildi = FALSE", conn))
                    {
                        cmd.Parameters.AddWithValue("@MasaNo", masaNo);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                siparisler.Add(new Yemek(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.IsDBNull(2) ? null : reader.GetString(2),
                                    reader.GetDecimal(3),
                                    reader.IsDBNull(4) ? null : reader.GetString(4),
                                    reader.GetBoolean(5),
                                    reader.GetInt32(6)
                                ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Siparişler alınamadı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return siparisler;
        }

        public void SiparisleriFisYazdirildiOlarakIsaretle(int masaNo)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "UPDATE siparisler SET FisYazdirildi = TRUE WHERE MasaNo = @MasaNo AND FisYazdirildi = FALSE", conn))
                    {
                        cmd.Parameters.AddWithValue("@MasaNo", masaNo);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Siparişler güncellenemedi: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Masa? MasaGetir(int masaNo)
        {
            return MasalariGetir().FirstOrDefault(m => m.MasaNo == masaNo);
        }

        public List<Siparis> SiparisleriGetir(int masaNo)
        {
            var siparisler = new List<Siparis>();
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new MySqlCommand(@"
                        SELECT s.*, y.YemekAdi 
                        FROM Siparisler s 
                        LEFT JOIN Yemekler y ON s.YemekID = y.YemekID 
                        WHERE s.MasaNo = @MasaNo", connection);
                    command.Parameters.AddWithValue("@MasaNo", masaNo);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var siparis = new Siparis
                            {
                                SiparisID = reader.GetInt32("SiparisID"),
                                MasaNo = reader.GetInt32("MasaNo"),
                                YemekID = reader.GetInt32("YemekID"),
                                YemekAdi = reader.GetString("YemekAdi"),
                                Adet = reader.GetInt32("Adet"),
                                Fiyat = reader.GetDecimal("Fiyat")
                            };
                            siparisler.Add(siparis);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Siparişler getirilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return siparisler;
        }

        public void KullaniciTablosuOlustur()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var cmd = new MySqlCommand(@"CREATE TABLE IF NOT EXISTS Kullanici (
                        KullaniciID INT AUTO_INCREMENT PRIMARY KEY,
                        KullaniciAdi VARCHAR(50) NOT NULL UNIQUE,
                        Sifre VARCHAR(100) NOT NULL,
                        Rol ENUM('admin','personel') NOT NULL
                    );", connection);
                    cmd.ExecuteNonQuery();

                    // Varsayılan admin ekle
                    var adminCmd = new MySqlCommand(@"INSERT IGNORE INTO Kullanici (KullaniciAdi, Sifre, Rol) VALUES ('admin', '123', 'admin');", connection);
                    adminCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kullanıcı tablosu oluşturulurken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool KullaniciGiris(string kullaniciAdi, string sifre, out string rol)
        {
            rol = string.Empty;
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var cmd = new MySqlCommand("SELECT Rol FROM Kullanici WHERE KullaniciAdi = @kullaniciAdi AND Sifre = @sifre", connection);
                    cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@sifre", sifre);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rol = reader.GetString("Rol");
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Giriş kontrolünde hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
} 