public enum tip { személyauto, kisbusz, busz }
struct auto
{

    public double atlagfogy, tank, aktmenny;
    public tip tipus;
    public string rendszam;
    public bool matrica;

}


class Program
{

    static List<auto> autok = new List<auto>();
    static Random r = new Random();
    static string rendszamg()
    {

        string rend = "";
        char temp = 'A';
        for (int i = 0; i < 3; i++)
        {
            temp = (char)r.Next(65, 92);  //unicode karakterek generálása, csak nagybetűket engedünk meg.
            rend += temp;
        }
        rend += '-';
        for (int i = 0; i < 3; i++)  //számok generálása
        {
            rend += r.Next(10);
        }
        return rend;
    }

    static void feltolt()
    {
        auto temp;
        for (int i = 0; i < 50; i++)
        {
            temp.atlagfogy = r.Next(220) / 10 + 3;
            temp.tank = r.Next(900) / 10 + 20;
            temp.aktmenny = r.Next(Convert.ToInt32(temp.tank * 10)) / 10;
            temp.tipus = (tip)(r.Next(3)); //sorszámozható típus, 0,1,2 értékeket generál, ami pont jó...
            temp.rendszam = rendszamg();
            temp.matrica = Convert.ToBoolean(r.Next(2));
            autok.Add(temp);
        }
    }


    static void Main(string[] args)
    {
        for (int i = 0; i < 50; i++)
        {
            feltolt();
        }
        Console.WriteLine("Hány autó van?");
        Console.WriteLine("{0}", autok.Count);
        Console.WriteLine("Az egyes típusokból mennyi van?");
        Console.WriteLine("Autó: {0}, kisbusz: {1}, busz:{2}", ??????);
        //nem túl gyors, de kevet kell gépelni.
        Console.WriteLine("Melyik járműben van a legtöbb üzemanyag");
        Console.WriteLine("{0}", ??);
        Console.WriteLine("Mely autókkal lehet megtenni a bekért km-t? ");
        int km = int.Parse(Console.ReadLine());
        var eredmeny = autok.Where(????);  //visszaadja, h mikkel lehet
        if (eredmeny.Count() != 0)
        {
            foreach (var item in eredmeny)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.rendszam, item.tipus, item.aktmenny, item.atlagfogy);
            }
        }
        else
            Console.WriteLine("Nincs ilyen jármű");

        Console.WriteLine("Melyik személykocsival lehet megtenni a legtöbb km-et?");
        var megtettkm = autok.Where(????);
        try
        {
            Console.WriteLine("{0}", ?????);
        }
        catch { Console.WriteLine("Nincs ilyen jármű"); }
        var result1 = autok.Where(????);  //ha több van, akkor gond van.
        Console.WriteLine("{0} {1} {2}", result1.rendszam, result1.aktmenny, result1.atlagfogy);
        Console.WriteLine("Kérjünk be egy rendszámot, írjuk ki az adatait!");
        string rendsz = Console.ReadLine();
        var sorszam = autok.FindIndex()????;
        try
        {
            Console.WriteLine("{0} {1} {2}", autok[sorszam].rendszam, autok[sorszam].tank, autok[sorszam].matrica);
        }
        catch { Console.WriteLine("Nincs ilyen jármű"); }
        //Írassuk ki buszokat tankméret szerint csökkenő sorrendben, de először a matricával rendelkezőek jelenjenek meg, utána a nem rendelkezőek

        var adatok = ;
        foreach (var rekord in adatok)
        {
            Console.WriteLine("{0} {1} {2} {3}", rekord.rendszam, rekord.tipus, rekord.tank, rekord.matrica);
        }
        //Írassuk ki típusonként a legnagyobb átlagfogyasztású járművek típusát és átlagfogyasztását!
        var find = from n in autok group n by n.tipus into tipusok select new { tipus = tipusok.Key, atlag = tipusok.Max(item => item.atlagfogy) };
        foreach (var item in find)
        {
            Console.WriteLine("Típus: {0}, átlagfogyasztás: {1}", item.tipus, item.atlag, item);
            var findhozauto = autok.Where(????
            foreach (var auto in findhozauto)
            {
                Console.WriteLine("Rendszáma: {0} ", auto.rendszam);
            }
        }
        //Írassuk ki típusonként melyik járműben van a legtöbb üzemanyag. Típus szerint fordított sorrendben legyenek az adatok
        var find2 = from n in autok orderby n.tipus descending group n by n.tipus into tipusok select new { tipus = tipusok.Key, akt = tipusok.Max(item => item.aktmenny) };
        foreach (var item in find2)
        {
            Console.WriteLine("Típus: {0}, átlagfogyasztás: {1}", item.tipus, item.akt, item);
            var findhozauto = autok.Where(????
            foreach (var auto in findhozauto)
            {
                Console.WriteLine("Rendszáma: {0} ", auto.rendszam);
            }
        }
        //További feladatok: írj még 3 feladatot, amelyet meg is tudsz oldalni, és oldd is meg!!

        DateTime adat = new DateTime();
        adat = Convert.ToDateTime("1970.01.01.00:00:00");
        DateTime adat2 = adat.AddSeconds(1385756740);

        Console.WriteLine(adat2);




        Console.ReadKey();

    }

    static string rendszam()
    {
        string rend = "";
        char temp = 'A';
        for (int i = 0; i < 3; i++)
        {
            temp = (char)r.Next(65, 92);  //unicode karakterek generálása, csak nagybetűket engedünk meg.
            rend += temp;
        }
        rend += '-';
        for (int i = 0; i < 3; i++)  //számok generálása
        {
            rend += r.Next(10);
        }
        return rend;
    }

}

