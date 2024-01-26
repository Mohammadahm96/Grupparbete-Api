
using Domain.Models.ListModels;

namespace Infrastructure.Interface
{
    public interface IArticleRepository
    {
        Task AddShoppingListAsync<T>(T entity) where T : class;
        Task<string> GetFamilyNameAsync(Guid familyId);

        Task<List<string>> GetArticleNamesByFamilyIdAsync(Guid familyId);
        Task<FamilyArticleList> GetFamilyArticleAsync(Guid familyId, Guid articleId);
        Task UpdateShoppingListAsync<T>(T entity) where T : class;
    }
}