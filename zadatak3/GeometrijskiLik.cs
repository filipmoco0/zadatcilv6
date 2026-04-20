using System;
using System.Collections.Generic;

public class GeometrijskiLik
{
    public string boja;
    
    
    public GeometrijskiLik(string b)
    {
        boja = b;
    }

    public GeometrijskiLik()
    {
        boja = "Zelena";
    }
    
    ~GeometrijskiLik()
    {
        Console.WriteLine("Unisten Geometrijski lik!");
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
