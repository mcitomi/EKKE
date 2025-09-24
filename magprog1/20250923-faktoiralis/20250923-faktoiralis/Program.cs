namespace _20250923_faktoiralis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N;
            int sum = 1;

            while (!int.TryParse(Console.ReadLine(), out N) || N < 1 || N > 100) {
                Console.WriteLine("Hibas bemenet");
            }

            for (int i = 1; i <= N; i++)
            {
                sum *= i;
            }

            Console.WriteLine(sum);
        }
    }
}
