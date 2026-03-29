using System;

class Program
{
    static void Main(string[] args)
    {
        Student s1 = new Student("Ivan", "Ivić", "1234547890");

        s1.Ispis();
        
        Console.WriteLine("Promejna JMBAGA.");
        
        s1.PromijeniJMBAG("3535");
        
        
    }
}
