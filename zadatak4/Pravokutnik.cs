using System;

class Pravokutnik : GeometrijskiLik
{
    protected float _a, _b;

    public Pravokutnik() : base()
    {
        _a = 0;
        _b = 0;
    }

    public Pravokutnik(float a, float b) : base()
    {
        _a = a;
        _b = b;
    }

    public Pravokutnik(string bo, float a, float b) : base(bo)
    {
        _a = a;
        _b = b;
    }

    ~Pravokutnik()
    {
        Console.WriteLine("Unisten Pravokutnik");
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

class Kvadrat : Pravokutnik
{
    public Kvadrat() : base()
    {
        _a = 1;
        _b = 1;
    }

    public Kvadrat(float a) : base(a, a)
    {
    }

    public Kvadrat(string bo, float a) : base(bo, a, a)
    {
    }

    ~Kvadrat()
    {
        Console.WriteLine("Unisten Kvadrat");
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
