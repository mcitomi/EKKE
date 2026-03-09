using Konyves;
using System;
namespace konyvespolc
{
    class Book
    {
        private static int ID = 1; //A static mit is jelent?

        private int id;
        public int Id
        {
            get { return id; }
            private set
            {
                if (value < 1)
                    throw new Exception("The Id cannot be equals or less than 1!");
                id = value;
            }
        }

        private string _author; //első betű nagxbetűsnek kell lennie!!!!!!
        public string Author
        {
            get
            {
               return _author;
            }
            set
            {
                if (value.Length > 20)
                    this._author = value.Substring(0, 20);
                    //throw new ArgumentException("A név hosszának 3 és 20 közöttinek kell lennie!");
                string[] reszek = value.Split(' ');
                if (!char.IsAsciiLetterUpper(reszek[0][0]) || !char.IsAsciiLetterUpper(reszek[1][0]))
                    throw new ArgumentException("Nem nagybetűs");
                if (value.Length < 2)
                    throw new ArgumentException("Túl kicsi (<2)");
                //Kimaradt rész. Az első betűk nagybetűk, legalább 2 karakter 
                this._author = value;
            }
        }
        private string _title;
        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                if (value.Length < 3 || value.Length > 50)
                    throw new ArgumentException("A cím hosszának 3 és 50 közöttinek kell lennie!");
                this._title = value;
            }
        }
        private DateTime _publishDate;
        public DateTime PublishDate
        {
            get
            {
                return _publishDate;
            }
            set
            {
                if (value > DateTime.Now)
                    throw new Exception("Túl nagy a dátum");
                _publishDate = value;
            }
        }
        private int _price;
        public int Price
        {
            get
            {
                return this._price;
            }
            set
            {
                if (value > 15000 || value % 5 != 0)
                    throw new ArgumentException("Nem megfelelő ár");
                this._price = value;
                _isSetPrice = true;
            }
        }
       
        public bool isEbook = false;
        private bool _isSetPrice;
        public bool isSetPrice
        {
            get
            {
                return this._isSetPrice;
            }
        }

        public genre_enum Genre;
        private Book()
        { 
        }

        //Szerző és cím(itt az isSetPrice értéke legyen false)

        public Book(string author, string title)
        {
            this.Author = author;
            this.Title = title;
            this._isSetPrice = false;
            this.Id = ID++;
        }

        public Book(string author, string title, int price):this(author, title)
        {
            this.Price = price;
        }

        public Book(string author, string title, int price, genre_enum genr, bool ebooke, DateTime publish ) 
            : this(author, title, price)
        {
            this.Genre = genr;
            this.isEbook = ebooke;
            this.PublishDate = publish;
        }
        public Book Clone
        {
            get
            {

                //return new Book(this.author, this.title, 
                //    this.price, this.genre); //Ez működik vajon?  Egyébként jobb, ha a Clone az Clone(). :-)
                Book clone = new Book();
                clone.Author = this.Author;
                clone.Title = this.Title;
                clone.Price = this.Price;
                clone.Genre = this.Genre;
                clone.isEbook= this.isEbook;
                clone.PublishDate = this.PublishDate; clone.id = this.id;

                return clone;
            }
        }

        public override string ToString()
        {

            return $"Book[" +
                $"Id='{Id}" +
                $"author='{Author}'," +
                $"title='{Title}'," +
                $"price='{(isSetPrice ? Price.ToString() + " HUF" : "N/A")}'," +
                $"genre='{this.Genre}'," +
                $"ebook='{(isEbook ? "yes" : "no")}'" +
                $"]";
        }
        public override int GetHashCode()
        {
            // Összeadással hülyeség ez, Combine 👍
            // összeadással lehetne két ugyan olyan hashcode

            return HashCode.Combine(this._author, this._title.GetHashCode(),this.isEbook);
        }
        /*public override int GetHashCode()
        {
            return 1; //Mikor azonos két könyv?
        }*/
        /*public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (obj is not Book)
                return false;
            Book MyBook = (Book)obj;
            return this.Author == MyBook.Author && this.Title == MyBook.Title && MyBook.isEbook == this.isEbook;
        }*/
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj is null)
                return false;
            if (obj is not Book)
                return false;
            Book MyBook = (Book)obj;
            return this.Author.GetHashCode() == MyBook.Author.GetHashCode() && this.Title.GetHashCode() == MyBook.Title.GetHashCode() && MyBook.isEbook.GetHashCode() == this.isEbook.GetHashCode();   
        }
    }
}
