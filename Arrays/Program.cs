using System;
using Arrays;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("MyArrayList Test Programı");
        Console.WriteLine("========================\n");

        // MyArrayList nesnesi oluşturuyorum
        MyArrayList liste = new MyArrayList();

        Console.WriteLine("1. Eleman ekleme testi:");
        liste.Add("Elma");
        liste.Add("Armut");
        liste.Add("Muz");
        liste.Add("Kiraz");
        Console.WriteLine($"Liste: {liste}");
        Console.WriteLine($"Eleman sayısı: {liste.Count}\n");

        Console.WriteLine("2. İndekse eleman ekleme testi:");
        liste.Insert(1, "Portakal");
        Console.WriteLine($"Liste: {liste}");
        Console.WriteLine($"Eleman sayısı: {liste.Count}\n");

        Console.WriteLine("3. Eleman silme testi:");
        liste.RemoveAt(2);
        Console.WriteLine($"Liste: {liste}");
        Console.WriteLine($"Eleman sayısı: {liste.Count}\n");

        Console.WriteLine("4. Eleman alma testi:");
        Console.WriteLine($"0. indeksteki eleman: {liste.Get(0)}");
        Console.WriteLine($"2. indeksteki eleman: {liste.Get(2)}\n");

        Console.WriteLine("5. Kapasite artırma testi:");
        liste.Add("Çilek");
        liste.Add("Böğürtlen");
        liste.Add("Ahududu");
        liste.Add("Dut");
        liste.Add("İncir");
        Console.WriteLine($"Liste: {liste}");
        Console.WriteLine($"Eleman sayısı: {liste.Count}\n");

        Console.WriteLine("Test tamamlandı!");
        Console.ReadLine();
    }
}
