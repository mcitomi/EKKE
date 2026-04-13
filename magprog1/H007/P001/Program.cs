namespace P001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("allatok.csv");
            //ha van fejléc az a sort átugrojuk
            sr.ReadLine();
            AllatBolt bolt = new AllatBolt();
            bolt.BoltTulaj = "Gunics Roland";

            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adatok= sor.Split(';');

                switch (adatok[0])
                {
                    case "A":
                        Allat allat = new Allat(
                            adatok[1], adatok[2],
                            (Faj)Enum.Parse(typeof(Faj), adatok[3]),
                            (adatok[4] == "true" ? true : false));
                        bolt.AddAllat(allat);
                        
                        break;

                    case "F":
                        Allat farm_allat = new FarmAllat(
                            adatok[1], adatok[2],
                            (Faj)Enum.Parse(typeof(Faj), adatok[3]),
                            (adatok[4] == "true" ? true : false),
                            int.Parse(adatok[5])
                            );

                        bolt.AddAllat(farm_allat);

                        break;

                    default:
                        break;
                }
            }
            sr.Close();

            //Jelenítse meg a megvalósított lekérdezéseket

            Console.WriteLine("A későnm kelő farm állatok");
            List<FarmAllat> kesonKelo = bolt.KesoNKeloFarmAllat;
            foreach (var allat in kesonKelo)
            {
                Console.WriteLine(allat);
            }

            Console.WriteLine("Adott Tulaj allatai");
            List<Allat> tulajAllatai = bolt.AdottTulajAllatok("Roland");
            foreach (var allat in tulajAllatai)
            {
                Console.WriteLine(allat);
            }

            Allat indexelt = bolt["SWR"];
            Console.WriteLine("Az SWR azonosítójú állat");
            Console.WriteLine(indexelt);
        }
    }
}
