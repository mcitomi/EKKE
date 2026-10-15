class Supervisor
{
    static readonly List<Flower> puffer = new List<Flower>();
    const int MAXSIZE = 50;
    static int NumberOfProducers = 0;
    static int NumberOfConsumers = 0;
    static bool ProducersStopped = false;
    static bool ConsumersStopped = false;

    public static void ProducerStarts()
    {
        Interlocked.Increment(ref NumberOfProducers);
    }

    public static void ConsumerStarts()
    {
        Interlocked.Increment(ref NumberOfConsumers);

    }

    public static void ProducerStops()
    {
        lock (typeof(Supervisor))
        {
            NumberOfProducers--;
            if (NumberOfProducers == 0)
            {
                ProducersStopped = true;
                lock (puffer)
                {
                    Monitor.PulseAll(puffer);
                }
            }
        }
    }
    public static void ConsumerStops()
    {
        lock (typeof(Supervisor))
        {
            NumberOfConsumers--;
            if (NumberOfConsumers == 0)
            {
                ConsumersStopped = true;
                lock (puffer)
                {
                    Monitor.PulseAll(puffer);
                }
            }
        }
    }


    public static void AddItem(Flower item)
    {
        lock (puffer)
        {
            while (puffer.Count == MAXSIZE)
            {
                if (ConsumersStopped)
                {
                    throw new Exception("Nincs több éhező");
                }
                Monitor.Wait(puffer);
            }
            puffer.Add(item);
            Monitor.PulseAll(puffer);
        }
    }

    public static Flower Removeitem(FlowerType type)
    {
        Flower found = new Flower(type, 0, 1); //initialize with default values

        lock (puffer)
        {
            while (!puffer.Exists((x) => x.FType == type))
            {
                if (ProducersStopped)
                {
                    throw new Exception("A termelők megálltak");
                }
                Monitor.Wait(puffer);

            }
            found = puffer.Find((x) => x.FType == type);
            puffer.Remove(found);
            Monitor.PulseAll(puffer);
        }

        return found;
    }
}

public enum FlowerType { rose, daisy, mix }
public enum FlowerColour { magenta, yellow, green }
public class Flower
{
    public FlowerType FType { get; }          // rose, daisy, minx
    public FlowerColour Colour { get; }  // kcolour
    public int Id { get; }               // random id

    public ConsoleColor Ccolor { get; }

    public Flower(FlowerType type, FlowerColour colour, int id)
    {
        FType = type;
        if (type == FlowerType.rose)
        {
            Colour = FlowerColour.magenta;
            Ccolor = ConsoleColor.Magenta;
        }
        else if (type == FlowerType.daisy)
        {
            Colour = FlowerColour.yellow; Ccolor = ConsoleColor.Yellow;
        }
        else if (type == FlowerType.mix)
        {
            Colour = FlowerColour.green; Ccolor = ConsoleColor.Green;
        }
        Id = id;
    }

    public override string ToString()
    {
        return $"{FType} flower (#{Id}";
    }
}

class Producer
{

    int Quantity;
    int Worktime;
    int Type;
    public Producer(char type, int quantity, int worktime)
    {
        this.Worktime = worktime;
        this.Quantity = quantity;
        this.Type = type;
    }
    public void Work()
    {
        Random random = new Random();

        Supervisor.ProducerStarts();

        FlowerType ftype = (FlowerType)Type;

        for (int i = 0; i < Quantity; i++)
        {
            Supervisor.AddItem(new Flower(ftype, 0, i));
           
            Thread.Sleep(Worktime * 1000);
        }

        Supervisor.ProducerStops();
    }

}
class Consumer
{
    FlowerType Flower;

    int Amount;
    int Id = 0;
    public Consumer(FlowerType FType, int Amount, int id)
    {
        this.Flower = FType;
        this.Amount = Amount;
        this.Id = id;

    }
    public void Consume(object o) //no parameter if dedicated
    {


    }


    internal class Program
    {
        private static void Main(string[] args)
        {

            Producer pr1 = new Producer('A', 20, 10);
            Producer pr2 = new Producer('B', 25, 20);
            Producer pr3 = new Producer('C', 30, 30);
            Consumer cr1 = new Consumer(FlowerType.rose, 1, 1);
            Consumer cr2 = new Consumer(FlowerType.daisy, 2, 2);
            Consumer cr3 = new Consumer(FlowerType.mix, 1, 3);

        }
    }
}