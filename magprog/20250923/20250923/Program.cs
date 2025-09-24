namespace _20250923
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int limit;
            long sum = 0;

            while (!int.TryParse(Console.ReadLine(), out limit) || limit < 1 || limit > 1_000_000) {
                Console.WriteLine("Hibás bemenet: 1<=N<=100");
            }

            for (int i = 1; i < limit; i++)
            {
                if(i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("bumm");
                } else if (i % 5 == 0 )
                {
                    Console.WriteLine("bamm");
                } else if (i % 3 == 0 )
                {
                    Console.WriteLine("bimm");
                } else
                {
                    Console.WriteLine(i);
                    sum += i;
                }
            }
            Console.WriteLine($"Összeg: {sum:N0}");
        }
    }
}
