using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    internal class Movie
    {
        string _title;
        //string _director;
        int _year;
        double _rateing;

        public string Title
        {
            get { return _title; }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("A cím nem lehet üres");
                }

                _title = value;
            }
        }

        public string Director { get; set; }
        public int Year
        {
            get { return _year; }
            set
            {
                if(value < 1900 || value > DateTime.Now.Year)
                {
                    throw new ArgumentOutOfRangeException("Az évszám nem lehet kisebb mint 1900 vagy nagyobb mint a jelenlegi év");
                }

                _year = value;
            }
        }

        public double Rateing
        {
            get { return _rateing; }
            set
            {
                if(value > 10 || value < 1)
                {
                    throw new ArgumentOutOfRangeException("Az értékelés 0-10 között kell megadni");
                }
            }
        }

        public Movie(string title, string director, int year, double rateing)
        {
            _title = title;
            Director = director;
            _rateing = rateing;
            _year = year;
        }

        public override string ToString()
        {
            return $"{Title} - {Director} - {Year} - {Rateing}";
        }
    }
}
