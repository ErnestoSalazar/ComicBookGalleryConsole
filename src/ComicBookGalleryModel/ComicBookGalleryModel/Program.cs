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
