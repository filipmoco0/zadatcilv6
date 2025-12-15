using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public string JMBAG { get; set; }
    public List<int> Ocjene { get; set; }
}

class Program
{
    static void Main()
    {
        List<Student> studenti = new List<Student>
        {
            new Student {
                Ime="Ana", Prezime="Anić", JMBAG="1234567890",
                Ocjene = new List<int> {5, 4, 5}
            },
            new Student {
                Ime="Marko", Prezime="Marić", JMBAG="1234567890",
                Ocjene = new List<int> {3, 4, 4}
            },
            new Student {
                Ime="Ivan", Prezime="Ivić", JMBAG="0987654321",
                Ocjene = new List<int>()   // još nema ocjena
            },
            new Student {
                Ime="Petra", Prezime="Petrić", JMBAG="1111111111",
                Ocjene = new List<int> {5, 5, 5}
            },
            new Student {
                Ime="Luka", Prezime="Lukić", JMBAG="2222222222",
                Ocjene = new List<int>()   // još nema ocjena
            }
        };

        // Zapis u JSON
        string json = JsonSerializer.Serialize(
            studenti,
            new JsonSerializerOptions { WriteIndented = true }
        );
        File.WriteAllText("studenti.json", json);

        // Pozivi funkcija
        ProvjeriIspravnostJMBAG(studenti);
        ProvjeriIsteJMBAG(studenti);
        IspisiStudenteSNajvecimProsjekom(studenti);
    }

    // Provjera JMBAG-a (10 znamenaka)
    static void ProvjeriIspravnostJMBAG(List<Student> studenti)
    {
        foreach (Student s in studenti)
        {
            if (s.JMBAG.Length != 10 || !s.JMBAG.All(char.IsDigit))
                Console.WriteLine($"Neispravan JMBAG: {s.Ime} {s.Prezime}");
        }
    }

    // Provjera duplikata JMBAG-a
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
        foreach (var grupa in grupe)
            foreach (Student s in grupa)
                Console.WriteLine($"{s.Ime} {s.Prezime} - {s.JMBAG}");
    }

    // Studenti s najvećim prosjekom
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
