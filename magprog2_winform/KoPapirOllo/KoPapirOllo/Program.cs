using KoPapirOllo;

internal class Program
{
    private static void Main(string[] args)
    {
        Random rnd = new Random();
        //kellene egy barland nevű lista;
        Jatekbarlang barlang = new Jatekbarlang(60, 10);


        // játékosok
        for (int i = 0; i < 50; i++)
        {
            int esely = rnd.Next(100);

            if (esely < 70)
            {
                barlang.HozzaadJatekos(
                    new KinaiJatekos("J" + i, rnd.Next(2, 11), rnd.Next(10, 101)));
            }
            else
            {
                barlang.HozzaadJatekos(
                    new FixKinaiJatekos("F" + i, rnd.Next(2, 11), rnd.Next(10, 101),
                    (EnumLepes)rnd.Next(3)));
            }
        }

        // bírók
        for (int i = 0; i < 8; i++)
        {
            if (rnd.Next(100) < 80)
                barlang.HozzaadBiro(new Biro());
            else
                barlang.HozzaadBiro(new MaffiaBiro());
        }

        // játékok
        for (int i = 0; i < 100; i++)
            barlang.Lebonyolit();

        int tonkre = 0;
        int boldog = 0;
        int osszMaffia = 0;

        foreach (KinaiJatekos jatek in barlang.GetJatekosok())
        {
            if (jatek.RizsMenny < 3)
                tonkre++;

            if (jatek.RizsMenny >= jatek.RizsKezd * jatek.Mohosag)
                boldog++;
        }

        foreach (Biro b in barlang.GetBirok())
        {
            if (b is MaffiaBiro)
                osszMaffia += ((MaffiaBiro)b).Beszedett;
        }

        Console.WriteLine("Tönkrement: " + tonkre);
        Console.WriteLine("Boldog: " + boldog);
        Console.WriteLine("Maffia rizs: " + osszMaffia);

        Console.Write("Név: ");
        string nev = Console.ReadLine();

        KinaiJatekos j = barlang[nev];
        Console.WriteLine(j);

        string nev2 = Console.ReadLine();
        KinaiJatekos j2 = barlang[nev2];
        
        if(barlang[nev] > barlang[nev2])
        {
            System.Console.WriteLine($"{nev} a nagyobb {barlang[nev].RizsMenny}");
        }
        else if(barlang[nev] < barlang[nev2])
        {
            System.Console.WriteLine($"{nev2} a nagyobb {barlang[nev2].RizsMenny}");
        }
        else
        {
            System.Console.WriteLine("Egyenlő");
        }
    }
}