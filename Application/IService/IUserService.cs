using Domain.Model.Users;
using Domain.ValueObject;

namespace Application.IService
{
    public interface IUserService
    {
        JWToken GenerateJwtToken(User user,string roleName);

	}
}
