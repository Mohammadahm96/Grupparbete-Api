using Elasticsearch.Net;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Query.Users.LoginUser
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly IUserRepository _userRepository;

        public LoginUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            string jwtToken = await _userRepository.GetsTokenToLogin(request.LoginUser.UserName, request.LoginUser.Password);
            if (jwtToken == null)
            {
                return null!;
            }
            return jwtToken;
        }
    }
}
