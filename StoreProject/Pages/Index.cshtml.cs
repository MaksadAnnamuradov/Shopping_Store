using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoreProject.Data;

namespace StoreProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPostSaveUserNameAsync(String username)
        {
            Response.Cookies.Append("UserName", username, new Microsoft.AspNetCore.Http.CookieOptions()
            {
                IsEssential = true,
                MaxAge = TimeSpan.FromMinutes(5)
            });
            return RedirectToPage();
        }

     
         
    /*private void LoadCartFromSession()
    {
        Cart = new List<LineItem>();
        var CartJson = HttpContext.Session.GetString("CartJson");
        if(CartJson != null)
        {
            foreach(var item in System.Text.Json.JsonSerializer.Deserialize<IEnumerable<LineItem>>(CartJson))
            {
                Cart.Add(item);
            }
        }
    }


    public async Task<IActionResult> OnPostAddItem(string itemName, int quantity)
    {
        LoadCartFromSession();

        var existingLine = LoadCartFromSession.FirstOrDefault(i => i.Item.Name == itemName);

        if(existingLine == null)
        {
            var item = new Item { Name = itemName, Price = 1.23M };
            LoadCartFromSession.Add(new LineItem){
                Item = item,

            }
        }
    }
    public void OnGet()
    {

    }*/
}
}
