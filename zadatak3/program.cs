using System;
using System.Collections.Generic;

public class GeometrijskiLik
{
    public string boja;

    public GeometrijskiLik()
    {
        boja = "Zelena";
    }

    public virtual void Tip()
    {
        Console.WriteLine("Geometrijski lik.");
    }

    public virtual float Povrsina()
    {
        Console.WriteLine("Povrsina geometrijskog lika.");
        return 0;
    }

    public virtual float Opseg()
    {
        Console.WriteLine("Opseg geometrijskog lika.");
        return 0;
    }
}

// --------------------

class Krug : GeometrijskiLik
{
    private float _r;

    public Krug()
    {
        _r = 1;
    }

    public Krug(float polumjer)
    {
        _r = polumjer;
    }

    public override void Tip()
    {
        Console.WriteLine("Krug polumjera " + _r);
    }

    public override float Povrsina()
    {
        return _r * _r * (float)(Math.PI);
    }

    public override float Opseg()
    {
        return 2 * _r * (float)Math.PI;
    }
}

// --------------------

class Pravokutnik : GeometrijskiLik
{
    protected float _a, _b;

    public Pravokutnik()
    {
        _a = 0;
        _b = 0;
    }

    public Pravokutnik(float a, float b)
    {
        _a = a;
        _b = b;
    }

    public override void Tip()
    {
        Console.WriteLine("Pravokutnik sa stranicama duljine " + _a + " i " + _b);
    }

    public override float Povrsina()
    {
        return _a * _b;
    }

    public override float Opseg()
    {
        return 2 * _a + 2 * _b;
    }
}

// --------------------

class Kvadrat : Pravokutnik
{
    public Kvadrat()
    {
        _a = 1;
    }

    public Kvadrat(float a)
    {
        _a = a;
    }

    public override void Tip()
    {
        Console.WriteLine("Kvadrat sa stranicom duljine " + _a);
    }

    public override float Povrsina()
    {
        return _a * _a;
    }

    public override float Opseg()
    {
        return 4 * _a;
    }
}

// --------------------

public class Trokut : GeometrijskiLik
{
    protected float _a, _b, _c;

    public Trokut()
    {
        _a = _b = _c = 0;
    }

    public Trokut(float a, float b, float c)
    {
        _a = a;
        _b = b;
        _c = c;
    }

    protected bool isValid()
    {
        if (_a <= 0 || _b <= 0 || _c <= 0)
            return false;
        else if ((_a + _b) <= _c || (_a + _c) <= _b || (_b + _c) <= _a)
            return false;
        else return true;
    }

    public override void Tip()
    {
        Console.WriteLine("Trokut sa stranicama duljine " + _a + ", " + _b + " i " + _c);
    }

    public override float Povrsina()
    {
        if (isValid())
        {
            float s = (_a + _b + _c) / 2;
            float P = (float)Math.Sqrt(s * (s - _a) * (s - _b) * (s - _c));
            return P;
        }
        else
        {
            return -1;
        }
    }

    public override float Opseg()
    {
        if (isValid())
        {
            return _a + _b + _c;
        }
        else
        {
            return -1;
        }
    }
}

// --------------------

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

        bool starost = pice1.JeStarijeOd(10);
        Console.WriteLine(starost);
    } 
}
