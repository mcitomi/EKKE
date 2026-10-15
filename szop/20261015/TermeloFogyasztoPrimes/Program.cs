namespace TermeloFogyasztoPrimes
{
    class Supervisor
    { 
        private readonly static List<int> buffer=new List<int>();
        const int BufferSize = 50;
        static int numberOfConsumers=0;
        static int numberOfProducers = 0;
        static bool ProducerStopped = false;
        static bool ConsumerStopped = false;
        
        public static void ProducerStarts()
        {
            Interlocked.Increment(ref numberOfProducers);
        }
        public static void ProducerStop()
        {
            Interlocked.Decrement(ref numberOfProducers);
            if(numberOfProducers==0)
            {
                ProducerStopped = true;
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
        public static void ConsumerStop()
        {
            
            lock(buffer)
            {
                numberOfConsumers--;
                if (numberOfConsumers == 0) 
                {
                    ConsumerStopped = true;
                    Monitor.PulseAll(buffer);
                }
            }
        }
        public static void Produce(int number)
        {
            lock (buffer) 
            {
                while (buffer.Count == BufferSize)
                {
                    if (ConsumerStopped)
                        throw new Exception("A fogyasztók megálltak");
                    Monitor.Wait(buffer);
                }
                buffer.Add(number);
                Monitor.PulseAll(buffer);
            }
        }

        public static int Consume()
        {
            int temp;
            lock (buffer)
            {
                while (buffer.Count == 0)
                {
                    if (ProducerStopped)
                        throw new Exception("A termelők megálltak");
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
        static int from = 0;static int until = 0;
        public Producer(int interv1, int interv2)
        { 
            from = interv1;until= interv2;
        }

        static bool Prime(int number)
        { 
            bool prim = true;
            for (int i = 2; i <= Math.Sqrt(number) && prim; i++)
                if (number % i == 0)
                    prim = false;
            return prim;

        }
        public void Produce() //szálként hívjuk meg
        {
            Supervisor.ProducerStarts();
            for (int i = from; i <= until; i++)
                if (Prime(i))
                    Supervisor.Produce(i); //try-ba kellene tenni, de nem lehet kivétel a berakáskor.

            Supervisor.ProducerStop();
        }
    }

    class Consumer
    {
        static Object LockObjectForScreen=new object();
        ConsoleColor cl;
        public Consumer(ConsoleColor cl) 
        { 
            this.cl= cl;
                
        }
        public void Consume() //szállként fog futni!
        {
            Supervisor.ConsumerStarts();
            while(true)
            {
                try
                {
                    int temp = Supervisor.Consume();
                    lock (typeof(Program)) //lock (LockObjectForScreen)
                    {
                        Console.ForegroundColor = cl;
                        Console.WriteLine(temp);
                    }
                }
                catch (Exception e) { Console.WriteLine("A fogyasztó leállt, nincs több termelő!"); break; }
            }
            Supervisor.ConsumerStop();
        }



    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Producer p1 = new Producer(2, 100);
            Producer p2 = new Producer(101, 200);
            Producer p3 = new Producer(201, 300);
            Producer p4 = new Producer(301, 400);
            Consumer c1=new Consumer(ConsoleColor.Yellow);
            Consumer c2 = new Consumer(ConsoleColor.Blue);
            Thread t1 = new Thread(p1.Produce);
            Thread t2 = new Thread(p2.Produce);
            Thread t3 = new Thread(p3.Produce);
            Thread t4 = new Thread(p4.Produce);
            Thread t5 = new Thread(c1.Consume);
            Thread t6 = new Thread(c2.Consume);
            t1.Start();t2.Start();t3.Start();t4.Start();t5.Start();t6.Start();

        }
    }
}
