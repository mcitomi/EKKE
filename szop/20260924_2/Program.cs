namespace _20260924_2;

class Program
{
    static int paratlanok = 0;
    static int[] numbers = new int[10000];

    static int Szamol1()
    {
        int pratlanok1 = 0;

        for (int i = 0; i < numbers.Length / 2; i++)
        {
            if (numbers[i] % 2 != 0)
            {
                pratlanok1++;
                paratlanok++;
                Console.WriteLine(paratlanok);
            }
        }

        return pratlanok1;
    }

    static int Szamol2()
    {
        int pratlanok2 = 0;

        for (int i = numbers.Length - 1; i > numbers.Length / 2; i--)
        {
            if (numbers[i] % 2 != 0)
            {
                pratlanok2++;
                paratlanok++;
                Console.WriteLine(paratlanok);
            }
        }

        return pratlanok2;
    }
    static void Main(string[] args)
    {
        Random random = new Random();

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(2, 50000 + 1);
        }

        int threadOsszegek = 0;
        Thread t1 = new Thread(() =>
        {
            int osszeg1 = Szamol1();
            Interlocked.Add(ref threadOsszegek, osszeg1);
        });
        Thread t2 = new Thread(() =>
        {
            int osszeg2 = Szamol2();
            Interlocked.Add(ref threadOsszegek, osszeg2);
        });

        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
        System.Console.WriteLine(threadOsszegek);
        System.Console.WriteLine(paratlanok);
    }
}
