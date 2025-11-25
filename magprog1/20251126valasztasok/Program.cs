namespace _20251126valasztasok;

class Kepviselo
{
    // valasztokerulet szavazatok_szama vezetek utonev párt
    public int Kerulet;
    public int Szavazatok;
    public string VezetekNev;
    public string UtoNev;
    public string Part;

    public Kepviselo(int ker, int szavazatok, string veznev, string utonev, string part)
    {
        this.Kerulet = ker;
        this.Szavazatok = szavazatok;
        this.VezetekNev = veznev;
        this.UtoNev = utonev;
        this.Part = part;
    }
}
class Partok
{
    public string Part;
    public int Szavazat;
    public Partok(string part, int szavazat)
    {
        this.Part = part;
        this.Szavazat = szavazat;
    }
}
class Program
{
    static bool F2_Kereses(string veznev, string utnev, List<Kepviselo> list, out int szavazatok)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].UtoNev == utnev && list[i].VezetekNev == veznev)
            {
                szavazatok = list[i].Szavazatok;
                return true;
            }
        }
        szavazatok = 0;
        return false;
    }
    static List<Partok> F5_PartokListaja(List<Partok> list)
    {
        List<Partok> PartLista = new List<Partok>();
        for (int i = 0; i < list.Count; i++)
        {
            Partok talaltPart = PartLista.Find(p => p.Part == list[i].Part);

            if (talaltPart != null)
            {
                talaltPart.Szavazat += list[i].Szavazat;
            }
            else
            {
                PartLista.Add(list[i]);
            }
        }
        return PartLista;
    }
    static Kepviselo F6_Max(List<Kepviselo> kepviselok)
    {
        Kepviselo maxKepviselo = kepviselok[0];

        for (int i = 1; i < kepviselok.Count; i++)
        {
            if (kepviselok[i].Szavazatok > maxKepviselo.Szavazatok)
            {
                maxKepviselo = kepviselok[i];
            }
        }
        return maxKepviselo;
    }
    static void Main(string[] args)
    {
        int SzavazasraJogosultakSzama = 12345;

        List<Kepviselo> kepviselok = new List<Kepviselo>();

        StreamReader sr = new StreamReader("szavazatok.txt");

        // 1. feladat
        while (!sr.EndOfStream)
        {
            string[] lineValues = sr.ReadLine().Split(' ');

            kepviselok.Add(new Kepviselo(
                int.Parse(lineValues[0]),
                int.Parse(lineValues[1]),
                lineValues[2],
                lineValues[3],
                lineValues[4] == "-" ? "Független jelöltek" : lineValues[4]
            ));
        }

        // 2. feladat
        Console.WriteLine($"\n2. feladat:\nA helyhatósági választáson {kepviselok.Count} képviselőjelölt indult.");

        //3. feladat
        Console.Write("\n3. feladat:\nAdja meg egy jelölt vezetéknevét: ");
        string Veznev = Console.ReadLine();

        Console.Write("Adja meg egy jelölt utónevét: ");
        string Utnev = Console.ReadLine();

        Kepviselo KeresettKepviselo = kepviselok.Find(k => k.VezetekNev == Veznev && k.UtoNev == Utnev);
        bool Talalt = F2_Kereses(Veznev, Utnev, kepviselok, out int SzavazatokSzama);


        Console.WriteLine("\n3.1. feladat:");
        if (KeresettKepviselo != null)
        {
            Console.WriteLine($"{Veznev} {Utnev} nevű képviselőjelölt {KeresettKepviselo.Szavazatok} szavazatot kapott.");
        }
        else
        {
            Console.WriteLine("Ilyen nevű képviselőjelölt nem szerepel a nyilvántartásban!");
        }

        Console.WriteLine("\n3.2. feladat:");
        Console.WriteLine(Talalt ? $"{Veznev} {Utnev} nevű képviselőjelölt {SzavazatokSzama} szavazatot kapott." : "Ilyen nevű képviselőjelölt nem szerepel a nyilvántartásban!");

        // 4. feladat
        int osszSzavazat = 0;
        foreach (Kepviselo kepviselo in kepviselok)
        {
            osszSzavazat += kepviselo.Szavazatok;
        }

        Console.WriteLine($"\n4. feladat:\nA választáson {osszSzavazat} állampolgár, a jogosultak {Math.Round((double)osszSzavazat / SzavazasraJogosultakSzama * 100, 2)}%-a vett részt.");

        // 5. feladat
        List<Partok> PartokSzavazatai = new List<Partok>();
        Dictionary<string, int> dict = new Dictionary<string, int>();

        foreach (Kepviselo kepviselo in kepviselok)
        {
            if (dict.ContainsKey(kepviselo.Part))
            {
                dict[kepviselo.Part] += kepviselo.Szavazatok;
            }
            else
            {
                dict.Add(kepviselo.Part, kepviselo.Szavazatok);
            }

            PartokSzavazatai.Add(new Partok(kepviselo.Part, kepviselo.Szavazatok));
        }

        Console.WriteLine("\n5. feladat: a. megoldas:");

        foreach (KeyValuePair<string, int> part in dict)
        {
            Console.WriteLine($"{part.Key}= {Math.Round((double)part.Value / osszSzavazat * 100, 2)}%");
        }

        Console.WriteLine("\n5. feladat: b. megoldas:");
        List<Partok> PartokListaja = F5_PartokListaja(PartokSzavazatai);
        foreach (Partok part in PartokListaja)
        {
            Console.WriteLine($"{part.Part}= {Math.Round((double)part.Szavazat / osszSzavazat * 100, 2)}%");
        }

        // 6. feladat
        Console.WriteLine("\n6.1. feladat:");

        Kepviselo maxKepviselo = F6_Max(kepviselok);
        int maxSzavazat = maxKepviselo.Szavazatok;

        for (int i = 0; i < kepviselok.Count; i++)
        {
            if (kepviselok[i].Szavazatok == maxSzavazat)
            {
                Console.WriteLine($"{kepviselok[i].VezetekNev} {kepviselok[i].UtoNev}, {kepviselok[i].Part.Split(' ')[0].ToLower()}");
            }
        }

        Console.WriteLine("\n6.2. feladat:");
        List<Kepviselo> NyertesekSzerintRendezve = kepviselok.OrderByDescending(k => k.Szavazatok).ToList();
        for (int i = 0; i < NyertesekSzerintRendezve.Count && NyertesekSzerintRendezve[0].Szavazatok == NyertesekSzerintRendezve[i].Szavazatok; i++)
        {
            Console.WriteLine($"{NyertesekSzerintRendezve[i].VezetekNev} {NyertesekSzerintRendezve[i].UtoNev}, {NyertesekSzerintRendezve[i].Part.Split(' ')[0].ToLower()}");
        }

        // 7. feladat
        Console.WriteLine("\n7.a. feladat: Fájlba írás kepviselok_a.txt");
        List<int> keruletek = kepviselok.Select(k => k.Kerulet).Distinct().OrderBy(k => k).ToList();

        StreamWriter sw = new StreamWriter("kepviselok_a.txt");

        foreach (int kerulet in keruletek)
        {
            Kepviselo keruletiJelolt = kepviselok.Where(k => k.Kerulet == kerulet).OrderByDescending(k => k.Szavazatok).First();

            sw.WriteLine($"{kerulet} {keruletiJelolt.VezetekNev} {keruletiJelolt.UtoNev} {keruletiJelolt.Part.Split(' ')[0].ToLower()}");
        }
        sw.Close();

        Console.WriteLine("\n7.b. feladat: Fájlba írás kepviselok_b.txt");

        Dictionary<int, Tuple<int, string, string>> dict3 = new Dictionary<int, Tuple<int, string, string>>();

        foreach (Kepviselo kepviselo in kepviselok)
        {
            Tuple<int, string, string> aktualisKepviselo = new Tuple<int, string, string>(kepviselo.Szavazatok, $"{kepviselo.VezetekNev} {kepviselo.UtoNev}", kepviselo.Part);
            
            if (!dict3.ContainsKey(kepviselo.Kerulet))
            {
                dict3.Add(kepviselo.Kerulet, aktualisKepviselo);
            }
            else
            {
                if (kepviselo.Szavazatok > dict3[kepviselo.Kerulet].Item1)
                {
                    dict3[kepviselo.Kerulet] = aktualisKepviselo;
                }
            }
        }

        StreamWriter sw2 = new StreamWriter("kepviselok_b.txt");

        foreach (KeyValuePair<int, Tuple<int, string, string>> kepviselo in dict3.OrderBy(kvp => kvp.Key))
        {
            sw2.WriteLine($"{kepviselo.Key} {kepviselo.Value.Item2} {kepviselo.Value.Item3.Split(' ')[0].ToLower()}");
        }
        sw2.Close();
    }
}
