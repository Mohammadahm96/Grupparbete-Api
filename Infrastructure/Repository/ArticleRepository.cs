
using Infrastructure.Data;
using Infrastructure.Interface;

namespace Infrastructure.Repositories.AnimalRepository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MyDbContext _MyDbContext;

        public ArticleRepository(MyDbContext myDbContext)
        {
            _MyDbContext = _MyDbContext;

        }

        public async Task AddShoppingListAsync<T>(T entity) where T : class
        {

            try
            {

                await _MyDbContext.Set<T>().AddAsync(entity);
                await _MyDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}