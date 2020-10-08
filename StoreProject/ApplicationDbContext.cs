using Microsoft.EntityFrameworkCore;
using System.Linq;
using StoreProject.Data;

namespace StoreProject
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Item> Items { get; set;}


    }
}