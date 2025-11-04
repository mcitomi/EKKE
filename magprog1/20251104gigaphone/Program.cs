namespace _20251104gigaphone;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Szeretne korlátlan hálózaton belüli és EU-s hívást? (igen/nem): ");
        bool korlatlanHivas = Console.ReadLine() == "igen";

        string csomag = "";
        bool plusNet = false;

        double szamla = 0;

        if (korlatlanHivas)
        {
            Console.Write("Becslése szerint hány GB adatforgalomra lesz szüksége? (6 / 15): ");
            int adatgb = int.Parse(Console.ReadLine());

            switch (adatgb)
            {
                case 6:
                    Console.WriteLine("Önnek a Normál csomag ajánlott");
                    csomag = "Normál";
                    szamla += 8590;
                    break;

                case 15:
                    Console.WriteLine("Önnek a Fullos csomag ajánlott");
                    csomag = "Fullos";
                    szamla += 13990;
                    break;

                default:
                    Console.WriteLine("Inavlid adatforgalom mennyiség!");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Önnek a Mini csomag ajánlott");
            csomag = "Mini";
            szamla += 4990;
        }

        if (csomag != "Fullos")
        {
            Console.Write("Szeretne gavi 1600Ft-ért plusz 1,5GB adatot? (igen/nem): ");
            plusNet = Console.ReadLine() == "igen";
        }

        Random random = new Random();

        int hivassltoltottPercek = random.Next(0, 360);
        int elkuldottSmsSzama = random.Next(0, 100);
        double adatHasznalat = random.NextDouble() * 7.5;


        switch (csomag)
        {
            case "Fullos":
                if (adatHasznalat - 15 > 0)
                {
                    szamla += (adatHasznalat - 15) * 900;
                }
                break;

            case "Normál":
                szamla += elkuldottSmsSzama * 20;
                if (adatHasznalat - 6 > 0)
                {
                    szamla += (adatHasznalat - 6) * 1050;
                }

                if (plusNet)
                {
                    szamla += 1600;
                }
                break;

            case "Mini":
                szamla += hivassltoltottPercek * 25;
                szamla += elkuldottSmsSzama * 25;
                if(adatHasznalat - 1 > 0)
                {
                    szamla += (adatHasznalat - 1) * 1250;
                }
                
                if (plusNet)
                {
                    szamla += 1600;
                }
                break;
            default:
                break;
        }

        System.Console.WriteLine($"Önnek {hivassltoltottPercek} Perc, {elkuldottSmsSzama} db SMS és {adatHasznalat} GB adatot használt, a számlája {szamla:0.00} Ft");
    }
}
