using Application.Dto;
using MediatR;

namespace Application.Query.Users.LoginUser
{
    public class LoginUserQuery : IRequest<string>
    {
        public UserDto LoginUser { get; }
        public LoginUserQuery(UserDto loginUser)
        {
            LoginUser = loginUser;
        }
    }
}
