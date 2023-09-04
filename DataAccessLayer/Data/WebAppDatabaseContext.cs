using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class WebAppDatabaseContext : DbContext
    {
        public WebAppDatabaseContext(DbContextOptions<WebAppDatabaseContext> options) 
            : base(options)
        {
        }

        public DbSet<Phone> Phones { get; set; }
    }
}