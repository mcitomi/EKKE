namespace _20261008;
class Pass
{
    public CountdownEvent ce;
    public int[] vektor = new int[Program.N];

}
class Program
{
    public const int N = 100_000;


    static void Generate(int[] vektor)
    {
        Random random = new Random();

        for (int i = 0; i < N; i++)
        {
            lock (vektor)
            {
                vektor[i] = random.Next(1, 100);
            }

        }
    }

    static void GenerateThreadPool(Object state)
    {
        Pass p1 = (Pass)state;

        Random random = new Random();

        for (int i = 0; i < N; i++)
        {
            lock (p1.vektor)
            {
                p1.vektor[i] = random.Next(1, 100);
            }

        }
        p1.ce.Signal();
    }

    static void Remover(int[] vektor)
    {
        Random random = new Random();
        int pos = 0;

        for (int i = 0; i < N; i++)
        {
            pos = random.Next(0, N);

            lock(vektor)
            {
                if(vektor[pos] != 0)
                {
                    vektor[pos] = 0;
                }
            }
        }
    }

    static void RemoverThreadPool(Object state)
    {
        Pass p1 = (Pass)state;

        Random random = new Random();
        int pos = 0;

        for (int i = 0; i < N; i++)
        {
            pos = random.Next(0, N);

            lock(p1.vektor)
            {
                if(p1.vektor[pos] != 0)
                {
                    p1.vektor[pos] = 0;
                }
            }
        }
        p1.ce.Signal();
    }

    static void Main(string[] args)
    {

        int[] vektor = new int[N];
        Thread t1 = new Thread(() => Generate(vektor));
        Thread t2 = new Thread(() => Remover(vektor));

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        int db = 0;

        for (int i = 0; i < N; i++)
        {
            if(vektor[i] != 0)
            {
                Console.WriteLine(vektor[i]);
                db++;
            }
        }

        Console.WriteLine(db);

        vektor = new int[N];
        db = 0;

        CountdownEvent countdownEvent = new CountdownEvent(2);
        
        Pass p1 = new Pass();
        p1.vektor = vektor;
        p1.ce = countdownEvent;

        ThreadPool.QueueUserWorkItem(GenerateThreadPool, p1);
        ThreadPool.QueueUserWorkItem(RemoverThreadPool, p1);

        countdownEvent.Wait();

        for (int i = 0; i < N; i++)
        {
            if(vektor[i] != 0)
            {
                // Console.WriteLine(vektor[i]);
                db++;
            }
        }

        Console.WriteLine(db);

        // ParalellFor 
    }
}
