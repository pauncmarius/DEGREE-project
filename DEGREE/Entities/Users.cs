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
        [Key]
        public int id_user { get; set; }

        public string username { get; set; }

        public string email { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string hashed_password { get; set; }

        public int phone_number { get; set; }

        public UserRole role { get; set; }

        public DateTime created_at { get; set; }

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
