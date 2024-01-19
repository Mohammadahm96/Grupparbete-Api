using Application.Commands.SommarHusLists.DeleteSommarHusList;
using Domain.Models.ListModels;
using Infrastructure.Interfaces;
using Moq;

namespace Test.SommarHusTest.CommandTest
{
    [TestFixture]
    public class DeleteSommarHusListByIdCommandHandlerTest
    {
        private DeleteSommarHusListByIdCommandHandler? _handler;
        private Mock<ISommarHusListRepository>? _sommarHusListRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _sommarHusListRepositoryMock = new Mock<ISommarHusListRepository>();
            _handler = new DeleteSommarHusListByIdCommandHandler(_sommarHusListRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ShouldDeleteSommarHusList()
        {
            // Arrange
            var sommarHusListId = Guid.NewGuid();
            var sommarHusListToDelete = new SommarHusArticleList { Id = sommarHusListId, HouseName = "Radhus", IsAvailable = true };
            var command = new DeleteSommarHusListByIdCommand(sommarHusListId);

            _sommarHusListRepositoryMock!.Setup(repo => repo.GetSommarHusListByIdAsync(sommarHusListId)).ReturnsAsync(sommarHusListToDelete);
            _sommarHusListRepositoryMock!.Setup(repo => repo.DeleteSommarHusListByIdAsync(sommarHusListId)).ReturnsAsync(sommarHusListToDelete);

            // Act
            var result = await _handler!.Handle(command, CancellationToken.None);

            // Assert
            _sommarHusListRepositoryMock.Verify(repo => repo.GetSommarHusListByIdAsync(sommarHusListId), Times.Once);
            _sommarHusListRepositoryMock.Verify(repo => repo.DeleteSommarHusListByIdAsync(sommarHusListId), Times.Once);
            Assert.That(result, Is.EqualTo(sommarHusListToDelete));
        }
        [Test]
        public async Task Handle_WhenSommarHusDoesNotExist_ShouldThrowNotFoundException()
        {
            // Arrange
            var sommarHusListId = Guid.NewGuid();

            var command = new DeleteSommarHusListByIdCommand(sommarHusListId);

            _sommarHusListRepositoryMock!.Setup(repo => repo.GetSommarHusListByIdAsync(sommarHusListId)).ReturnsAsync((SommarHusArticleList?)null);
            _sommarHusListRepositoryMock!.Setup(repo => repo.DeleteSommarHusListByIdAsync(sommarHusListId)).ReturnsAsync((SommarHusArticleList?)null);

            // Act
            var result = await _handler!.Handle(command, CancellationToken.None);

            // Assert
            _sommarHusListRepositoryMock.Verify(repo => repo.GetSommarHusListByIdAsync(sommarHusListId), Times.Once);
            _sommarHusListRepositoryMock.Verify(repo => repo.DeleteSommarHusListByIdAsync(sommarHusListId), Times.Never);
            Assert.That(result, Is.Null);
        }

    }
}
