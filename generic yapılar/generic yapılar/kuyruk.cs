using System;

// Bu sınıf, generic kuyruk veri yapısını tutuyor.
public class Kuyruk<T>
{
    // Kuyruğun her bir elemanını tutan iç sınıf.
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

    private Dugum on, arka;

    // Kuyruğu ilk oluşturduğumda başı ve sonu boş yapıyorum.
    public Kuyruk()
    {
        on = arka = null;
    }

    // Kuyruğun sonuna eleman eklemek için bu fonksiyonu yazdım.
    public void Ekle(T veri)
    {
        Dugum yeni = new Dugum(veri);
        if (arka == null)
            on = arka = yeni;
        else
        {
            arka.Sonraki = yeni;
            arka = yeni;
        }
    }

    // Kuyruğun başından eleman çıkarmak için bu fonksiyonu kullandım.
    public T Cikar()
    {
        if (on == null)
            return default(T);
        T veri = on.Veri;
        on = on.Sonraki;
        if (on == null)
            arka = null;
        return veri;
    }

    // Kuyruktaki tüm elemanları ekrana yazdırmak için bu fonksiyonu yazdım.
    public void Yazdir()
    {
        Dugum simdiki = on;
        while (simdiki != null)
        {
            Console.Write(simdiki.Veri + " <- ");
            simdiki = simdiki.Sonraki;
        }
        Console.WriteLine("null");
    }
} 