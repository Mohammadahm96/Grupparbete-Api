using Infrastructure.Data;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.AnimalRepository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DbContext _dbContext;

        public ArticleRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddShoppingListAsync<T>(T entity) where T : class
        {
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Börja inte med 'throw;' här om du inte gör något med undantaget.
                // Det kan göra felsökningen svårare.
                throw;
            }
        }
    }
}
