using System;
using System.Collections.Generic;

class Kvadrat : Pravokutnik
{
    public Kvadrat(float a, string b) : base(a, a, b)
    {
    }
    public Kvadrat()
    {
        _a = 1;
    }

    ~Kvadrat()
    {
        Console.WriteLine("Unisten Kvadrat!");
    }
    
    public Kvadrat(float a)
    {
        _a = a;
    }

    public override void Tip()
    {
        Console.WriteLine("Kvadrat sa stranicom duljine " + _a);
    }

    public override float Povrsina()
    {
        return _a * _a;
    }

    public override float Opseg()
    {
        return 4 * _a;
    }
}
