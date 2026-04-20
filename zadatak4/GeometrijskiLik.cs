using System;

public class GeometrijskiLik
{
    public string boja;
    public static int Broj = 0;

    public GeometrijskiLik()
    {
        boja = "Zelena";
        Broj++;
    }

    public GeometrijskiLik(string b)
    {
        boja = b;
        Broj++;
    }

    ~GeometrijskiLik()
    {
        Console.WriteLine("Unisten GeometrijskiLik");
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
