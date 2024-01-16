using Domain.Models.UserModel;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Query.Users.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {

            List<User> allUsersFromDB = await _userRepository.GetAllUsers();
            return allUsersFromDB;

        }
    }
}
