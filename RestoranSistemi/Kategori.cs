namespace RestoranSistemi
{
    public class Kategori
    {
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; } = string.Empty;

        public override string ToString()
        {
            return KategoriAdi;
        }
    }
} 