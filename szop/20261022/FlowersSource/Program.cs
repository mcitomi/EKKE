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
            if (NumberOfProducers == 0) {
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
                    throw new Exception("Nincs több éhes száj, ne má'");
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
            while (!puffer.Exists((x)=>x.FType==type))
            {
                if (ProducersStopped)
                    throw new Exception("A termelők megálltak");
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
    
    public Producer(int quantity, int worktime)
    {
        this.Worktime = worktime;
        this.Quantity = quantity;
    }
    public void Work()
    {
        Supervisor.ProducerStarts(); Random rn=new Random(); 
        for (int i = 0; i < Quantity; i++)
        {

            Supervisor.AddItem(new Flower((FlowerType)rn.Next(0,3), 0, i));
            Console.WriteLine($"A termelő berakott 1 virágot {i} ");
            Thread.Sleep(Worktime * 10);
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
        Supervisor.ConsumerStarts();
        while (true)
        {
            try
            {
                Flower temp = Supervisor.Removeitem(this.Flower);
                if (Amount == 2)
                {
                    Flower temp2 = Supervisor.Removeitem(this.Flower);
                    lock (typeof(Program))
                    {
                        Console.ForegroundColor = temp.Ccolor;
                        Console.WriteLine($"{Id} elvett 2 csokrot {temp} és {temp2}");
                    }
                }
                else
                {
                    lock (typeof(Program))
                    {
                        Console.ForegroundColor = temp.Ccolor;
                        Console.WriteLine($"{Id} elvett 1 csokrot {temp}");
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine($"A termelők leálltak, így a fogyasztó ({Id}) is"); break; }
        }
        Supervisor.ConsumerStops();

    }


    internal class Program
    {
        private static void Main(string[] args)
        {
            
            Producer pr1 = new Producer(20, 10);
            Producer pr2 = new Producer(25, 20);
            Producer pr3 = new Producer(30, 30);
            Consumer cr1 = new Consumer(FlowerType.rose, 1, 1);
            Consumer cr2 = new Consumer(FlowerType.daisy, 2, 2);
            Consumer cr3 = new Consumer(FlowerType.mix, 1, 3);
            Thread t1 = new Thread(pr1.Work); Thread t2= new Thread(pr2.Work); Thread t3= new Thread(pr3.Work);
            Thread t4 = new Thread(cr1.Consume); Thread t5= new Thread(cr2.Consume); Thread t6= new Thread(cr3.Consume);
            t1.Start();t2.Start();t3.Start();t4.Start();t5.Start();t6.Start();
            
            
        }
    }
}