using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Čitanje brojeva iz datoteke u listu
        List<int> brojevi = new List<int>();
        foreach (string red in File.ReadAllLines("Zad2-1.txt"))
            brojevi.Add(int.Parse(red));

        // Kopija nesortirane liste
        List<int> nesortirana = new List<int>(brojevi);

        // Sortiranje silazno
        SortirajSilazno(brojevi);

        int trazeniBroj = 10; // primjer tražene vrijednosti
        bool postoji = BinarnaPretraga(brojevi, trazeniBroj);

        // Upis u datoteku
        using (StreamWriter sw = new StreamWriter("Zad2-2.txt"))
        {
            sw.WriteLine(string.Join(",", nesortirana));
            sw.WriteLine(string.Join(",", brojevi));
            sw.WriteLine(trazeniBroj);
            sw.WriteLine(postoji ? 1 : 0);
        }
    }

    static void SortirajSilazno(List<int> lista)
    {
        lista.Sort();
        lista.Reverse();
    }

    static bool BinarnaPretraga(List<int> lista, int n)
    {
        int lijevo = 0, desno = lista.Count - 1;

        while (lijevo <= desno)
        {
            int sredina = (lijevo + desno) / 2;

            if (lista[sredina] == n) return true;
            if (lista[sredina] < n)
                desno = sredina - 1;   // jer je silazno sortirano
            else
                lijevo = sredina + 1;
        }
        return false;
    }
}
