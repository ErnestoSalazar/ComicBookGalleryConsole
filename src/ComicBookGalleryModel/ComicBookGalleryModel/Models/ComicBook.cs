using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    // Each ComicBook belongs to a series
    public class ComicBook
    {
        public int Id { get; set; }
        public Series Series { get; set; } // Many-to-One relationship
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal? AvarageRating { get; set; } // '?' makes prop to be nullable, making DB table add a null allowed column

    }
}
