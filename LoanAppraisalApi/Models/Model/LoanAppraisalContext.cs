using Microsoft.EntityFrameworkCore;

namespace LoanAppraisalApi.Models
{
    public class LoanAppraisalContext : DbContext
    {
        public LoanAppraisalContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Users> users { get; set; }

        public DbSet<Inspection> inspections { get; set; }

        public DbSet<LoanAppraisalDetails> loanAppraisalDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Inspection>()
            .HasOne(i => i.Users)
            .WithMany(c => c.Inspections)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LoanAppraisalDetails>()
            .HasOne(i => i.Users)
            .WithMany(c => c.loanAppraisalDetails)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        }

    }


}
