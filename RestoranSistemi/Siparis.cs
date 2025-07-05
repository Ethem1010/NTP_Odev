using System;
using System.Collections.Generic;
using System.IO;

namespace RestoranSistemi
{
    public class Siparis
    {
        public int SiparisID { get; set; }
        public int MasaNo { get; set; }
        public int YemekID { get; set; }
        public string YemekAdi { get; set; } = string.Empty;
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }

        public Siparis(int siparisID, int masaNo, int yemekID, int adet, decimal fiyat)
        {
            SiparisID = siparisID;
            MasaNo = masaNo;
            YemekID = yemekID;
            Adet = adet;
            Fiyat = fiyat;
        }
        public Siparis() { }
    }
} 