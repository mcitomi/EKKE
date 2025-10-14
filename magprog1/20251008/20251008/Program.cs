namespace _20251008
{
    class Filmek
    {
        public int Id;
        public int From;
        public int Until;

        public Filmek(int id, int from, int until)
        {
            this.Id = id;
            this.From = from;
            this.Until = until;
        }
    }
    internal class Program
    {
        static void Rendez(Filmek[] films)  // referenciat ad at,nem uj tömböt hanem az eredetit
        {
            for (int i = 0; i < films.Length - 1; i++)
            {
                for (int j = i + 1; j < films.Length; j++)
                {
                    if (films[i].Until > films[j].Until)
                    {
                        Filmek temp = films[i];
                        films[i] = films[j];
                        films[j] = temp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            StreamReader be = new StreamReader("sorozat.be");
            int n = int.Parse(be.ReadLine());

            Filmek[] films = new Filmek[n];

            for (int i = 0; i < n; i++)
            {
                int[] line = be.ReadLine().Split().Select(int.Parse).ToArray();

                //films[i].Id = i;
                //films[i].From = line[0];
                //films[i].Until = line[1];

                films[i] = new Filmek(i, line[0], line[1]);

            }
            be.Close();
            Rendez(films);
            int max = 1;
            int j = 1; int ido = films[0].Until;
            while (j < n)
            {
                while (j < n && films[j].From <= ido)
                {
                    j++;
                }
                if(j < n)
                {
                    max++;
                    ido = films[j].Until;
                }
            }
            StreamWriter ki = new StreamWriter("sorozat.ki");
            ki.WriteLine(max);
            ki.Close();
        }
    }
}
