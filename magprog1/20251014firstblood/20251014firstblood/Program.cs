namespace _20251014firstblood
{
    class Karakter
    {
        public int Sebesseg {  get; set; }
        public int Ero {  get; set; }
        public int Ugyesseg { get; set; }
        public int NyeresekSzama { get; set; }

        public Karakter(int sebesseg, int ero, int ugyesseg) {
            this.Sebesseg = sebesseg;
            this.Ero = ero;
            this.Ugyesseg = ugyesseg;
        }
        public Karakter() { }
    }
    internal class Program
    {
        static int DoboKocka()
        {
            return new Random().Next(1, 7);
        }

        static Karakter KarakterGenerator() {
            int pontok = 6;

            Random random = new();

            Karakter harcos = new Karakter();

            harcos.Sebesseg = random.Next(0, pontok);
            pontok -= harcos.Sebesseg;

            harcos.Ero = random.Next(1, pontok + 1);
            pontok -= harcos.Ero;

            harcos.Ugyesseg = random.Next(0, pontok +1);
            pontok -= harcos.Ugyesseg;

            harcos.Ugyesseg += pontok;
            return harcos;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Szeretné betölteni mentését? (y/n)");
            string mentes = Console.ReadLine();

            string harcosokSzamaTemp;
            int harcosokSzama;
            do
            {
                Console.Write("Adja meg a harcosok számát: (Ha betölti a mentést, adja meg a sorok hosszát!) ");
                harcosokSzamaTemp = Console.ReadLine();
            }
            while (!int.TryParse(harcosokSzamaTemp, out harcosokSzama));

            Karakter[] harcosok = new Karakter[harcosokSzama];
            
            if (mentes == "y")
            {
                StreamReader sr = new("mentes.txt");
                sr.ReadLine();

                for (int i = 0; i < harcosokSzama; i++)
                {
                    string[] line = sr.ReadLine().Split(';');
                    Karakter harcos = new Karakter(int.Parse(line[0]), int.Parse(line[1]), int.Parse(line[2]));

                    harcosok[i] = harcos;
                }
                sr.Close();
            } 
            else
            {
                for (int i = 0; i < harcosokSzama; i++)
                {
                    harcosok[i] = KarakterGenerator();
                    Console.WriteLine($"{harcosok[i].Sebesseg} {harcosok[i].Ero} {harcosok[i].Ugyesseg}");
                }
            }

            for (int i = 0; i < harcosok.Length - 1; i++)
            {
                for (int j = 0; j < harcosok.Length; j++)
                {
                    if (i != j)
                    {
                        bool vanNyertes = false;
                        int k = 0;
                        while (!vanNyertes)
                        {
                            if (DoboKocka() <= harcosok[k % 2 == 0 ? i : j].Ero)
                            {
                                Console.WriteLine("Erőpróba teljesítve");
                                if (DoboKocka() <= harcosok[k % 2 == 0 ? j : i].Ugyesseg)
                                {
                                    Console.WriteLine("Ütés kivédve");
                                }
                                else
                                {
                                    harcosok[k % 2 == 0 ? i : j].NyeresekSzama++;
                                    vanNyertes = true;
                                }
                            }
                            k++;
                        }
                    }
                }
            }

            Console.WriteLine("Szeretné elmenteni a végeredményeket? (y/n)");
            mentes = Console.ReadLine();

            if(mentes == "y")
            {
                StreamWriter sw = new("mentes.txt");

                sw.WriteLine("Sebesseg;Ero;Ugyesseg;NyereseiSzama");

                foreach (Karakter harcos in harcosok)
                {
                    sw.WriteLine($"{harcos.Sebesseg};{harcos.Ero};{harcos.Ugyesseg};{harcos.NyeresekSzama}");
                }
                sw.Close();
                Console.WriteLine("Sikeresen mentve");
            }



            Console.ReadLine();
        }
    }
}
