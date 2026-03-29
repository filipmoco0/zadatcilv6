using System;
using System.Text.RegularExpressions;

public class Student
{
    public string Ime;
    public string Prezime;
    public string Jmbag;
    
    // Konstruktor

    public Student(string ime, string prezime, string jmbag)
    {
        Ime = ime;
        Prezime = prezime;
        Jmbag = jmbag;
    }
    
    // Destruktor
    ~Student()
    {
        Console.WriteLine($"Objekt student {Ime} {Prezime} se uništava.");
    }
    
    // Funkcijski članovi

    public void Ispis()
    {
        Console.WriteLine($"Ime: {Ime}");
        Console.WriteLine($"Prezime: {Prezime}");
        Console.WriteLine($"JMBAG: {Jmbag}");
    }

    private bool ValidirajJMBAG(string jmbag)
    {
        if (jmbag.Length != 10)
            return false;

        foreach (char c in jmbag)
        {
            if (!char.IsDigit(c))
                return false;
        }
        return true;
    }

    public bool PromijeniJMBAG(string s)
    {
        if (ValidirajJMBAG(s))
        {
            Jmbag = s;
            return true;
        }
        else
        {
            Console.WriteLine("Neispravan JMBAG!");
            return false;
        }
    }
}
    }
}
