namespace _20260304_gunics_02;

class Program
{
    static Meteraru Beolvas(string fajlnev)
    {
        StreamReader sr = new StreamReader(fajlnev);
        sr.ReadLine(); // <-- header sor átugrása

        Meteraru bolt = new Meteraru();

        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            string[] parts = line.Split(';');

            Szonyeg szonyeg = new Szonyeg(
                float.Parse(parts[1]),
                float.Parse(parts[0]),
                int.Parse(parts[2]),
                (Szin)Enum.Parse(typeof(Szin), parts[3]),
                parts[4] == "igen"
            );

            bolt.AddSzonyeg(szonyeg);
        }

        return bolt;
    }
    static void Main(string[] args)
    {
        // fájl beolvasás
        // property
        // osztályok
        // enum
        // matek
        
        Console.WriteLine("Hello, World!");

        Meteraru bolt = Beolvas("szonegy.txt");

        foreach (Szonyeg sz in bolt.Szonyegek)
        {
            System.Console.WriteLine(sz);
        }
    }
}
