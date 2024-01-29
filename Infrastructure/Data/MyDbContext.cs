using Microsoft.EntityFrameworkCore;
using Domain.Models.UserModel;

using Domain.Models.ListModels;
using Infrastructure.Data.DatabaseHelper;

namespace Infrastructure.Data;

public class MyDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<FamilyArticleList> FamilyArticleList { get; set; }
    public virtual DbSet<SommarHusArticleList> SommarHusLists { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Call the SeedData method from the external class
        DatabaseSeedHelper.SeedData(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }
}