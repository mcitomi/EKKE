namespace _20250924asztronautaparok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = 100;
            int n;

            Console.Write("Adja meg az asztronauták számát: ");

            while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > N)
            {
                Console.Write("Adja meg az asztronauták számát: ");
                n = int.Parse(Console.ReadLine());
            }

            Console.Write("\nAdja meg az asztronauták súlyát: ");

            int[] sulyok = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int parok = 0;

            for (int i = 0; i < sulyok.Length-1; i++)
            {
                for (int j = i + 1; j < sulyok.Length; j++)
                {
                    if (sulyok[i] == sulyok[j]) { 
                        parok++;
                    }
                }
            }

            Console.WriteLine(parok);
        }
    }
}
