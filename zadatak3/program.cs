using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        GeometrijskiLik t1 = new Trokut(2, 3, 30);
        GeometrijskiLik k1 = new Krug(3);
        GeometrijskiLik p1 = new Pravokutnik(2, 4);
        GeometrijskiLik kv1 = new Kvadrat(5);

        List<GeometrijskiLik> lista = new List<GeometrijskiLik>() { t1, k1, p1, kv1 };

        foreach (GeometrijskiLik g in lista)
        {
            g.Tip();

            if (g.Opseg() <= 0 || g.Povrsina() <= 0)
            {
                Console.WriteLine("Geometrijski lik nije dobro definiran!");
                Console.WriteLine("Boja: " + g.boja);
            }
            else
            {
                Console.WriteLine("Opseg: " + g.Opseg());
                Console.WriteLine("Povrsina: " + g.Povrsina());
                Console.WriteLine("Boja: " + g.boja);
            }

            Console.WriteLine();
        }
    }
}        get { return _godinaProizvodnje; }
        private set { _godinaProizvodnje = value; }
    }
    public List<string> Sastojci
    {
        get { return _sastojci; }
        private set { _sastojci = value; }
    }

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
