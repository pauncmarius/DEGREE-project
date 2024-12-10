using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //--------------Relations--------------------//

        public ICollection<NewsModel> News { get; set; }
        public ICollection<CommentsModel> Comments { get; set; }
        public ICollection<FeedbacksModel> FeedbackFromStaff { get; set; }
        public ICollection<FeedbacksModel> FeedbackToPlayers { get; set; }
        public ICollection<TicketsModel> Tickets { get; set; }
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
