using System;
using System.Collections.Generic;
using System.Linq;

namespace konyvespolc
{
    class Bookshelf
    {
        public List<Book> booksOnShelf;//Kérdés: Kell ide static?
        public Bookshelf()
        {
            //Kimaradt...
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
                return 1;
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
    }
}
