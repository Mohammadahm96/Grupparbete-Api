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

        public Task<string> GetSommarHusNameAsync(object sommarHusId)
        {
            throw new NotImplementedException();
        }
    }
}
