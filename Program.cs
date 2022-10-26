using MovieDatabase_EF_Console.Models;
using System.Runtime.Intrinsics.X86;

namespace MovieDatabase_EF_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PopulateMovieTable();//call this function once then comment it out

            MovieCRUD movieCRUD = new MovieCRUD();
            movieCRUD.MovieSelector();

        }
        //function will be called only once to connect list to ssms
        public static void PopulateMovieTable()
        {
            //List<Movie> movies = new List<Movie>();
            MovieDBContext dbContext = new MovieDBContext();

            dbContext.Movies.Add(new Movie {Title = "Harry Potter", Genre = "Fantasy", Runtime = 118});
            dbContext.Movies.Add(new Movie {Title = "Halloween", Genre = "Horror", Runtime = 96 });
            dbContext.Movies.Add(new Movie {Title = "Inception", Genre = "Action", Runtime = 153 });
            dbContext.Movies.Add(new Movie {Title = "Interstellar", Genre = "Sci-Fi", Runtime = 142 });
            dbContext.Movies.Add(new Movie {Title = "Meet The Parents", Genre = "Comedy", Runtime = 104 });
            dbContext.Movies.Add(new Movie {Title = "Batman", Genre = "Action", Runtime = 138 });
            dbContext.Movies.Add(new Movie {Title = "Mean Girls", Genre = "Comedy", Runtime = 149 });
            dbContext.Movies.Add(new Movie {Title = "Titanic", Genre = "Romance", Runtime = 191 });

            dbContext.SaveChanges();
        }

    }
}
/*Build Specifications:

Use Database First and create a movie database. The database should contain a table named “Movies” with the following Columns: 
	int Id - Primary Key
	nvarchar(50) Title
    nvarchar(20) Genre
    float Runtime 

Create a static function in your program class that populates your table with 10 to 15 movies. Call this function from your main; run it; then remove the call from your main so it doesn’t run again.

Add two static methods to your Movie class:

SearchByGenre: This method will return a list of Movie instances that match the genre.

SearchByTitle: This method will return a list of Movie instances that match the title.

Hint: Use the.ToList() method on the table to get it into list format.


Write a console application that displays a menu and asks the user whether they wish to search by genre or title. Then allow the user to enter either genre or title respectively. Call the appropriate method to retrieve the movies. Print out the movie information to the console.
Tip: Include a ToString() method in your Movie class to make printing easier.
*/