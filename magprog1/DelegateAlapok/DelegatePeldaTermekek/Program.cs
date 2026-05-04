using DelegatePeldaTermekek;

internal class Program
{
    static List<Product> GetExpensiveProducts(List<Product> products)
    {
        List<Product> result = new List<Product>();
        foreach (var p in products) //Var esetében fordítási időben eldől a típusa a p-nek
            if (p.Price > 1000)
                result.Add(p);
        return result;
    }

    static List<Product> GetInStockProducts(List<Product> products)
    {
        List<Product> result = new List<Product>();
        foreach (Product p in products)
            if (p.InStock)
                result.Add(p);
        return result;
    }
    /*
     Problem:
    minden új feltételhez új metódus, kód duplikáció, nehezen bővíthető
     */

    delegate bool ProductFilter(Product p);
    //A viselkedés lesz a paraméter , a metódusok helyett, így egyetlen metódusunk lesz, ami bármilyen feltételt tud kezelni
    static List<Product> Filter(List<Product> products, ProductFilter filter)
    {
        List<Product> result = new List<Product>();

        foreach (Product p in products)
        {
            if (filter(p))
                result.Add(p);
        }

        return result;
    }


    private static void Main(string[] args)
    {
        List<Product> products = new List<Product>
        {
            new Product { Name = "Laptop", Price = 3000, InStock = true },
            new Product { Name = "Mouse", Price = 500, InStock = true },
            new Product { Name = "Keyboard", Price = 1500, InStock = false }
        };

        //1. feladat: Drága termékek listája
        List<Product> expensive = Filter(products, p => p.Price > 1000);
        //2. feladat: Raktáron lévő termékek listája    
        List<Product> inStock = Filter(products, p => p.InStock);
        //3. feladat: Drága és raktáron lévő termékek listája
        List<Product> cheapAndAvailable = Filter(products, p => p.Price < 2000 && p.InStock);

        /*
         Func<Product, bool>
        static List<Product> Filter(List<Product> products, Func<Product, bool> filter)
        Ugyanaz, csak a beépített delegát típust használjuk, nem kell saját típusdefiníciót létrehozni
         */

        List<Product> expensive2 = products.Where(p => p.Price > 1000).ToList();
        List<Product> inStock2 = products.Where(p => p.InStock).ToList();
        List<Product> cheapAndAvailable2 = products.Where(p => p.Price < 2000 && p.InStock).ToList();
        List<Product> result = products.Where(p => p.Price > 500).Where(p => p.InStock).OrderBy(p => p.Price).ToList();
        /*
         Érdekesség:
        var products = new List<Product>(); //Itt teljesen egyértelmű a típus, nincs információvesztés
        var result = products.Where(p => p.Price > 1000); //Itt már nem egyértelmű a típus, mert a Where visszatérési értéke egy IEnumerable<Product>, ami egy gyenge típusú kollekció, nem List<Product>
        A típus valójában: IEnumerable<Product>. De gyakran még bonyolultabb:IEnumerable<AnonymousType>
        Ezt nem is tudnánk kiírni normálisan, ezért itt a var gyakorlatilag kötelező. :-))
        var data = products.Select(p => new { p.Name, p.Price }); //nincs is konkrét típus, csak var lehet
        Elrettentő példák: 
        var result = GetData(); //Oké… de ez most mi? List? IEnumerable? int?
        var result = products.Where(...); //Ez most lista? Nem! De miből látszik?
        IEnumerable<Product> result = products.Where(...); //Ja, így már egyértelmű. 
        Használjuk a var-t, ha:
        - jobb oldalból egyértelmű a típus
        - LINQ + anonim típus
        - csökkenti a zajt
         */
    }
}