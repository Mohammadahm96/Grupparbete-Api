using Domain.Models.ListModels;

namespace Infrastructure.Interfaces
{
    public interface ISommarHusListRepository
    {
        Task AddShoppingListAsync<T>(T entity) where T : class;
        Task<SommarHusArticleList?> CreateSommarHusListAsync(SommarHusArticleList sommarHusList);
        Task<List<SommarHusArticleList>> GetAllSommarHusListAsync();
        Task<SommarHusArticleList?> GetSommarHusListByIdAsync(Guid id);
        Task<SommarHusArticleList?> DeleteSommarHusListByIdAsync(Guid id);
        Task<SommarHusArticleList?> UpdateSommarHusListByIdAsync(Guid id);

        Task<string> GetHouseNameAsync(Guid sommarHusId);

        Task<List<string>> GetArticleNamesBySommarHusIdAsync(Guid sommarHusId);
        //Task<List<(Guid SommarHusId, string HouseName)>> GetIdAndNameAsync();
        Task<List<object>> GetIdAndNameAsync();
    }
}
