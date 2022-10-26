using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MovieDatabase_EF_Console.Models
{
    public partial class MovieDBContext : DbContext
    {
        public MovieDBContext()
        {
        }

        public MovieDBContext(DbContextOptions<MovieDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=MovieDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Genre).HasMaxLength(20);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
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