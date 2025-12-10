namespace _20251203auto;

class CarHash : IComparable<CarHash>
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

    public int CompareTo(CarHash car)
    {
        return this.Rendszam.CompareTo(car.Rendszam);
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

    static List<string> Rendszamok(List<Car> lista)
    {
        List<string> kigyujtott = new List<string>();
        for (int i = 0; i < lista.Count; i++)
        {
            if (!kigyujtott.Contains(lista[i].Rendszam))
            {
                kigyujtott.Add(lista[i].Rendszam);
            }
        }
        return kigyujtott;
    }

    static List<string> F6_Szemelykereso(List<Car> lista)
    {
        List<string> szemelyek = new List<string>();
        foreach (Car item in lista)
        {
            if (!szemelyek.Contains(item.SzemelyiId))
            {
                szemelyek.Add(item.SzemelyiId);
            }
        }
        return szemelyek;
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

        int dbnemvoltbenn = 0;
        foreach (CarHash cars in autok_start)
        {
            bool kint = false;
            foreach (Car item in autok)
            {
                if (cars.Rendszam == item.Rendszam)
                {
                    kint = item.Kibe == 0;
                }
            }
            if (kint)
            {
                dbnemvoltbenn++;
            }
        }
        Console.WriteLine($"A hónap végén {dbnemvoltbenn} autót nem hoztak vissza");

        List<CarHash> temp = new List<CarHash>();

        StreamWriter sw = new StreamWriter("stat.txt");

        List<string> rendszamok = Rendszamok(autok);

        foreach (string rendszam in rendszamok)
        {
            int start = 0; int vege = 0;
            foreach (Car item in autok)
            {
                if (item.Rendszam == rendszam && start == 0)
                {
                    start = item.Km;
                }
                else
                {
                    if (item.Rendszam == rendszam)
                    {
                        vege = item.Km;
                    }
                }
            }
            temp.Add(new CarHash(rendszam, vege - start));
            // System.Console.WriteLine($"{rendszam} {vege - start}"); -- inkabb listaba rendezes
        }

        temp.Sort();
        // temp.Sort((x, y) => x.Rendszam.CompareTo(y.Rendszam));
        var temp3 = autok.OrderBy(x => x.Rendszam);

        foreach (CarHash item in temp)
        {
            sw.WriteLine($"{item.Rendszam}: {item.Km} km");
        }
        sw.Close();

        // ........................
        System.Console.WriteLine("3. feladtat");

        System.Console.WriteLine("Nap?: ");
        int nap = int.Parse(Console.ReadLine());

        List<Car> kivittek = F3_adottNapon(autok, nap);
        foreach (Car elem in kivittek)
        {
            System.Console.WriteLine($"{elem.OraPerc} {elem.Rendszam} stb.");
        }

        List<string> szemelyek = F6_Szemelykereso(autok);
        int max = -1; int maxMax = -1; string kio = "";
        foreach (string item in szemelyek)
        {
            int start = 0; int vege = 0;
            foreach (Car auto in autok)
            {
                if (auto.SzemelyiId == item && start == 0)
                {
                    start = auto.Km;
                }
                else
                {
                    if (auto.SzemelyiId == item && vege == 0)
                    {
                        vege = auto.Km;
                        if (max < vege - start)
                        {
                            max = vege - start;
                        }
                    }
                }
            }
            if(max > maxMax)
            {
                maxMax = max;
                kio = item;
            }
        }

        System.Console.WriteLine($"6. feladat: \r\t Leghosszabb út : {maxMax} km, szemely: {kio}\r\n");

        System.Console.WriteLine("7. feladat");

        System.Console.WriteLine("Kérem a rendszámot: ");
        string rszam = Console.ReadLine();

        if (!autok_start.Contains(new CarHash(rszam, 0)))
        {
            System.Console.WriteLine("Nincs ilyen autó!");
        }
        else
        {
            CarHash temp2 = autok_start.FirstOrDefault(x => x.Rendszam == rszam);
            System.Console.WriteLine($"Km: {temp2.Km}");
        }
    }
}
