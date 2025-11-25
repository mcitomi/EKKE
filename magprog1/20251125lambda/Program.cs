using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;

namespace _202324_ZH2
{
	public class Etel {
        public string Nev;
        public string Kategoria;
        public bool isNormalAdag; //
        public int Tomeg; 
        public DateOnly MelyikNap;
        public string[] Allergenek; //
        public int Energia;
        public int Ar;
    }
    internal class Program
    {
        static int F2_Energia_szamit(Etel etel) //
        {
            return (int)((etel.Energia / 100) * etel.Tomeg);
        }


        static bool F5_Allergen(Etel etel, List<string> allergenek) //
        {
            foreach (string x in allergenek)
            {
                if (etel.Allergenek.Contains(x))
                {
                    return true;
                }
            }

            return false;
        }

        static void F7_Etelek_kategoriai(List<Etel> etelek) //
        {
            List<string> kategoriak = new List<string>();

            foreach (Etel etel in etelek)
            {
                bool bennevan = false;

                foreach (string kat in kategoriak)
                {
                    if (kat == etel.Kategoria)
                    {
                        //
                        break;
                    }
                }

                //
				//
            }

            for (int i = 0; i < kategoriak.Count - 1; i++)
            {
                for (int j = i + 1; j < kategoriak.Count; j++)
                {
                    if (kategoriak[i].CompareTo(kategoriak[j]) > 0)
                    {
                        //
                        //
                        //
                    }
                }
            }

            //
        }
		
