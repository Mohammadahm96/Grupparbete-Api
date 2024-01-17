using Application.Commands.FamilyShoppingListCommands.AddFamilyShoppingList;
using Domain.Models.ListModels;
using Infrastructure.Interface;
using MediatR;

namespace Application.Commands.FamilyShoppingList.AddFamilyShoppingList
{
    public class AddFamilyShoppingListCommandHandler : IRequestHandler<AddFamilyShoppingListCommand, FamilyArticleList>
    {
        private readonly IArticleRepository _ArticleRepository;

        public AddFamilyShoppingListCommandHandler(IArticleRepository articleRepository)
        {
            _ArticleRepository = articleRepository;
        }

        public async Task<FamilyArticleList> Handle(AddFamilyShoppingListCommand request, CancellationToken cancellationToken)
        {
            FamilyArticleList FamilyListToCreate = new FamilyArticleList
            {
                FamilyName = request.NewFamilyShoppingList.FamilyName,
                ArticleId = Guid.NewGuid(),
                ArticleName = request.NewFamilyShoppingList.ArticleName,
                ArticleQuantity = 1,
                IsAvailable = true

            };

            try
            {
                await _ArticleRepository.AddShoppingListAsync(FamilyListToCreate);
                return FamilyListToCreate;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add FamilyList to the database", ex);
            }
        }
    }
}