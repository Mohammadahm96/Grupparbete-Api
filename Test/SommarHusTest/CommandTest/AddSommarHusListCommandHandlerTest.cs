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
            //Arrange
            var sommarHusListDto = new SommarHusListDto { HouseName = "NewHouseName", IsAvailable = true, ArticleName = "Test", ArticleQuantity = 2 };
            var command = new AddSommarHusListCommand(sommarHusListDto);

            SommarHusArticleList createdSommarHusList = null!;
            _sommarHusListRepositoryMock.Setup(repo => repo.CreateSommarHusListAsync(It.IsAny<SommarHusArticleList>()))
                .Callback<SommarHusArticleList>(sommarHusList => createdSommarHusList = sommarHusList);

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert
            _sommarHusListRepositoryMock.Verify(repo => repo.CreateSommarHusListAsync(It.IsAny<SommarHusArticleList>()), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.HouseName, Is.EqualTo(sommarHusListDto.HouseName));
            Assert.That(result.IsAvailable, Is.EqualTo(sommarHusListDto.IsAvailable));
            Assert.That(result.ArticleName, Is.EqualTo(sommarHusListDto.ArticleName));
            Assert.That(result.ArticleQuantity, Is.EqualTo(sommarHusListDto.ArticleQuantity));
        }

    }
}
