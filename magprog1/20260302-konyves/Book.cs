using System;

// Óra elejen nem írtam bele mindent mert az aries.ektf.hu-val szenvedtem mert mobilnetről nem tölt be se nekem se rolandnak xd

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
                if (value.Length < 3 || value.Length > 20)
                    this._author = value.Substring(0, 20);
                //throw new ArgumentException("A név hosszának 3 és 20 közöttinek kell lennie!");
                var reszek = value.Split(' ');
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
                return this._publishDate;
            }
            set
            {
                //kimaradt
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
                //Kimaradt
            }
        }
        // public ..... genre_enum deklarálása;
        public bool isEbook = false;
        private bool _isSetPrice;
        public bool isSetPrice
        {
            get
            {
                return this._isSetPrice;
            }
        }

        public genreEnum Genre;

        // Kell egy priavate Book konstruktor, param nélkül
        //Konstruktorok megírása!!! 3+1

        public Book() { }

        private Book(string author, string title)
        {
            // Kötelező a propertyt hívni
            this.Author = author;
            this.Title = title;
            this._isSetPrice = false;
        }

        public Book(string author, string title, int price) : this(author, title) // Meghívjuk a felette lévő konstruktort
        {
            this.Price = price;
        }

        public Book(string author, string title, int price, genreEnum genre, bool ebooke, DateTime publish) : this(author, title, price) // Meghívjuk a felette lévő konstruktort
        {
            this.Genre = genre;
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
                return clone;
            }
        }

        public override string ToString()
        {
            return $"Book[" +
                $"author='{Author}'," +
                $"title='{Title}'," +
                $"price='{(isSetPrice ? Price.ToString() + " HUF" : "N/A")}'," +
                $"genre='{this.Genre}'," +
                $"ebook='{(isEbook ? "yes" : "no")}'" +
                $"]";
        }
        public override int GetHashCode()
        {
            return 1; //Mikor azonos két könyv?

            // A GetHashCode az most.. inkabb elmondom.
            // text kent kapunk meg egy adatot, azokat parsoljuk enum int stb
            // az enum vissza adja a text referenciajat, bele pakolja ebbe, 
            // bullshit amit alapbol az equalsba kérnek, pl a lista nem nézi a GetHashCode() nem fog működni,
            // ez akkor kell ha Dictionary, SortedSet
            // A hash szám összeadas hulyeseg, HashCode.Combine(...params) amit használni érdemes
            
        }
        public override bool Equals(object obj)
        {
            if(obj is null)
            {
                return false;
            }

            if(obj is not Book)
            {
                return false;
            }

            Book MyBook = (Book)obj;

            return this.Author == MyBook.Author && this.Title == MyBook.Title && this.isEbook == MyBook.isEbook;
            // ennyi lenn, DE: ha ezt nem írjuk meg sose lehet két obj egyenlo
        }
    }
}
