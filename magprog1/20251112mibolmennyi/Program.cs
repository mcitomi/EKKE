namespace _20251112mibolmennyi;
class Program
{
    static void Main(string[] args)
    {
        const int GYEREK = 11;
        int N = int.Parse(Console.ReadLine());

        int[] jelenlet = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int[] hanyan = new int[GYEREK];
        for (int i = 0; i < jelenlet.Length; i++)
        {
            hanyan[jelenlet[i]]++;
        }

        for (int i = 0; i < GYEREK; i++)
        {
            Console.Write(hanyan[i] + " ");
        }
        Console.WriteLine();
    }
}
