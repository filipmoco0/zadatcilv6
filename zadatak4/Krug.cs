using System;

class Krug : GeometrijskiLik
{
    private float _r;

    public Krug() : base()
    {
        _r = 1;
    }

    public Krug(float polumjer) : base()
    {
        _r = polumjer;
    }

    public Krug(string b, float polumjer) : base(b)
    {
        _r = polumjer;
    }

    ~Krug()
    {
        Console.WriteLine("Unisten Krug");
    }

    public override void Tip()
    {
        Console.WriteLine("Krug polumjera " + _r);
    }

    public override float Povrsina()
    {
        return _r * _r * (float)Math.PI;
    }

    public override float Opseg()
    {
        return 2 * _r * (float)Math.PI;
    }
}
