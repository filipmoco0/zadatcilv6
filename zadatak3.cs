using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

struct Student
{
    public string Ime;
    public string Prezime;
    public string JMBAG;
    public List<int> Ocjene;

    // Parametrizirani konstruktor
    public Student(string ime, string prezime, string jmbag, List<int> ocjene)
    {
        Ime = ime;
        Prezime = prezime;
        JMBAG = jmbag;
        Ocjene = ocjene;
    }
}

class Program
{
    static void Main()
    {
        List<Student> studenti = new List<Student>
        {
            new Student("Ana", "Anić", "1234567890", new List<int> {5,4,5}),
            new Student("Marko", "Marić", "1234567890", new List<int> {3,4,4}),
            new Student("Ivan", "Ivić", "0987654321", new List<int>()),
            new Student("Petra", "Petrić", "1111111111", new List<int> {5,5,5}),
            new Student("Luka", "Lukić", "2222222222", new List<int>())
        };

        // zapis u JSON
        string json = JsonSerializer.Serialize(studenti, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText("studenti.json", json);

        ProvjeriIspravnostJMBAG(studenti);
        ProvjeriIsteJMBAG(studenti);
        IspisiStudenteSNajvecimProsjekom(studenti);
    }

    static void ProvjeriIspravnostJMBAG(List<Student> studenti)
    {
        foreach (Student s in studenti)
        {
            if (s.JMBAG.Length != 10 || !s.JMBAG.All(char.IsDigit))
                Console.WriteLine($"Neispravan JMBAG: {s.Ime} {s.Prezime}");
        }
    }

    static void ProvjeriIsteJMBAG(List<Student> studenti)
    {
        var grupe = studenti.GroupBy(s => s.JMBAG)
                            .Where(g => g.Count() > 1);

        if (!grupe.Any())
        {
            Console.WriteLine("Nema studenata s istim JMBAG-om.");
            return;
        }

        Console.WriteLine("Studenti s istim JMBAG-om:");
        foreach (var g in grupe)
            foreach (Student s in g)
                Console.WriteLine($"{s.Ime} {s.Prezime} - {s.JMBAG}");
    }

    static void IspisiStudenteSNajvecimProsjekom(List<Student> studenti)
    {
        if (studenti.All(s => s.Ocjene == null || s.Ocjene.Count == 0))
        {
            Console.WriteLine("Nijedan student još nije polagao ispite.");
            return;
        }

        double max = studenti
            .Where(s => s.Ocjene != null && s.Ocjene.Count > 0)
            .Max(s => s.Ocjene.Average());

        Console.WriteLine("Studenti s najvećim prosjekom:");
        foreach (Student s in studenti)
            if (s.Ocjene != null && s.Ocjene.Count > 0 &&
                s.Ocjene.Average() == max)
                Console.WriteLine($"{s.Ime} {s.Prezime} - {max:F2}");
    }
}
