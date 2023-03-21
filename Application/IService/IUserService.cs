using Domain.Model.Base;
using Domain.Model.Posts;
using Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IUserService
    {
        JWToken GenerateJwtToken(User user,string roleName);

		(IEnumerable<User> data, int total) GetList(string? role, int? pageSize, int? page);
	}
}
