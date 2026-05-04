/*
 A delegate C#-ban egy típusbiztos függvénypointer. Ez azt jelenti, hogy eltárolhatunk benne egy
egy metódust, átadhatjuk paraméterként, sőt, meg is hívhajtuk. A delegate–ek legnagyobb haszna, hogy nem kell előre megadott metódusokat használnunk, ehelyett később
tetszés szerint adhatjuk meg az elvégzendő műveletet.

 */
internal class Program
{
    static void HelloWorld()
    {
        Console.WriteLine("Hello, K csoport");
    }

    static void DoSomething(Action action)
    {
        action();
    }
    static void Process(int a, int b, Func<int, int, int> operation) //Nincs saját delegate, helyette használjuk a beépített Func-ot.
                                                                     //Ez egy általános típus, ami három típusparamétert vár: az első kettő a bemeneti paraméterek típusa, a harmadik pedig a visszatérési érték típusa.
    {
        Console.WriteLine(operation(a, b));
    }

    delegate int Operation(int a, int b); //Ez egy delagete. Neve? Operation. Két int-et vár, és egy int-et ad vissza.

    // Metódus, amely delegate-et vár
    static void ProcessNumbers(int a, int b, Operation operation)
    {
        Console.WriteLine("Result: " + operation(a, b));
    }
    //------------------------------------------------------------------------------
    static int Add(int a, int b)
    {
        return a + b;
    }

    static int Multiply(int a, int b)
    {
        return a * b;
    }

    static int Divide(int a, int b)
    {
        return a / b;
    }

    private static void Main(string[] args)
    {
        Action action = HelloWorld;
        action();
        //Így még sosem használtam!:-)

        /*
         Sokkal jobb a második példa, mert itt függvényt adok át paraméterként!

         */
        DoSomething(HelloWorld); //A HelloWorld egy függvény!:-)
        //Nézzünk egy hasznosabbat, látványosabbat!
        Process(5, 3, (x, y) => x + y); // összeadás
        Process(5, 3, (x, y) => x * y); // szorzás
        //Amúgy jó még Callback használatakor és az event-ek mögött is ők vannak!
        //A fentiek helyett hozták be a delegate-eket!
        //-------------------------------------------
        // Delegate példányosítása
        Operation op;

        // Összeadás hozzárendelése
        op = Add;//Ez teljesen valid? Miért? mert az Add pont olyan metódus, ami megfelel az Operation delegate aláírásának: két int-et vár és egy int-et ad vissza.
        //op = Add();//Ez nem jó, mert meghívja!:-))) Pedig függvényreferenciát kellenene átadni, nem a függvény eredményét!:-)
        Console.WriteLine("Add: " + op(5, 3)); //Ez mi? Delegate hívás! Olyan, mintha így írnánk: Add(5, 3)

        // Szorzás hozzárendelése
        op = Multiply;
        Console.WriteLine("Multiply: " + op(5, 3)); //Ez mi? Delegate hívás! Olyan, mintha így írnánk: Multiply(5, 3)

        // Lambda használata (modern megoldás)
        op = (x, y) => x - y;
        Console.WriteLine("Subtract: " + op(5, 3));

        // Delegate átadása paraméterként
        ProcessNumbers(10, 2, Divide);
    }
}