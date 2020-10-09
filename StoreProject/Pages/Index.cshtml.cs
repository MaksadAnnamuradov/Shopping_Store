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

            /*Response.Cookies["userInfo"]["userName"] = "patrick"; //userInfo is the cookie, userName is the subkey
            Response.Cookies["userInfo"]["lastVisit"] = DateTime.Now.ToString(); //now lastVisit is the subkey
            Response.Cookies["userInfo"].Expires = DateTime.Now.AddDays(1);

            HttpCookie aCookie = new HttpCookie("userInfo");
            aCookie.Values["userName"] = "patrick";
            aCookie.Values["lastVisit"] = DateTime.Now.ToString();
            aCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(aCookie);*/


            Response.Cookies.Append("UserName", username, new Microsoft.AspNetCore.Http.CookieOptions()
            {
                IsEssential = true,
                MaxAge = TimeSpan.FromMinutes(5)
            });
            return RedirectToPage();
        }

}
}
