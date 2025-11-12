namespace _20251112nevekszama;
// interface: I betű (IComapare...), olyan mint a szomszéd macskéja, csak kibelezve
// van szeme, de lóg, és nincs semmi benne
class Names
{
    public string Name { get; set; }
    public int Darab;
    public Names(string name, int db)
    {
        this.Name = name;
        this.Darab = db;
    }

    public override string ToString()
    {
        return $"Név: {Name}, Hányszor: {Darab}";
    }

    public int CompareTo(Names names)
    {
        // return this.Darab.CompareTo(names.Darab);

        if (this.Darab == names.Darab)
        {
            return this.Name.CompareTo(names.Name) * -1;
        }
        else
        {
            return this.Darab.CompareTo(names.Darab) * -1;
        }
    }
}
class Program
{
    static int IndexOf(List<Names> lista, string name)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i].Name == name)
            {
                return i;
            }
        }
        return -1;
    }
    static void Main(string[] args)
    {
        // nevek.txt minden sor egy név, kiíratni melyik névbőlhány van

        // Names name = new Names("Malack", 0);

        List<Names> names = new List<Names>();

        StreamReader sr = new StreamReader("nevek.txt");

        Dictionary<string, int> dict = new Dictionary<string, int>(); // ez jo mert nem kell a sokparáde
        Dictionary<string, Tuple<int, string, int>> dict2 = new Dictionary<string, Tuple<int, string, int>>();

        while (!sr.EndOfStream)
        {
            string name = sr.ReadLine();
            int where = IndexOf(names, name);
            if (where == -1)
            {
                names.Add(new Names(name, 1));
            }
            else
            {
                names[where].Darab++;
            }
        }
        sr.Close();

        foreach (Names items in names)
        {
            Console.WriteLine(items);
        }

        System.Console.WriteLine();

        var temp = names.OrderByDescending(x => x.Darab).ThenBy(x => x.Name).ToList();  // ThenBy: HA már rendezted rendezd még ez alapjanis
        foreach (Names items in temp)
        {
            Console.WriteLine(items);
        }

        System.Console.WriteLine();

        // names.Sort((x,y) => x.Darab.CompareTo(y.Darab));
        names.Sort();
        foreach (Names items in names)
        {
            Console.WriteLine(items);
        }
    }
}
