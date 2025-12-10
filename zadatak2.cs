using System;
using System.Collections.Generic;
using System.Linq;

struct Racunalo
{
    public string naziv;
    public double takt;          // u GHz
    public string opis;
    public Kategorija kategorija;

    public enum Kategorija
    {
        Gaming = 1,
        Poslovno = 2,
        RadnaStanica = 3
    }

    public void Ispis()
    {
        Console.WriteLine($"Naziv: {naziv}, Takt: {takt} GHz, Kategorija: {kategorija}, Opis: {opis}");
    }
}

class Program
{
    static void Main()
    {
        // 1) Kreiranje 5 računala i dodavanje u listu
        List<Racunalo> lracunala = new List<Racunalo>()
        {
            new Racunalo{ naziv="Acer Nitro", takt=3.8, opis="Gaming laptop", kategorija=Racunalo.Kategorija.Gaming },
            new Racunalo{ naziv="Dell XPS", takt=4.1, opis="Premium poslovni laptop", kategorija=Racunalo.Kategorija.Poslovno },
            new Racunalo{ naziv="HP ZBook", takt=3.5, opis="Workstation model", kategorija=Racunalo.Kategorija.RadnaStanica },
            new Racunalo{ naziv="Lenovo ThinkPad", takt=4.1, opis="Poslovni laptop", kategorija=Racunalo.Kategorija.Poslovno },
            new Racunalo{ naziv="MSI Stealth", takt=3.9, opis="Gaming ultrabook", kategorija=Racunalo.Kategorija.Gaming }
        };

        // Ispis for
        Console.WriteLine("FOR petlja:");
        for (int i = 0; i < lracunala.Count; i++)
            lracunala[i].Ispis();

        // Ispis foreach
        Console.WriteLine("\nFOREACH petlja:");
        foreach (var r in lracunala)
            r.Ispis();


        // 2) Ispis računala s najvećim taktom
        Console.WriteLine("\nRačunala s najvećim taktom:");
        IspisiNajveciTakt(lracunala);


        // 3) Dodavanje računala
        DodajRacunalo(lracunala, new Racunalo
        {
            naziv = "Asus ROG",
            takt = 4.1,
            opis = "Gaming high-end laptop",
            kategorija = Racunalo.Kategorija.Gaming
        });


        // 4) Ispis po kategoriji preko switch-a
        Console.WriteLine("\nOdaberi kategoriju (1=Gaming, 2=Poslovno, 3=Radna stanica):");
        int kat = int.Parse(Console.ReadLine());
        IspisiPoKategoriji(lracunala, kat);


        // 5) Pretraga po opisu
        Console.WriteLine("\nUnesi pojam za pretragu opisa:");
        string pojam = Console.ReadLine();
        PretraziOpis(lracunala, pojam);
    }


    // ============================================
    // 2) Najveći takt
    // ============================================
    static void IspisiNajveciTakt(List<Racunalo> lista)
    {
        double max = lista.Max(r => r.takt);

        foreach (var r in lista)
            if (r.takt == max)
                r.Ispis();
    }

    // ============================================
    // 3) Dodavanje novog računala
    // Kriterij: validni podaci (npr. naziv != null, takt > 0)
    // ============================================
    static void DodajRacunalo(List<Racunalo> lista, Racunalo r)
    {
        if (r.takt <= 0 || string.IsNullOrWhiteSpace(r.naziv))
        {
            Console.WriteLine("Greška: neispravni podaci.");
            return;
        }

        lista.Add(r);
    }

    // ============================================
    // 4) Ispis po kategoriji — SWITCH
    // ============================================
    static void IspisiPoKategoriji(List<Racunalo> lista, int tip)
    {
        Racunalo.Kategorija kat;

        switch (tip)
        {
            case 1: kat = Racunalo.Kategorija.Gaming; break;
            case 2: kat = Racunalo.Kategorija.Poslovno; break;
            case 3: kat = Racunalo.Kategorija.RadnaStanica; break;
            default:
                Console.WriteLine("Nepostojeća kategorija.");
                return;
        }

        foreach (var r in lista)
            if (r.kategorija == kat)
                r.Ispis();
    }

    // ============================================
    // 5) Pretraga opisa - case insensitive + dio pojma
    // ============================================
    static void PretraziOpis(List<Racunalo> lista, string pojam)
    {
        pojam = pojam.ToLower();

        foreach (var r in lista)
            if (r.opis.ToLower().Contains(pojam))
                r.Ispis();
    }
}
