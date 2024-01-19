using Domain.Models.ListModels;
using Infrastructure.Data;
using Infrastructure.Interface;

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
        
        //public async Task<Guid> AddFamilyAsync(string familyName)
        //{
        //    try
        //    {
        //        var newFamily = new FamilyArticleList
        //        {
        //            FamilyId = Guid.NewGuid(),
        //            FamilyName = familyName
        //        };

        //        await _myDbContext.Set<FamilyArticleList>().AddAsync(newFamily);
        //        await _myDbContext.SaveChangesAsync();

        //        return newFamily.FamilyId;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Hantera undantag här om det behövs
        //        throw;
        //    }
        //}
        
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
                    // Handle the case when the family with the given ID is not found
                    // You can throw an exception or return a default value as needed
                    throw new InvalidOperationException($"Family with ID {familyId} not found.");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions according to your application's requirements
                throw new Exception("Failed to retrieve familyName from the database", ex);
            }
        }
    }
}