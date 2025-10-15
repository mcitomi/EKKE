namespace _20251015auto
{
    class Stations
    {
        public int Km;
        public int Liter;

        public Stations(int km, int liter) {
            this.Km = km;
            this.Liter = liter;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(' ');
            int k = int.Parse(line[0]);
            int n = int.Parse(line[1]);
            int b = int.Parse(line[2]);
            int l = int.Parse(line[3]);

            Stations[] stations = new Stations[n];

            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine().Split(' ');
                stations[i] = new Stations(int.Parse(line[0]), int.Parse(line[1]));
            }

            int opt = 0;
            int index = 0;
            int kmeleg = b * 100 / l;
            int holkm = 0;
            while (index < n)
            {
                while (index < n && stations[index].Km - holkm < kmeleg )
                {
                    index++;
                }
                if (index < n)
                {
                    opt++; // tankoltam
                    kmeleg = kmeleg - stations[index - 1].Km + stations[index - 1].Liter * 100 / l;
                    holkm = stations[index - 1].Km;
                }
            }
            if(kmeleg + holkm < k)
            {
                opt++;
            }

            Console.WriteLine(opt);
            Console.ReadLine();
        }
    }
}
