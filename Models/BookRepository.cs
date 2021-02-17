using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5_Database.Models
{
    //this class helps us querry the data in the database
    public interface BookRepository
    {
        IQueryable<Book> Books { get;  }
    }
}
