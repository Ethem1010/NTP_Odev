using System;

// Bu sınıf, generic yığın (stack) veri yapısını tutuyor.
public class Yigin<T>
{
    // Yığının her bir elemanını tutan iç sınıf.
    private class Dugum
    {
        public T Veri;
        public Dugum Sonraki;
        // Düğüm oluştururken içine veri koyuyorum ve sonraki düğümü başta boş bırakıyorum.
        public Dugum(T veri)
        {
            Veri = veri;
            Sonraki = null;
        }
    }

    private Dugum tepe;

    // Yığını ilk oluşturduğumda tepeyi boş yapıyorum.
    public Yigin()
    {
        tepe = null;
    }

    // Yığının tepesine eleman eklemek için bu fonksiyonu yazdım.
    public void Ekle(T veri)
    {
        Dugum yeni = new Dugum(veri);
        yeni.Sonraki = tepe;
        tepe = yeni;
    }

    // Yığının tepesinden eleman çıkarmak için bu fonksiyonu kullandım.
    public T Cikar()
    {
        if (tepe == null)
            return default(T);
        T veri = tepe.Veri;
        tepe = tepe.Sonraki;
        return veri;
    }

    // Yığındaki tüm elemanları ekrana yazdırmak için bu fonksiyonu yazdım.
    public void Yazdir()
    {
        Dugum simdiki = tepe;
        while (simdiki != null)
        {
            Console.Write(simdiki.Veri + " | ");
            simdiki = simdiki.Sonraki;
        }
        Console.WriteLine("null");
    }
} 