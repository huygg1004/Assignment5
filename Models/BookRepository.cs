using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5_Database.Models
{
    public interface BookRepository
    {
        IQueryable<Book> Books { get;  }
    }
}
