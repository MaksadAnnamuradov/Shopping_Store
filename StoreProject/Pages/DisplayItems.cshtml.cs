using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StoreProject.Data;
using StoreProject;

namespace StoreProject.Pages
{
    public class DisplayItems : PageModel
    {
        private readonly StoreProject.ApplicationDbContext _context;

        public DisplayItems(StoreProject.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get; set; }

        public async Task OnGetAsync()
        {
            Item = await _context.Items.ToListAsync();
        }
    }
}