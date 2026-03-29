using System;
using System.Collections.Generic;

public class Alkohol
{
    // Podatkovni članovi (private)
    private string Naziv;
    private double Cijena;
    private double PostotakAlkohola;
    private string TipAlkohola;
    private int GodinaProizvodnje;
    private List<string> Sastojci;

    // Konstruktor bez parametara
    public Alkohol()
    {
        Naziv = "Nepoznato";
        Cijena = 0;
        PostotakAlkohola = 0;
        TipAlkohola = "Nepoznato";
        GodinaProizvodnje = 0;
        Sastojci = new List<string>();
    }

    // Konstruktor s parametrima
    public Alkohol(string naziv, double cijena, double postotakAlkohola, string tipAlkohola, int godinaProizvodnje)
    {
        Naziv = naziv;
        Cijena = cijena;
        PostotakAlkohola = postotakAlkohola;
        TipAlkohola = tipAlkohola;
        GodinaProizvodnje = godinaProizvodnje;
        Sastojci = new List<string>();
    }

    // Destruktor
    ~Alkohol()
    {
        Console.WriteLine("Objekt je uništen");
    }

    // Funkcijski članovi

    public void DodajSastojak(string sastojak)
    {
        Sastojci.Add(sastojak);
    }

    public double IzracunajCijenuSPopustom(double popust)
    {
        return Cijena - (Cijena * popust / 100);
    }

    public void PovecajCijenu(double iznos)
    {
        Cijena += iznos;
    }

    public bool JeVino()
    {
        return TipAlkohola.ToLower() == "vino";
    }

    public void IspisiPodatke()
    {
        Console.WriteLine($"{Naziv}, {Cijena}, {PostotakAlkohola}%, {TipAlkohola}, {GodinaProizvodnje}, Sastojci: {string.Join(", ", Sastojci)}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // objekti
        Alkohol p1 = new Alkohol("Graševina", 10, 12.5, "Vino", 2020);
        Alkohol p2 = new Alkohol("Ožujsko", 2, 4.5, "Pivo", 2023);
        Alkohol p3 = new Alkohol();

        // testovi 
        p1.DodajSastojak("Grožđe");
        p2.DodajSastojak("Ječam");

        Console.WriteLine("Cijena s popustom:");
        Console.WriteLine(p1.IzracunajCijenuSPopustom(10));

        p1.PovecajCijenu(5);

        Console.WriteLine("Je vino:");
        Console.WriteLine(p1.JeVino());

        Console.WriteLine("\nPodaci o pićima:");
        p1.IspisiPodatke();
        p2.IspisiPodatke();
        p3.IspisiPodatke();
    }
}
