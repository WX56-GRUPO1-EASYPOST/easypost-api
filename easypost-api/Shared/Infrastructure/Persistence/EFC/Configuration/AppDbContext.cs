using easypost_api.IAM.Domain.Model.Aggregates;
using easypost_api.Profiles.Domain.Model.Aggregates;
using easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using easypost_api.Tickets.Domain.Model.Aggregates;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace easypost_api.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Contexts
        
        //Profiles Context
        builder.Entity<Profile>().HasKey(p=>p.Id);
        builder.Entity<Profile>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<Profile>().OwnsOne(p => p.Detail,
            d =>
            {
                d.WithOwner().HasForeignKey("Id");
                d.Property(p => p.Name).HasColumnName("Name");
                d.Property(p => p.Description).HasColumnName("Description");
                d.Property(p => p.Ruc).HasColumnName("Ruc");
            });

        builder.Entity<Profile>().OwnsOne(p => p.Contact,
            c =>
            {
                c.WithOwner().HasForeignKey("Id");
                c.Property(p => p.Telefono).HasColumnName("PhoneNumber");
                c.Property(p => p.Correo).HasColumnName("Email");
            });

        builder.Entity<Profile>().OwnsOne(p => p.Address,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(p => p.Departamento).HasColumnName("Department");
                a.Property(p => p.Distrito).HasColumnName("District");
                a.Property(p => p.Residential).HasColumnName("Residential");
            });
        
        // IAM Context

        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.Password).IsRequired();
        builder.Entity<User>().Property(u => u.Type).IsRequired();
        
        // Tickets Context
        builder.Entity<Ticket>().HasKey(t => t.Id);
        builder.Entity<Ticket>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Ticket>().Property(t => t.Title).IsRequired();
        builder.Entity<Ticket>().Property(t => t.Description).IsRequired();
        builder.Entity<Ticket>().Property(t => t.Category).IsRequired();
        builder.Entity<Ticket>().Property(t => t.Priority).IsRequired();
        builder.Entity<Ticket>().Property(t => t.ProfileId).IsRequired();
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}