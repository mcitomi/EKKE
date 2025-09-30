namespace _20250930peldazh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pizzaAr = 1350;
            int feltetekSzama = 0;

            string[] kat200 = { "sonka", "kukorica", "gomba" };
            string[] kat250 = { "kolbász", "ananász", "jalapenho" };
            string[] kat300 = { "kagyló", "articsóka", "oliva" };

            Console.WriteLine("Üdvözli önt a MixAPizza pizzéria!");

            string feltet = "";

            while (feltetekSzama < 5 && feltet != "-")
            {
                Console.Write("Adjon meg egy feltétet: ");
                feltet = Console.ReadLine();

                foreach (var item in kat200)
                {
                    if(item == feltet)
                    {
                        pizzaAr += 200;
                        feltetekSzama++;
                        break;
                    }
                }

                foreach (var item in kat250)
                {
                    if (item == feltet)
                    {
                        pizzaAr += 250;
                        feltetekSzama++;
                        break;
                    }
                }

                foreach (var item in kat300)
                {
                    if (item == feltet)
                    {
                        pizzaAr += 300;
                        feltetekSzama++;
                        break;
                    }
                }
            }

            Console.WriteLine($"A pizzára {feltetekSzama} db feltét került, a pizza {pizzaAr} Ft lesz");
        }
    }
}
