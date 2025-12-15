using System;
using System.IO;

class Program
{
    static void Main()
    {
        using (StreamWriter sw = File.CreateText("Zad1.txt"))
        {
            for (int i = 8; i <= 142; i++)
            {
                if (i % 7 == 0 && !SveZnamenkeIste(i))
                    sw.WriteLine(i);
            }
        }
    }

    static bool SveZnamenkeIste(int broj)
    {
        string s = broj.ToString();
        foreach (char c in s)
            if (c != s[0]) return false;
        return true;
    }
}
