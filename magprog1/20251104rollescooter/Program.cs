namespace _20251104rollescooter;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Hány városban vannak jelen? (10-45):");
        int varosok = int.Parse(Console.ReadLine());

        if (varosok < 10 || varosok > 45)
        {
            Console.WriteLine("Hibás bevitel!");
            return;
        }

        double[] rollerek = new double[50 * varosok];

        Random random = new Random();

        double atlagosToltottseg60alatt = 0;
        int toltottseg60alattdarab = 0;

        int fullosRollerek = 0;
        int minimumRollerek = 0;


        for (int i = 0; i < rollerek.Length; i++)
        {
            rollerek[i] = Math.Round(random.NextDouble() * 69.9 + 30.1, 1);

            if (rollerek[i] < 60)
            {
                toltottseg60alattdarab++;
                atlagosToltottseg60alatt += rollerek[i];
            }

            if (rollerek[i] == 100)
            {
                fullosRollerek++;
            }

            if (rollerek[i] == 30.1)
            {
                minimumRollerek++;
            }
            
            System.Console.WriteLine(rollerek[i]);
        }

        System.Console.WriteLine($"60% alatt lévők általgos töltöttsége: {atlagosToltottseg60alatt / toltottseg60alattdarab:0.00}%");

        System.Console.WriteLine(minimumRollerek > fullosRollerek ? "30,1% töltöttségből van több" : "100% töltöttségű rollerből van több");

        int legalacsonyabbToltottseguVaros = 0;
        double legalacsonyabbToltottseguVarosToltottsege = Double.MaxValue;
        double toltottsegek = 0.00;
        for (int i = 0; i < rollerek.Length; i++)
        {
            toltottsegek += rollerek[i];
            if (i % 50 == 0 && i > 0)
            {
                if (legalacsonyabbToltottseguVarosToltottsege > (toltottsegek / 50))
                {
                    legalacsonyabbToltottseguVarosToltottsege = toltottsegek / 50;
                    legalacsonyabbToltottseguVaros = (i / 50) + 1;
                }
                toltottsegek = 0.00;
            }
        }
        
        System.Console.WriteLine($"Legalacsonyabb töltöttségű város a {legalacsonyabbToltottseguVaros}. város");
    }
}
