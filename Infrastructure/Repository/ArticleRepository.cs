﻿using Infrastructure.Data;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.AnimalRepository
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
                // Börja inte med 'throw;' här om du inte gör något med undantaget.
                // Det kan göra felsökningen svårare.
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