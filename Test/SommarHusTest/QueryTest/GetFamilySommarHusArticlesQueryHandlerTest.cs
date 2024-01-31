using Application.Query.SommarHusList.GetAll;
using Domain.Models.ListModels;
using Infrastructure.Interfaces;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Test.SommarHusTest.QueryTest
{
    [TestFixture]
    public class GetFamilySommarHusArticlesQueryHandlerTest
    {
        private Mock<ISommarHusListRepository> _sommarHusListRepository;
        private GetFamilySommarHusArticlesQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _sommarHusListRepository = new Mock<ISommarHusListRepository>();
            _handler = new GetFamilySommarHusArticlesQueryHandler(_sommarHusListRepository.Object);
        }

        [Test]
        public async Task Handle_ReturnsFamilyAndArticles()
        {
            // Arrange
            var sommarHusId = Guid.NewGuid(); // Provide a valid Guid
            string expectedSommarhusName = "Villa";
            List<string> expectedArticleNames = new List<string> { "Article1", "Article2" };

            _sommarHusListRepository.Setup(repo => repo.GetHouseNameAsync(sommarHusId)).ReturnsAsync(expectedSommarhusName);
            _sommarHusListRepository.Setup(repo => repo.GetArticleNamesBySommarHusIdAsync(sommarHusId)).ReturnsAsync(expectedArticleNames);

            var request = new GetFamilySommarHusArticlesQuery(sommarHusId); // Provide the Guid here

            // Act
            List<string> result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(expectedSommarhusName, result[0]);
            Assert.AreEqual(expectedArticleNames.Count, result.Count - 1); // excluding the family name
            Assert.AreEqual(expectedArticleNames, result.GetRange(1, expectedArticleNames.Count));
        }
    }
}