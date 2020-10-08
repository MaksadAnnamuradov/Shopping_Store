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

        public void OnGet()
        {
            cart = SessionHelper.GetObjectFromJson<List<LineItem>>(HttpContext.Session, "cart");

            //Total = cart.Sum(i => i.Item.Price * castQuantity);
        }

        public IActionResult OnGetAddToCart(int id)
        {
            //var productModel = new LineItem();

            var cartItems = cart.FirstOrDefault(i => i.Item.Id == id);

            if (cartItems == null)
            {
                var item = new Item { Id = id, Price = 1.4M };

                cart.Add(new LineItem
                {
                    Item = item,
                    
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                cartItems.Quantity += 1;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToPage("Cart");
        }

    /*    public IActionResult OnGetDelete( id)
        {
            cart = cart.FirstOrDefault(i => i.Item.Id == id);
            int index = Exists(cart, id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("Cart");
        }*/

        public IActionResult OnPostUpdate(int[] quantities)
        {
            cart = SessionHelper.GetObjectFromJson<List<LineItem>>(HttpContext.Session, "cart");

            for (var i = 0; i < cart.Count; i++)
            {
                cart[i].Quantity = quantities[i];
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("Cart");
        }

    /*    private int Exists(List<Item> cart, string id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].Item.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
*/
    }
}