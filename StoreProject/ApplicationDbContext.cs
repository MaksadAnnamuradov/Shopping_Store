using Microsoft.EntityFrameworkCore;

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