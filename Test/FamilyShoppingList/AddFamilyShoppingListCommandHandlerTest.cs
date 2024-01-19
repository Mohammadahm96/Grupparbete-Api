using Application.Commands.FamilyShoppingList.AddFamilyShoppingList;
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

namespace Test.ShoppingList
{
    [TestFixture]

    public class AddFamilyShoppingListCommandHandlerTest
    {
        [Test]
        public async Task Handle_ValidNew_FamilyShoppingList()
        {
            //Arrange        
            var famRepo = A.Fake<IArticleRepository>();
            var newFamilyShoppingList = new FamilyShoppingListDto {
                
                FamilyName = "TestFam", ArticleName = "TestArticle",
                ArticleQuantity = 1, IsAvailable = true,
            };          
            var addFamilyShoppingListCmd = new AddFamilyShoppingListCommand(newFamilyShoppingList);

            var expectFamShoppingList = new FamilyArticleList
            {
                FamilyName = newFamilyShoppingList.FamilyName,
                ArticleName = newFamilyShoppingList.ArticleName,
                ArticleQuantity = newFamilyShoppingList.ArticleQuantity,
                IsAvailable = newFamilyShoppingList.IsAvailable
            };

            var handler = new AddFamilyShoppingListCommandHandler(famRepo);

            A.CallTo(() => famRepo.AddShoppingListAsync(newFamilyShoppingList));

            var result = await handler.Handle(addFamilyShoppingListCmd, CancellationToken.None);


            Assert.That(result.FamilyName, Is.EqualTo(expectFamShoppingList.FamilyName));
            Assert.That(result.ArticleName, Is.EqualTo(expectFamShoppingList.ArticleName));
            Assert.That(result.ArticleQuantity, Is.EqualTo(expectFamShoppingList.ArticleQuantity));
            Assert.That(result.IsAvailable, Is.EqualTo(expectFamShoppingList.IsAvailable));






        }
    }
}
