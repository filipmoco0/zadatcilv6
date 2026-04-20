using System;
using System.Collections.Generic;


class Krug : GeometrijskiLik
{
    public Krug(float polumjer, string b) : base(b)
    {
        _r = polumjer;
    }
    
    private float _r;

    public Krug()
    {
        _r = 1;
    }
    
    ~Krug()
    {
        Console.WriteLine("Unisten Krug!");
    }

    public Krug(float polumjer)
    {
        _r = polumjer;
    }

    public override void Tip()
    {
        Console.WriteLine("Krug polumjera " + _r);
    }

    public override float Povrsina()
    {
        return _r * _r * (float)(Math.PI);
    }

    public override float Opseg()
    {
        return 2 * _r * (float)Math.PI;
    }
}
