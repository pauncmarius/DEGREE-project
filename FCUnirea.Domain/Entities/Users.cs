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

        public string HashedPassword { get; set; }

        public string PhoneNumber { get; set; }

        public UserRole Role { get; set; }

        public DateTime CreatedAt { get; set; }

        //--------------Relations--------------------//

        public ICollection<News> News { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public ICollection<Feedbacks> FeedbackFromStaff { get; set; }
        public ICollection<Feedbacks> FeedbackToPlayers { get; set; }
        public ICollection<Tickets> Tickets { get; set; }
    }

    // Enum definition for roles
    public enum UserRole
    {
        Admin,
        Customer,
        Player,
        Staff
    }
}
