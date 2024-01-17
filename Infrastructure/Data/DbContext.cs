using Microsoft.EntityFrameworkCore;
using Domain.Models.UserModel;

namespace Infrastructure.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

    }
}