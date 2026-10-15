using System.Collections.Concurrent;

namespace TermeloFogyasztoBlocking;

class Program
{
    const int PufferSize = 50;
    static BlockingCollection<int> puffer = new BlockingCollection<int>(PufferSize);
    static void Main(string[] args)
    {
        Task t1 = Task.Run(() => Produce(2, 100));
        Task t2 = Task.Run(() => Produce(101, 100));
        Task t3 = Task.Run(() => Produce(201, 300));
        Task t4 = Task.Run(() => Consume(ConsoleColor.Cyan));
        Task t5 = Task.Run(() => Consume(ConsoleColor.Magenta));

        Task.WaitAll(t1, t2, t3);
        Console.WriteLine("A termelők készen vannak");
        puffer.CompleteAdding();

        Task.WaitAll(t4, t5);
        Console.WriteLine("Vége");
    }

    static void Produce(int from, int until)
    {
        for (int i = from; i <= until; i++)
        {
            if(Prime(i))
            {
                puffer.Add(i);
            }
        }
    }

    static void Consume(ConsoleColor color)
    {
        int temp = 0;
        while (!puffer.IsCompleted)
        {
            temp = puffer.Take();
            lock(typeof(Program))
            {
                Console.ForegroundColor = color;
                Console.WriteLine(temp);
            }
        }

        // foreach (var item in puffer.GetConsumingEnumerable())
        // {
        //     lock(typeof(Program))
        //     {
        //         Console.ForegroundColor = color;
        //         Console.WriteLine(item);
        //     }
        // }
    }

    static bool Prime(int number)
    {
        bool prim = true;
        for (int i = 2; i <= Math.Sqrt(number) && prim; i++)
            if (number % i == 0)
                prim = false;
        return prim;

    }
}
