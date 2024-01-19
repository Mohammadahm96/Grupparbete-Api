using Application.Commands.FamilyShoppingListCommands.AddFamilyShoppingList;
using Application.Dto;
using Domain.Models;
using Domain.Models.ListModels;
using FakeItEasy;
using Infrastructure.Data;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.FamilyShoppingList.Command
{
    [TestFixture]

    public class AddFamilyShoppingListCommandHandlerTest
    {
        [Test]
        public async Task Handle_ValidNew_FamilyShoppingList()
        {
            //Arrange        
            var famRepo = A.Fake<IArticleRepository>();

            var guid = new Guid("ce9b91e4-08d1-4628-82c1-8ef6ec623223");

            var newFamilyShoppingList = new FamilyShoppingListDto
            {
                FamilyId = new Guid("ce9b91e4-08d1-4628-82c1-8ef6ec623223"),
                ArticleName = "TestFam",              
                ArticleQuantity = 1,
                IsAvailable = true,
            };
            var addFamilyShoppingListCmd = new AddArticleToFamilyShoppingListCommand(newFamilyShoppingList);

            var expectFamShoppingList = new FamilyArticleList
            {

                FamilyId = newFamilyShoppingList.FamilyId,
                ArticleName = newFamilyShoppingList.ArticleName,
                ArticleQuantity = newFamilyShoppingList.ArticleQuantity,
                IsAvailable = newFamilyShoppingList.IsAvailable
            };

           
            var handler = new AddArticleToFamilyShoppingListCommandHandler(famRepo);

            A.CallTo(() => famRepo.AddShoppingListAsync(newFamilyShoppingList));

            //Act
            var result = await handler.Handle(addFamilyShoppingListCmd, CancellationToken.None);

            //Assert
            Assert.That(result.FamilyId, Is.EqualTo(expectFamShoppingList.FamilyId));
            Assert.That(result.ArticleName, Is.EqualTo(expectFamShoppingList.ArticleName));
            Assert.That(result.ArticleQuantity, Is.EqualTo(expectFamShoppingList.ArticleQuantity));
            Assert.That(result.IsAvailable, Is.EqualTo(expectFamShoppingList.IsAvailable));
            





        }
    }
}
