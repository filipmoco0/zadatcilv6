using System;
using System.IO;

class Program
{
    static void Main()
    {
        string path = "Zad1.txt";
        using (StreamWriter sw = new StreamWriter(path))
        {
            for (int i = 8; i <= 142; i++)
            {
                if (i % 7 == 0 && !SveZnamenkeJednake(i))
                {
                    sw.WriteLine(i);
                }
            }
        }
        Console.WriteLine("Zapisano u Zad1.txt.");
    }

    static bool SveZnamenkeJednake(int broj)
    {
        string s = broj.ToString();
        foreach (char c in s)
        {
            if (c != s[0]) return false;
        }
        return true;
    }
}
