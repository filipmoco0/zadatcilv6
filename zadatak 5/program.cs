using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Kreiranje studenta
            Student s1 = new Student("Ivan", "Ivić", "1234567890");

            // Ispis podataka
            s1.Ispis();

            Console.WriteLine("\nPokušaj promjene JMBAG-a:");

            // Neispravan JMBAG
            s1.PromijeniJMBAG("123");

            // Ispravan JMBAG
            s1.PromijeniJMBAG("0987654321");

            // Ponovni ispis
            Console.WriteLine("\nNovi podaci:");
            s1.Ispis();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.ReadKey();
    }
}
