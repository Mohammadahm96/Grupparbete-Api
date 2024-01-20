using Application.Commands.FamilyShoppingListCommands.AddFamilyList;
using Domain.Models.ListModels;
using Infrastructure.Data;
using MediatR;

public class AddFamilyCommandHandler : IRequestHandler<AddFamilyCommand, Guid>
{
    private readonly MyDbContext _myDbContext;

    public AddFamilyCommandHandler(MyDbContext myDbContext)
    {
        _myDbContext = myDbContext;
    }

    public async Task<Guid> Handle(AddFamilyCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newFamily = new FamilyArticleList
            {
                FamilyId = Guid.NewGuid(),
                FamilyName = request.FamilyDto.FamilyName,
                ArticleName = " ",
                ArticleQuantity = 0,
                IsAvailable = true
            };

            await _myDbContext.Set<FamilyArticleList>().AddAsync(newFamily);

            await _myDbContext.SaveChangesAsync();

            return newFamily.FamilyId;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in AddFamilyCommandHandler: {ex.Message}");

            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
            }

            throw;
        }
    }
}