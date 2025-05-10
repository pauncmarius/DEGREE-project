//UserProfileUpdate.cs

namespace FCUnirea.Business.Models
{
    public class NameUpdateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class UsernameUpdateModel
    {
        public string Username { get; set; }
    }

    public class EmailUpdateModel
    {
        public string Email { get; set; }
    }

    public class PhoneUpdateModel
    {
        public string PhoneNumber { get; set; }
    }

}
