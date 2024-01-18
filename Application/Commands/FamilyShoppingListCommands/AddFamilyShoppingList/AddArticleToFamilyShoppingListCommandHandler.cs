using Application.Commands.FamilyShoppingListCommands.AddFamilyShoppingList;
using Domain.Models.ListModels;
using Infrastructure.Interface;
using MediatR;

namespace Application.Commands.FamilyShoppingList.AddFamilyShoppingList
{
    public class AddArticleToFamilyShoppingListCommandHandler : IRequestHandler<AddArticleToFamilyShoppingListCommand, FamilyArticleList>
    {
        private readonly IArticleRepository _ArticleRepository;

        public AddArticleToFamilyShoppingListCommandHandler(IArticleRepository articleRepository)
        {
            _ArticleRepository = articleRepository;
        }

        public async Task<FamilyArticleList> Handle(AddArticleToFamilyShoppingListCommand request, CancellationToken cancellationToken)
        {
            // Kontrollera om FamilyId är giltigt
            if (request.NewFamilyShoppingList.FamilyId == Guid.Empty)
            {
                throw new Exception("FamilyId is required to add an article to the family shopping list.");
            }

            FamilyArticleList FamilyListToCreate = new FamilyArticleList
            {
                FamilyId = request.NewFamilyShoppingList.FamilyId,
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