using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Data
{
    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country() { Id = 1, Name = "Macedonia", ShortName = "MK" },
                new Country() { Id = 2, Name = "Serbia", ShortName = "SRB" },
                new Country() { Id = 3, Name = "Croatia", ShortName = "HR" }
                );
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel() 
                {   Id = 1,
                    Name = "Aurora Resort and Spa",
                    Address = "Ul.3 bb",
                    CountryId = 1,
                    Rating = 4.4
                },
                new Hotel()
                {
                    Id = 2,
                    Name = "Viceroy Kopaonik Serbia",
                    Address = "Josifa Pančića 12, 36354 Kopaonik",
                    CountryId = 2,
                    Rating = 4.8
                },
                new Hotel()
                {
                    Id = 3,
                    Name = "Hotel Ora",
                    Address = "Poljička cesta 26E, 21000 Split",
                    CountryId = 3,
                    Rating = 3.7
                }
                );
        }
    }
}
