using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            // context makes connection with the Database that is an unmanaged memory so we use it inside using block 
            using (var context = new Context())
            {

                context.Database.Log = (message) => Debug.WriteLine(message);

                //var comicBooks = context.ComicBooks.ToList();

                //var comicBooksQuery = from cb in context.ComicBooks select cb; // this query won't be called until we call ToList()
                //var comicBooks = comicBooksQuery
                //    .Include(cb => cb.Series)
                //    .OrderByDescending(cb => cb.IssueNumber)
                //    .ThenBy(cb => cb.PublishedOn)
                //    .ToList();

                // .Where(cb => cb.IssueNumber == 1 && cb.Series.Title == "The Amazing Spider-Man")

                var comicBooksQuery = context.ComicBooks
                    .Include(cb => cb.Series)
                    .OrderByDescending(cb => cb.IssueNumber);

                var comicBooks = comicBooksQuery.ToList();

                var comicBooks2 = comicBooksQuery.Where(cb => cb.AverageRating < 7)
                    .ToList();

                foreach (var comicBook in comicBooks)
                {
                    Console.WriteLine(comicBook.DisplayText);
                }


                Console.WriteLine();
                Console.WriteLine("# of comic books; {0}", comicBooks.Count);
                Console.WriteLine();

                foreach (var comicBook in comicBooks2)
                {
                    Console.WriteLine(comicBook.DisplayText);
                }

                Console.WriteLine();
                Console.WriteLine("# of comic books; {0}", comicBooks2.Count);

                //var comicBooks = context.ComicBooks
                //    .Include(cb => cb.Series)
                //    .Include(cb => cb.Artists.Select(a => a.Artist)) // include the associated artist and role data for each bridge entity instance
                //    .Include(cb => cb.Artists.Select(a => a.Role))
                //    .ToList(); // retireve all comic books from the database (no particular order)

                //foreach(var comicBook in comicBooks)
                //{
                //    List<string> artistRoleNames = comicBook.Artists
                //        .Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                //    var artisRoletDisplayText = string.Join(", ", artistRoleNames);

                //    Console.WriteLine(comicBook.DisplayText);
                //    Console.WriteLine(artisRoletDisplayText);
                //}
                Console.ReadLine();
            }

                // retrieve data
                //context.Dispose(); // we're letting EF know that database connection can be closed
        }
    }
}
