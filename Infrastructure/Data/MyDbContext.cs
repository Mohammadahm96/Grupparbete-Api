using Microsoft.EntityFrameworkCore;
using Domain.Models.UserModel;
using Domain.Models.ListModels;

namespace Infrastructure.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<FamilyArticleList> FamilyArticleList { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
    }
}