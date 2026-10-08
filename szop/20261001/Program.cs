namespace _20261001;

class SuperVisor
{
    private readonly static List<int> buffer = new List<int>();
    const int bufferSize = 50;

    static int numberOfConsumers = 0;
    static int numberOfProducers = 0;
    static bool producerStopped = false;    // ToDo: kell majd property hozzá hogy elérjék, mert ez most local.
    static bool costumerStopped = false;

    public static void ProducerStarts()
    {
        Interlocked.Increment(ref numberOfProducers);

    }

    public static void ProducerStops()
    {
        Interlocked.Decrement(ref numberOfProducers);

        if (numberOfProducers == 0)
        {
            producerStopped = true;
            lock (buffer)
            {
                Monitor.PulseAll(buffer);
            }
        }
    }

    public static void ConsumerStarts()
    {
        Interlocked.Increment(ref numberOfConsumers);

    }

    public static void ConsumerStops()
    {
        Interlocked.Decrement(ref numberOfConsumers);

        if (numberOfConsumers == 0)
        {
            costumerStopped = true;
            lock (buffer)
            {
                Monitor.PulseAll(buffer);
            }
        }

    }

    public static void Produce(int number)
    {
        lock(buffer)
        {
            while (buffer.Count == bufferSize)
            {
                if(costumerStopped)
                {
                    throw new Exception("A fogyasztók megálltak");
                } 
                Monitor.Wait(buffer);
            }
            buffer.Add(number);
            Monitor.PulseAll(buffer);
        }
    }

    public static int Consume()
    {
        int temp;
        lock(buffer)
        {
            while (buffer.Count == 0)
            {
                if(producerStopped)
                {
                    throw new Exception("A termelők megálltak");
                } 

                Monitor.Wait(buffer);
            }
            temp = buffer[0];
            buffer.RemoveAt(0);
            Monitor.PulseAll(buffer);
        }
        return temp;
    }
}

class Producer
{
    static int from = 0;
    static int until = 0;
    public Producer(int interv1, int interv2)
    {
        from = interv1; 
        until = interv2;
    }

    static bool Prime(int number)
    {
        bool prim = true;
        for (int i = 2; i <= Math.Sqrt(number) && prim; i++)
        {
            if(number % i == 0)
            {
                prim = false;
            }
        }

        return prim;
    }

    public void Produce()
    {
        SuperVisor.ProducerStarts();
        for (int i = from; i <= until; i++)
        {
            if(Prime(i))
            {
                SuperVisor.Produce(i);  // tryba kell tenni, de nem lehet kivétel a berakáskor
            }
        }
        SuperVisor.ProducerStops();
    }
}

class Consumer
{
    static Object lockObjectForScreen = new object();
    ConsoleColor consoleColor;

    public Consumer(ConsoleColor cl)
    {
        this.consoleColor = cl;
    }

    public void Consume()    // szálként fog futni
    {
        SuperVisor.ConsumerStarts();

        while(true)
        {
            try
            {
                int temp = SuperVisor.Consume();

                lock (typeof(Program))
                {
                    Console.ForegroundColor = consoleColor;
                    Console.WriteLine(temp);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("A fogyasztó leállt, nincs több termelő");
                break;
            }
        }

        SuperVisor.ConsumerStops();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Producer p1 = new Producer(2, 100);
        Producer p2 = new Producer(101, 200);
        Producer p3 = new Producer(201, 300);
        Producer p4 = new Producer(301, 400);

        Consumer c1 = new Consumer(ConsoleColor.Yellow);
        Consumer c2 = new Consumer(ConsoleColor.Blue);

        Thread t1 = new Thread(p1.Produce);
        Thread t2 = new Thread(p2.Produce);
        Thread t3 = new Thread(p3.Produce);
        Thread t4 = new Thread(p4.Produce);
        Thread t5 = new Thread(c1.Consume);
        Thread t6 = new Thread(c2.Consume);

        t1.Start();
        t2.Start();
        t3.Start();
        t4.Start();
        t5.Start();
        t6.Start();
        t6.Start();
    }
}
