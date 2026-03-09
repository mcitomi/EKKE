using System;
using System.Collections.Generic;
using System.Linq;

namespace konyvespolc
{
    class Bookshelf
    {
        private List<Book> booksOnShelf;//Kérdés: Kell ide static?
        public Bookshelf()
        {
            booksOnShelf = new List<Book>();
        }
        public void Load(List<Book> newBooks)
        {
            foreach (var item in newBooks)
            {
                if (item == null)
                    throw new ArgumentException("The value cannot be null!");
                else if (!booksOnShelf.Contains(item))
                    booksOnShelf.Add(item);
            }
        }
        public void AddBook(Book book)
        {
            //Ide kell egy if
            booksOnShelf.Add(book);
        }
        public int priceSum
        {
            get
            {
                // Csak olvasható property. Lambdával kellene! :-)


                return booksOnShelf.Where(x => x.isSetPrice).Sum(x => x.Price);
            
            }
        }
        public List<Book> Search(string name)
        {
            List<Book> authorBooks = new List<Book>(); //Meghagytam, triviális 
            foreach (var item in booksOnShelf)
            {
                if (item.Author.Equals(name))
                    authorBooks.Add(item);
            }
            return authorBooks;
        }

        public List<Book> GetAllBooks()
        {
            Book myBook = booksOnShelf[0].Clone;
            myBook.Author = "Malacka Géza";
            Console.WriteLine(booksOnShelf[0].Author); // Egyenlővé tettük a két objektumot, ezért átírja a listában is. Memória. 
            // //  De ha klónuzzok nem íródik át a listába

            return booksOnShelf;
        }
    }
}
