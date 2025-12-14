using System;
using System.Collections.Generic;
using LV6_Zadatak3;
using System.Xml;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        string path = "studenti.json";
        List<Student> studenti;

        if (!File.Exists(path))
        {
            studenti = new List<Student>()
            {
                new Student{
                    Ime="Ana", Prezime="Anić", Jmbag="1234567890", GodinaRodenja=2000,
                    Ocjene=new List<Ocjena>{
                        new Ocjena{PredmetId="OP", Vrijednost=5},
                        new Ocjena{PredmetId="MAT", Vrijednost=4}
                    }},
                new Student{
                    Ime="Marko", Prezime="Marić", Jmbag="2345678901", GodinaRodenja=1999,
                    Ocjene=new List<Ocjena>{
                        new Ocjena{PredmetId="OP", Vrijednost=0},
                        new Ocjena{PredmetId="MAT", Vrijednost=3}
                    }},
            };

            string jsonInit = JsonSerializer.Serialize(studenti, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, jsonInit);
        }

        string json = File.ReadAllText(path);
        studenti = JsonSerializer.Deserialize<List<Student>>(json);

        ProvjeriJmbag(studenti);
        IspisiStudente(studenti);
        NajboljiStudenti(studenti);
        studenti = AzurirajOcjenu(studenti);

        string jsonOut = JsonSerializer.Serialize(studenti, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, jsonOut);
    }

    static void ProvjeriJmbag(List<Student> studenti)
    {
        HashSet<string> set = new HashSet<string>();
        foreach (var s in studenti)
        {
            if (s.Jmbag.Length != 10) Console.WriteLine($"Neispravan JMBAG: {s.Ime} {s.Prezime}");
            if (!set.Add(s.Jmbag))
                Console.WriteLine($"Duplikat JMBAG: {s.Jmbag}");
        }
    }

    static void IspisiStudente(List<Student> studenti)
    {
        int br = 1;
        foreach (var s in studenti)
        {
            double prosjek = Prosjek(s.Ocjene);
            Console.WriteLine($"{br++}. {s.Ime} {s.Prezime} ({s.Jmbag}) prosjek: {(prosjek > 0 ? prosjek.ToString("F2") : "Nema položenih")}");
            foreach (var o in s.Ocjene)
            {
                if (o.Vrijednost > 0)
                    Console.WriteLine($"   {o.PredmetId} – {o.Vrijednost}");
                else
                    Console.WriteLine($"   {o.PredmetId} – Kolegij nije položen");
            }
        }
    }

    static double Prosjek(List<Ocjena> ocjene)
    {
        int suma = 0, br = 0;
        foreach (var o in ocjene)
        {
            if (o.Vrijednost > 0) { suma += o.Vrijednost; br++; }
        }
        return br > 0 ? (double)suma / br : 0;
    }

    static void NajboljiStudenti(List<Student> studenti)
    {
        double max = 0;
        foreach (var s in studenti) max = Math.Max(max, Prosjek(s.Ocjene));
        if (max == 0) { Console.WriteLine("Nijedan student nema položenih predmeta."); return; }
        Console.WriteLine("Studenti s najvećim prosjekom:");
        foreach (var s in studenti)
            if (Math.Abs(Prosjek(s.Ocjene) - max) < 0.001)
                Console.WriteLine($"   {s.Ime} {s.Prezime}, prosjek: {max:F2}");
    }

    static List<Student> AzurirajOcjenu(List<Student> studenti)
    {
        Console.WriteLine("Odaberite studenta:");
        for (int i = 0; i < studenti.Count; i++)
            Console.WriteLine($"{i + 1}. {studenti[i].Ime} {studenti[i].Prezime} ({studenti[i].Jmbag})");

        int izbor = int.Parse(Console.ReadLine()) - 1;
        Student odabrani = studenti[izbor];

        Console.WriteLine("Odaberite predmet:");
        for (int i = 0; i < odabrani.Ocjene.Count; i++)
            Console.WriteLine($"{i + 1}. {odabrani.Ocjene[i].PredmetId} – {odabrani.Ocjene[i].Vrijednost}");

        int izborPredmet = int.Parse(Console.ReadLine()) - 1;

        int novaOcjena;
        do
        {
            Console.Write("Unesite novu ocjenu (0-5): ");
            novaOcjena = int.Parse(Console.ReadLine());
        } while (novaOcjena < 0 || novaOcjena > 5);

        odabrani.Ocjene[izborPredmet] = new Ocjena
        {
            PredmetId = odabrani.Ocjene[izborPredmet].PredmetId,
            Vrijednost = novaOcjena
        };
        studenti[izbor] = odabrani;

        return studenti;
    }
}
