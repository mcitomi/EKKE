// https://xdepot.uni-eszterhazy.hu/index.php/s/i66uTfLh5XjkSqc?path=%2FMagasszint%C5%B1%20programoz%C3%A1si%20nyelvek%201%2FMinta%20ZH#pdfviewer
namespace _20250930fenyok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Console.Write("Mennyi fát termelnek 1nap alatt?: ");
            int faPerNap;

            while (!int.TryParse(Console.ReadLine(), out faPerNap) || faPerNap < 35 || faPerNap > 55)
            {
                Console.Write("Hibás bevitel! Mennyi fát termelnek 1nap alatt?: ");
            }

            int[] fak = new int[faPerNap * 14];

            int[] legkisebbfa = new int[2]; // nap, fa cm

            int atlagMagassagTemp = 0;

            int legnagyobbOsszertekuNap = 0;
            int legnagyobbOsszertekuNapTermelese = 0;

            int osszeretek = 0;

            for (int i = 0; i < fak.Length; i++)
            {
                fak[i] = random.Next(150, 300 + 1);

                atlagMagassagTemp += fak[i];
                if((i + 1) % faPerNap == 0)
                {
                    int aktualisNapTermelese = ((atlagMagassagTemp / faPerNap) / 10) * 500;
                    if (legnagyobbOsszertekuNapTermelese < aktualisNapTermelese)
                    {
                        legnagyobbOsszertekuNap = i / faPerNap + 1;
                        legnagyobbOsszertekuNapTermelese = aktualisNapTermelese;
                    }

                    Console.WriteLine($"Az {i / faPerNap + 1}. nap avg magassága {(float)(atlagMagassagTemp / faPerNap) / 100} méter.");
                    atlagMagassagTemp = 0;
                }

                if (fak[i] < legkisebbfa[1] || legkisebbfa[1] == 0)
                {
                    legkisebbfa[1] = fak[i];
                    legkisebbfa[0] = i / faPerNap + 1;
                }

                osszeretek += (fak[i] / 10) * 500;
            }

            Console.WriteLine($"\nA legkisebb fát a {legkisebbfa[0]}. napon teremelték ki és {(float)legkisebbfa[1] / 100} méter volt.");
            Console.WriteLine($"\nHa minden fát kitermelnénk {osszeretek:N0} Ft bevételre számíthatnánk.");
            Console.WriteLine($"\nA legnagyobb összértékű kitermelés a {legnagyobbOsszertekuNap}. napon volt ami {legnagyobbOsszertekuNapTermelese:N0} Ft.");

            Console.ReadLine();
        }
    }
}
