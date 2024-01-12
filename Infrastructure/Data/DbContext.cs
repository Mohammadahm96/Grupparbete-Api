using Microsoft.EntityFrameworkCore;
using Domain.Models.UserModel;
using System.Collections.Generic;

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