		static Etel LegolcsobbEtel(List<Etel> etelek, string kategoria, bool adag)
        {
            Etel legolcsobb = null;
            //

            foreach (Etel e in etelek)
            {
                if (//)
                {
                    if (//)
                    {
                        //
                        //
                    }
                }
            }

            return legolcsobb;
        }

        static void Main(string[] args)
        {
            StreamReader file = new StreamReader("MP1_ZH2_2023_24_input.csv");
            List<Etel> etelek = new List<Etel>();

            //
            while (!file.EndOfStream) //
            {
                string sor = file.ReadLine();
                //
                string[] darabok = sor.Split(';');

                Etel ujEtel = new Etel();
                ujEtel.Nev = darabok[0];
                ujEtel.Kategoria = darabok[1];

                ujEtel.isNormalAdag = (darabok[2] == "normál");

                ujEtel.Tomeg = int.Parse(darabok[3]);
                ujEtel.MelyikNap = //
                
                ujEtel.Allergenek = darabok[5];
                ujEtel.Energia = int.Parse(darabok[6]);
                ujEtel.Ar = int.Parse(darabok[7]);
                etelek.Add(ujEtel);
            }

            int osszAr = 0;
            int db700kjal = 0;
            for (int i = 0; i < etelek.Count; i++)
            {
                if (etelek[i].MelyikNap < DateOnly.Parse("2023.12.15") && etelek[i].MelyikNap > DateOnly.Parse("2023.12.14"))
                {
                    int F2 = F2_Energia_szamit(etelek[i]);
                    if (F2 > 700)
                    {
                        Console.WriteLine($"{etelek[i].Nev} ({etelek[i].isNormalAdag}: {etelek[i].Tomeg} g) - {F2} kcal, {etelek[i].Ar}");
                        osszAr += etelek[i].Ar;
                        db700kjal++;
                    }
                }
            }
            int atlagAr = osszAr / db700kjal;
            Console.WriteLine($"A fenti ételek átlagos ára {atlagAr} Ft.");

            Console.WriteLine("\n4. feladat:\n");
            // 4. feladat

            //Etel minEtel1 = // LINQ-lambda-val
            Etel minEtel1 = etelek.Where(e => e.Kategoria == "rántott" && e.isNormalAdag).OrderBy(e => e.Ar).FirstOrDefault();
           
            Etel minEtel2 = etelek.Where(e => e.Kategoria == "rántott" && !e.isNormalAdag).OrderBy(e => e.Ar).FirstOrDefault();
            //Etel minEtel1 = LegolcsobbEtel(etelek, "rántott", false); // kis adag rántott
            //Etel minEtel2 = LegolcsobbEtel(etelek, "főzelék", true);   // normál adag főzelék
            
			Console.WriteLine($"A legolcsóbb kis adag rántott a {minEtel1.Nev}, az ára pedig {minEtel1.Ar} Ft.");
            Console.WriteLine($"A legolcsóbb normál adag főzelék a {minEtel2.Nev}, az ára pedig {minEtel2.Ar} Ft.");
            if (minEtel1.Ar > minEtel2.Ar)
                Console.WriteLine($"A {minEtel1.Nev} drágább.");
            else
                Console.WriteLine($"A {minEtel2.Nev} drágább.");

            Console.WriteLine("\n6. feladat\n");
            // 6. feladat
            List<string> alergenek = new List<string>();
            string adat = "";
            while (adat != "-")
            {
                Console.WriteLine("Adja meg az alergént!");
                adat = Console.ReadLine();
                //
                alergenek.Add(adat);
            }
            Console.WriteLine("Az Ön számára megfelelő ételek:");
            foreach (Etel x in etelek)
            {
                if (!F5_Allergen(x, alergenek))
                    Console.WriteLine($"{x.Nev} - allergének: {x.Allergenek}");
            }

            Console.WriteLine("\n8. feladat\n");
            // 8. FELADAT
			
			//List<string> kategoriak2 = // LINQ-lambda-val
            List<string> kategoriak2 = F7_Etelek_kategoriai(etelek);

            foreach (string kateg in kategoriak2)
            {
                Etel legkisebb = null;
                int legEnergia = int.MaxValue;

                foreach (Etel x in etelek)
                {
                    // kategória egyezik?
                    if (//)
                        continue;

                    // tartalmaz-e gombát?
                    if (//)
                        continue;

                    int teljesEnergia = F2_Energia_szamit(x);

                    // legkisebb kiválasztása
                    if (teljesEnergia < legEnergia)
                    {
                        //
                        //
                    }
                }

                Console.WriteLine($"{kateg}: {legkisebb.Nev} ({legkisebb.Tomeg} g), {legEnergia} kcal - {legkisebb.Ar} Ft");

            }

            Console.WriteLine("\nExtra feladat\n");
            // EXTRA FELADAT
            Console.WriteLine("\nExtra feladat – heti menü:");

            string[] napok = { "Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek" };
            Random r = new Random();
            int hetiOsszeg = 0;

            foreach (string nap in napok)
            {
                // --- LEGOLCSÓBB LEVES ---
                Etel leves = null;
                int minLeves = int.MaxValue;

                foreach (Etel x in etelek)
                {
                    if (x.Kategoria == "leves")
                    {
                        if (//)
                        {
                            minLeves = x.Ar;
                            leves = x;
                        }
                    }
                }

                // --- RANDOM kategória ---
                string[] koztes = { "saláta", "rántott", "főzelék" };
                string chosenCat = //

                Etel kozetel = null;
                int minKoz = int.MaxValue;

                foreach (Etel x in etelek)
                {
                    if (//)
                    {
                        if (x.Ar < minKoz)
                        {
                            minKoz = x.Ar;
                            kozetel = x;
                        }
                    }
                }

                // --- DESSZERT ---
                Etel desszert = null;
                int minDessz = int.MaxValue;

                foreach (Etel x in etelek)
                {
                    if (x.Kategoria == "desszert")
                    {
                        if (x.Ar < minDessz)
                        {
                            minDessz = x.Ar;
                            desszert = x;
                        }
                    }
                }

                int napiOsszeg = leves.Ar + kozetel.Ar + desszert.Ar;
                hetiOsszeg += napiOsszeg;

                Console.WriteLine($"{nap} ({napiOsszeg} Ft)");
                Console.WriteLine($"  leves: {leves.Nev} - {leves.Ar} Ft");
                Console.WriteLine($"  {chosenCat}: {kozetel.Nev} - {kozetel.Ar} Ft");
                Console.WriteLine($"  desszert: {desszert.Nev} - {desszert.Ar} Ft\n");
            }

            Console.WriteLine($"A heti menü teljes ára: {hetiOsszeg} Ft");
        }
    }
}