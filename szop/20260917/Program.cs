namespace Kiirasok
{
  
    internal class Program
    {
        const int N = 100;
        static int[] numbers = new int[N];

        static long sum = 0;

        static void First()
        {
            for (int i = 0; i < N / 2; i++)
            {
                Console.WriteLine($"F {i}");
            }
        }

        static void Second()
        {
            for (int i = N / 2; i < N; i++)
            {
                Console.WriteLine($"S {i}");
            }
        }

        static public void Sum1()
        {
            for (int i = 0; i <  N / 2; i++)
            {
                Interlocked.Add(ref sum, numbers[i]);   // elemi műveletek, nem vált közben szálat
                //sum += numbers[i];                    // itt simán váltana
            }
        }

        static public void Sum2()
        {
            long sum1 = 0;
            for (int i = N - 1; i >= N/2; i--)
            {
                //Interlocked.Add(ref sum, numbers[i]);
                sum1 += numbers[i];
            }
            Interlocked.Add(ref sum1, sum); // ez jobb, gyorsabb, mert nem interlockolunk minden számolásnál, csak a legvégén, így nem lassítja egymást a két szál a közös forrás miatt
        }

        static void Main(string[] args)
        {
            First();
            Second();

            Thread t1 = new Thread(First);
            Thread t2 = new Thread(Second);

            t1.Priority = ThreadPriority.Lowest;
            t2.Priority = ThreadPriority.Highest;

            t1.Start();
            t2.Start();
           
            t1.Join();  // join: bevárja a fő szál az adott szálat
            t2.Join();

            Console.WriteLine("Itt a vég?");

            for (int i = 0; i < N; i++)
            {
                numbers[i] = i + 1;
            }

            // var thread = new Thread(() => { DoMethod(a, b, c); });

            // Foo parameter = // get parameter value
            // Thread thread = new Thread(new ParameterizedThreadStart(DoMethod));
            // thread.Start(parameter)

            t1 = new Thread(new ThreadStart(Sum1));
            t2 = new Thread(Sum2);
            //t1.IsBackground = true;
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine(sum);
        }
    }
}