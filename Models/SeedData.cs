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
            BookstoreDbContext context = application.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<BookstoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                        new Book
                        {
                            Title="Les Miserables",
                            Author="Victor Hugo",
                            Publisher="Signet",
                            ISBN = "978-0451419439",
                            Classification_Category = "Fiction, Classic",
                            Price = 9.95
                        }

                    );
                context.SaveChanges();
            }
        }
    }
}
