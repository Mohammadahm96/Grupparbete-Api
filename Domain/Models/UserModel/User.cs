﻿
namespace Domain.Models.UserModel
{
    public class User
    {
        public Guid UserId { get; set; }

        public required string Username { get; set; }

        public required string Password { get; set; }
    }
}
