using easypost_api.DailyActivities.Domain.Model.Aggregates;
using easypost_api.DailyActivities.Domain.Model.Entities;
using easypost_api.ManageProject.Domain.Model.Aggregates;
using easypost_api.ManageProject.Domain.Model.Entities;
using easypost_api.Poles.Domain.Model.Aggregates;
using easypost_api.Poles.Domain.Model.Entities;
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
        
        // Location Conection

        builder.Entity<Location>()
            .HasMany(l => l.Projects)
            .WithOne(t => t.Location)
            .HasForeignKey(t => t.LocationId)
            .HasPrincipalKey(t => t.Id);

        // Material Bounded Context
        
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
        
        // Poles Bounded Context
        
        builder.Entity<GeoReference>().HasKey(c => c.Id);
        builder.Entity<GeoReference>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<GeoReference>().Property(c => c.Description).IsRequired().HasMaxLength(255);
        builder.Entity<GeoReference>().Property(c => c.Latitude).IsRequired().HasMaxLength(255);
        builder.Entity<GeoReference>().Property(c => c.Longitude).IsRequired().HasMaxLength(255);
        
        builder.Entity<Pole>().HasKey(c => c.Id);
        builder.Entity<Pole>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Pole>().Property(c => c.Description).IsRequired().HasMaxLength(255);
        
        builder.Entity<PolePicture>().HasKey(c => c.Id);
        builder.Entity<PolePicture>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<PolePicture>().Property(c => c.ImageUri).IsRequired();
        builder.Entity<PolePicture>().Property(c => c.Description).IsRequired().HasMaxLength(255);
        builder.Entity<Pole>().HasMany(t => t.PolePictures);

        builder.Entity<Pole>()
            .HasOne(l => l.Project)
            .WithMany(t => t.Poles)
            .HasForeignKey(t => t.ProjectId)
            .HasPrincipalKey(t => t.Id);
        
        // GeoReference Connection
        
        builder.Entity<GeoReference>()
            .HasOne(l => l.Poles)
            .WithOne(t => t.GeoReference)
            .HasForeignKey<Pole>(t => t.GeoReferenceId)
            .HasPrincipalKey<GeoReference>(t => t.Id);
        
        // Daily Activity Bounded Context
        
        builder.Entity<DailyActivity>().HasKey(c => c.Id);
        builder.Entity<DailyActivity>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<DailyActivity>().Property(c => c.Description).IsRequired().HasMaxLength(255);
        builder.Entity<DailyActivity>().Property(c => c.Name).IsRequired().HasMaxLength(255);
        
        builder.Entity<DailyActivityPicture>().HasKey(c => c.Id);
        builder.Entity<DailyActivityPicture>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<DailyActivityPicture>().Property(c => c.ImageUri).IsRequired();
        builder.Entity<DailyActivityPicture>().Property(c => c.Description).IsRequired().HasMaxLength(255);
        builder.Entity<DailyActivity>().HasMany(t => t.DailyActivityPictures);
        
        builder.Entity<DailyActivity>()
            .HasOne(l => l.Project)
            .WithMany(t => t.DailyActivities)
            .HasForeignKey(t => t.ProjectId)
            .HasPrincipalKey(t => t.Id);
        
        // -------
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}