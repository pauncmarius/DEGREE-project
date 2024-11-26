using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Entities
{

    public class Users
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string HashedPassword { get; set; }

        public int PhoneNumber { get; set; }

        public UserRole Role { get; set; }

        public DateTime CreatedAt { get; set; }

        //--------------Relations--------------------//

        public ICollection<News> News { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public ICollection<Feedback> FeedbackFromStaff { get; set; }
        public ICollection<Feedback> FeedbackToPlayers { get; set; }
        public ICollection<Tickets> Tickets { get; set; }
    }

    // Enum definition for roles
    public enum UserRole
    {
        Admin,
        Customers,
        Players,
        Staff
    }
}
