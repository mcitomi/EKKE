
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;



internal class Program
{
    private static void Main(string[] args)
    {
        /*[A - Za - z.\\- ] * – a megengedett karakterek: angol kis-és nagybetűk, pont(.), kötőjel(-), szóköz()
        A - karaktert escape - elni kell, különben a regex karaktertartománynak értelmezi(pl.a - z), ezért \\-kell.
        $ – a szöveg vége, ^ - a szöveg eleje.
        * – bármennyi megengedett karakter(akár nulla is)*/
        string kod = "AAA-.";
        Regex regex = new Regex("^[A-Za-z/. ]* $"); //A * utáni szóköz azt jelenti, hogy a minta csak akkor egyezik, ha a szöveg egy szóközzel végződik, ami valószínűleg nem célunk
        //A - nincs benne a karakterkészletben. A / karakter nem szükséges, ha csak . és - kellenek a betűk mellett.
        Regex regex2 = new Regex("^[A-Za-z.\\- ]*$"); //betűk, angol, pont, kötőjel és szóköz. De a kötőjelnek más jelentés van, ezért \\
        if (!regex2.IsMatch(kod))
        {
            throw new Exception("Baj van");
        }

        if (!Regex.IsMatch(kod, @"^[a-zA-Z.-]*$")) //Ugyanez, de nincs benne szóköz! A @ miatt nem kell \\-, csak -
        {
            throw new Exception("csak betűk és . valamint - lehet.");
        }


        string pattern = @"^[A-Z]{3}-\d{3}$";  // @".....". Kötelező. Az első(!) három karakter: ^[A-Z]{3}. Után "-" kell!. Majd három szám \d{3}. 
        //A ^ és $ miatt a teljes szöveg pontosan illeszkedi a mintára
        //^ => a string eleje. $ string vége.
        regex = new Regex(pattern);

        string pattern2 = @"^[A-Z]{2}-[A-Z]{2}-\d{3}$";  //2 betű, "-", majd két betű, majd "-", majd 3 szám!
        string[] testPlates = { "ABC-123", "XYZ-789", "A1C-456", "ABCD-123", "XYZ-12A" }; //$ a vége

        foreach (var plate in testPlates)
        {
            if (regex.IsMatch(plate))  //Itt a hasonlítás
            {
                Console.WriteLine($"{plate} érvényes");
            }
            else
            {
                Console.WriteLine($"{plate} nem érvényes.");
            }
        }
        string pattern3 = @"^\+36-(20|30|70)-\d{7}$";
        regex2 = new Regex(pattern3);
        if (regex2.IsMatch("+36-20-3642668"))
            Console.WriteLine("Hurrá");
        //Kérdés: Új rendszám???
        //+36-20-3642669  ^\+36(20|30|70)\d{7}$
        //^\d{ 3}-\d{ 3}$
        //^(Cat | CAT | C[aeiouAEIOU]T)$ Vagy Cat vagy CAT vagy C?T
        //^[\p{L}]+$"; // \p{L} jelentése: bármilyen Unicode betű. + jelentése: legalább egy. Szóköz nem lehet.
        //^[\p{L} ]+$  =>bármilyen Unicode betű, de szóköz is!
        //^[\p{L}]+( [\p{L}]+)+$ - Név formátum, pl Zorró Lajos
        //^[A-Za-zÁÉÍÓÖŐÚÜŰáéíóöőúüű]+$ - Fapados
        //^cat$|^c[aeiou]t$ ^(cat|c[aeiou]t)$ - Nem számít a nagybetű kisbetű
        //@"^[A-Z]{2}-[A-Z]{2}-[0-9]{3}$"


    }
}