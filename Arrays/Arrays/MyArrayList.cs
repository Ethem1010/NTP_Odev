namespace Arrays
{
// Bu sınıfı ödev için kendim yazdım, hazır ArrayList veya List<T> kullanmadım.
public class MyArrayList
{
    // Elemanları tutmak için object tipinde bir dizi kullandım.
    private object[] dizi;
    // Listedeki eleman sayısını tutuyorum.
    private int elemanSayisi;

    // Başlangıçta kapasiteyi 4 olarak ayarladım.
    public MyArrayList()
    {
        dizi = new object[4];
        elemanSayisi = 0;
    }

    // Listedeki eleman sayısını dışarıdan sadece okunabilir yaptım.
    public int Count => elemanSayisi;

    // Yeni bir eleman eklemek için bu metodu yazdım.
    public void Add(object item)
    {
        // Eğer dizi dolduysa kapasiteyi iki katına çıkarıyorum.
        if (elemanSayisi == dizi.Length)
        {
            // Kapasiteyi artırmak için yeni bir dizi oluşturup eskileri kopyalıyorum.
            object[] yeniDizi = new object[dizi.Length * 2];
            for (int i = 0; i < dizi.Length; i++)
            {
                yeniDizi[i] = dizi[i];
            }
            dizi = yeniDizi;
        }
        // Elemanı sona ekliyorum.
        dizi[elemanSayisi] = item;
        elemanSayisi++;
    }

    // Belirli bir indekse eleman eklemek için bu metodu yazdım.
    public void Insert(int index, object item)
    {
        // İndeksin geçerli olup olmadığını kontrol ediyorum.
        if (index < 0 || index > elemanSayisi)
        {
            throw new ArgumentOutOfRangeException("index", "Geçersiz indeks.");
        }
        // Eğer dizi dolduysa kapasiteyi artırıyorum.
        if (elemanSayisi == dizi.Length)
        {
            object[] yeniDizi = new object[dizi.Length * 2];
            for (int i = 0; i < dizi.Length; i++)
            {
                yeniDizi[i] = dizi[i];
            }
            dizi = yeniDizi;
        }
        // Elemanları sağa kaydırıyorum.
        for (int i = elemanSayisi; i > index; i--)
        {
            dizi[i] = dizi[i - 1];
        }
        // Yeni elemanı ilgili yere ekliyorum.
        dizi[index] = item;
        elemanSayisi++;
    }

    // Belirli bir indeksteki elemanı silmek için bu metodu yazdım.
    public void RemoveAt(int index)
    {
        // İndeksin geçerli olup olmadığını kontrol ediyorum.
        if (index < 0 || index >= elemanSayisi)
        {
            throw new ArgumentOutOfRangeException("index", "Geçersiz indeks.");
        }
        // Elemanları sola kaydırıyorum.
        for (int i = index; i < elemanSayisi - 1; i++)
        {
            dizi[i] = dizi[i + 1];
        }
        // Son elemanı null yapıyorum, gerek olmasa da alışkanlık.
        dizi[elemanSayisi - 1] = null;
        elemanSayisi--;
    }

    // Belirli bir indeksteki elemanı döndürmek için bu metodu yazdım.
    public object Get(int index)
    {
        // İndeksin geçerli olup olmadığını kontrol ediyorum.
        if (index < 0 || index >= elemanSayisi)
        {
            throw new ArgumentOutOfRangeException("index", "Geçersiz indeks.");
        }
        return dizi[index];
    }

    // Listedeki elemanları virgül ile ayırıp string olarak döndürüyorum.
    public override string ToString()
    {
        if (elemanSayisi == 0)
            return string.Empty;
        string sonuc = "";
        for (int i = 0; i < elemanSayisi; i++)
        {
            // Elemanları aralarına virgül koyarak ekliyorum.
            sonuc += dizi[i];
            if (i < elemanSayisi - 1)
                sonuc += ", ";
        }
        return sonuc;
    }
}
} 