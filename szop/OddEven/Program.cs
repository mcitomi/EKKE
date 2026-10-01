using System.Diagnostics;

namespace OddEven
{
    internal class Program
    {
        const int N = 100000;
        static int[] a = new int[N];
        static int bottom = 0;
        static int top = N - 1;
        static int numberOfOddNumbers = 0;
        static int numberOfEvenNumbers = 0;

        static void FromBottom()
        {
            int bottoml = bottom;
            while (bottom < top) //100 101
            {
                if (a[bottoml] % 2 == 0)
                    Interlocked.Increment(ref numberOfOddNumbers);
                else
                    Interlocked.Increment(ref numberOfEvenNumbers);

                // Interlocked.Increment(ref bottom);
                bottoml++;
                Interlocked.Exchange(ref bottom, bottoml);
            }
        }
        static void FromTop()
        {
            int topl = top;
            while (bottom <= top)
            {
                if (a[topl] % 2 == 0)
                    Interlocked.Increment(ref numberOfOddNumbers);
                else
                    Interlocked.Increment(ref numberOfEvenNumbers);

                // Interlocked.Decrement(ref top);
                topl--;
                Interlocked.Exchange(ref top, topl);
            }
        }

        static void FromBottomT(Object state)
        {
            CountdownEvent cd = (CountdownEvent)state;

            int bottoml = bottom;
            while (bottom < top) //100 101
            {
                if (a[bottoml] % 2 == 0)
                    Interlocked.Increment(ref numberOfOddNumbers);
                else
                    Interlocked.Increment(ref numberOfEvenNumbers);

                // Interlocked.Increment(ref bottom);
                bottoml++;
                Interlocked.Exchange(ref bottom, bottoml);
            }
            cd.Signal();
        }
        static void FromTopT(Object state)
        {
            CountdownEvent cd = (CountdownEvent)state;

            int topl = top;
            while (bottom <= top)
            {
                if (a[topl] % 2 == 0)
                    Interlocked.Increment(ref numberOfOddNumbers);
                else
                    Interlocked.Increment(ref numberOfEvenNumbers);

                // Interlocked.Decrement(ref top);
                topl--;
                Interlocked.Exchange(ref top, topl);
            }
            cd.Signal();
        }
        static void Main(string[] args)
        {
            Random rn = new Random();
            for (int i = 0; i < N; i++)
            {
                a[i] = rn.Next(1, N + 1);
            }
            Thread t1 = new Thread(FromBottom); Thread t2 = new Thread(FromTop);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            t1.Start(); t2.Start(); t1.Join(); t2.Join();

            stopwatch.Stop();
            Console.WriteLine("{0} {1}", numberOfEvenNumbers, numberOfOddNumbers);
            Console.WriteLine($"{stopwatch.ElapsedTicks}");

            bottom = 0;
            top = N - 1;
            numberOfEvenNumbers = 0;
            numberOfOddNumbers = 0;

            stopwatch.Restart();

            CountdownEvent ce = new CountdownEvent(2);  // A "ce" kerül bele a Object state-be.

            ThreadPool.QueueUserWorkItem(FromBottomT, ce);
            ThreadPool.QueueUserWorkItem(FromTopT, ce);

            ce.Wait();  // olyan mint a join

            Console.WriteLine("{0} {1}", numberOfEvenNumbers, numberOfOddNumbers);
            Console.WriteLine($"{stopwatch.ElapsedTicks}");

        }
    }
}
