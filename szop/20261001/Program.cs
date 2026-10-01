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
                } else
                {
                    Monitor.Wait(buffer);
                }
            }
            buffer.Add(number);
            Monitor.PulseAll(buffer);
        }
    }

    public static int Consumer()
    {
        lock(buffer)
        {
            while (buffer.Count == 0)
            {
                if(producerStopped)
                {
                    throw new Exception("A termelők megálltak");
                } else
                {
                    Monitor.Wait(buffer);
                }
            }
            int temp = buffer[0];
            buffer.RemoveAt(0);
            return temp;
        }
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
        return true;
    }

    public static void Produce()
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

}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
