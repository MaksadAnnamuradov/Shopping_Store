using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StoreProject;

namespace StoreProject.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly StoreProject.ApplicationDbContext _context;

        public IndexModel(StoreProject.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; }

        public async Task OnGetAsync()
        {
            Item = await _context.Items.ToListAsync();
        }
    }
}
