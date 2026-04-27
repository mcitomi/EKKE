using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerator_Example1
{
    class Library : IEnumerable<Book>
    {
        private List<Book> books = new List<Book>();

        public void Add(Book b)
        {
            books.Add(b);
        }

        IEnumerator IEnumerable.GetEnumerator() //Ez kell!!!
        {
            return GetEnumerator();
        }
        //egy lekérdezést, sorozatot ad vissza. 
        //csak akkor dolgozik, amikor kérünk egy elemet, nem készül teljes lista, "on-demand” működik
        public IEnumerator<Book> GetEnumerator() //Ennek a neve kötött. Book-okat ad vissza, kérés.re
        {
            foreach (var book in books)
            {
                if (book.Pages > 200)
                    yield return book;
            }
        }
        //Ha ezt írnánk, amit eddig írtunk:
        /*public List<Book> GetBigBooks()
         {
              return books.Where(b => b.Pages > 200).ToList();
         }
         * AZONNAL végigmenne az összes elemen, létrehozna egy új listát, ami memória + idő költség igényes.
         */
        //Miért jó?
        // nagy adathalmaz esetén, adat streaming (pl. fájl olvasás soronként), LINQ láncolás, részleges feldolgozás (Take(1)),        adatbázis / API-s gondolkodás
         
        
    }
}
