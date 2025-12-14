using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string inputPath = "Zad2-1.txt";
        string outputPath = "Zad2-2.txt";

        List<int> brojevi = new List<int>();
        foreach (string line in File.ReadAllLines(inputPath))
        {
            brojevi.Add(int.Parse(line));
        }

        List<int> nesortirana = new List<int>(brojevi);

        brojevi.Sort((a, b) => b.CompareTo(a));

        Console.Write("Unesite broj za pretragu: ");
        int n = int.Parse(Console.ReadLine());

        bool postoji = BinarnaPretraga(brojevi, n);

        using (StreamWriter sw = new StreamWriter(outputPath))
        {
            sw.WriteLine(string.Join(",", nesortirana));
            sw.WriteLine(string.Join(",", brojevi));
            sw.WriteLine($"{n},{(postoji ? 1 : 0)}");
        }

        Console.WriteLine("Rezultat zapisan u Zad2-2.txt");
    }

    static bool BinarnaPretraga(List<int> lista, int n)
    {
        int left = 0, right = lista.Count - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (lista[mid] == n) return true;
            else if (lista[mid] > n) left = mid + 1;
            else right = mid - 1;
        }
        return false;
    }
}
