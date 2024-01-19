using Application.Commands.FamilyShoppingListCommands.AddFamilyShoppingList;
using Domain.Models.ListModels;
using Infrastructure.Interface;
using MediatR;

public class AddArticleToFamilyShoppingListCommandHandler : IRequestHandler<AddArticleToFamilyShoppingListCommand, FamilyArticleList>
{
    private readonly IArticleRepository _articleRepository;

    public AddArticleToFamilyShoppingListCommandHandler(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public async Task<FamilyArticleList> Handle(AddArticleToFamilyShoppingListCommand request, CancellationToken cancellationToken)
    {
        // Kontrollera om FamilyId är giltigt
        if (request.NewFamilyShoppingList.FamilyId == Guid.Empty)
        {
            throw new Exception("FamilyId is required to add an article to the family shopping list.");
        }

        // Fetch the familyName based on FamilyId (assuming you have a method to get familyName from FamilyId)
        string familyName = await _articleRepository.GetFamilyNameAsync(request.NewFamilyShoppingList.FamilyId);

        FamilyArticleList familyListToCreate = new FamilyArticleList
        {
            FamilyId = request.NewFamilyShoppingList.FamilyId,
            ArticleId = Guid.NewGuid(), // This should be the same for a given family
            ArticleName = request.NewFamilyShoppingList.ArticleName,
            ArticleQuantity = 1,
            IsAvailable = true,
            FamilyName = familyName // Set the familyName
        };

        try
        {
            await _articleRepository.AddShoppingListAsync(familyListToCreate);
            return familyListToCreate;
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to add FamilyList to the database", ex);
        }
    }
}