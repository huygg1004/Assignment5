using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5_Database.Models
{
    public class BookstoreDbContext : DbContext
    {
        //this class helps us set up services necessary
        public BookstoreDbContext (DbContextOptions<BookstoreDbContext> options) : base(options)
        {
                
        }
        public DbSet<Book> Books { get; set; }

    }
}
