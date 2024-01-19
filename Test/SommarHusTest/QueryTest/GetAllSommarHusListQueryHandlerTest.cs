using Application.Queries.SommarHusList.GetAll;
using Application.Query.SommarHusList.GetAll;
using Domain.Models.ListModels;
using Infrastructure.Interfaces;
using Moq;

namespace Test.SommarHusTest.QueryTest
{
    [TestFixture]
    public class GetAllSommarHusListQueryHandlerTest
    {
        private Mock<ISommarHusListRepository> _sommarHusListBirdRepository;
        private GetAllSommarHusListQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _sommarHusListBirdRepository = new Mock<ISommarHusListRepository>();
            _handler = new GetAllSommarHusListQueryHandler(_sommarHusListBirdRepository.Object);
        }

        [Test]
        public async Task Handle_ReturnsAllSommarHus()
        {
            //Arrange
            List<SommarHusArticleList> expectedSommarHusList = new List<SommarHusArticleList>
            {
                new SommarHusArticleList { Id = Guid.NewGuid(), HouseName = "Villa" },
                new SommarHusArticleList { Id = Guid.NewGuid(), HouseName = "RadHus" },
                new SommarHusArticleList { Id = Guid.NewGuid(), HouseName = "LitteMabel" },
                new SommarHusArticleList { Id = Guid.NewGuid(), HouseName = "Skyscaper" },
                new SommarHusArticleList { Id = Guid.NewGuid(), HouseName = "Långtornet" },
            };

            _sommarHusListBirdRepository.Setup(repo => repo.GetAllSommarHusListAsync()).ReturnsAsync(expectedSommarHusList);


            //Act
            List<SommarHusArticleList> actualSommarHusList = await _handler.Handle(new GetAllSommarHusListQuery(), CancellationToken.None);

            //Assert
            Assert.That(actualSommarHusList, Is.EqualTo(expectedSommarHusList));
        }
    }
}
