using System;

class Program
{
    static void Main()
    {
        // Önce bağlı listeyi deniyorum.
        Console.WriteLine("--- Bağlı Liste Örneği ---");
        BagliListe<int> bl = new BagliListe<int>();
        bl.Ekle(10); // 10'u ekledim
        bl.Ekle(20); // 20'yi ekledim
        bl.Ekle(30); // 30'u ekledim
        bl.Yazdir(); // Şu anki hali: 10 -> 20 -> 30 -> null
        bl.Sil(20);  // 20'yi sildim
        bl.Yazdir(); // Şu anki hali: 10 -> 30 -> null

        // Şimdi kuyruk yapısını deniyorum.
        Console.WriteLine("\n--- Kuyruk Örneği ---");
        Kuyruk<string> k = new Kuyruk<string>();
        k.Ekle("A"); // Kuyruğa A'yı ekledim
        k.Ekle("B"); // Kuyruğa B'yi ekledim
        k.Ekle("C"); // Kuyruğa C'yi ekledim
        k.Yazdir();   // Şu anki hali: A <- B <- C <- null
        Console.WriteLine("Çıkan: " + k.Cikar()); // Kuyruktan A çıktı
        k.Yazdir();   // Şu anki hali: B <- C <- null

        // Son olarak yığın (stack) yapısını deniyorum.
        Console.WriteLine("\n--- Yığın (Stack) Örneği ---");
        Yigin<int> y = new Yigin<int>();
        y.Ekle(1); // 1'i ekledim
        y.Ekle(2); // 2'yi ekledim
        y.Ekle(3); // 3'ü ekledim
        y.Yazdir(); // Şu anki hali: 3 | 2 | 1 | null
        Console.WriteLine("Çıkan: " + y.Cikar()); // Yığından 3 çıktı
        y.Yazdir(); // Şu anki hali: 2 | 1 | null
    }
} 