using System;
using System.Text.RegularExpressions;

public class Student
{
    // Podatkovni članovi (privatni)
    private string ime;
    private string prezime;
    private string jmbag;

    // Konstruktor
    public Student(string ime, string prezime, string jmbag)
    {
        this.ime = ime;
        this.prezime = prezime;

        if (JeValidanJMBAG(jmbag))
            this.jmbag = jmbag;
        else
            throw new ArgumentException("Neispravan JMBAG!");
    }

    // Destruktor
    ~Student()
    {
        Console.WriteLine($"Objekt student {ime} {prezime} se uništava.");
    }

    // Funkcija za promjenu JMBAG-a
    public bool PromijeniJMBAG(string s)
    {
        if (JeValidanJMBAG(s))
        {
            jmbag = s;
            return true;
        }
        else
        {
            Console.WriteLine("Neispravan JMBAG!");
            return false;
        }
    }

    // Pomoćna funkcija za validaciju JMBAG-a
    private bool JeValidanJMBAG(string s)
    {
        // Primjer kriterija:
        // - mora imati točno 10 znamenki
        // - samo brojevi

        if (s.Length != 10)
            return false;

        return Regex.IsMatch(s, @"^\d{10}$");
    }

    // Ispis podataka
    public void Ispis()
    {
        Console.WriteLine($"Ime: {ime}");
        Console.WriteLine($"Prezime: {prezime}");
        Console.WriteLine($"JMBAG: {jmbag}");
    }
}
