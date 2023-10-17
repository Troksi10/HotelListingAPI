using HotelListingAPI.Models.Hotel;

namespace HotelListingAPI.Models.Country
{
    public class CountryDetails : BaseCountryDetail
    {
        public int Id { get; set; }

        public List<HotelDetails>? Hotels { get; set; }
    }
}
