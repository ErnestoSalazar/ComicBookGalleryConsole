using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {

                Series series1 = new Series()
                {
                    Title = "The Amazing Spider-Man"
                };
                Series series2 = new Series()
                {
                    Title = "The Invincible Iron Man"
                };

                Artist artist1 = new Artist()
                {
                    Name = "Stan Lee"
                };

                Artist artist2 = new Artist()
                {
                    Name = "Steve Ditko"
                };

                Artist artist3 = new Artist()
                {
                    Name = "Jack Kirby"
                };

                Role role1 = new Role()
                {
                    Name = "Script"
                };

                Role role2 = new Role()
                {
                    Name = "Pencils"
                };


                ComicBook comicBook1 = new ComicBook()
                { // The first time that we access the context ComicBook DbSet property
                    // EF will check if the DB exists and if not, it will create it
                    Series = series1,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                };

                comicBook1.AddArtist(artist1, role1);
                comicBook1.AddArtist(artist2, role2);


                ComicBook comicBook2 = new ComicBook()
                {

                    Series = series1,
                    IssueNumber = 2,
                    PublishedOn = DateTime.Today
                };

                comicBook2.AddArtist(artist1, role1);
                comicBook2.AddArtist(artist2, role2);


                ComicBook comicBook3 = new ComicBook()
                {
                    Series = series2,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                };

                comicBook3.AddArtist(artist1, role1);
                comicBook3.AddArtist(artist3, role2);

                // we add a new ComicBook to the context ComicBooks property
                // The first time that we access the context ComicBook DbSet property
                // EF will check if the DB exists and if not, it will create it
                context.ComicBooks.Add(comicBook1);
                context.ComicBooks.Add(comicBook2);
                context.ComicBooks.Add(comicBook3);

                context.SaveChanges();

                var comicBooks = context.ComicBooks
                    .Include(cb => cb.Series)
                    .Include(cb => cb.Artists.Select(a => a.Artist)) // include the associated artist and role data for each bridge entity instance
                    .Include(cb => cb.Artists.Select(a => a.Role))
                    .ToList(); // retireve all comic books from the database (no particular order)

                foreach(var comicBook in comicBooks)
                {
                    List<string> artistRoleNames = comicBook.Artists
                        .Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                    var artisRoletDisplayText = string.Join(", ", artistRoleNames);

                    Console.WriteLine(comicBook.DisplayText);
                    Console.WriteLine(artisRoletDisplayText);
                }
                Console.ReadLine();
            }

                // retrieve data
                //context.Dispose(); // we're letting EF know that database connection can be closed
        }
    }
}
