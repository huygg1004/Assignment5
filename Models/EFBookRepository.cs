using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5_Database.Models
{
    public class EFBookRepository : BookRepository
    {
        private BookstoreDbContext _context;
        //Constructor
        public EFBookRepository (BookstoreDbContext context)
        {
            _context = context;
        }
        public IQueryable<Book> Books => _context.Books;
    }
}
