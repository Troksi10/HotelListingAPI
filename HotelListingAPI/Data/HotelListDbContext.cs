using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Data
{
    public class HotelListDbContext : DbContext
    {
        public HotelListDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Macedonia",
                    ShortName = "MK",
                }, new Country
                {
                    Id = 2,
                    Name = "Italy",
                    ShortName = "IT",
                }, new Country
                {
                    Id = 3,
                    Name = "Serbia",
                    ShortName = "SRB",
                }, new Country
                {
                    Id = 4,
                    Name = "Croatia",
                    ShortName = "HR",
                }, new Country
                {
                    Id = 5,
                    Name = "Greece",
                    ShortName = "GR",
                }
                );
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id=1,
                    Name = "Royal View",
                    Address = "Jane Sandanski 2,Ohrid",
                    CountryId = 1,
                    Rating = 4.3
                }, new Hotel
                {
                    Id = 2,
                    Name = "Hotel Djina",
                    Address = "Kopaonik 36354",
                    CountryId = 3,
                    Rating = 4.6
                }, new Hotel
                {
                    Id = 3,
                    Name = "Oikos Boutique Residences",
                    Address = "Platies, Kefalonia, Plateies, Greece ",
                    CountryId = 5,
                    Rating = 5
                }, new Hotel
                {
                    Id = 4,
                    Name = "Hotel Corner",
                    Address = "Mažuranićevo Šetalište 1, 21000 Split",
                    CountryId = 4,
                    Rating = 4.7
                }, new Hotel
                {
                    Id = 5,
                    Name = "Park Hotel Leonardo",
                    Address = "Strada de Ciroch 15, 38035 Moena,",
                    CountryId = 2,
                    Rating = 4.3
                }
                );
        }
    }
}
