using konyvespolc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyves
{
    internal class BookShelfHashSet
    {
        private HashSet<Book> bookShelf;
        public BookShelfHashSet()
        {
            
            bookShelf = new HashSet<Book>();
        }
        public void Load(List<Book> newBooks)
        {
            foreach (var item in newBooks)
            {
                if (item == null)
                    throw new ArgumentException("The value cannot be null!");
                bookShelf.Add(item);

            }
        }

        public void Load(HashSet<Book> newBooks)
        {
            foreach (var item in newBooks)
            {
                if (item == null)
                    throw new ArgumentException("The value cannot be null!");
                bookShelf.Add(item);
            }
        }
        public void AddBook(Book book)
        {
            
            bookShelf.Add(book);

        }
        public int priceSum
        {
            get
            {
                // Csak olvasható property. Lambdával kellene! :-)
                int sumprice = bookShelf.Sum(x => x.isSetPrice ? x.Price : 0);
                return sumprice;
            }
        }

        public HashSet<Book> GetBooks()
        {
            return bookShelf;
        }
        public HashSet<Book> Search(string name)
        {
            HashSet<Book> authorBooks = new HashSet<Book>(); //Meghagytam, triviális 
            foreach (var item in bookShelf)
            {
                if (item.Author.Equals(name))
                    authorBooks.Add(item);
            }
            return authorBooks;
        }
    }
}

