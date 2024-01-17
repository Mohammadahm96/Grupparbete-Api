using Domain.Models.UserModel;
using MediatR;

namespace Application.Query.Users.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}
