using AutoMapper;
using HotelListingAPI.Data;
using HotelListingAPI.Models.Country;
using HotelListingAPI.Models.Hotel;
using HotelListingAPI.Models.Users;

namespace HotelListingAPI.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, CreateCountryDetail>().ReverseMap();
            CreateMap<Country, GetCountryDetail>().ReverseMap();
            CreateMap<Country, CountryDetails>().ReverseMap();
            CreateMap<Country,UpdateCountryDetail>().ReverseMap();

            CreateMap<Hotel, HotelDetails>().ReverseMap();
            CreateMap<Hotel, CreateHotelDetails>().ReverseMap();

            CreateMap<ApiUserDto, ApiUser>().ReverseMap();
        }
    }
}
