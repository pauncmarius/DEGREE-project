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

        public string HashedPassword { get; set; }

        public string PhoneNumber { get; set; }

        public UserRole Role { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
