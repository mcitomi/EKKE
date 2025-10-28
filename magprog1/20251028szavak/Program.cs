namespace _20251028szavak;

class Program
{
    static string AnalyzeSentence(string mondat, out int szavak_szama, out string leghosszabb_szo)
    {
        string[] szavak = mondat.Split(' ');

        szavak_szama = szavak.Length;

        leghosszabb_szo = szavak[0];
        foreach (string s in szavak)
        {
            if (leghosszabb_szo.Length < s.Length)
            {
                leghosszabb_szo = s;
            }
        }

        return mondat.ToLower();
    }
    static int SentenceLength(ref string mondat)
    {
        string temp = mondat[0].ToString().ToUpper(); ;
        for (int i = 1; i < mondat.Length; i++)
        {
            if (mondat[i - 1] == ' ')
            {
                temp += mondat[i].ToString().ToUpper();
            }
            else
            {
                temp += mondat[i];
            }
        }
        mondat = temp;

        return mondat.Length;
    }
    static string AnalyzeSentence(string mondat, char separator, out int szavak_szama, out string leghosszabb_szo)
    {
        string[] szavak = mondat.Split(separator);

        szavak_szama = szavak.Length;

        leghosszabb_szo = szavak[0];
        foreach (string s in szavak)
        {
            if (leghosszabb_szo.Length < s.Length)
            {
                leghosszabb_szo = s;
            }
        }

        return mondat.ToUpper();
    }
    
    static void Main(string[] args)
    {
        string analyzed = AnalyzeSentence("Az tej nagyon finom és a kakó is", out int szavak_szama, out string leghosszabb_szo);
        System.Console.WriteLine(analyzed);
        System.Console.WriteLine(szavak_szama);
        System.Console.WriteLine(leghosszabb_szo);

        string eredeti = "ez itt az eredeti mondat";
        int counted = SentenceLength(ref eredeti);
        System.Console.WriteLine(counted);
        System.Console.WriteLine(eredeti);

        string separateAnalyzed = AnalyzeSentence("Ez;most;mashogy;van;elválasztva", ';', out int szavak_sz, out string leghosszabb_sz);
        System.Console.WriteLine(separateAnalyzed);
        System.Console.WriteLine(szavak_sz);
        System.Console.WriteLine(leghosszabb_sz);
    }
}
