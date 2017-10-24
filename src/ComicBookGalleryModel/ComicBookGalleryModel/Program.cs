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
                // we add a new ComicBook to the context ComicBooks property
                context.ComicBooks.Add(new ComicBook()
                { // The first time that we access the context ComicBook DbSet property
                    // EF will check if the DB exists and if not, it will create it
                    Series = new Series()
                    {
                        Title = "The Amazing Spider-Man"
                    },
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                });

                context.SaveChanges();

                var comicBooks = context.ComicBooks
                    .Include(cb => cb.Series)
                    .ToList(); // retireve all comic books from the database (no particular order)

                foreach(var comicBook in comicBooks)
                {
                    Console.WriteLine(comicBook.Series.Title);
                }
                Console.ReadLine();
            }

                // retrieve data
                //context.Dispose(); // we're letting EF know that database connection can be closed
        }
    }
}
