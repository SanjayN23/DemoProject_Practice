using Microsoft.EntityFrameworkCore;

namespace Pratice.Models
{
    public class DeletedDataDbContext : DbContext
    {
        public DeletedDataDbContext()
        {

        }

        public DeletedDataDbContext(DbContextOptions<DeletedDataDbContext> options)
       : base(options)
        {
        }
        public virtual DbSet<BackupCountry> BackupCountries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=200411LTP2848\\SQLEXPRESS;Database=DeletedData;integrated security=true;Encrypt=False");
            }
        }
    }
}
