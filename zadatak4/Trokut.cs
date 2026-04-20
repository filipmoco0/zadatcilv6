using System;

public class Trokut : GeometrijskiLik
{
    protected float _a, _b, _c;

    public Trokut() : base()
    {
        _a = _b = _c = 0;
    }

    public Trokut(float a, float b, float c) : base()
    {
        _a = a;
        _b = b;
        _c = c;
    }

    public Trokut(string bo, float a, float b, float c) : base(bo)
    {
        _a = a;
        _b = b;
        _c = c;
    }

    protected virtual bool isValid()
    {
        if (_a <= 0 || _b <= 0 || _c <= 0)
            return false;
        else if ((_a + _b) <= _c || (_a + _c) <= _b || (_b + _c) <= _a)
            return false;
        else
            return true;
    }

    public override void Tip()
    {
        Console.WriteLine("Trokut sa stranicama duljine " + _a + ", " + _b + " i " + _c);
    }

    ~Trokut()
    {
        Console.WriteLine("Unisten Trokut");
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

public class JednakostranicniTrokut : Trokut
{
    public JednakostranicniTrokut(float a) : base(a, a, a)
    {
    }

    public JednakostranicniTrokut(string bo, float a) : base(bo, a, a, a)
    {
    }

    ~JednakostranicniTrokut()
    {
        Console.WriteLine("Unisten JednakostranicniTrokut");
    }

    public override void Tip()
    {
        Console.WriteLine("Jednakostranicni trokut sa stranicom duljine " + _a);
    }

    public override float Povrsina()
    {
        return (float)(Math.Sqrt(3) / 4) * _a * _a;
    }

    public override float Opseg()
    {
        return 3 * _a;
    }
}

public class PravokutniTrokut : Trokut
{
    public PravokutniTrokut(float a, float b, float c) : base(a, b, c)
    {
    }

    public PravokutniTrokut(string bo, float a, float b, float c) : base(bo, a, b, c)
    {
    }

    ~PravokutniTrokut()
    {
        Console.WriteLine("Unisten PravokutniTrokut");
    }

    protected override bool isValid()
    {
        if (_a <= 0 || _b <= 0 || _c <= 0)
            return false;
        else if ((_a + _b) <= _c || (_a + _c) <= _b || (_b + _c) <= _a)
            return false;
        else if (_a * _a + _b * _b != _c * _c)
            return false;
        else
            return true;
    }

    public override void Tip()
    {
        Console.WriteLine("Pravokutni trokut sa stranicama duljine " + _a + ", " + _b + " i " + _c);
    }

    public override float Povrsina()
    {
        if (isValid())
            return _a * _b / 2;
        else
            return -1;
    }
}

public class JednakokracanTrokut : Trokut
{
    public JednakokracanTrokut(float a, float b) : base(a, b, a)
    {
    }

    public JednakokracanTrokut(string bo, float a, float b) : base(bo, a, b, a)
    {
    }

    ~JednakokracanTrokut()
    {
        Console.WriteLine("Unisten JednakokracanTrokut");
    }

    protected override bool isValid()
    {
        if (_a <= 0 || _b <= 0 || _c <= 0)
            return false;
        else if (_a != _c)
            return false;
        else if ((_a + _b) <= _c || (_a + _c) <= _b || (_b + _c) <= _a)
            return false;
        else
            return true;
    }

    private float Visina()
    {
        return (float)Math.Sqrt(_a * _a - (_b / 2) * (_b / 2));
    }

    public override void Tip()
    {
        Console.WriteLine("Jednakokracan trokut s krakovima " + _a + " i osnovicom " + _b);
    }

    public override float Povrsina()
    {
        if (isValid())
            return _b * Visina() / 2;
        else
            return -1;
    }

    public override float Opseg()
    {
        if (isValid())
            return _a + _b + _c;
        else
            return -1;
    }
}
