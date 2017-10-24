using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel
{
    public class Context : DbContext // we need to inherit from EF DbContext
    {

        // we create a constructor to pass to the base class the name of
        // the DB that we want as a string
        //public Context() : base(@"")
        //{

        //}

        public Context()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }


        public DbSet<ComicBook> ComicBooks { get; set; }
    }
}
