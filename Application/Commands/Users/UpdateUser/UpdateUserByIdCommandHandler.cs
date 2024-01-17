using Domain.Models.UserModel;
using Infrastructure.Interfaces;
using MediatR;


namespace Application.Commands.Users.UpdateUser
{
    public class UpdateUserByIdCommandHandler : IRequestHandler<UpdateUserByIdCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserByIdCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(UpdateUserByIdCommand request, CancellationToken cancellationToken)
        {
            User userToUpdate = await _userRepository.GetUserById(request.Id);
            if (userToUpdate == null)
            {
                return null!;
            }

            // userToUpdate.Username = request.UpdatedUser.UserName;
            userToUpdate.Password = BCrypt.Net.BCrypt.HashPassword(request.UpdatedUser.Password);

            var updatedUser = await _userRepository.UpdateUser(userToUpdate);

            return updatedUser;
        }
    }
}
