using Microsoft.AspNetCore.Mvc;
using Assignment5_Database.Models;
namespace SportsStore.Components

    //This class helps define the view for the summary cart - a "view component that passes on the cart to the view method"
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}