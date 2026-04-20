using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        GeometrijskiLik t1 = new Trokut("Plava", 2, 3, 30);
        GeometrijskiLik t2 = new JednakostranicniTrokut(2);
        GeometrijskiLik t3 = new PravokutniTrokut(3, 4, 6);
        GeometrijskiLik jt1 = new JednakokracanTrokut("Narancasta", 5, 6);
        GeometrijskiLik jt2 = new JednakokracanTrokut(4, 4);

        GeometrijskiLik k1 = new Krug();
        GeometrijskiLik k2 = new Krug((float)3.4);
        GeometrijskiLik p1 = new Pravokutnik("Crvena", (float)2.5, 4);
        GeometrijskiLik kv1 = new Kvadrat("Zuta", 5);
        GeometrijskiLik kv2 = new Kvadrat();

        GeometrijskiLik e1 = new Elipsa("Siva", 3, 2);
        GeometrijskiLik e2 = new Elipsa("Ruzicasta", 5, 1);

        Console.WriteLine("Lista geometrijskih likova:");
        List<GeometrijskiLik> geom_likovi = new List<GeometrijskiLik>()
        {
            t1, t2, t3, jt1, jt2, k1, k2, p1, kv1, kv2, e1, e2
        };

        foreach (GeometrijskiLik g in geom_likovi)
        {
            g.Tip();
            if (g.Opseg() <= 0 || g.Povrsina() <= 0)
            {
                Console.WriteLine("Geometrijski lik nije dobro definiran!");
                Console.WriteLine("Boja: " + g.boja);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Opseg: " + g.Opseg());
                Console.WriteLine("Povrsina: " + g.Povrsina());
                Console.WriteLine("Boja: " + g.boja);
                Console.WriteLine();
            }
        }

        Console.WriteLine("Ukupno kreirano objekata: " + GeometrijskiLik.Broj);
        Console.WriteLine();

        List<Trokut> trokuti = new List<Trokut>()
        {
            new Trokut("Ljubicasta", 3, 4, 5),
            new JednakostranicniTrokut("Bijela", 6),
            new PravokutniTrokut("Crna", 3, 4, 5),
            new JednakokracanTrokut("Smeda", 5, 6)
        };

        Console.WriteLine("Lista trokuta:");
        foreach (Trokut t in trokuti)
        {
            t.Tip();
            if (t.Opseg() <= 0 || t.Povrsina() <= 0)
            {
                Console.WriteLine("Trokut nije dobro definiran!");
                Console.WriteLine("Boja: " + t.boja);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Opseg: " + t.Opseg());
                Console.WriteLine("Povrsina: " + t.Povrsina());
                Console.WriteLine("Boja: " + t.boja);
                Console.WriteLine();
            }
        }
    }
}
