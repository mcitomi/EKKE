enum Fegyver { Kard, Landzsa, Ij }
enum Szarmazas { Romai, Gall, Trak }

class Warrior
{
    public string Name;
    public int Age;
    public Fegyver Weapon;
    public Szarmazas Origin;
}




internal class Program
{
    /*
     A LINQ (Language Integrated Query) a C# nyelvbe épített lekérdező mechanizmus, amely lehetővé teszi adathalmazok (pl. lista, tömb, adatbázis) deklaratív feldolgozását.
    Mire jó? 
   Listák szűrése (Where)
    keresés (First, FirstOrDefault), a többi mint Adatbázisrendszerek I. órán
    aggregáció (Count, Sum, Average, Max, Min)
    rendezés (OrderBy, ThenBy)
    csoportosítás (GroupBy)
    projekció (Select)
     Kétfél szintaxisa van:
    1. Metódus alapú: list.Where(x => x.Age > 10).OrderBy(x => x.Name)
    2. Lekérdező (SQL-szerű)
    from x in list
    where x.Age > 10
    orderby x.Name
    select x
    Mondjuk AB1 gyakorlatok után nehéz lesz ilyeneket írni...
     */

    static List<Warrior> warriors = new List<Warrior>();
    static void Generate()
    {
        Random rnd = new Random();

        for (int i = 0; i < 100; i++)
        {
            Warrior w = new Warrior();
            w.Name = ((char)rnd.Next(65, 91)).ToString() +
                     ((char)rnd.Next(65, 91)).ToString() +
                     ((char)rnd.Next(65, 91)).ToString();

            w.Age = rnd.Next(18, 50);
            w.Weapon = (Fegyver)rnd.Next(3);
            w.Origin = (Szarmazas)rnd.Next(3);
            Console.WriteLine(warriors.Any(x => x.Age > 40));
            warriors.Add(w);
        }
    }
    private static void Main(string[] args)
    {
        Generate();
        // 1. Hány harcos van?
        Console.WriteLine(warriors.Count());

        // 2. Átlag életkor
        Console.WriteLine(warriors.Average(x => x.Age));

        // 3. Legidősebb harcos
        Console.WriteLine(warriors.Max(x => x.Age));

        // 4. Hány római harcos van? 
        Console.WriteLine(warriors.Where(x => x.Origin == Szarmazas.Romai).Count());

        // 5. Hány kardos harcos van?
        Console.WriteLine(warriors.Count(x => x.Weapon == Fegyver.Kard));

        // 6. Van-e 40 év feletti harcos? De mi van, ha nincs 40 év feletti? Amúgy nem dob kivételt, csak false-t, de tegyük fel, hogy ezt nem tudjuk
        try
        {
            Console.WriteLine(warriors.Any(x => x.Age > 40));
        }
        catch (Exception e) { Warrior w2 = new Warrior();  w2.Age = 41; warriors.Add(w2);}

        // 7. Első gall harcos neve
        var gall = warriors.FirstOrDefault(x => x.Origin == Szarmazas.Gall);
        if (gall != null)
            Console.WriteLine(gall.Name);

        // 8. Legidősebb római harcos
        var maxRomai = warriors
            .Where(x => x.Origin == Szarmazas.Romai)
            .OrderByDescending(x => x.Age)
            .FirstOrDefault();

        if (maxRomai != null)
            Console.WriteLine(maxRomai.Name);

        // 9. Rendezés név szerint
        var sorted = warriors.OrderBy(x => x.Name);
        foreach (var w in sorted)
            Console.WriteLine(w.Name + " " + w.Age);

        // 10. Rendezés: kor csökkenő, név növekvő
        var sorted2 = warriors
            .OrderByDescending(x => x.Age)
            .ThenBy(x => x.Name);

        // 11. Legfiatalabb gall kardos harcos
        var youngest = warriors
            .Where(x => x.Origin == Szarmazas.Gall && x.Weapon == Fegyver.Kard)
            .OrderBy(x => x.Age)
            .FirstOrDefault();

        if (youngest != null)
            Console.WriteLine(youngest.Name);

        // 12. Csoportosítás származás szerint
        var groups = warriors.GroupBy(x => x.Origin);

        foreach (var g in groups)
        {
            Console.WriteLine(g.Key + ": " + g.Count());
        }

        // 13. Származásonként legidősebb
        var maxByOrigin = warriors
            .GroupBy(x => x.Origin)
            .Select(g => new
            {
                Origin = g.Key,
                MaxAge = g.Max(x => x.Age)
            });

        foreach (var item in maxByOrigin)
        {
            Console.WriteLine(item.Origin + " - " + item.MaxAge);
        }

        Console.ReadKey();

    }
}