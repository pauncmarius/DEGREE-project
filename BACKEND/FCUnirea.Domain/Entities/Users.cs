//Users
using System;
using System.Collections.Generic;

namespace FCUnirea.Domain.Entities
{

    public class Users : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }

        //--------------Relations--------------------//

        public ICollection<News> Users_News { get; set; }
        public ICollection<Comments> Users_Comments { get; set; }
        public ICollection<Tickets> Users_Tickets { get; set; }
    }
    public enum UserRole
    {
        Admin,
        Customer
    }
}
