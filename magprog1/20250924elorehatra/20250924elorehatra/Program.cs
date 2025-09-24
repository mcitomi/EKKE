namespace _20250924elorehatra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int N = 13;

            int[] a = new int[N];   // vektor nem tömb

            string[] line = Console.ReadLine().Split(' ');

            for (int i = 0; i < line.Length; i++)
            {
                Console.Write($"{int.Parse(line[i])} ");
            }

            Console.WriteLine();

            for (int i = N - 1; i >= 0; i--)
            {
                Console.Write($"{int.Parse(line[i])} ");
            }
        }
    }
}
