using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ShortLinkContext : DbContext
    {
        public ShortLinkContext(DbContextOptions<ShortLinkContext> options)
            : base(options)
        {
        }

        public DbSet<LinkEntity> Links { get; set; }
    }
}
