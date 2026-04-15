namespace H008
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SzamkitalaloJatek jatek = new SzamkitalaloJatek(10, 100);

            jatek.VersenyzoFelvetele(new VeletelenTippelo());
            jatek.VersenyzoFelvetele(new VeletelenTippelo());
            jatek.VersenyzoFelvetele(new BejaroTippelo());
            jatek.VersenyzoFelvetele(new LogaritmikusKereso());
            jatek.VersenyzoFelvetele(new LogaritmikusKereso());

            jatek.Jatek();
        }
    }
}
