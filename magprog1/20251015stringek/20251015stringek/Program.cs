namespace _20251015stringek
{
    internal class Program
    {
        static (bool, int) VaneBenneHanyszor(string miben, string mi)
        {
            (bool, int) vaneshanyszor = (false, 0);
            int db = 0;

            // int hol = miben.IndexOf(mi);
            // int hol2 = miben.IndexOf(mi, hol + 1);  // amig az ertek nem -1

            int hol = 0;
            int hol2 = 0;
            hol = miben.IndexOf(mi);

            while (hol != -1)
            {
                db++;
                hol2 = miben.IndexOf(mi, hol + 1);
                hol = hol2;
            }

            if(db == 0)
            {
                return (false, 0);
            } else
            {
                return (true, db);
            }
        }

        static bool VaneBenneHanyszor(string miben, string mi, ref int hanyszor)
        {
            (bool, int) vaneshanyszor = (false, 0);
            int db = 0;

            int hol = 0;
            int hol2 = 0;
            hol = miben.IndexOf(mi);

            while (hol != -1)
            {
                db++;
                hol2 = miben.IndexOf(mi, hol + 1);
                hol = hol2;
            }
            hanyszor = db;
            if (db == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool Palindrom(string szo)
        {
            bool isPalindrom = true;

            for (int i = 0; i < szo.Length; i++)
            {
                if(szo[i] != szo[szo.Length - i - 1])
                {
                    isPalindrom = false;
                    break;
                }
            }

            return isPalindrom;
        }
        static void Main(string[] args)
        {
            string pelda = "Esik az alma a fáról";

            Console.WriteLine(pelda[0]);
            Console.WriteLine(pelda[1].ToString().ToUpper());
            Console.WriteLine(pelda.Length);
            Console.WriteLine(pelda.IndexOf("alma"));
            pelda = pelda.Replace("alma", "körte");

            Console.WriteLine(Palindrom("komor görög romok"));

            Console.WriteLine(VaneBenneHanyszor("Malacka vacka cicka", "acka"));

            int db = 0;
            Console.WriteLine(VaneBenneHanyszor("Malacka vacka cicka", "acka", ref db));
            Console.WriteLine(db);
        }
    }
}
