using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace KindCoins_Backend.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<TypeOfDonation> TypeOfDonations { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("User");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
 
            // Relationships
            builder.Entity<User>()
                .HasMany(p => p.Campaigns)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
 
            builder.Entity<Campaign>().ToTable("Campaign");
            builder.Entity<Campaign>().HasKey(p => p.Id);
            builder.Entity<Campaign>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Campaign>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Campaign>().Property(p => p.Description).HasMaxLength(120);

            builder.Entity<TypeOfDonation>().ToTable("TypeOfDonation");
            builder.Entity<TypeOfDonation>().HasKey(p => p.Id);
            builder.Entity<TypeOfDonation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<TypeOfDonation>().Property(p => p.TypeDonation).IsRequired().HasMaxLength(50);
            
                        
            // Relationships
            builder.Entity<TypeOfDonation>()
                .HasMany(p => p.Campaigns)
                .WithOne(p => p.TypeOfDonation)
                .HasForeignKey(p => p.TypeOfDonationId);

            // Apply Snake Case Naming Convention
 
            builder.UseSnakeCaseNamingConvention();
        }

    }
}