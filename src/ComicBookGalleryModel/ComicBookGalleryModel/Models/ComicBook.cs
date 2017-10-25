using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    // Each ComicBook belongs to a series
    public class ComicBook
    {

        public ComicBook()
        {
            Artists = new List<ComicBookArtist>();
        }

        public int Id { get; set; }
        public int SeriesId { get; set; } // foreign key property
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal? AverageRating { get; set; } // '?' makes prop to be nullable, making DB table add a null allowed column
        
        public Series Series { get; set; } // Many-to-One relationship

        public ICollection<ComicBookArtist> Artists { get; set; } // we define that this entity objet has many Artists

        // EF will ignore when generating the in memory representation of the model
        // any property that don't define a setter
        public string DisplayText
        {
            get
            {
                return $"{Series?.Title} #{IssueNumber}"; // using ? will cause the Series property to be check if it's null, if it is, return null, else return the value of the title property
            }
        }


        public void AddArtist(Artist artist, Role role)
        {
            Artists.Add(new ComicBookArtist()
            {
                Artist = artist,
                Role = role
            });
        }

    }
}
