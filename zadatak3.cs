using System;
using System.Collections.Generic;

struct Nastavnik
{
    public string ime;
    public string prezime;
    public string oib;
    public string titula;
    public List<string> lInstitucije;
}

struct Kolegij
{
    public int id;
    public string naziv;
    public List<Nastavnik> lNositeljKolegija;
    public int ectsBodovi;
    public int semestar;
}

class Program
{
    static void Main()
    {
        // -----------------------------
        // DEFINIRANJE NASTAVNIKA
        // -----------------------------
        Nastavnik n1 = new Nastavnik
        {
            ime = "Marko",
            prezime = "Marković",
            oib = "12345678901",
            titula = "prof.dr.sc.",
            lInstitucije = new List<string> { "FER", "PMF" }
        };

        Nastavnik n2 = new Nastavnik
        {
            ime = "Ivana",
            prezime = "Ivić",
            oib = "98765432109",
            titula = "doc.dr.sc.",
            lInstitucije = new List<string> { "TVZ" }
        };

        // -----------------------------
        // TVOJI KOLEGIJI
        // -----------------------------
        Kolegij k1 = new Kolegij
        {
            id = 1,
            naziv = "Osnove programiranja",
            ectsBodovi = 6,
            semestar = 1,
            lNositeljKolegija = new List<Nastavnik> { n1 }
        };

        Kolegij k2 = new Kolegij
        {
            id = 2,
            naziv = "Matematika 1",
            ectsBodovi = 7,
            semestar = 1,
            lNositeljKolegija = new List<Nastavnik> { n2 }
        };

        Kolegij k3 = new Kolegij
        {
            id = 3,
            naziv = "Baze podataka",
            ectsBodovi = 6,
            semestar = 2,
            lNositeljKolegija = new List<Nastavnik> { n1, n2 }
        };

        List<Kolegij> lKolegiji = new List<Kolegij> { k1, k2, k3 };

        // -----------------------------
        // ISPIS SVIH KOLEGIJA
        // -----------------------------
        Console.WriteLine("----- SVI KOLEGIJI -----");
        foreach (var k in lKolegiji)
            IspisiKolegij(k);

        // -----------------------------
        // TEST PRONALASKA KOLEGIJA
        // -----------------------------
        Console.WriteLine("----- PRONADJI KOLEGIJ (ID 1) -----");
        PronadjiKolegij(lKolegiji, 1);

        Console.WriteLine("----- PRONADJI KOLEGIJ (ID 99) -----");
        PronadjiKolegij(lKolegiji, 99);

        // -----------------------------
        // KOLEGIJI S MAKSIMALNIM ECTS
        // -----------------------------
        Console.WriteLine("----- MAKSIMALNI ECTS -----");
        List<Kolegij> max = MaxEcts(lKolegiji);
        foreach (var k in max)
            IspisiKolegij(k);

        // -----------------------------
        // SVI NASTAVNICI + OP NOSITELJI
        // -----------------------------
        Console.WriteLine("----- SVI NASTAVNICI -----");
        List<Nastavnik> svi = SviNastavnici(lKolegiji);
    }

    // -----------------------------
    // ISPIS KOLEGIJA
    // -----------------------------
    static void IspisiKolegij(Kolegij k)
    {
        Console.WriteLine($"ID: {k.id}");
        Console.WriteLine($"Naziv: {k.naziv}");
        Console.WriteLine($"ECTS: {k.ectsBodovi}");
        Console.WriteLine($"Semestar: {k.semestar}");
        Console.WriteLine("Nositelji:");
        foreach (var n in k.lNositeljKolegija)
            Console.WriteLine($"  {n.titula} {n.ime} {n.prezime}");
        Console.WriteLine();
    }

    // -----------------------------
    // PRONADJI KOLEGIJ
    // -----------------------------
    static void PronadjiKolegij(List<Kolegij> lista, int trazeniId)
    {
        var found = lista.FindAll(k => k.id == trazeniId);

        if (found.Count == 0)
        {
            Console.WriteLine($"Kolegij s ID {trazeniId} ne postoji.");
            return;
        }

        Console.WriteLine($"Pronađeno: {found.Count}");
        foreach (var k in found)
            IspisiKolegij(k);
    }

    // -----------------------------
    // MAX ECTS
    // -----------------------------
    static List<Kolegij> MaxEcts(List<Kolegij> lista)
    {
        int max = 0;
        foreach (var k in lista)
            if (k.ectsBodovi > max)
                max = k.ectsBodovi;

        return lista.FindAll(k => k.ectsBodovi == max);
    }

    // -----------------------------
    // SVI NASTAVNICI (bez duplikata)
    // -----------------------------
    static List<Nastavnik> SviNastavnici(List<Kolegij> lista)
    {
        List<Nastavnik> rezultat = new List<Nastavnik>();
        bool opPostoji = false;

        foreach (var k in lista)
        {
            // dodavanje unikatnih nastavnika
            foreach (var n in k.lNositeljKolegija)
            {
                if (!rezultat.Exists(x => x.oib == n.oib))
                    rezultat.Add(n);
            }

            // provjera OP
            if (k.naziv == "Osnove programiranja")
            {
                opPostoji = true;
                Console.WriteLine("Nositelji kolegija Osnove programiranja:");
                foreach (var n in k.lNositeljKolegija)
                    Console.WriteLine($"{n.titula} {n.ime} {n.prezime}");
            }
        }

        if (!opPostoji)
            Console.WriteLine("Kolegij Osnove programiranja se ne nalazi u listi predmeta.");

        return rezultat;
    }
}
