namespace _20251015fenykep
{
    class Vendeg
    {
        public int Erkezes { get; set; }
        public int Tavozas { get; set; }
        public bool SzerepelMarKepen { get; set; }

        public Vendeg(int erkezes, int tavozas)
        {
            this.Erkezes = erkezes;
            this.Tavozas = tavozas;
            this.SzerepelMarKepen = false;
        }
    }
    internal class Program
    {
        static void Csere(ref Vendeg a, ref Vendeg b)
        {
            Vendeg temp = a;
            a = b;
            b = temp;
        }

        static void RendezesTavozasSzerint(Vendeg[] Vendegek, int vendegekSzama)
        {
            for (int i = 0; i < vendegekSzama - 1; i++)
            {
                int korabbiIndex = i;

                for (int j = i + 1; j < vendegekSzama; j++)
                {
                    if (Vendegek[j].Tavozas < Vendegek[korabbiIndex].Tavozas || (Vendegek[j].Tavozas == Vendegek[korabbiIndex].Tavozas && Vendegek[j].Erkezes < Vendegek[korabbiIndex].Erkezes))
                    {
                        korabbiIndex = j;
                    }
                }
                Csere(ref Vendegek[korabbiIndex], ref Vendegek[i]);
            }
        }

        static void Main(string[] args)
        {
            int vendegekSzama = int.Parse(Console.ReadLine());

            Vendeg[] vendegek = new Vendeg[vendegekSzama];

            for (int i = 0; i < vendegekSzama; i++)
            {
                string[] line = Console.ReadLine().Split(' ');

                vendegek[i] = new Vendeg(int.Parse(line[0]), int.Parse(line[1]));
            }

            RendezesTavozasSzerint(vendegek, vendegekSzama);

            int fenykepezesekSzama = 0;
            int kepenSzereplokSzama = 0;
            int[] fenykepIdopontok = new int[vendegekSzama];

            for (int i = 0; i < vendegekSzama; i++)
            {
                if (!vendegek[i].SzerepelMarKepen)
                {
                    int fenykepIdo = vendegek[i].Tavozas - 1;

                    fenykepIdopontok[fenykepezesekSzama] = fenykepIdo;
                    fenykepezesekSzama++;

                    for (int j = i; j < vendegekSzama; j++)
                    {
                        if (!vendegek[j].SzerepelMarKepen)
                        {
                            if (vendegek[j].Erkezes <= fenykepIdo && fenykepIdo < vendegek[j].Tavozas)
                            {
                                vendegek[j].SzerepelMarKepen = true;
                                kepenSzereplokSzama++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(fenykepezesekSzama);

            for (int i = 0; i < fenykepezesekSzama; i++)
            {
                Console.Write(fenykepIdopontok[i] == 0 ? "" : i == 0 ? fenykepIdopontok[i] : $" {fenykepIdopontok[i]}");
            }
        }
    }
}
