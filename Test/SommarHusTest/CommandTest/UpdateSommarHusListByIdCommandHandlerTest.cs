using Application.Commands.SommarHusListCommands.UpdateSommarHusList;
using Application.Dto;
using Domain.Models.ListModels;
using Infrastructure.Interfaces;
using Moq;

namespace Test.SommarHusTest.CommandTest
{
    [TestFixture]
    public class UpdateSommarHusListByIdCommandHandlerTest
    {
        private UpdateSommarHusListByIdCommandHandler? _handler;
        private Mock<ISommarHusListRepository>? _sommarHusListRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _sommarHusListRepositoryMock = new Mock<ISommarHusListRepository>();
            _handler = new UpdateSommarHusListByIdCommandHandler(_sommarHusListRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_WhenExist_ShouldUpdateSommarHus()
        {
            //Arrange
            var sommarHusListId = Guid.NewGuid();
            var sommarHusListToUpdate = new SommarHusArticleList { Id = sommarHusListId, HouseName = "Radhus", IsAvailable = true };
            var updatedSommarHusListDto = new SommarHusListDto { HouseName = "Updated", IsAvailable = false, ArticleName = "UpdatedArticle" };
            var command = new UpdateSommarHusListByIdCommand(sommarHusListId, updatedSommarHusListDto);
            _sommarHusListRepositoryMock!.Setup(repo => repo.GetSommarHusListByIdAsync(sommarHusListId)).ReturnsAsync(sommarHusListToUpdate);
            _sommarHusListRepositoryMock!.Setup(repo => repo.UpdateSommarHusListByIdAsync(sommarHusListId)).ReturnsAsync(sommarHusListToUpdate);

            //Act
            var result = await _handler!.Handle(command, CancellationToken.None);

            //Assert
            _sommarHusListRepositoryMock.Verify(repo => repo.GetSommarHusListByIdAsync(sommarHusListId), Times.Once);
            _sommarHusListRepositoryMock.Verify(repo => repo.UpdateSommarHusListByIdAsync(sommarHusListId), Times.Once);
            Assert.That(result, Is.EqualTo(sommarHusListToUpdate));

        }
        [Test]
        public async Task Handle_WhenNotExist_ShouldThrowException()
        {
            //Arrange
            var sommarHusListId = Guid.NewGuid();
            var updatedSommarHusListDto = new SommarHusListDto { HouseName = "Updated", IsAvailable = false, ArticleName = "UpdatedArticle" };
            var command = new UpdateSommarHusListByIdCommand(sommarHusListId, updatedSommarHusListDto);
            _sommarHusListRepositoryMock!.Setup(repo => repo.GetSommarHusListByIdAsync(sommarHusListId)).ReturnsAsync((SommarHusArticleList?)null);

            //Act
            var result = await _handler!.Handle(command, CancellationToken.None);

            //Assert
            _sommarHusListRepositoryMock.Verify(repo => repo.GetSommarHusListByIdAsync(sommarHusListId), Times.Once);
            _sommarHusListRepositoryMock.Verify(repo => repo.UpdateSommarHusListByIdAsync(sommarHusListId), Times.Never);
            Assert.That(result, Is.Null);
        }
    }
}
