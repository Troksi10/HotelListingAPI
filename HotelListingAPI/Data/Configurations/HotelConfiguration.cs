using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace HotelListingAPI.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
          new Hotel()
          {
              Id = 1,
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
    
