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
        private Mock<ISommarHusListRepository> _sommarHusListRepository;
        private GetAllSommarHusListQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _sommarHusListRepository = new Mock<ISommarHusListRepository>();
            _handler = new GetAllSommarHusListQueryHandler(_sommarHusListRepository.Object);
        }

        [Test]
        public async Task Handle_ReturnsAllSommarHus()
        {
            //Arrange
            List<SommarHusArticleList> expectedSommarHusList = new List<SommarHusArticleList>
            {
                new SommarHusArticleList { SommarHusId = Guid.NewGuid(), HouseName = "Villa" },
                new SommarHusArticleList { SommarHusId = Guid.NewGuid(), HouseName = "RadHus" },
                new SommarHusArticleList { SommarHusId = Guid.NewGuid(), HouseName = "LitteMabel" },
                new SommarHusArticleList { SommarHusId = Guid.NewGuid(), HouseName = "Skyscaper" },
                new SommarHusArticleList { SommarHusId = Guid.NewGuid(), HouseName = "Långtornet" },
            };

            _sommarHusListRepository.Setup(repo => repo.GetAllSommarHusListAsync()).ReturnsAsync(expectedSommarHusList);


            //Act
            List<SommarHusArticleList> actualSommarHusList = await _handler.Handle(new GetAllSommarHusListQuery(), CancellationToken.None);

            //Assert
            Assert.That(actualSommarHusList, Is.EqualTo(expectedSommarHusList));
        }
    }
}
