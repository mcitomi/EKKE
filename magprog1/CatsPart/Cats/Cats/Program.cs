using Cats;

internal class Program
{
    private static void Main(string[] args)
    {
        const int CATM = 10;
        Cat myCat = new Cat("Cirmi", 3, "CiT");
        Cat myCat2 = new Cat("Cirmi2", 3, "CeT");
        Console.WriteLine(myCat < myCat2);
        Console.WriteLine(myCat > myCat2);

        CatHotel ch = new CatHotel();

        //Cat k1 = new Cat(); //private...
        Random rn = new Random();


        Dictionary<string, Cat> dct = new Dictionary<string, Cat>(); //Ez még menne?
        Cat mother = new Cat("Mother", 10, "Cat"); //Ez macska anyával...
        Console.WriteLine(mother);
        ch.AddCat(mother);
        for (int i = 0; i < CATM - 3; i++)
        {
            Cat child = mother.Clone();
            child.SetName(((char)rn.Next(65, 91)).ToString() + ((char)rn.Next(65, 91)).ToString());
            child.Age = Convert.ToByte(rn.Next(10));
            child.ChipID = "CAT";
            child.Mother = mother;
            ch.AddCat(child);
        }
        for (int i = 0; i < CATM - 7; i++)
        {
            HouseCat child = new HouseCat(mother, rn.Next(1, 21));
            child.SetName(((char)rn.Next(65, 91)).ToString() + ((char)rn.Next(65, 91)).ToString());  //ne az anyja neve legyen, hanem valami random
            child.Age = Convert.ToByte(rn.Next(10));
            child.ChipID = "CiT";
            child.Mother = mother;
            ch.AddCat(child);//Mi lesz az ID-vel???
        }
        foreach (Cat catitems in ch.GetAllCats())
            Console.WriteLine(catitems);

        if (ch.Exist(mother))
            Console.WriteLine("Exist");
        List<Cat> sorted = ch.Ordered();
        Console.WriteLine("Sorted:");
        foreach (Cat item in sorted)
            Console.WriteLine(item);
        Console.WriteLine("Enter an index");
        int index = int.Parse(Console.ReadLine());
        Console.WriteLine(ch[index]);
        Cat tesztclone = ch[1];
        Cat teszt2 = tesztclone.Clone();
        if (tesztclone.Equals(teszt2))
            Console.WriteLine("Hja, identical");
        if (ch.Exist(ch[2]))
            Console.WriteLine("There is");
        Cat k3 = new Cat();
        k3.Age = 6;
        k3.ChipID = "CiT";
        Cat k4 = new Cat();
        k4.Age = 6;
        k4.ChipID = "CuT";
        if (k3 < k4) //compare two cats
            Console.WriteLine("k3 is smaller");
        // ch[11] = tesztclone;//This is not okay? Why? Add is enough.

        Console.ReadKey();

    }
}