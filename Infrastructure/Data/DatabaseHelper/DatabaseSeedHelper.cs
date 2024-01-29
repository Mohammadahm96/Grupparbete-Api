using Domain.Models.UserModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DatabaseHelper
{
    public static class DatabaseSeedHelper
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            SeedUsers(modelBuilder);
            // Add more methods for other entities as needed
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                 new User { UserId = new Guid("08260479-52a0-4c0e-a588-274101a2c3be"), Username = "Bojan", Password = BCrypt.Net.BCrypt.HashPassword("Bojan123") },
            new User { UserId = new Guid("047425eb-15a5-4310-9d25-e281ab036868"), Username = "Sandra", Password = BCrypt.Net.BCrypt.HashPassword("Sandra123") },
            new User { UserId = new Guid("047425eb-15a5-4310-9d25-e281ab036869"), Username = "Mohamed", Password = BCrypt.Net.BCrypt.HashPassword("Mohamad123") },
            new User { UserId = new Guid("047425eb-15a5-4310-9d25-e281ab036870"), Username = "Felix", Password = BCrypt.Net.BCrypt.HashPassword("Felix123") },
            new User { UserId = new Guid("047425eb-15a5-4310-9d25-e281ab036871"), Username = "Kamphol", Password = BCrypt.Net.BCrypt.HashPassword("Kamphol123") },
            new User { UserId = new Guid("047425eb-15a5-4310-9d25-e281ab036872"), Username = "Louis", Password = BCrypt.Net.BCrypt.HashPassword("Louis123") }
            );
        }
    }
}
