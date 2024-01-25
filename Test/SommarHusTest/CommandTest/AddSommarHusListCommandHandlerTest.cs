using Application.Commands.SommarHusListCommands.AddSommarHusList;
using Application.Commands.SommarHusLists.AddSommarHusList;
using Application.Dto;
using Domain.Models.ListModels;
using Infrastructure.Interfaces;
using Moq;

namespace Test.SommarHusTest.CommandTest
{
    [TestFixture]
    public class AddSommarHusListCommandHandlerTests
    {
        private AddSommarHusListCommandHandler? _handler;
        private Mock<ISommarHusListRepository>? _sommarHusListRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _sommarHusListRepositoryMock = new Mock<ISommarHusListRepository>();
            _handler = new AddSommarHusListCommandHandler(_sommarHusListRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ShouldCreateSommarHusList()
        {
            // Arrange
            var addNewSommarHusDto = new AddNewSommarHusDto { HouseName = "NewHouseName" };
            var command = new AddSommarHusListCommand(addNewSommarHusDto);

            SommarHusArticleList createdSommarHusList = null!;
            Moq.Language.Flow.IReturnsThrows<ISommarHusListRepository, Task<SommarHusArticleList?>> returnsThrows =
                _sommarHusListRepositoryMock.Setup(repo => repo.CreateSommarHusListAsync(It.IsAny<SommarHusArticleList>()))
                .Callback<SommarHusArticleList>(sommarHusList => createdSommarHusList = sommarHusList);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _sommarHusListRepositoryMock.Verify(repo => repo.CreateSommarHusListAsync(It.IsAny<SommarHusArticleList>()), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.HouseName, Is.EqualTo(addNewSommarHusDto.HouseName));
        }
    }
}
