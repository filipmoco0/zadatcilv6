using System;

class Elipsa : GeometrijskiLik
{
    protected float _a, _b;

    public Elipsa() : base()
    {
        _a = 1;
        _b = 1;
    }

    public Elipsa(float a, float b) : base()
    {
        _a = a;
        _b = b;
    }

    public Elipsa(string bo, float a, float b) : base(bo)
    {
        _a = a;
        _b = b;
    }

    ~Elipsa()
    {
        Console.WriteLine("Unistena Elipsa");
    }

    public override void Tip()
    {
        Console.WriteLine("Elipsa s poluosima " + _a + " i " + _b);
    }

    public override float Povrsina()
    {
        return _a * _b * (float)Math.PI;
    }

    public override float Opseg()
    {
        Console.WriteLine("Opseg elipse!");
        return 0;
    }
}
