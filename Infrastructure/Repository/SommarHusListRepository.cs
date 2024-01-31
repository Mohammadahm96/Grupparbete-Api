using Domain.Models.ListModels;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class SommarHusListRepository : ISommarHusListRepository
    {
        private readonly MyDbContext _context;

        public SommarHusListRepository(MyDbContext context)
        {
            _context = context;

        }

        public async Task AddShoppingListAsync<T>(T entity) where T : class
        {

            try
            {

                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<SommarHusArticleList?> CreateSommarHusListAsync(SommarHusArticleList sommarHusArticleList)
        {
            _context.SommarHusLists.Add(sommarHusArticleList);
            await _context.SaveChangesAsync();
            return sommarHusArticleList;
        }
        public async Task<List<SommarHusArticleList>> GetAllSommarHusListAsync()
        {
            return await _context.SommarHusLists.ToListAsync();
        }
        public async Task<SommarHusArticleList?> GetSommarHusListByIdAsync(Guid id)
        {
            return await _context.SommarHusLists.FirstOrDefaultAsync(sommarHusArticleList => sommarHusArticleList.SommarHusId == id);
        }
        public async Task<SommarHusArticleList?> DeleteSommarHusListByIdAsync(Guid id)
        {
            SommarHusArticleList? sommarHusArticleListToDelete = await _context.SommarHusLists.FirstOrDefaultAsync(sommarHusArticleList => sommarHusArticleList.SommarHusId == id);
            if (sommarHusArticleListToDelete != null)
            {
                _context.SommarHusLists.Remove(sommarHusArticleListToDelete);
                await _context.SaveChangesAsync();
                return sommarHusArticleListToDelete;
            }
            return null;
        }
        public async Task<SommarHusArticleList?> UpdateSommarHusListByIdAsync(Guid id)
        {
            SommarHusArticleList? sommarHusArticleListToUpdate = await _context.SommarHusLists.FirstOrDefaultAsync(sommarHusArticleList => sommarHusArticleList.SommarHusId == id);
            if (sommarHusArticleListToUpdate != null)
            {
                _context.SommarHusLists.Update(sommarHusArticleListToUpdate);
                await _context.SaveChangesAsync();
                return sommarHusArticleListToUpdate;
            }
            return null;
        }

        public async Task<string> GetHouseNameAsync(Guid sommarHusId)
        {
            try
            {
                var sommarHus = await _context.SommarHusLists
                    .Where(sh => sh.SommarHusId == sommarHusId)
                    .FirstOrDefaultAsync();

                if (sommarHus != null)
                {
                    return sommarHus.HouseName;
                }
                else
                {
                    throw new InvalidOperationException($"SommarHus with ID {sommarHusId} not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve houseName from the database", ex);
            }
        }

        public async Task<List<string>> GetArticleNamesBySommarHusIdAsync(Guid SommarHusId)
        {
            try
            {
                var articleNames = await _context.SommarHusLists
                    .Where(f => f.SommarHusId == SommarHusId)
                    .Select(f => f.ArticleName)
                    .ToListAsync();

                return articleNames;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve ArticleNames from the database", ex);
            }
        }

        public async Task<List<object>> GetIdAndNameAsync()
        {
            try
            {
                var idAndNames = await _context.SommarHusLists
                    .OfType<SommarHusArticleList>()
                    .Select(sh => new { SommarHusId = sh.SommarHusId, HouseName = sh.HouseName })
                    .ToListAsync();

                // Logga antalet rader och varje rad för felsökning
                Console.WriteLine($"Antal rader hämtade från databasen: {idAndNames.Count}");
                foreach (var item in idAndNames)
                {
                    Console.WriteLine($"SommarHusId: {item.SommarHusId}, HouseName: {item.HouseName}");
                }

                return idAndNames.Cast<object>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve IDs and names from the database", ex);
            }
        }
    }
}
