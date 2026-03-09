using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
        }

        public DbSet<User> Users { get; set; } 
        public DbSet<SMT_CauTrucDe> SMT_CauTrucDes { get; set; }
        public DbSet<SMT_CauTrucDe_ThanhPhan> SMT_CauTrucDe_ThanhPhans { get; set; }
        public DbSet<SMT_CauTrucDe_ThanhPhan_Sub> SMT_CauTrucDe_ThanhPhan_Subs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SMT_CauTrucDe_ThanhPhan>()
                .Property(x => x.coefficient)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SMT_CauTrucDe_ThanhPhan>()
                .Property(x => x.total_score)
                .HasPrecision(10, 2);
        }
    }
}
