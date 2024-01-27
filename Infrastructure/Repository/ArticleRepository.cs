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
        public async Task<FamilyArticleList> GetFamilyArticleAsync(Guid familyId, Guid articleId)
        {
            try
            {
                var familyList = await _myDbContext.FamilyArticleList
                    .Where(f => f.FamilyId == familyId && f.ArticleId == articleId)
                    .FirstOrDefaultAsync();

                return familyList;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve FamilyArticle from the database", ex);
            }
        }

        public async Task UpdateShoppingListAsync<T>(T entity) where T : class
        {
            try
            {
                _myDbContext.Set<T>().Update(entity);
                await _myDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update FamilyList in the database", ex);
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

        public async Task<List<string>> GetArticleNamesByFamilyIdAsync(Guid familyId)
        {
            try
            {
                var articleNames = await _myDbContext.FamilyArticleList
                    .Where(f => f.FamilyId == familyId)
                    .Select(f => f.ArticleName)
                    .ToListAsync();

                return articleNames;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve ArticleNames from the database", ex);
            }
        }
        public async Task DeleteFamilyArticleAsync(string familyId, string articleId)
        {
            try
            {
                var familyList = new FamilyArticleList { FamilyId = Guid.Parse(familyId), ArticleId = Guid.Parse(articleId) };
                _myDbContext.Remove(familyList);
                await _myDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception ("Failed to delete", ex);
            }
        }

    }
}