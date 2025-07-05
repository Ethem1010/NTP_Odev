using System;

// Bu sınıf, bağlı listenin her bir elemanını (düğümünü) tutuyor.
public class Dugum<T>
{
    public T Veri;
    public Dugum<T> Sonraki;

    // Düğüm oluştururken içine veri koyuyorum ve sonraki düğümü başta boş bırakıyorum.
    public Dugum(T veri)
    {
        Veri = veri;
        Sonraki = null;
    }
}

// Bu sınıf, generic bağlı listeyi temsil ediyor.
public class BagliListe<T>
{
    private Dugum<T> bas;

    // Bağlı listeyi ilk oluşturduğumda başı boş yapıyorum.
    public BagliListe()
    {
        bas = null;
    }

    // Listenin sonuna eleman eklemek için bu fonksiyonu yazdım.
    public void Ekle(T veri)
    {
        Dugum<T> yeni = new Dugum<T>(veri);
        if (bas == null)
            bas = yeni;
        else
        {
            Dugum<T> simdiki = bas;
            while (simdiki.Sonraki != null)
                simdiki = simdiki.Sonraki;
            simdiki.Sonraki = yeni;
        }
    }

    // Listedeki tüm elemanları ekrana yazdırmak için bu fonksiyonu kullandım.
    public void Yazdir()
    {
        Dugum<T> simdiki = bas;
        while (simdiki != null)
        {
            Console.Write(simdiki.Veri + " -> ");
            simdiki = simdiki.Sonraki;
        }
        Console.WriteLine("null");
    }

    // Listede verdiğim değeri bulup silmek için bu fonksiyonu yazdım.
    public bool Sil(T veri)
    {
        Dugum<T> simdiki = bas;
        Dugum<T> onceki = null;
        while (simdiki != null)
        {
            if (simdiki.Veri.Equals(veri))
            {
                if (onceki != null)
                    onceki.Sonraki = simdiki.Sonraki;
                else
                    bas = simdiki.Sonraki;
                return true;
            }
            onceki = simdiki;
            simdiki = simdiki.Sonraki;
        }
        return false;
    }
} 