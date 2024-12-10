using DEGREE.Data;
using FCUnirea.Domain.Entities;
using System;

namespace FCUnirea

{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new DataContext();

            var guest = new Users()
            {
                Username = "Mapau32",
                FirstName = "Marius",
                LastName = "Paun",
                PhoneNumber = "0766525113",
                Role = UserRole.Player,
                CreatedAt = DateTime.Now
            };

            context.Users.Add(guest);
            context.SaveChanges();
        }
    }
}
