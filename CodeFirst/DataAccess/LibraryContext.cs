using CodeFirst.Entities;
using CodeFirst.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DataAccess
{
    public class LibraryContext:DbContext
    {
        public LibraryContext()
            :base("MyLibraryDb")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
