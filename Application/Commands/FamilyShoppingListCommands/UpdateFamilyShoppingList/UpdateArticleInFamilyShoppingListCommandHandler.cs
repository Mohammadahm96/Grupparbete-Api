using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models.ListModels;
using Infrastructure.Interface;

namespace Application.Commands.FamilyShoppingListCommands.UpdateFamilyShoppingList
{
    public class UpdateArticleInFamilyShoppingListCommandHandler : IRequestHandler<UpdateArticleInFamilyShoppingListCommand, FamilyArticleList>
    {
        private readonly IArticleRepository _articleRepository;

        public UpdateArticleInFamilyShoppingListCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<FamilyArticleList> Handle(UpdateArticleInFamilyShoppingListCommand request, CancellationToken cancellationToken)
        {
            if (request.UpdateFamilyShoppingListDto.FamilyId == Guid.Empty || request.UpdateFamilyShoppingListDto.ArticleId == Guid.Empty)
            {
                throw new Exception("FamilyId and ArticleId are required to update an article in the family shopping list.");
            }

            FamilyArticleList existingFamilyList = await _articleRepository.GetFamilyArticleAsync(request.UpdateFamilyShoppingListDto.FamilyId, request.UpdateFamilyShoppingListDto.ArticleId);

            if (existingFamilyList == null)
            {
                throw new InvalidOperationException($"Article with FamilyId {request.UpdateFamilyShoppingListDto.FamilyId} and ArticleId {request.UpdateFamilyShoppingListDto.ArticleId} not found.");
            }

            existingFamilyList.ArticleName = request.UpdateFamilyShoppingListDto.ArticleName;

            try
            {
                await _articleRepository.UpdateShoppingListAsync(existingFamilyList);
                return existingFamilyList;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update FamilyList in the database", ex);
            }
        }
    }
}