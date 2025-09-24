namespace _20250923_xytablazat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N;

            while (!int.TryParse(Console.ReadLine(), out N) || N < 1 || N > 20)
            {
                Console.WriteLine("Hibás bemenet: 1<=N<=20");
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write((i + j) % 2 == 0 ? "X" : "Y");
                }
                Console.WriteLine();
            }
        }
    }
}
