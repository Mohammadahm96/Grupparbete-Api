using Application.Commands.Users.UpdateUser;
using Application.Dto;
using Domain.Models.UserModel;
using FakeItEasy;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.UserTests.CommandTest
{
    public class UpdateUserByIdTest
    {
        [Test]
        public async Task Handle_Update_Correct_User_By_Id()
        {
            //Arrange

            var guid = new Guid("ce9b91e4-08d1-4628-82c1-8ef6ec623230");

            var user = new User
            {
                UserId = new Guid("ce9b91e4-08d1-4628-82c1-8ef6ec623230"),
                Username = "TestUser",
                Password = "Test12345",
            };

            var userDto = new UserDto { UserName = "Max", Password = "MadDog123" };

            var userRepository = A.Fake<IUserRepository>();

            var handler = new UpdateUserByIdCommandHandler(userRepository);

            A.CallTo(() => userRepository.GetUserById(user.UserId)).Returns(user);

            A.CallTo(() => userRepository.UpdateUser(user)).Returns(user);

            var command = new UpdateUserByIdCommand(guid, userDto);


            //Act

            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.UserId, Is.EqualTo(guid));
            Assert.That(result.Username, Is.EqualTo("TestUser"));
            // Ensure the password is updated correctly
            Assert.IsTrue(BCrypt.Net.BCrypt.Verify(userDto.Password, result.Password));
            Assert.That(result, Is.TypeOf<User>());
        }
    }
}
