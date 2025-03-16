using FCUnirea.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FCUnirea.Business.Models
{

    public class UsersModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; } // Folosit la Register/Login
        public string PhoneNumber { get; set; }
        public UserRole Role { get; set; } = UserRole.Customer; // Implicit client
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
