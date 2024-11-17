using FCUnirea.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEGREE.Data
{
    public class DataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=FCUnirea;Trusted_Connection=True;";
            options.UseSqlServer(connectionString);
        }

        public DbSet<Users> Users { get; set; }
    }
}
