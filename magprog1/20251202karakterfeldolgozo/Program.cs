using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace kiraly_feladatok
{
    public static class DetRandom
    {
        public static int Next(string seedString, int min, int max)
        {
            if (min >= max)
                throw new ArgumentException("min must be less than max");

            // SHA256
            byte[] hashBytes;
            using (var sha = SHA256.Create())
            {
                hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(seedString));
            }
            int hash = BitConverter.ToInt32(hashBytes, 0);

            uint positiveHash = (uint)hash;

            int range = max - min;
            int result = (int)(positiveHash % (uint)range) + min;

            return result;
        }
    }


    public enum Karakter_osztaly
    {
        Warrior, Mage, Rogue, Cleric, Ranger
    }
    public enum Megiteles
    {
        Good, Neutral, Evil
    }

    public class Karakter
    {
        public string ID { get; set; }
        public string Nev { get; set; }
        public int Szint { get; set; }
        public Karakter_osztaly Karakter_osztaly { get; set; }
        public int Eletero { get; set; }
        public int Mana { get; set; }
        public Megiteles Megiteles { get; set; }
        public string Regio { get; set; }
        public double Arany { get; set; }

        // ÚJ MEZŐ
        public DateTime SzuletesDatum { get; set; }

        public Karakter(string iD, string nev, int szint, Karakter_osztaly karakter_osztaly, int eletero, int mana, Megiteles megiteles, string regio, double arany)
        {
            ID = iD;
            Nev = nev;
            Szint = szint;
            Karakter_osztaly = karakter_osztaly;
            Eletero = eletero;
            Mana = mana;
            Megiteles = megiteles;
            Regio = regio;
            Arany = arany;

            // ABSZURD SZÜLETÉSI DÁTUM SZÁMÍTÁS
            SzuletesDatum = AbsurdDatumSzamitas();
        }
        public string GetDetSeed(string szoveg = "seed")
        {
            return $"{this.ID}|{this.Nev}|{this.Szint}|{this.Karakter_osztaly}|{this.Eletero}|{this.Mana}|{this.Megiteles}|{this.Regio}|{this.Arany}";
        }

        // (1) Absurd dátum számítása
        private DateTime AbsurdDatumSzamitas()
        {
            DateTime alap = new DateTime(DetRandom.Next(GetDetSeed("1800 2001"), 1800, 2001),1,1);
            alap.AddDays(this.Szint * 17 + this.Eletero * 3 - this.Mana * 2 + ((int)this.Megiteles * 50));

            int Months = this.Eletero * this.Mana * (int)this.Karakter_osztaly * 1;
            if(Months > 50)
            {
                Months = 50;
            }
            alap.AddMonths(Months);
            return alap;
        }

        // (2) Módosító függvény
        public DateTime ModositottDatum(int bemenet, out int eltolasNap)
        {
            eltolasNap = (int)this.Arany + bemenet % 30;

            return new DateTime(DetRandom.Next(GetDetSeed(), eltolasNap * -1, eltolasNap) + this.SzuletesDatum.Ticks);
        }

        // (5) kiírás fájlba
        public string ToFileLine()
        {
            return $"{ID}|{Nev}|{Szint}|{Karakter_osztaly}|{Eletero}|{Mana}|{Megiteles}|{Regio}|{Arany}|{SzuletesDatum:yyyy-MM-dd}";
        }

        public override string ToString()
        {
            return $"ID: {ID} - {Nev}, {Karakter_osztaly} - {Szint} szint | {Eletero} hp, {Mana} mana {Megiteles}, {Regio} régió, Aranyak: {Arany}, Születési dátum: {SzuletesDatum:yyyy.MM.dd}";
        }
    }

    internal class K_csoport
    {

        static void Main(string[] args)
        {
            // help: dict létrehozás helye
            Dictionary<string, Karakter> karakterDict = new Dictionary<string, Karakter>();

            StreamReader sr = new StreamReader("adatok.txt");
            int osszes_nap_modositas = 0;
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split('|');
                bool helyes_sor = true;

                int szint;
                if (!int.TryParse(sor[2], out szint) || szint > 100 || szint < 0)
                    helyes_sor = false;

                Karakter_osztaly karakter_osztaly;
                if (!Enum.TryParse(sor[3], out karakter_osztaly))
                    helyes_sor = false;

                int hp;
                if (!int.TryParse(sor[4], out hp) || hp < 0)
                    helyes_sor = false;

                int mana;
                if (!int.TryParse(sor[5], out mana) || mana < -1)
                    helyes_sor = false;

                Megiteles megiteles = Megiteles.Evil;
                if (!Enum.TryParse(sor[6], out megiteles))
                    helyes_sor = false;

                if (sor[7] == "") helyes_sor = false;

                int arany;
                if (!int.TryParse(sor[8], out arany) || arany < 0 || arany > 1_000_000)
                    helyes_sor = false;

                if (!helyes_sor) continue;

                Karakter uj = new Karakter(sor[0], sor[1], szint, karakter_osztaly, hp, mana, megiteles, sor[7], arany);

                // help: dátum módosítás
                uj.SzuletesDatum = uj.ModositottDatum(osszes_nap_modositas, out int eltolas);
                osszes_nap_modositas += eltolas;

                karakterDict[uj.ID] = uj;
            }

            sr.Close();

            Console.WriteLine($"Összesen {osszes_nap_modositas} nappal lett módosítva a születési dátumok.");
            Console.WriteLine("\n===== STATISZTIKÁK ÉS LEKÉRDEZÉSEK =====\n");

            // Régiónkénti átlagos szint
            //
            (string Regio, double Atlag)[] regio_atlag_szint = regio_atlag_szint = karakterDict.Values
                .GroupBy(c => c.Regio)
                .Select(g => (Regio: g.Key, Atlag: g.Average(c => c.Szint)))
                .ToArray();

            Console.WriteLine("Régiónkénti átlagos szint:");
            foreach (var r in regio_atlag_szint)
                Console.WriteLine($"- {r.Regio}: {r.Atlag:F2}");
            Console.WriteLine();

            // Osztályonként a legtöbb arannyal rendelkező karakter
            //
            (Karakter_osztaly Osztaly, (string Nev, double Arany) Gazdag)[] legtobb_arany_osztalyonkent = karakterDict.Values
                .GroupBy(c => c.Karakter_osztaly)
                .Select(g =>
                    (Osztaly: g.Key, Gazdag: g.Select(c => (Nev: c.Nev, Arany: c.Arany))
                        .OrderByDescending(x => x.Arany).FirstOrDefault())).ToArray();

            Console.WriteLine("Osztályonként a leggazdagabb karakter:");
            foreach (var p in legtobb_arany_osztalyonkent)
                Console.WriteLine($"- {p.Osztaly}: {p.Gazdag.Nev} ({p.Gazdag.Arany} arany)");
            Console.WriteLine();

            // Morális megítélés szerinti darabszám
            //
            (Megiteles Megiteles, int Count)[] moralStats = karakterDict.Values
                .GroupBy(c => c.Megiteles)
                .Select(g => (Megiteles: g.Key, Count: g.Count())).ToArray();

            Console.WriteLine("Morális kategóriák eloszlása:");
            foreach (var m in moralStats)
                Console.WriteLine($"- {m.Megiteles}: {m.Count} db");
            Console.WriteLine();

            // TOP 5 legerősebb karakter (egyedi power score alapján)
            //
            Karakter[] top5 = karakterDict.Values
                .OrderByDescending(c => c.Eletero * 1.5 + c.Mana * 1.2 + c.Szint * 5)
                .Take(5)
                .ToArray();

            Console.WriteLine("TOP 5 legerősebb karakter:");
            foreach (var k in top5)
                Console.WriteLine($"- {k.Nev}: {k.Eletero} HP, {k.Mana} mana, szint {k.Szint}");
            Console.WriteLine();

            // Legfiatalabb 3 karakter (legkésőbbi születési dátum)
            //
            Karakter[] legfiatalabb3 = karakterDict.Values
                .OrderByDescending(c => c.SzuletesDatum)
                .Take(3)
                .ToArray();

            Console.WriteLine("Legfiatalabb (legkésőbb született) 3 karakter:");
            foreach (var k in legfiatalabb3)
                Console.WriteLine($"- {k.Nev}: {k.SzuletesDatum:yyyy-MM-dd}");
            Console.WriteLine();

            // (5) kiírás új fájlba
            //
            StreamWriter sw = new StreamWriter("kimenő_karakterek.txt");
            foreach (KeyValuePair<string, Karakter> k in karakterDict)
            {
                sw.WriteLine(k.ToString());
            }
            sw.Close();
        }
    }
}