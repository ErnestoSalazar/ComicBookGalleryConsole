using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class Artist
    {
        public Artist()
        {
            ComicBooks = new List<ComicBookArtist>();
        }

        public int Id { get; set; }
        [Required,StringLength(100)] // we make the Name property to be required (not null)
        public string Name { get; set; }
        
        //[NotMapped] // EF will ignore this set property when generating the in memory representation of the model
        //public string Test { get; set; }

        public ICollection<ComicBookArtist> ComicBooks { get; set; } // we define that this entity objet has many ComicBooks
    }
}
