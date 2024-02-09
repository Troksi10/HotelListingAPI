using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel
                {
                    Id = 1,
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
                    Rating = 4
                }
                );
        }
    }
}