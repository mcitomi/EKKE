using static System.Net.WebRequestMethods;

namespace MovieLib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Movie> list = new List<Movie>();

            list.Add(new Movie("The Shawshank Redemption", "Frank Darabont", 1994, 9.3));
            list.Add(new Movie("The Godfather", "Francis Ford Coppola", 1972, 9.2));
            list.Add(new Movie("The Dark Knight", "Christopher Nolan", 2008, 9.0));
            list.Add(new Movie("Pulp Fiction", "Quentin Tarantino", 1994, 8.9));
            list.Add(new Movie("Inception", "Christopher Nolan", 2010, 6.8));
            list.Add(new Movie("The Matrix", "Lana Wachowski", 1999, 8.7));

            foreach (Movie movie in list)
            {
                Console.WriteLine(movie);
            }

        }
    }
}
