using WBVentas.Models.Request;
using WBVentas.Models.Response;

namespace WBVentas.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
