using Application.Query.Users.GetAllUsers;
using Domain.Models.UserModel;
using FakeItEasy;
using Infrastructure.Interfaces;

namespace Test.UserTests.QueryTest
{
    [TestFixture]
    public class GetAllUsersTest
    {
        [Test]
        public async Task Handle_Get_All_Users_ReturnListAvUsers()
        {
            List<User> users = new List<User>
            {
              new User {Username="Bojan" , Password = "Bojan123"},
              new User {Username="TestUser" , Password = "Test1234"}
            };

            var userRepository = A.Fake<IUserRepository>();

            var handler = new GetAllUsersQueryHandler(userRepository);

            A.CallTo(() => userRepository.GetAllUsers()).Returns(users);

            var command = new GetAllUsersQuery();

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.InstanceOf<List<User>>()); // result is a list of User objects
            Assert.That(result.Count, Is.EqualTo(users.Count));
            CollectionAssert.AreEqual(users, result);//compare both lists directly for equality
        }
    }
}
