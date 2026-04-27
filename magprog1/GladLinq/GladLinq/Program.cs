using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Glad
{
    enum szarmazas { Római, Trák, Gall, Hispan, Pun }  //ezt csak azért, hogy láss ilyet is. Ha string-re veszem fel, akkor bármit bele lehet tenni, így meg csak ezeket. Ráadásul könnyebb értékeket generálni
    enum szinkod { Sárga, Piros, Fekete } //tehát azt enum felsorolásos típus. Ha egy változónak a típus enum, akkor mást nem vehet fel! Ha mást írnak be, akkor kivételt dob.
    enum fegyvernem { Kard, Lándzsa, Buzogány, Acélháló }  // az osztályokon kívülre érdemes tenni, így mindenhonnan könnyen elérhető
    class gladiator
    {
        public string nev;
        public int ev; //hány éve gladiátor - kora
        public fegyvernem fegyver;
        public szarmazas szarm;
        public szinkod szin;  //0-2 év Sarga, ha már legalább 3 éve gladiátor, akkor a szinkodja   Piros lesz, ha pedig már legalább 6 éve akkor Fekete.)
        public bool szabad;
    }

    class Program
    {
        static List<gladiator> glad = new List<gladiator>();
        static void feltoltes()
        {
            Random rnd = new Random();
            szinkod[] szinek = new szinkod[10] { szinkod.Sárga, szinkod.Sárga, szinkod.Piros, szinkod.Piros, szinkod.Piros, szinkod.Fekete, szinkod.Fekete, szinkod.Fekete, szinkod.Fekete, szinkod.Fekete };
            int ev = 0;
            gladiator temp= new gladiator();
            for (int i = 0; i <100; i++)  //100 harcost hozunk létre
            {
                ev = rnd.Next(10);
                temp.ev = ev;
                temp.szin = szinek[ev];
                temp.szarm = (szarmazas)(rnd.Next(5));
                temp.fegyver = (fegyvernem)(rnd.Next(4));
                temp.szabad = false;
                temp.nev = ((char)rnd.Next(65, 91)).ToString() + ((char)rnd.Next(65, 91)).ToString() + ((char)rnd.Next(65, 91)).ToString();
                glad.Add(temp);
                Console.WriteLine(temp.nev+temp.szin+temp.fegyver);
                temp = new gladiator();

            }
        }

        static int Sargak(List<gladiator> glad)
        {
            int db = 0;
            foreach (gladiator elem in glad)
                if (elem.szin == szinkod.Sárga)
                    db++;
            return db;

        }
        static int MaxPiros(List<gladiator> glad)
        {
            int max = -1;
            foreach (gladiator elem in glad)
            {
                if (elem.szin == szinkod.Piros && elem.ev > max)
                    max = elem.ev;
            }
            return max;
        }

        static void Main(string[] args)
        {

            feltoltes(); //tehát most van egy listánk, elemei gladiator típusúak. Nézzünk egyszerű (ejtsd érettségi) feladatokat!
            //Hány gladiátor van?
            Console.WriteLine("{0} gladiátor van", glad.Count());
            Console.WriteLine("{0} a gladiátorok átlagos életkora ", glad.Average(item => item.ev));  //mert ugye meg kell mondanom, h minek az átlagát számoljam ki. Olyan elemeknek az átlagát, amelyeknek az év mezője számít.:-)
            Console.WriteLine("{0} a legidősebb gladiátor kora ", glad.Max(item => item.ev));  //mert ugye meg kell mondanom, h minek a maximumát vegye!
            //keressünk meg egy adott nevűt, és mondjuk meg a származását!!!
            Console.WriteLine("Kérek egy nevet");
            string name = Console.ReadLine();
            int index = glad.FindIndex(item => item.nev.Equals(name)); //keressük meg az indexét a listában!
            //var gladiator = glad.FirstOrDefault(x => x.nev == name); Ez jobb, de láss ilyet is!
            if (index == -1)  //ha -1, akkor nem talált, egyébként visszaadja a talált elem sorszámát!
                Console.WriteLine("Ilyen nevű gladiátor nincs!"); //
            else
                Console.WriteLine("A gladiátor származása {0}", glad[index].szarm);  //de mi van, ha nincs ilyen? Akkor hibát dob, az index -1 lesz. Ezt kivételkezeléssel is megoldhatjuk
            //Nézzük ezt kivételkezeléssel!!!
            try
            {
                Console.WriteLine("A gladiátor származása {0} ", glad[index].szarm);  //de mi van, ha nincs ilyen? Akkor hibát dob, az index -1 lesz. 
                //Ha itt hiba van, akkor kiakad, azaz, ha az index érvénytelen
                int k = index / 0;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Nem jön, mert tud nllával osztani.....");
            }
            catch (Exception e) //IndexOutOfRangeException jobb
            {
                Console.WriteLine("Ilyen nevű gladiátor nincs!"); //De nem akad ki, mert hiba esetén a catch részre megy, ott pedig ezt íratom ki. És a program fut tovább. Ha nincs try catch, akkor kiakadna
                Console.WriteLine(e);
            }
            //Ennyi sokkkkk után nézzünk "egyszerűbbeket"!
            Console.WriteLine("{0} sárga gladiátor van", glad.Where(item => item.szin == szinkod.Sárga).Count());  //Hány sárga harcos van? Itt nem elég a count, szólni kell neki, h csak bizonyosokat számoljon meg
            Console.WriteLine("{0} sárga gladiátor van", Sargak(glad));
            try
            {
                Console.WriteLine("{0} a legidősebb piros gladiátor kora", glad.Where(item => item.szin == szinkod.Piros).Max(item2 => item2.ev));  //Hány éves a legidősebb piros harcos?
            }catch (Exception e) {Console.WriteLine("Nincs piros gladiator?"+e.Message); }
                Console.WriteLine("{0} a legidősebb piros gladiátor kora", MaxPiros(glad));
            //Hány pun harcos van?
            Console.WriteLine("{0} a Pun harcosok száma:", glad.Where(item => item.szarm == szarmazas.Pun).Count());
            //Hány buzogányos harcos van?
            Console.WriteLine("{0} a buzogányos harcosok száma ", glad.Where(item => item.fegyver == fegyvernem.Buzogány).Count());
            //A legidősebb Pun harcos kora
            try
            {
                Console.WriteLine("{0} a legidősebb Pun buzogányos kora ", glad.Where(item => item.szarm == szarmazas.Pun && item.fegyver == fegyvernem.Buzogány).Max(item2 => item2.ev));
            }
            catch (Exception e) { Console.WriteLine("Pun buzogányos nincs" + e.Message); }
            //A legidősebb sárga harcos neve
            int kor = 0;
            if (glad.Where(item => item.szin == szinkod.Sárga).Any())
            {
                kor = glad.Where(item => item.szin == szinkod.Sárga).Max(item2 => item2.ev); //itt megkapja a legidősebb korát
                var temp = glad.Where(item => item.ev == kor);//visszadja azt a gladiátort, akinek a kora a kor-ral egyezik meg. Ha több ilyen is van, akkor többet ad vissza, ezért ki tudja, h mit ad vissza. Ha senki, akkor írjuk elé a var-t
                Console.WriteLine("{0} a legidősebb sárga gladiátor neve", temp.FirstOrDefault  ().nev); //az első neve kell...Van first is, de az veszélyes!
                                                                                              //Persze lehetne egybe is:
                Console.WriteLine("{0} a legidősebb sárga gladiátor neve", glad.Where(item => item.ev == kor).FirstOrDefault().nev); //ha a kor meg van.
                                                                                                                            //sőt, nagyon egybe is lehet, ha még nincs meg a kor...
                Console.WriteLine("{0} a legidősebb sárga gladiátor neve", glad.Where(item => item.ev == glad.Where(item2 => item2.szin == szinkod.Sárga).Max(item3 => item3.ev)).First().nev);
            }//var - ha nem tudjuk biztosan a változó típusát!!
            else
                Console.WriteLine("Nincs sárga gladiator!");
            //A legidősebb Pun harcos neve
            try
            {
                Console.WriteLine("{0} a legidősebb Pun gladiátor neve", glad.Where(item => item.ev == glad.Where(item2 => item2.szarm == szarmazas.Pun).Max(item3 => item3.ev)).First().nev);
            }
            catch (Exception e) { Console.WriteLine("Nincs pun"); }
                //A legfiatalabb piros pun buzogányos harcos neve!!!! Van egyáltalán ilyen??? Mit tegyünk, ha nincs?? Megint kivételkezelés
            try
            {
                Console.WriteLine("{0} a legfiatalabb piros Pun buzogányos gladiátor neve", glad.Where(item => item.ev == glad.Where(item2 => item2.szarm == szarmazas.Pun && item2.fegyver == fegyvernem.Buzogány && item2.szin == szinkod.Piros).Min(item3 => item3.ev)).First().nev);
            }
            catch { Console.WriteLine("Nincs piros, pun, buzogányos harcos"); }
            //Mi a származása és a neve a legfiatalabb Pun származású, buzogányos harcosnak? Vegyük észre, h két feltétel is van!:-(( 
            try
            {
                Console.WriteLine("{0} a legfiatalabb Pun buzogányos gladiátor neve", glad.Where(item => item.ev == glad.Where(item2 => item2.szarm == szarmazas.Pun && item2.fegyver == fegyvernem.Buzogány).Min(item3 => item3.ev)).First().nev);
                //és származása
                Console.WriteLine("{0} a legfiatalabb Pun buzogányos gladiátor származása", glad.Where(item => item.ev == glad.Where(item2 => item2.szarm == szarmazas.Pun && item2.fegyver == fegyvernem.Buzogány).Min(item3 => item3.ev)).First().szarm);
            }
            catch (Exception e) { Console.WriteLine("Nincs pun, buzogánnyal!"); }
                //írassuk ki a gladiátorok nevét és korát ABC sorrendbe!
            var eredmeny = glad.OrderBy(item => item.nev);
            foreach (gladiator items in eredmeny)
            {
                Console.WriteLine("Nev: {0} Kor: {1}", items.nev, items.ev);
            }

            //Most kor szerint csökkenőbe:
            Console.WriteLine("Kor szerint csökkenőbe");
            var eredmeny2 = glad.OrderByDescending(item => item.ev);
            foreach (gladiator items in eredmeny2)
            {
                Console.WriteLine("Nev: {0} Kor: {1}", items.nev, items.ev);
            }
            //Most kor szerint csökkenőbe, de ha vannak azonos korúak, akkor név szerint növekvőbe
            Console.WriteLine("Kor szerint csökkenőbe + név szerint növekvőbe");
            var eredmeny3 = glad.OrderByDescending(item => item.ev).ThenBy(item2 => item2.nev);
            foreach (gladiator items in eredmeny3)  //a gladiator helyére var-t is írhattam volna, ha már nem tudom.:-)
            {
                Console.WriteLine("Nev: {0} Kor: {1}", items.nev, items.ev);
            }

            //select-tel
            var ered = (from n in glad select n.ev).Average();
            Console.WriteLine("{0} a gladiátorok átlagos életkora ", ered);
            var ered2 = (from n in glad select n.ev).Max();
            Console.WriteLine("{0} a legidősebb gladiátor kora ", ered2);


            //adjuk meg származásonként a legnagyobb kort
            var find = from n in glad group n by n.szarm into szarmaz select new { Szarmazas = szarmaz.Key, kor = szarmaz.Max(item => item.ev) };
            foreach (var item in find)
            {
                Console.WriteLine("Származás: {0}, kor: {1}", item.Szarmazas, item.kor);
            }
            //Ki a legidősebb sárga gladiátor?
            try
            {
                int maxkor = (from n in glad where n.szin == szinkod.Sárga select n.ev).Max(); //legnagyobb megadása
                var legek = from c in glad where c.ev == (maxkor) && c.szin == szinkod.Sárga select new { Neve = c.nev, Kora = c.ev, Szine = c.szin }; //a legnagyobb kort elérők. Sajnos lehet több is...
                foreach (var item in legek)
                {
                    Console.WriteLine("Név: {0}, kor: {1} színe: {2}", item.Neve, item.Kora, item.Szine);
                }
            }
            catch (Exception e) { Console.WriteLine("NIncs sárga???");}
            //Ki a legidősebb Római harcos?
            int maxkorRomai = (from n in glad where n.szarm == szarmazas.Római select n.ev).Max(); //legnagyobb megadása
            var legekRomai = from c in glad where c.ev == (maxkorRomai) && c.szarm == szarmazas.Római select new { Neve = c.nev, Kora = c.ev, Szine = c.szin }; //
            Console.WriteLine("A legidősebb római adatai");
            foreach (var item in legekRomai)
            {
                Console.WriteLine("Név: {0}, kor: {1} színe: {2}", item.Neve, item.Kora, item.Szine);
            }
            //És még egy elegáns megoldás
            var result = glad
    .Where(x => x.szin == szinkod.Sárga)
    .OrderByDescending(x => x.ev)
    .Select(x => x.nev)
    .FirstOrDefault();
            Console.WriteLine(result);







            Console.ReadKey();



        }
    }
}

