using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country 
                { Id = 1, 
                  Name = "Macedonia", 
                  ShortName = "MK" 
                },
                new Country 
                { Id = 2, 
                  Name = "Serbia", 
                  ShortName = "SRB" },
                new Country 
                { Id = 3, 
                  Name = "Croatia", 
                  ShortName = "HR" }
                );
        }
    }
}

