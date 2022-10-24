using Microsoft.EntityFrameworkCore;
using MVCWebApplication.Models;

namespace MVCWebApplication.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options) : base(options)
        {
            //_dbContext=DbContext;
        }

        public DbSet<Category> Categories => Set<Category>();
    }
}
