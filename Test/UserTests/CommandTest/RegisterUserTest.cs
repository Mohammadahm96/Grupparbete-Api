using Application.Commands.Users.RegisterNewUser;
using Application.Dto;
using Domain.Models.UserModel;
using FakeItEasy;
using Infrastructure.Interfaces;

namespace Test.UserTests.CommandTest
{
    [TestFixture]
    public class RegisterUserTest
    {
        [Test]
        public async Task Handle_ValidUser_ReturnsCreatedUser()
        {
            // Arrange
            var userRepository = A.Fake<IUserRepository>();
            var newUser = new UserDto { UserName = "testUser", Password = "testPassword" };
            var registerCommand = new RegisterUserCommand(newUser);

            var expectedUser = new User
            {
                UserId = Guid.NewGuid(),
                Username = newUser.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password),
            };

            A.CallTo(() => userRepository.RegisterUser(A<User>._))
                .WithAnyArguments()
                .Returns(Task.FromResult(expectedUser));

            var handler = new RegisterUserCommandHandler(userRepository);

            // Act
            var result = await handler.Handle(registerCommand, CancellationToken.None);

            // Assert
            Assert.That(result.UserId, Is.EqualTo(expectedUser.UserId));
            Assert.That(result.Username, Is.EqualTo(expectedUser.Username));
            Assert.That(result.Password, Is.EqualTo(expectedUser.Password));
        }

        [Test]
        public void Handle_NullUser_ThrowsArgumentNullException()
        {
            // Arrange
            var userRepository = A.Fake<IUserRepository>();
            var registerCommand = new RegisterUserCommand(null!); // Passing null user

            var handler = new RegisterUserCommandHandler(userRepository);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await handler.Handle(registerCommand, CancellationToken.None);
            });
        }
    }
}
