using Microsoft.EntityFrameworkCore;
using PolicyManager.Models.Domain;

namespace PolicyManager.Data
{
    public class PoliciesDbContext : DbContext
    {
        public PoliciesDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Policies> Policies { get; set; }
    }
}
