using FCUnirea.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Data.Mappings
{
    internal abstract class UsersMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<Users>()
                .Property(s => s.Email)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
