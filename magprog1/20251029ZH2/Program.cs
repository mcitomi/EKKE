namespace _20251029ZH2;

class Vizsga
{
    public string Kod { get; set; }
    public string Nev { get; set; }
    public bool Irasbeli { get; set; }
    public DateTime Datum { get; set; }
    public int MaxLetszam { get; set; }
    public int Jelentkezettek { get; set; }
    public string Terem { get; set; }

    public Vizsga(string kod, string nev, bool irasbelie, DateTime datum, int maxletszam, int jelentkezettek, string terem)
    {
        Kod = kod;
        Nev = nev;
        Irasbeli = irasbelie;
        Datum = datum;
        MaxLetszam = maxletszam;
        Jelentkezettek = jelentkezettek;
        Terem = terem;
    }
}
class Program
{
    static int F2_Telitettseg(Vizsga vizsga)
    {
        return (int)Math.Floor(((double)vizsga.Jelentkezettek / vizsga.MaxLetszam) * 100);
    }
    static void Main(string[] args)
    {
        List<Vizsga> vizsgak = new List<Vizsga>();

        StreamReader sr = new StreamReader("MP1_2024_25_ZH2_input.csv");

        sr.ReadLine();

        while (!sr.EndOfStream)
        {
            string[] line = sr.ReadLine().Split(';');

            vizsgak.Add(new Vizsga(line[0], line[1], line[2] == "I", DateTime.Parse(line[3]), int.Parse(line[4]), int.Parse(line[5]), line[6]));
        }

        #region 3.Feladat
        List<Vizsga> mainapElottiTelitettVizsgak = vizsgak.Where(vizsga => vizsga.Datum < DateTime.Parse("2024.12.04 10:00") && vizsga.Datum.Month == 12 && F2_Telitettseg(vizsga) > 70).ToList();

        double atlagosTelitettseg = mainapElottiTelitettVizsgak.Average(v => F2_Telitettseg(v));

        Console.WriteLine("3. feladat\nDecember elejei 70% fölötti vizsgák:");

        foreach (Vizsga vizsga in mainapElottiTelitettVizsgak)
        {
            Console.WriteLine($"{vizsga.Datum.ToString("MMMM d. HH:mm")} - {vizsga.Kod} - {vizsga.Nev} ({(vizsga.Irasbeli ? "írásbeli" : "szóbeli")}) - {vizsga.Jelentkezettek}/{vizsga.MaxLetszam} ({F2_Telitettseg(vizsga)}%)");
        }
        #endregion

        #region 4.Feladat

        Console.WriteLine("4. feladat");
        
        Vizsga vizsgakMP1 = vizsgak.Where(v => v.Nev == "Magasszintű programozási nyelvek 1").Where(v => v.Jelentkezettek == v.MaxLetszam).OrderByDescending(v => v.Datum).First();
        Vizsga vizsgakGrafika = vizsgak.Where(v => v.Nev == "Bevezetés a számítógépi grafikába").Where(v => v.Jelentkezettek == v.MaxLetszam).OrderByDescending(v => v.Datum).First();

        if(vizsgakGrafika.MaxLetszam > vizsgakMP1.MaxLetszam)
        {
            Console.WriteLine("Bevezetés a számítógépi grafikába vizsgán többen vannak.");
        } else if(vizsgakGrafika.MaxLetszam < vizsgakMP1.MaxLetszam)
        {
            Console.WriteLine("Magasszintű programozási nyelvek 1 vizsgán többen vannak.");
        } else
        {
            System.Console.WriteLine("Mind két vizsgán ugyan annyian vannak.");
        }

        #endregion
    }
}
