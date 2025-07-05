using System;
using System.Collections.Generic;
using System.IO;

namespace RestoranSistemi
{
    public class Yemek
    {
        public int ID { get; set; }
        public string? Ad { get; set; }
        public string? Aciklama { get; set; }
        public decimal Fiyat { get; set; }
        public string? KategoriAdi { get; set; }
        public bool AnaYemek { get; set; }
        public int KategoriID { get; set; }

        public Yemek(int id, string ad, string aciklama, decimal fiyat, string kategoriAdi, bool anaYemek = false, int kategoriID = 0)
        {
            ID = id;
            Ad = ad;
            Aciklama = aciklama;
            Fiyat = fiyat;
            KategoriAdi = kategoriAdi;
            AnaYemek = anaYemek;
            KategoriID = kategoriID;
        }
        public Yemek() { }

        public void IcindekileriEkle(string icindekiler)
        {
            // This method is no longer used in the new Yemek class
        }

        public void Yazdir()
        {
            Console.WriteLine($"Yemek: {Ad}");
            Console.WriteLine($"Fiyat: {Fiyat:C}");
            Console.WriteLine("İçindekiler:");
            // This method is no longer used in the new Yemek class
        }

        public override string ToString()
        {
            return $"{Ad} - {Fiyat:C}";
        }

        public void DosyayaYazdir(string dosyaYolu)
        {
            using (StreamWriter writer = new StreamWriter(dosyaYolu))
            {
                writer.WriteLine("=== Sipariş Fişi ===");
                writer.WriteLine($"Yemek: {Ad}");
                writer.WriteLine($"Fiyat: {Fiyat:C}");
                if (!string.IsNullOrEmpty(Aciklama))
                {
                    writer.WriteLine($"Açıklama: {Aciklama}");
                }
                writer.WriteLine("===================");
            }
        }
    }
} 