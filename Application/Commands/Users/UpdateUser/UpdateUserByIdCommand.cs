using Application.Dto;
using Domain.Models.UserModel;
using MediatR;

namespace Application.Commands.Users.UpdateUser
{
    public class UpdateUserByIdCommand : IRequest<User>
    {
        public Guid Id { get; }
        public UserDto UpdatedUser { get; }
        public UpdateUserByIdCommand(Guid id, UserDto updatedUser)
        {
            Id = id;
            UpdatedUser = updatedUser;
        }
    }
}
