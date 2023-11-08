using Microsoft.AspNetCore.Identity;

namespace HotelListingAPI.Models.Users
{
    public interface AuthResponseDto
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);

        Task<AuthResponseDto> Login(ApiUserDto userDto);
    }
}
