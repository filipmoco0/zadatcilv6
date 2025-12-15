using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Student> studenti = new List<Student>
        {
            new Student {
                Ime="Ana", Prezime="Anić", JMBAG="1234567890",
                Ocjene = new List<Ocjena> {
                    new Ocjena { Vrijednost = 5 },
                    new Ocjena { Vrijednost = 4 },
                    new Ocjena { Vrijednost = 5 }
                }
            },
            new Student {
                Ime="Marko", Prezime="Marić", JMBAG="1234567890",
                Ocjene = new List<Ocjena> {
                    new Ocjena { Vrijednost = 3 },
                    new Ocjena { Vrijednost = 4 }
                }
            },
            new Student {
                Ime="Ivan", Prezime="Ivić", JMBAG="0987654321",
                Ocjene = new List<Ocjena>()
            },
            new Student {
                Ime="Petra", Prezime="Petrić", JMBAG="1111111111",
                Ocjene = new List<Ocjena> {
                    new Ocjena { Vrijednost = 5 },
                    new Ocjena { Vrijednost = 5 }
                }
            },
            new Student {
                Ime="Luka", Prezime="Lukić", JMBAG="2222222222",
                Ocjene = new List<Ocjena>()
            }
        };

        // Zapis u JSON
        string json = JsonSerializer.Serialize(
            studenti,
            new JsonSerializerOptions { WriteIndented = true }
        );
        File.WriteAllText("studenti.json", json);

        ProvjeriIspravnostJMBAG(studenti);
        ProvjeriIsteJMBAG(studenti);
        IspisiStudenteSNajvecimProsjekom(studenti);
    }

    static void ProvjeriIspravnostJMBAG(List<Student> studenti)
    {
        foreach (Student s in studenti)
            if (s.JMBAG.Length != 10 || !s.JMBAG.All(char.IsDigit))
                Console.WriteLine($"Neispravan JMBAG: {s.Ime} {s.Prezime}");
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
        foreach (var grupa in grupe)
            foreach (Student s in grupa)
                Console.WriteLine($"{s.Ime} {s.Prezime} - {s.JMBAG}");
    }

    static void IspisiStudenteSNajvecimProsjekom(List<Student> studenti)
    {
        var studentiSOcjenama = studenti
            .Where(s => s.Ocjene != null && s.Ocjene.Count > 0)
            .ToList();

        if (studentiSOcjenama.Count == 0)
        {
            Console.WriteLine("Nijedan student još nije polagao ispite.");
            return;
        }

        double max = studentiSOcjenama
            .Max(s => s.Ocjene.Average(o => o.Vrijednost));

        Console.WriteLine("Studenti s najvećim prosjekom:");
        foreach (Student s in studentiSOcjenama)
            if (s.Ocjene.Average(o => o.Vrijednost) == max)
                Console.WriteLine($"{s.Ime} {s.Prezime} - {max:F2}");
    }
}
