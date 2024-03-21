using Microsoft.EntityFrameworkCore;
using PartyOutfitRental.Models;

namespace PartyOutfitRental.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PartyOutfit> PartyOutfits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartyOutfit>().HasData(
                new PartyOutfit
                {
                    ID = 1,
                    Name = "Elegant Evening Gown",
                    Description = "A stunning black evening gown perfect for formal events.",
                    Size = "M",
                    Price = 99.99m,
                    Availability = true
               },
                new PartyOutfit
                {
                    ID = 2,
                    Name = "Classic Tuxedo",
                    Description = "A sharp-looking classic tuxedo for men, comes with a bow tie.",
                    Size = "L",
                    Price = 119.99m,
                    Availability = true
                }
                // Add more seed data as needed
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
