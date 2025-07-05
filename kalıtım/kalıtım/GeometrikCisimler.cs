using System;

// Şekil sınıfı, tüm geometrik cisimlerin temelini oluşturur.
public abstract class Sekil
{
    // Alan hesaplama fonksiyonu, alt sınıflarda override edilecek.
    public abstract double Alan();
    // Çevre hesaplama fonksiyonu, alt sınıflarda override edilecek.
    public abstract double Cevre();
    // Hacim hesaplama fonksiyonu, alt sınıflarda override edilecek.
    public virtual double Hacim() { return 0; } // Varsayılan olarak 0 döner, hacmi olmayanlar için.
}

// Daire sınıfı, Şekil'den türetiliyor.
public class Daire : Sekil
{
    public double YariCap { get; set; }
    public Daire(double yariCap) { YariCap = yariCap; }
    public override double Alan() => Math.PI * YariCap * YariCap;
    public override double Cevre() => 2 * Math.PI * YariCap;
}

// Çember sınıfı, Şekil'den türetiliyor. Alanı yok, sadece çevresi var.
public class Cember : Sekil
{
    public double YariCap { get; set; }
    public Cember(double yariCap) { YariCap = yariCap; }
    public override double Alan() => 0; // Çemberin alanı yok.
    public override double Cevre() => 2 * Math.PI * YariCap;
}

// Kare sınıfı
public class Kare : Sekil
{
    public double Kenar { get; set; }
    public Kare(double kenar) { Kenar = kenar; }
    public override double Alan() => Kenar * Kenar;
    public override double Cevre() => 4 * Kenar;
}

// Dikdörtgen sınıfı
public class Dikdortgen : Sekil
{
    public double KisaKenar { get; set; }
    public double UzunKenar { get; set; }
    public Dikdortgen(double kisa, double uzun) { KisaKenar = kisa; UzunKenar = uzun; }
    public override double Alan() => KisaKenar * UzunKenar;
    public override double Cevre() => 2 * (KisaKenar + UzunKenar);
}

// Üçgen sınıfı (kenar uzunlukları ile)
public class Ucgen : Sekil
{
    public double KenarA { get; set; }
    public double KenarB { get; set; }
    public double KenarC { get; set; }
    public Ucgen(double a, double b, double c) { KenarA = a; KenarB = b; KenarC = c; }
    public override double Alan()
    {
        // Heron formülü ile alan hesaplama
        double s = (KenarA + KenarB + KenarC) / 2;
        return Math.Sqrt(s * (s - KenarA) * (s - KenarB) * (s - KenarC));
    }
    public override double Cevre() => KenarA + KenarB + KenarC;
}

// Küre sınıfı
public class Kure : Sekil
{
    public double YariCap { get; set; }
    public Kure(double yariCap) { YariCap = yariCap; }
    public override double Alan() => 4 * Math.PI * YariCap * YariCap; // Yüzey alanı
    public override double Cevre() => 0; // Kürenin çevresi yok, 0 döndürüyorum.
    public override double Hacim() => (4.0 / 3.0) * Math.PI * Math.Pow(YariCap, 3);
}

// İleride başka geometrik cisimler de eklenebilir. Mesela silindir, prizma vs.
// Her biri için bu yapıyı kullanabilirsin. 