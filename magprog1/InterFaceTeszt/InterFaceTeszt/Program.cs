namespace InterFaceTeszt
{
    class Matek : IAllatok
    {
        public long Multiple(int a, int b)
        {
            return a * b;
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

        //public Matek(int a, int b)
        //{
        //}
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Matek matek = new Matek();
            Console.WriteLine(matek.Multiple(10, 10));
            Console.WriteLine(matek.Add(1,2));
        }
    }
}
