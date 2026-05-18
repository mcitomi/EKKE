namespace ZH2_NAP_APP
{
    internal class Program
    {
        static Telepules telepules;
        static void OkosottohnokRogzitese(Telepules bolt, string file)
        {
            try
            {
                StreamReader sr = new StreamReader(file);
                while(!sr.EndOfStream) 
                {
                    string sor = sr.ReadLine();
                    try
                    {
                        string[] adatok = sor.Split(';');

                        int terulet = int.Parse(adatok[0]);
                        int szobak = int.Parse(adatok[1]);
                        string cegNev = adatok[2];

                        EpitoCeg ceg = new EpitoCeg(cegNev);

                        List<OkosFunkcio> okosFunkciok = new List<OkosFunkcio>();

                        for (int i = 3; i < adatok.Length; i++)
                        {
                            if (!string.IsNullOrWhiteSpace(adatok[i]))
                            {
                                okosFunkciok.Add( (OkosFunkcio)Enum.Parse(typeof(OkosFunkcio),adatok[i]));
                            }
                        }

                        Okosotthon okosotthon = null;
                        try
                        {
                            okosotthon = new Okosotthon(ceg, terulet,szobak,okosFunkciok);
                        }
                            catch (TeruletAlacsonyException)
                            {
                                Console.WriteLine(
                                    $"Túl alacsony terület ({terulet}), automatikusan 50-re állítva."
                                );

                                okosotthon = new Okosotthon(ceg, 50, szobak,okosFunkciok);
                            }
                            catch (SzobakSzamaNemErvenyesException ex)
                            {
                                Console.WriteLine($"Hibás szobaszám: {ex.RosszErtek}");

                                int ujSzobaszam;

                                if (ex.RosszErtek < 1)
                                    ujSzobaszam = 1;
                                else
                                    ujSzobaszam = 15;

                                okosotthon = new Okosotthon(ceg,terulet,ujSzobaszam,okosFunkciok);
                            }

                            telepules.Regisztral(okosotthon);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Hiba egy sor feldolgozásakor:");
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("A telepulesek.csv fájl nem található!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Általános hiba:");
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("\nModern Living által épített 100m 2 fölötti épületek:");

                foreach (Epulet epulet in telepules.ModernLivingAltalEpitett100M2FolottiEpuletek)
                {
                    Console.WriteLine(epulet);
                }

                Console.WriteLine("\nMegbízható cégek által épített épületek");

                foreach (Epulet epulet in telepules.MegbizhatoCegAltalEpitettEpuletek)
                {
                    Console.WriteLine(epulet);
                }

                Console.WriteLine("\n Top 5 Eco Homes okosotthon 120 m2 fölött:");

                foreach (Epulet epulet in telepules.OtLegkomfortosabbOkosotthon120m2FolottAmitEcoHomesEpitett)
                {
                    Console.WriteLine(epulet);
                }

                Console.WriteLine("\nÁtlagos terület:");

                double atlagTerulet =
                    telepules.Atlag(o => o.Terulet);

                Console.WriteLine(atlagTerulet);
                //Az Extra pontért!!! :-))
                Console.WriteLine("\nIEnumerable teszt (klónok)");

                foreach (Epulet epulet in telepules)
                {
                    Console.WriteLine(epulet);
                }

                Console.ReadKey();
            }


        static void Main(string[] args)
        {
            telepules = new Telepules();
            OkosottohnokRogzitese(telepules, "telepulesek.csv");

        }
    }
}
