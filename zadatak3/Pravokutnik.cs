using System;
using System.Collections.Generic;

class Pravokutnik : GeometrijskiLik
{
    public Pravokutnik(float a, float b2, string b) : base(b)
    {
        _a = a;
        _b = b2;
    }
    
    ~Pravokutnik()
    {
        Console.WriteLine("Unisten Pravokutnik!");
    }
    
    protected float _a, _b;

    public Pravokutnik()
    {
        _a = 0;
        _b = 0;
    }

    public Pravokutnik(float a, float b)
    {
        _a = a;
        _b = b;
    }

    public override void Tip()
    {
        Console.WriteLine("Pravokutnik sa stranicama duljine " + _a + " i " + _b);
    }

    public override float Povrsina()
    {
        return _a * _b;
    }

    public override float Opseg()
    {
        return 2 * _a + 2 * _b;
    }
}
