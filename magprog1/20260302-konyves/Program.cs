using konyvespolc;
using static System.Reflection.Metadata.BlobBuilder;

internal class Program
{
   
        static void Main(string[] args)
        {
            Bookshelf p = new Bookshelf();
        //Példa:
            DateTime tempNow= DateTime.Now;
            Book b1 = new Book("Barbie Baba", "OOP Programming in C#", 5000, genre_enum.mese, false, tempNow);
            Book b2 = new Book("Barbie Baba", "OOP Programming in C#", 5000, genre_enum.mese, false, tempNow);
            Console.WriteLine(b1 == b2);
            Console.WriteLine(b1.Equals(b2)); //Mikor egyenlő két könyv? Mitől függ???

            Random rn = new Random();
            string[] nev = { "John Tolkien", "Mikszath Kalman", "Stephen Hawking", "JK Rowling", "Gardonyi Géza", "Dan Brown" };
            string[] cim = { "Harry Potter", "Szent Péter esernyője", "Egri Csillagok", "Da Vinci kód", "Brief History of time" };
            for (int i = 0; i < 40; i++)
            {
                int f = rn.Next(Enum.GetNames(typeof(genre_enum)).Length);
                Book temp = new Book(nev[rn.Next(nev.Count())], cim[rn.Next(cim.Count())], rn.Next(180, 3001) * 5, ((genre_enum)(f)), rn.Next(2) == 0, new DateTime(rn.Next(1910, DateTime.Now.Year), rn.Next(1, 12), rn.Next(1, 28)));
                p.AddBook(temp);
            }


            Console.WriteLine($"A könyvespolc összértéke:",????); //A kérdőjelek helyére kell egy property!
            Console.WriteLine("\nKinek a könyveit akarod kikeresni? (a sorszámot írd): ");
            for (int i = 0; i < nev.Length; i++)
            {
                Console.Write($"{i + 1} {nev[i]}, ");
            }
            Console.WriteLine();
            int keres = int.Parse(Console.ReadLine());
            Console.WriteLine(p.Search(nev[keres - 1]));
            foreach (var item in p.Search(nev[keres - 1]))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nAz adott dátum előtti könyvek listája:");
            foreach (var item in p.booksOnShelf)
            {
                if (item.PublishDate < DateTime.Now)
                Console.WriteLine(item);
        }
        StreamReader input = new StreamReader("books.csv");
        //...................
        input.Close();

        }
    
}

