using System;
using System.Collections.Generic;

public class Trokut : GeometrijskiLik
{
    public Trokut(string b, float a, float b2, float c) : base(b)
    {
        _a = a;
        _b = b2;
        _c = c;
    }
    
    protected float _a, _b, _c;

    public Trokut()
    {
        _a = _b = _c = 0;
    }
    
    ~Trokut()
    {
        Console.WriteLine("Unisten Trokut!");
    }
    
    public Trokut(float a, float b, float c)
    {
        _a = a;
        _b = b;
        _c = c;
    }

    protected bool isValid()
    {
        if (_a <= 0 || _b <= 0 || _c <= 0)
            return false;
        else if ((_a + _b) <= _c || (_a + _c) <= _b || (_b + _c) <= _a)
            return false;
        else return true;
    }

    public override void Tip()
    {
        Console.WriteLine("Trokut sa stranicama duljine " + _a + ", " + _b + " i " + _c);
    }

    public override float Povrsina()
    {
        if (isValid())
        {
            float s = (_a + _b + _c) / 2;
            float P = (float)Math.Sqrt(s * (s - _a) * (s - _b) * (s - _c));
            return P;
        }
        else
        {
            return -1;
        }
    }

    public override float Opseg()
    {
        if (isValid())
        {
            return _a + _b + _c;
        }
        else
        {
            return -1;
        }
    }
}
