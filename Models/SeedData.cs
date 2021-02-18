using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5_Database.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            //this class provide the data in the database for us to display on the index page
            BookstoreDbContext context = application.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<BookstoreDbContext>();

            //create migration
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                       new Book
                       {
                           Title = "Les Miserables",
                           Author_First = "Victor",
                           Author_Last = "Hugo",
                           Publisher = "Signet",
                           ISBN = "978-0451419439",
                           Classification = "Fiction",
                           Category = "Classic",
                           Price = 9.95
                       },
                        new Book
                        {
                            Title = "Team of Rivals",
                            Author_First = "Doris",
                            Author_Last = "Kearns Goodwin",
                            Publisher = "Simon & Schuster",
                            ISBN = "978-0743270755",
                            Classification = "Non-Fiction",
                            Category = "Biography",
                            Price = 14.58
                        },
                        new Book
                        {
                            Title = "The Snowball",
                            Author_First = "Alice",
                            Author_Last = "Schroeder",
                            Publisher = "Bantam",
                            ISBN = "978-0553384611",
                            Classification = "Non-Fiction",
                            Category = "Biography",
                            Price = 21.54
                        },
                        new Book
                        {
                            Title = "American Ulysses",
                            Author_First = "Ronald",
                            Author_Last = "C. White",
                            Publisher = "Random House",
                            ISBN = "978-0812981254",
                            Classification = "Non-Fiction",
                            Category = "Biography",
                            Price = 11.61
                        },
                        new Book
                        {
                            Title = "Unbroken",
                            Author_First = "Laura",
                            Author_Last = "Hillenbrand",
                            Publisher = "Random House",
                            ISBN = "978-0812974492",
                            Classification = "Non-Fiction",
                            Category = "Historical",
                            Price = 13.33
                        },
                        new Book
                        {
                            Title = "The Great Train Robbery",
                            Author_First = "Michael",
                            Author_Last = "Crichton",
                            Publisher = "Vintage",
                            ISBN = "978-0804171281",
                            Classification = "Fiction",
                            Category = " Historical Fiction",
                            Price = 15.95
                        },
                        new Book
                        {
                            Title = "Deep Work",
                            Author_First = "Cal",
                            Author_Last = "Newport",
                            Publisher = "Grand Central Publishing",
                            ISBN = "978-1455586691",
                            Classification = "Non-Fiction",
                            Category = "Self-Help",
                            Price = 14.99
                        },
                        new Book
                        {
                            Title = "It's Your Ship",
                            Author_First = "Michael",
                            Author_Last = "Abrashoff",
                            Publisher = "Grand Central Publishing",
                            ISBN = "978-1455523023",
                            Classification = "Non-Fiction",
                            Category = "Self-Help",
                            Price = 21.66
                        },
                         new Book
                         {
                             Title = "It's Your Ship",
                             Author_First = "Michael",
                             Author_Last = "Abrashoff",
                             Publisher = "Grand Central Publishing",
                             ISBN = "978-1455523023",
                             Classification = "Non-Fiction",
                             Category = "Self-Help",
                             Price = 21.66
                         },
                          new Book
                          {
                              Title = "The Virgin Way",
                              Author_First = "Richard",
                              Author_Last = "Branson",
                              Publisher = "Portfolio",
                              ISBN = "978-1591847984",
                              Classification = "Non-Fiction",
                              Category = "Business",
                              Price = 29.16
                          },
                           new Book
                           {
                               Title = "Sycamore Row",
                               Author_First = "John",
                               Author_Last = "Grisham",
                               Publisher = "Bantam",
                               ISBN = "978-0553393613",
                               Classification = "Fiction",
                               Category = "Thrillers",
                               Price = 15.03
                           }

                    );
                context.SaveChanges();
            }
        }
    }
}
