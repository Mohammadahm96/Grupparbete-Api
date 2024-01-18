
namespace Infrastructure.Interface
{
    public interface IArticleRepository
    {
        Task AddShoppingListAsync<T>(T entity) where T : class;

        Task<Guid> AddFamilyAsync(string familyName);
    }
}