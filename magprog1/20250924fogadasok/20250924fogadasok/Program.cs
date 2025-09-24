namespace _20250924fogadasok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[] penzek = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] diff = new int[N-1];

            for (int i = 0; i < penzek.Length - 1; i++)
            {
                diff[i] = penzek[i + 1] - penzek[i];
            }

            int[] win = new int[N - 2];

            for (int i = 0; i < diff.Length - 1; i++)
            {
                win[i] = diff[i + 1] - diff[i];
            }

            foreach (int e in win)
            {
                Console.Write($"{e} ");
            }

            Console.WriteLine();

            // egytizedesjegy [30.1,100]
            double[] tarol = new double[10];
            Random rn = new Random();

            for (int i = 0; i < tarol.Length; i++)
            {
                tarol[i] = (double)rn.NextDouble() * 70 + 30.1;
                tarol[2] = rn.Next(301, 1000) / 100;
            }
        }
    }
}
