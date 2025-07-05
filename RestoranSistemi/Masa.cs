using System;
using System.Collections.Generic;

namespace RestoranSistemi
{
    public class Masa
    {
        public int MasaNo { get; private set; }
        public bool Dolu { get; set; }
        public List<Yemek> Siparisler { get; private set; }

        public Masa(int masaNo)
        {
            MasaNo = masaNo;
            Dolu = false;
            Siparisler = new List<Yemek>();
        }

        public void SiparisEkle(Yemek yemek)
        {
            Siparisler.Add(yemek);
        }

        public decimal ToplamTutar()
        {
            decimal toplam = 0;
            foreach (var yemek in Siparisler)
            {
                toplam += yemek.Fiyat;
            }
            return toplam;
        }

        public override string ToString()
        {
            return $"Masa {MasaNo}";
        }
    }
} 