using System.Collections.Generic;
using StoreProject.Helpers;
using StoreProject.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace StoreProject.Pages
{
    public class CartModel : PageModel
    {
        public List<LineItem> cart { get; set; }

        public double Total { get; set; }


        private readonly StoreProject.ApplicationDbContext _context;

        public CartModel(StoreProject.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get; set; }

    /*    public async Task OnGetAsync()
        {
            Item = await _context.Items.ToListAsync();
        }*/

        public void OnGet()
        {
            cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");

            //Total = cart.Sum(i => i.Item.Price * castQuantity);
        }

        public IActionResult OnGetAddToCart(int id)
        {

            var cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");

            //var productModel = new LineItem();

            var newCartItem = _context.Items.FirstOrDefault(i => i.Id == id);

            //var cartItems = SessionHelper.GetObjectFromJson<List<LineItem>>(HttpContext.Session, "cart");


            var existingCartItem = cart.FirstOrDefault(i => i.Item.Id == id);

            if (existingCartItem == null)
            {

             
                cart.Add(new LineItem
                {
                    Item = newCartItem,
                    Quantity = 1
                    
                });

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                existingCartItem.Quantity += 1;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToPage("Cart");
        }

        public IActionResult OnGetDelete(int id)
        {
            var cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");

            var Item = cart.FirstOrDefault(i => i.Item.Id == id);

            if(Item != null)
            {
                cart.Remove(Item);
            }
           
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("Cart");
        }

        public IActionResult OnPostUpdate(int[] quantities)
        {
            cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");

            for (var i = 0; i < cart.Count; i++)
            {
                cart[i].Quantity = quantities[i];
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return RedirectToPage("Cart");
        }


    }
}