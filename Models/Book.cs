using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5_Database.Models
{
    //this creates the model book along with required validation and ISBN regular expresssion and set primary key for book id
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please enter Title field")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter Author field")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please enter Publisher field")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Please enter ISBN field")]
        [RegularExpression(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$", ErrorMessage = "Not a valid ISBN number")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Please enter Classification field")]
        public string Classification { get; set; }

        [Required(ErrorMessage = "Please enter Category field")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please enter Price field")]
        public double Price { get; set; }
      

    }
}
