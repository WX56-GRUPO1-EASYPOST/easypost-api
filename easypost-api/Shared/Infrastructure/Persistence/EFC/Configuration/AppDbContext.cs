using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options): DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }
        
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Context
        
        // Management Project Bounded Context
        builder.Entity<Location>().HasKey(c => c.Id);
        builder.Entity<Location>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Location>().Property(c => c.Address).IsRequired().HasMaxLength(255);
        builder.Entity<Location>().Property(c => c.Department).IsRequired().HasMaxLength(255);
        builder.Entity<Location>().Property(c => c.District).IsRequired().HasMaxLength(255);
        builder.Entity<Location>().Property(c => c.Province).IsRequired().HasMaxLength(255);
        builder.Entity<Location>().Property(c => c.Locality).IsRequired().HasMaxLength(255);
        builder.Entity<Location>().Property(c => c.Reference).IsRequired().HasMaxLength(255);

        builder.Entity<Project>().HasKey(c => c.Id);
        builder.Entity<Project>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Project>().Property(c => c.Title).IsRequired().HasMaxLength(255);
        builder.Entity<Project>().Property(c => c.AccessCode);
        builder.Entity<Project>().Property(c => c.TotalBudget).IsRequired();
        builder.Entity<Project>().Property(c => c.PartialBudget).IsRequired();
        
        builder.Entity<ConstructionPermit>().HasKey(c => c.Id);
        builder.Entity<ConstructionPermit>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ConstructionPermit>().Property(c => c.Title).IsRequired().HasMaxLength(255);
        builder.Entity<ConstructionPermit>().Property(c => c.Status).IsRequired().HasMaxLength(255);
        builder.Entity<Project>().HasMany(t => t.ConstructionPermits);
        
        builder.Entity<Material>().HasKey(c => c.Id);
        builder.Entity<Material>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Material>().Property(c => c.Name).IsRequired().HasMaxLength(255);
        builder.Entity<Material>().Property(c => c.Description).IsRequired().HasMaxLength(255);
        builder.Entity<Material>().Property(c => c.Cost).IsRequired();
        
        builder.Entity<ProjectMaterials>().HasKey(pm => new { pm.ProjectId, pm.MaterialId });
        builder.Entity<ProjectMaterials>().HasOne(pm => pm.Project)
            .WithMany(p => p.ProjectMaterials)
            .HasForeignKey(pm => pm.ProjectId);
        builder.Entity<ProjectMaterials>().HasOne(pm => pm.Material)
            .WithMany(m => m.ProjectMaterials)
            .HasForeignKey(pm => pm.MaterialId);
        builder.Entity<ProjectMaterials>().Property(pm => pm.Amount).IsRequired();
        
        // Location Conection

        builder.Entity<Location>()
            .HasMany(l => l.Projects)
            .WithOne(t => t.Location)
            .HasForeignKey(t => t.LocationId)
            .HasPrincipalKey(t => t.Id);
        
        // -------
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}