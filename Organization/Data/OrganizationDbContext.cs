using Microsoft.EntityFrameworkCore;
using Organization.Data.Entity;

namespace Organization.Data
{
    public class OrganizationDbContext : DbContext
    {
        public DbSet<OrganizationEntity> Organization { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=OrganizationTestCreate;Username=postgres;Password=admin");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OrganizationEntity>().ToTable("Organization");
		}
	}
}
