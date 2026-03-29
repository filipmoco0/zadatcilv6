using System;
using System.Collections.Generic;

public class Alkohol
{
    public string Naziv;
    public double Cijena;
    public double PostotakAlkohola;
    public string TipAlkohola;
    public int GodinaProizvodnje;

    public List<string> Sastojci = new List<string>();

    // Konstruktor sa parametrima
    public Alkohol(string naziv, double cijena, double postotakAlkohola, string tipAlkohola, int godinaProizvodnje, List<string> sastojci)
    {
        Naziv = naziv;
        Cijena = cijena;
        PostotakAlkohola = postotakAlkohola;
        TipAlkohola = tipAlkohola;
        GodinaProizvodnje = godinaProizvodnje;
        Sastojci = sastojci;
    }
    
    // Konstruktor bez parametara
    public Alkohol()
    {
        Naziv = "Nepoznato";
        Cijena = 0.00;
        PostotakAlkohola = 0.00;
        TipAlkohola = "Nepoznato";
        GodinaProizvodnje = 0;
        Sastojci = new List<string>();
    }
    
    

    public double IzracunajCijenuSPopustom(double popust)
    {
        return Cijena - (Cijena * popust / 100);
    }

    public void IspisiPodatke()
    {
        Console.WriteLine($"{Naziv}, {Cijena}, {PostotakAlkohola}%, {TipAlkohola}, {GodinaProizvodnje}");
        
        Console.Write("Sastojci: ");
        foreach (var s in Sastojci)
        {
            Console.WriteLine(s);
        }
    }
    
    public bool JeVino()
    {
        return TipAlkohola.ToLower() == "vino";
    }
    
    public void PovecajCijenu(double iznos)
    {
        Cijena += iznos;
    }
    
    public bool JeStarijeOd(int godine)
    {
        return (DateTime.Now.Year - GodinaProizvodnje) > godine;
    }
    
}    
public class Program
{
    public static void Main(string[] args)
    {
        Alkohol pice1 = new Alkohol("Graševina", 10.0, 12.5, "Vino", 2020, new List<string>{"Grožđe"});
        Alkohol pice2 = new Alkohol("Ožujsko", 2.0, 4.5, "Pivo", 2026, new List<string>{"Ječam"});
        Alkohol pice3 = new Alkohol("Jack Daniels", 20.0, 4.5, "Viski", 2018, new List<string>{"Kivi"});
        Alkohol pice4 = new Alkohol();
        
        pice1.IspisiPodatke();
        pice2.IspisiPodatke();
        pice3.IspisiPodatke();
        pice4.IspisiPodatke();
    } 
}
