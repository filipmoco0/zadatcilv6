using System;
using System.Collections.Generic;

class Predmet
{
    private int _sifra;
    private string _naziv;
    private int _ects;

    public Predmet(int sifra, string naziv, int ects)
    {
        Sifra = sifra;
        Naziv = naziv;
        Ects = ects;
    }

    public int Sifra
    {
        get { return _sifra; }
        set { _sifra = value; }
    }

    public string Naziv
    {
        get { return _naziv; }
        set { _naziv = value; }
    }

    public int Ects
    {
        get { return _ects; }
        set { _ects = value; }
    }
}

class Ocjena
{
    private int _iznos;
    private Predmet _predmet;

    public Ocjena(Predmet predmet, int iznos)
    {
        Predmet = predmet;
        Iznos = iznos;
    }

    public Predmet Predmet
    {
        get { return _predmet; }
        set { _predmet = value; }
    }

    public int Iznos
    {
        get { return _iznos; }
        set { _iznos = value; }
    }
}

class Student
{
    private string _ime;
    private string _prezime;
    private float _prosjek_ocjena;
    private List<Ocjena> _ocjene;
    private List<Student> _prijatelji;

    public Student(string ime, string prezime, List<Ocjena> ocjene, List<Student> prijatelji)
    {
        Ime = ime;
        Prezime = prezime;
        Ocjene = ocjene;
        Prijatelji = prijatelji;

        int sum = 0;
        int br = 0;
        foreach (Ocjena o in Ocjene)
        {
            if (o.Iznos >= 2 && o.Iznos <= 5)
            {
                sum += o.Iznos;
                br++;
            }
        }
        ProsjekOcjena = br > 0 ? (float)sum / br : 0f;
    }

    public string Ime
    {
        get { return _ime; }
        set { _ime = value; }
    }

    public string Prezime
    {
        get { return _prezime; }
        set { _prezime = value; }
    }

    // Samo get - prosjek se računa u konstruktoru, ne smije se mijenjati izvana
    public float ProsjekOcjena
    {
        get { return _prosjek_ocjena; }
        private set { _prosjek_ocjena = value; }
    }

    public List<Ocjena> Ocjene
    {
        get { return _ocjene; }
        set { _ocjene = value; }
    }

    public List<Student> Prijatelji
    {
        get { return _prijatelji; }
        set { _prijatelji = value; }
    }
    
    public int UkupnoECTS()
    {
        int ukupno = 0;
        foreach (Ocjena o in Ocjene)
        {
            if (o.Iznos >=2 && o.Iznos <= 5)
                ukupno += o.Predmet.Ects;
        }
        return ukupno;
    }

    public void TopStudentPrijatelj()
    {
        int maxPetica = 0;
        foreach (Student p in Prijatelji)
        {
            int brojPetica = 0;
            foreach (Ocjena o in p.Ocjene)
            {
                if (o.Iznos == 5)
                    brojPetica++;
            }
            if (brojPetica > maxPetica)
                maxPetica = brojPetica;
        }
        
        foreach (Student p in Prijatelji)
        {
            int brojPetica = 0;
            foreach (Ocjena o in p.Ocjene)
            {
                if (o.Iznos == 5)
                    brojPetica++;
            }

            if (brojPetica == maxPetica && maxPetica > 0)
                Console.WriteLine(p.Ime + " " + p.Prezime + " - petica " + maxPetica);
            
        }
            
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Klasa Student");

        Predmet p1 = new Predmet(1, "Osnove programiranja", 9);
        p1.Naziv = "Osnove programiranja u programskom jeziku C#";
        Console.WriteLine("Naziv predmeta objekta p1: " + p1.Naziv);

        Predmet p2 = new Predmet(2, "Objektno-orijentirano programiranje", 9);
        Predmet p3 = new Predmet(3, "Matematika", 6);

        List<Ocjena> ocjene1 = new List<Ocjena>();
        ocjene1.Add(new Ocjena(p1, 1));
        ocjene1.Add(new Ocjena(p2, 3));
        ocjene1.Add(new Ocjena(p3, 3));

        List<Ocjena> ocjene2 = new List<Ocjena>();
        ocjene2.Add(new Ocjena(p1, 1));
        ocjene2.Add(new Ocjena(p2, 2));
        ocjene2.Add(new Ocjena(p3, 1));
        
        List<Ocjena> ocjene3 = new List<Ocjena>();
        ocjene3.Add(new Ocjena(p1, 4));
        ocjene3.Add(new Ocjena(p2, 4));
        ocjene3.Add(new Ocjena(p3, 5));
        
        List<Ocjena> ocjene4 = new List<Ocjena>();
        ocjene4.Add(new Ocjena(p1, 5));
        ocjene4.Add(new Ocjena(p2, 5));
        ocjene4.Add(new Ocjena(p3, 5));
        
        List<Ocjena> ocjene5 = new List<Ocjena>();
        ocjene5.Add(new Ocjena(p1, 5));
        ocjene5.Add(new Ocjena(p2, 2));
        ocjene5.Add(new Ocjena(p3, 5));

        Student s1 = new Student("Ivan", "Ivanic", ocjene1, null);
        Student s2 = new Student("Marko", "Maric", ocjene2, null);
        Student s3 = new Student("Žarko", "Žalac", ocjene3, null);
        Student s4 = new Student("Tomislav", "Tomić", ocjene4, null);
        Student s5 = new Student("Žile", "Žilić", ocjene5, null);

        s1.Prijatelji = new List<Student>() { s3, s4 };
        s2.Prijatelji = new List<Student>() { s1, s4 };
        s3.Prijatelji = new List<Student>() { s2, s1 };
        s4.Prijatelji = new List<Student>() { s2, s3 };
        s5.Prijatelji = new List<Student>() { s2, s3, s4 };
        
        // POZIVANJA
        
        Console.WriteLine("Top student prijatelj: ");
        s1.TopStudentPrijatelj();
        
        Console.WriteLine("Ukupno ECTS studenta Ivan: " + s1.UkupnoECTS());
        
        Console.WriteLine("Prosjek ocjena studenta Ivan: " + s1.ProsjekOcjena);
        Console.WriteLine("Prosjek ocjena studenta Marko: " + s2.ProsjekOcjena);

        Console.WriteLine("Student " + s1.Ime + " " + s1.Prezime + ":");
        foreach (Ocjena o in s1.Ocjene)
        {
            Console.WriteLine(o.Predmet.Naziv + ": " + o.Iznos);
        }
        
        
    }
}
