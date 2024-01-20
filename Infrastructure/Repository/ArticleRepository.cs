using Domain.Models.ListModels;
using Infrastructure.Data;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MyDbContext _myDbContext;

        public ArticleRepository(MyDbContext mydbContext)
        {
            _myDbContext = mydbContext;
        }

        public async Task AddShoppingListAsync<T>(T entity) where T : class
        {
            try
            {
                await _myDbContext.Set<T>().AddAsync(entity);
                await _myDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<string> GetFamilyNameAsync(Guid familyId)
        {
            try
            {

                var family = await _myDbContext.FamilyArticleList
                    .Where(f => f.FamilyId == familyId)
                    .FirstOrDefaultAsync();

                if (family != null)
                {
                    return family.FamilyName;
                }
                else
                {
                    throw new InvalidOperationException($"Family with ID {familyId} not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve familyName from the database", ex);
            }
        }

        public async Task<Guid> AddFamilyAsync(string familyName)
        {
            try
            {
                var newFamily = new FamilyArticleList
                {
                    FamilyId = Guid.NewGuid(),
                    FamilyName = familyName,
                };

                await _myDbContext.Set<FamilyArticleList>().AddAsync(newFamily);
                await _myDbContext.SaveChangesAsync();

                return newFamily.FamilyId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}