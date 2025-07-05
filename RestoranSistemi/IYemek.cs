using System;

namespace RestoranSistemi
{
    public interface IYemek
    {
        string Ad { get; set; }
        decimal Fiyat { get; set; }
        string Aciklama { get; set; }
        bool AnaYemek { get; set; }
        int KategoriID { get; set; }
        string KategoriAdi { get; set; }
    }
} 