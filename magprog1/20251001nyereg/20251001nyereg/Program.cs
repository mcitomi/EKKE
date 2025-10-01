namespace _20251001nyereg
{
    internal class Program
    {
        const int N = 3; const int M = 3;
        static int[,] matrix = new int[N, M];

        static int MaxSor(int oszlop)
        {
            int max = int.MinValue; int maxSor = -1;
            for (int i = 0; i < N; i++)
            {
                if (max < matrix[oszlop, i])
                {
                    max = matrix[oszlop, i];
                    maxSor = i;
                }
            }
            return maxSor;
        }

        static int MaxOszlop(int sor)
        {
            int maxOszlopIndex = 0;
            for (int i = 0; i < M; i++)
            {
                if (matrix[maxOszlopIndex, sor] < matrix[i, sor])
                {
                    maxOszlopIndex = i;
                }
            }
            return maxOszlopIndex;
        }

        static int MinSor(int oszlop)
        {
            int minSorIndex = 0;
            for (int i = 0; i < N; i++)
            {
                if (matrix[oszlop, minSorIndex] > matrix[oszlop, i])
                {
                    minSorIndex = i;
                }
            }
            return minSorIndex;
        }

        static int MinOszlop(int sor)
        {
            int minOszlopIndex = 0;
            for (int i = 0; i < M; i++)
            {
                if (matrix[minOszlopIndex, sor] > matrix[i, sor])
                {
                    minOszlopIndex = i;
                }
            }
            return minOszlopIndex;
        }

        static void Main(string[] args)
        {
            //int[][] matrixhelyett = new int[N][];

            Random random = new Random();

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)   // oszlopok számát kéri le (M)
                {
                    matrix[i, j] = random.Next(10, 100);
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write($"{matrix[i, j],3}");
                }
                Console.WriteLine();
            }

            int nyeregSor = 0;
            int saddleOszlop = 0;
            for(int i = 0; i< M; i++)
            {
                int sor = MaxSor(i);
                int ittLegKisebbOszlop = MinOszlop(sor);
                if(i == ittLegKisebbOszlop)
                {
                    nyeregSor = sor;
                    saddleOszlop = i;

                    Console.SetCursorPosition(saddleOszlop * 3, sor);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{matrix[sor, i],3}");
                }
            }

            for (int i = 0; i < M; i++)
            {
                int sor = MinSor(i);
                int ittLegKisebbOszlop = MaxOszlop(sor);
                if (i == ittLegKisebbOszlop)
                {
                    nyeregSor = sor;
                    saddleOszlop = i;

                    Console.SetCursorPosition(saddleOszlop * 3, sor);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{matrix[sor, i],3}");
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();

            //Console.WriteLine(MaxSor(1));
            //Console.WriteLine(MinOszlop(1));
            //Console.WriteLine(MinSor(1));
        }
    }
}
