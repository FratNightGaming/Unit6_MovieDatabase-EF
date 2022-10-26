using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase_EF_Console.Models
{
    public class MovieCRUD
    {
        MovieDBContext dbContext = new MovieDBContext();
        public void MovieSelector()
        {
            bool runApplication = true;
            while (runApplication)
            {
                Console.WriteLine("Welcome to Blockbuster!");
                Console.WriteLine("Search for movie. Enter \"Title\" or \"Genre\":");

                string input = Console.ReadLine().ToUpper().Trim();

                if (input == "T" || input == "TITLE")
                {
                    Console.WriteLine("Enter the title of the movie:");
                    string titleInput = Console.ReadLine().ToUpper().Trim();

                    List<Movie> movies = SearchByTitle(titleInput);
                    DisplayMovies(movies);
                }

                else if (input == "G" || input == "GENRE")
                {
                    DisplayGenreList();
                    string genreInput = Console.ReadLine().ToUpper().Trim();

                    List<Movie> movies = SearchByGenre(genreInput);
                    DisplayMovies(movies);
                }

                else
                {
                    Console.WriteLine("Input not valid. Please try again.");
                    continue;
                }

                runApplication = Continue();
            }

            
        }

        public void DisplayGenreList()
        {
            Console.WriteLine("Genres to select:\n");

            Console.WriteLine("Drama");
            Console.WriteLine("Action");
            Console.WriteLine("Romance");
            Console.WriteLine("Sci-Fi");
            Console.WriteLine("Fantasy");
            Console.WriteLine("Horror");
            Console.WriteLine("Comedy");

            Console.WriteLine("\nType the genre you'd like to view below:\n ");
        }

        public List<Movie> SearchByTitle(string userInput)
        {
            List<Movie> moviesByTitle = dbContext.Movies.Where(x => x.Title.ToUpper() == userInput).ToList();
            
            if (moviesByTitle.Count > 0)
            {
                Console.WriteLine($"{userInput} Found");

                //DisplayMovies(moviesByTitle);
            }

            else
            {
                Console.WriteLine($"{userInput} not found");
            }
            
            return moviesByTitle;
        }

        public List<Movie> SearchByGenre(string userInput)
        {
            List<Movie> moviesByGenre = dbContext.Movies.Where(x => x.Genre.ToUpper() == userInput).ToList();

            if (moviesByGenre.Count > 0)
            {
                Console.WriteLine($"{userInput} Found");

                //DisplayMovies(moviesByTitle);
            }

            else
            {
                Console.WriteLine($"Genre - {userInput} - not found");
            }

            return moviesByGenre;
        }

        public void DisplayMovies(List<Movie> movies)
        {
            Console.WriteLine("Movies displayed below: \n\n");
            
            foreach (Movie movie in movies)
            {
                Console.WriteLine($"{movie.Id, -5} - Title: {movie.Title, -20} Genre: {movie.Genre, -15} Runtime: {movie.Runtime, -5} min");
            }
        }

        public bool Continue()
        {
            Console.WriteLine("Would you like to search for movies again? Y/N:");

            while (true)
            {
                string input = Console.ReadLine().ToUpper().Trim();
                
                if (input == "Y" || input == "YES")
                {
                    return true;
                }

                else if (input == "N" || input == "NO")
                {
                    Console.WriteLine("Thank you for coming to Blockbuster. Enjoy the rest of your day!");
                    return false;
                }

                else
                {
                    Console.WriteLine("Input not valid. Please enter Y/N:");
                    continue;
                }
            }
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