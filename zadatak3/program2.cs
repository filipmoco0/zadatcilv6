using System;
using System.Collections.Generic;

public class Alkohol
{
    private string _naziv;
    private double _cijena;
    private double _postotakAlkohola;
    private string _tipAlkohola;
    private string _lozinka;
    private int _godinaProizvodnje;
    private List<string> _sastojci;
    
    public string Naziv
    {
        get { return _naziv; }
        set { _naziv = value; }
    }

    public double Cijena
    {
        get {return _cijena; }
        private set { _cijena = value; }
    }
    public double PostotakAlkohola
    {
        get { return _postotakAlkohola; }
        private set { _postotakAlkohola = value; }
    }
    public string TipAlkohola
    {
        get { return _tipAlkohola; }
        private set { _tipAlkohola = value; }
    }
    
    public string Lozinka
    {
        set { _lozinka = value; }
    }
    public int GodinaProizvodnje
    {
        get { return _godinaProizvodnje; }
    }
    public List<string> Sastojci
    {
        get { return _sastojci; }
        private set { _sastojci = value; }
    }

    // Konstruktor sa parametrima
    public Alkohol(string naziv, double cijena, double postotakAlkohola, string tipAlkohola, string lozinka, int godinaProizvodnje, List<string> sastojci)
    {
        Naziv = naziv;
        Cijena = cijena;
        PostotakAlkohola = postotakAlkohola;
        TipAlkohola = tipAlkohola;
        Lozinka = lozinka;
        _godinaProizvodnje = godinaProizvodnje;
        Sastojci = sastojci;
    }
    
    // Konstruktor bez parametara
    public Alkohol()
    {
        Naziv = "Nepoznato";
        Cijena = 0.00;
        PostotakAlkohola = 0.00;
        TipAlkohola = "Nepoznato";
        Lozinka = "Nepoznata";
        _godinaProizvodnje = 0;
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
        Alkohol pice1 = new Alkohol("Graševina", 10.0, 12.5, "Vino", "tajna123!", 2020, new List<string>{"Grožđe"});
        Alkohol pice2 = new Alkohol("Ožujsko", 2.0, 4.5, "Pivo","tajna124!", 2026, new List<string>{"Ječam"});
        Alkohol pice3 = new Alkohol("Jack Daniels", 20.0, 4.5, "Viski", "tajna125!", 2018, new List<string>{"Kivi"});
        Alkohol pice4 = new Alkohol();
        
        pice1.IspisiPodatke();
        pice2.IspisiPodatke();
        pice3.IspisiPodatke();
        pice4.IspisiPodatke();

        bool starost = pice1.JeStarijeOd(10);
        Console.WriteLine(starost);
        
        pice1.PovecajCijenu(10);
        Console.WriteLine("Nova cijena za " + pice1.Naziv + " je: " + pice1.Cijena);
    } 
}
