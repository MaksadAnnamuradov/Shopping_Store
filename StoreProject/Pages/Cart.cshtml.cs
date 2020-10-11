using System.Collections.Generic;
using StoreProject.Helpers;
using StoreProject.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;


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

            Total = cart.Sum(i => Convert.ToDouble(i.Item.Price) * Convert.ToDouble(i.Quantity));
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



        public IActionResult OnGetCompleteOrder()
        {
            var cart = SessionHelper.GetObjectFromJson(HttpContext.Session, "cart");


            if (cart.Count == 0)
            {
                return RedirectToPage("Error");
            }

            var total = cart.Sum(i => Convert.ToDouble(i.Item.Price) * Convert.ToDouble(i.Quantity));

            var purchaseDate = DateTime.Now.ToString();
            Response.Cookies.Append("PurchaseDate", purchaseDate, new Microsoft.AspNetCore.Http.CookieOptions()
            {
                IsEssential = true,
                MaxAge = TimeSpan.FromMinutes(5)
            });

           
            Response.Cookies.Append("TotalSum", total.ToString(), new Microsoft.AspNetCore.Http.CookieOptions()
            {
                IsEssential = true,
                MaxAge = TimeSpan.FromMinutes(5)
            });

           /* List<string> myList = new List<string>();

            myList.Add(purchaseDate);
            myList.Add(Total.ToString());

            SessionHelper.SetObjectAsJson(HttpContext.Session, "Checkout", myList);*/


            cart.Clear();

            
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);


            
            return RedirectToPage("Thanks");
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