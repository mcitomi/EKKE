
/*
 Az IEnumerable egy interfész, amely azt jelenti kb., hogy "ez az objektum bejárható (iterálható)”
Ha egy osztály implementálja:
IEnumerable<T>
akkor:
- használható foreach-ben
- LINQ működik rajta
- elemenként feldolgozható. Csupa jó.:-)

Ugyanakkor az Enumerator az az objektum, amely:
végiglépked az elemeken, mindig "tudja”, hol tartunk

Fő metódusai:MoveNext(), amely	lép a következő elemre, Current az aktuális elemet jelenti, Reset()	visszaáll elejére
A kapcsolat:  IEnumerable -> GetEnumerator() -> IEnumerator.
Példa:
List<int> numbers = new List<int> { 1, 2, 3 };
foreach (int n in numbers)
{
    Console.WriteLine(n);
}
De itt hol van az Enumerator? Sajnos nem látszik, be van építve.:-) Amikor a fentit írjuk, akkor ez keletkezik:

var enumerator = numbers.GetEnumerator();

while (enumerator.MoveNext())
{
    Console.WriteLine(enumerator.Current);
}

Ilyenkor mindig az a kérdés merül fel. De minek ez nekünk? Mire jó? Íme:
!!!saját bejárási logika!!!!
!!nem kell mindent listába rakni!!
!„lustán” generálható adatok (lazy evaluation)!
nagy adathalmazoknál hatékony (Majd munkában milyen jó lesz!:-)

De van még egy kulcsszó. Yield.
Ez a legegyszerűbb mód saját IEnumerable írására:
public static IEnumerable<int> GetNumbers()
{
    yield return 1;
    yield return 2;
    yield return 3;
}
Ilyenkor nem kell kell külön Enumerator osztály!

Nézzük a kódot!

 */


using Enumerator_Example1;

class Numbers
{
    public IEnumerable<int> GetEvenNumbers(int max) //Ehelyett simán írok egy függvényt, amely visszaadja a páros számokat max-ig!:-))
    {
        for (int i = 0; i <= max; i++)
        {
            if (i % 2 == 0)
                yield return i;
        }
    }//Ez nem egy listát ad vissza, hanem ezt: IEnumerable<int>. Azaz int értékeket! 
    //Hasonlat: Kérsz sört? Igen. Lista: itt van, egy rekesz, igyad. IEnumberable-> itt van 1 üveg. Kérsz még? Aha. Itt egy másik.
    
}
internal class Program
{
    private static void Main(string[] args)
    {
        var n = new Numbers();

        foreach (var x in n.GetEvenNumbers(10)) //Függvényt hívok? Igen. Listát ad vissza? Nem. Egy sorozatot. 
        {
            Console.WriteLine(x);
        }
        //Másik példa--------------------------------------------------------------------

        Library lib = new Library();

        lib.Add(new Book { Title = "A", Author = "X", Pages = 150 });
        lib.Add(new Book { Title = "B", Author = "Y", Pages = 300 });
        lib.Add(new Book { Title = "C", Author = "Z", Pages = 500 });

        foreach (Book book in lib)
        {
            Console.WriteLine(book.Title); //meghívja a GetEnumerator()-t, csak a "szűrt" elemek jönnek vissza
        }
        /*Nem kell külön Where, a logika "be van építve” a bejárásba, így bármilyen saját szabály megadható*/
    }
}
/*
 public IEnumerable<string> ReadLines(string path)
{
    using var sr = new StreamReader(path);

    while (!sr.EndOfStream)
    {
        yield return sr.ReadLine();
    }
}

Ez a megoldás azért cool, mert nem olvassa be az egész fájlt, soronként dolgozik.
Amikor listát használunk, akkor mindent beolvas, amiből (élesben) lehet memória gond
Tehát az IEnumerable lehetővé teszi a lusta kiértékelést és a hatékony LINQ láncolást, ezért nagyobb rendszerekben előnyösebb.
 */

/*Aki eddig nem értett volna. Feladat:
 * Van egy nagy fájlunk (pl. log file):

- 5–10 GB
- több millió sor

Feladat:

Találjuk meg az első sort, ami tartalmazza az "ERROR" szót
 * 
 * 
 * Eddig, ahogyan a középiskolában egyesek tanulták:
 * public List<string> ReadAllLines(string path)
{
    return File.ReadAllLines(path).ToList();
}
List<string> lines = ReadAllLines("log.txt"); 

var errorLine = lines.First(line => line.Contains("ERROR"));

Mi lesz ennek az eredménye?
Az összes sort beolvassa memóriába, 5–10 GB RAM kell, lassú, akár OutOfMemoryException is lehet az eredménye, azaz
még a finally sem fut majd le!:-))
 * 
 * 
 * A MEGOLDÁS:
 * public IEnumerable<string> ReadLines(string path)
{
    using var sr = new StreamReader(path);

    while (!sr.EndOfStream)
    {
        yield return sr.ReadLine();
    }
}

var errorLine =
    ReadLines("log.txt")
    .First(line => line.Contains("ERROR")); //Lehet LINQ nélkül is, de mindjárt elővesszük ezt is!:-)

Console.WriteLine(errorLine);
------------------------------Amúgy LINQ nélkül:--------------------
string errorLine = null;

foreach (var line in ReadLines("log.txt"))
{
    if (line.Contains("ERROR"))
    {
        errorLine = line;
        break; // Hogy én mennyire utálom a break-et....De a foreach miatt....
    }
}

Azaz: beolvas 1 sort, megnézi: ERROR?, ha nem, akkor a következő, ha igen, akkor STOP
Ha meg nem az első kelle, hanem az első három:
var result =
    ReadLines("log.txt")
    .Where(line => line.Contains("ERROR"))
    .Take(3);
 */