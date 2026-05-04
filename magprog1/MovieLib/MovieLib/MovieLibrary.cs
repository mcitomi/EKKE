using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    internal class MovieLibrary : IEnumerable<Movie>
    {
        List<Movie> movies = new List<Movie>();
        public delegate bool MovieFilter(Movie m);

        public void Add(Movie m)
        {
            movies.Add(m);
        }

        public List<Movie> FilterMovies(MovieFilter filter)
        {
            List<Movie> res = new List<Movie>();

            foreach (Movie m in movies)
            {
                if(filter(m))
                {
                    res.Add(m);
                }
            }

            return res;
        }

        

        public IEnumerator<Movie> GetEnumerator()
        {
            foreach (Movie m in movies)
            {
                if(m.Rateing < 7)
                {
                    yield return m;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
