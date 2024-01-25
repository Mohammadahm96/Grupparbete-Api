using Application.Commands.SommarHusListCommands.AddArticleSommarhusList;
using Domain.Models.ListModels;
using Infrastructure.Interfaces;
using MediatR;

public class AddArticleToSommarHusShoppingListCommandHandler : IRequestHandler<AddArticleToSommarHusShoppingListCommand, SommarHusArticleList>
{
    private readonly ISommarHusListRepository _sommarHusListRepository;

    public AddArticleToSommarHusShoppingListCommandHandler(ISommarHusListRepository sommarHusListRepository)
    {
        _sommarHusListRepository = sommarHusListRepository;
    }

    public async Task<SommarHusArticleList> Handle(AddArticleToSommarHusShoppingListCommand request, CancellationToken cancellationToken)
    {
        // Kontrollera om SommarHusId är giltigt
        if (request.NewSommarHusShoppingList.SommarHusId == Guid.Empty)
        {
            throw new Exception("SommarHusId is required to add an article to the sommarHus shopping list.");
        }

        // Fetch the houseName based on HouseId (assuming you have a method to get houseName from HouseId)
        string houseName = await _sommarHusListRepository.GetSommarHusNameAsync(request.NewSommarHusShoppingList.SommarHusId);

        SommarHusArticleList sommarHusListToCreate = new SommarHusArticleList
        {
            SommarHusId = request.NewSommarHusShoppingList.SommarHusId,
            ArticleId = Guid.NewGuid(),
            ArticleName = request.NewSommarHusShoppingList.ArticleName,
            ArticleQuantity = 1,
            IsAvailable = true,
            HouseName = houseName // Set the houseName
        };

        try
        {
            await _sommarHusListRepository.AddShoppingListAsync(sommarHusListToCreate);
            return sommarHusListToCreate;
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to add SommarHusList to the database", ex);
        }
    }
}