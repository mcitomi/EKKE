namespace _20251203auto;

class CarHash
{
    public CarHash(string rendszam, int km)
    {
        Rendszam = rendszam;
        Km = km;
    }

    public string Rendszam { get; set; }
    public int Km { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }
        CarHash temp = obj as CarHash;
        return this.Rendszam.Equals(temp.Rendszam);
    }

    public override int GetHashCode()
    {
        return Rendszam.GetHashCode();
    }
}
class Car
{
    public int Nap { get; set; }
    public string OraPerc { get; set; }
    public string Rendszam { get; set; }
    public string SzemelyiId { get; set; }
    public int Km { get; set; }
    public int Kibe { get; set; }

    public Car(int nap, string oraPerc, string rendszam, string szemelyiId, int km, int kibe)
    {
        Nap = nap;
        OraPerc = oraPerc;
        Rendszam = rendszam;
        SzemelyiId = szemelyiId;
        Km = km;
        Kibe = kibe;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }
        Car temp = obj as Car;
        return this.Rendszam.Equals(temp.Rendszam);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
class Program
{
    static List<Car> F3_adottNapon(List<Car> autok, int nap)
    {
        List<Car> kivittek = new List<Car>();

        foreach (Car elem in autok)
        {
            if (elem.Nap == nap)
            {
                kivittek.Add(elem);
            }
        }

        return kivittek;
    }
    static void Main(string[] args)
    {
        List<Car> autok = new List<Car>();
        HashSet<CarHash> autok_start = new HashSet<CarHash>();

        StreamReader sr = new StreamReader("autok.txt");

        while (!sr.EndOfStream)
        {
            string[] sor = sr.ReadLine().Split(' ');

            autok.Add(new Car(
                int.Parse(sor[0]),
                sor[1],
                sor[2],
                sor[3],
                int.Parse(sor[4]),
                int.Parse(sor[5])
            ));

            autok_start.Add(new CarHash(
                sor[2],
                int.Parse(sor[4])
            ));
        }
        sr.Close();

        Console.WriteLine("2. feladat");

        for (int i = autok.Count - 1; i >= 0; i--)
        {
            if (autok[i].Kibe == 0)
            {
                System.Console.WriteLine($"{autok[i].Nap}. nap rendszám: {autok[i].Rendszam}");
                break;
            }
        }

        // ........................
        System.Console.WriteLine("3. feladtat");

        System.Console.WriteLine("Nap?: ");
        int nap = int.Parse(Console.ReadLine());

        List<Car> kivittek = F3_adottNapon(autok, nap);
        foreach (Car elem in kivittek)
        {
            System.Console.WriteLine($"{elem.OraPerc} {elem.Rendszam} stb.");
        }

        System.Console.WriteLine("7. feladat");

        System.Console.WriteLine("Kérem a rendszámot: ");
        string rszam = Console.ReadLine();

        if (!autok_start.Contains(new CarHash(rszam, 0)))
        {
            System.Console.WriteLine("Nincs ilyen autó!");
        }
        else
        {
            CarHash temp = autok_start.FirstOrDefault(x => x.Rendszam == rszam);
            System.Console.WriteLine($"Km: {temp.Km}");
        }
    }
}
