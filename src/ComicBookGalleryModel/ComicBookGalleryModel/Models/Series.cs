using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class Series
    {

        public Series()
        {
            // Ensures that the ComicBooks property is ready to be used after instantiating
            // a Series entity object
            ComicBooks = new List<ComicBook>();
        }

        // including an id is important so EF will know that we intend
        // the data for the series entity to be stored in its own table
        // if not, EF would treat Series class as a complex type
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Since a series can be associated with more than one ComicBook
        // we need to define the navigation property as a collection
        public ICollection<ComicBook> ComicBooks { get; set; }
    }
}
