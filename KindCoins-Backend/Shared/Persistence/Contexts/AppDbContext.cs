using KindCoins_Backend.KindCoins.Domain.Models;
using KindCoins_Backend.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace KindCoins_Backend.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{


    public DbSet<User> Users { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<TypeOfDonation> TypeOfDonations { get; set; }
    public DbSet<SuscriptionPlan> SuscriptionPlans { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        {
            base.OnModelCreating(builder);
            
            builder.Entity<User>().ToTable("User");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.DNI).IsRequired().HasMaxLength(8);
            builder.Entity<User>().Property(p => p.Phone).IsRequired().HasMaxLength(9);
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(15);
            
            // Relationships SuscriptionPlan with User
            builder.Entity<SuscriptionPlan>()
                .HasMany(p => p.Users)
                .WithOne(p => p.SuscriptionPlan)
                .HasForeignKey(p => p.SuscriptionPlanId);
            
            builder.Entity<SuscriptionPlan>().ToTable("SuscriptionPlan");
            builder.Entity<SuscriptionPlan>().HasKey(p => p.Id);
            builder.Entity<SuscriptionPlan>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<SuscriptionPlan>().Property(p => p.Plan).IsRequired().HasMaxLength(50);
 
            // Relationships User with Campaign
            builder.Entity<User>()
                .HasMany(p => p.Campaigns)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
 
            builder.Entity<Campaign>().ToTable("Campaign");
            builder.Entity<Campaign>().HasKey(p => p.Id);
            builder.Entity<Campaign>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Campaign>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Campaign>().Property(p => p.Slogan).IsRequired().HasMaxLength(50);
            builder.Entity<Campaign>().Property(p => p.HeaderPhoto).IsRequired().HasMaxLength(50);
            builder.Entity<Campaign>().Property(p => p.AditionalPhoto).IsRequired().HasMaxLength(50);
            builder.Entity<Campaign>().Property(p => p.Description).HasMaxLength(500);
            builder.Entity<Campaign>().Property(p => p.Goal).IsRequired();

            builder.Entity<TypeOfDonation>().ToTable("TypeOfDonation");
            builder.Entity<TypeOfDonation>().HasKey(p => p.Id);
            builder.Entity<TypeOfDonation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<TypeOfDonation>().Property(p => p.TypeDonation).IsRequired().HasMaxLength(50);
            
            // Relationships TypeOfDonation with Campaign
            builder.Entity<TypeOfDonation>()
                .HasMany(p => p.Campaigns)
                .WithOne(p => p.TypeOfDonation)
                .HasForeignKey(p => p.TypeOfDonationId);
            
            builder.Entity<BankAccount>().ToTable("BankAccount");
            builder.Entity<BankAccount>().HasKey(p => p.Id);
            builder.Entity<BankAccount>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<BankAccount>().Property(p => p.AccountNumber).IsRequired().HasMaxLength(15);
            
            // Relationships BankAccount with Campaign
            builder.Entity<Campaign>()
                .HasMany(p => p.BankAccounts)
                .WithOne(p => p.Campaign)
                .HasForeignKey(p => p.CampaignId);
            

            


            // Apply Snake Case Naming Convention
 
            builder.UseSnakeCaseNamingConvention();
        }

    }
}