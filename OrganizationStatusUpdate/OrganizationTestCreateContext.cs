using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OrganizationStatusUpdate;

public partial class OrganizationTestCreateContext : DbContext
{
    public OrganizationTestCreateContext()
    {
    }

    public OrganizationTestCreateContext(DbContextOptions<OrganizationTestCreateContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Organization> Organizations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=OrganizationTestCreate;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("Organization");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
