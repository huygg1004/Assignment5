using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment5_Database.Models;

namespace Assignment5_Database.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private BookRepository repository;


        // using the data from repository class
        public NavigationMenuViewComponent(BookRepository r)
        {
            repository = r;
        }

        // Return categories based on category in books database
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }

    }
}
