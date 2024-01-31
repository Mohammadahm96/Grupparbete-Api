using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models.ListModels;
using Infrastructure.Interface;

namespace Application.Commands.FamilyShoppingListCommands.DeleteFamilyShoppingList
{
    public class DeleteArticleFromFamilyShoppingListCommandHandler : IRequestHandler<DeleteArticleFromFamilyShoppingListCommand, FamilyArticleList>
    {
        private readonly IArticleRepository _articleRepository;

        public DeleteArticleFromFamilyShoppingListCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<FamilyArticleList> Handle(DeleteArticleFromFamilyShoppingListCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.DeleteFamilyShoppingListDto.FamilyId) || string.IsNullOrEmpty(request.DeleteFamilyShoppingListDto.ArticleId))
            {
                throw new Exception("FamilyId and ArticleId are required to delete an article from the family shopping list.");
            }

            if (!Guid.TryParse(request.DeleteFamilyShoppingListDto.FamilyId, out var familyId) || !Guid.TryParse(request.DeleteFamilyShoppingListDto.ArticleId, out var articleId))
            {
                throw new Exception("Invalid format for FamilyId or ArticleId.");
            }

            try
            {
                await _articleRepository.DeleteFamilyArticleAsync(request.DeleteFamilyShoppingListDto.FamilyId, request.DeleteFamilyShoppingListDto.ArticleId);
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete FamilyList from the database", ex);
            }
        }
    }
}