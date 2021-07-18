using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystemDemo.Models
{
    public class TicketSystemContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TicketType> TicketType { get; set; }
        public DbSet<UserType> UserType { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=TicketSystemDB.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User Default
            modelBuilder.Entity<User>().HasData(new User
            {
                Userkey = Guid.Parse("cc96a024-e68b-4682-a6b2-c11632b197fd"),
                UserTypeKey = Guid.Parse("15b65d1f-b1a4-4b68-b562-f2dad9882007"),
                UserName = "QA User"
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Userkey = Guid.Parse("52dba8a3-89d7-4e89-9644-faa6cb012fa7"),
                UserTypeKey = Guid.Parse("8d5e5e67-6c1f-4379-bba2-ee0436253d85"),
                UserName = "RD User"
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Userkey = Guid.Parse("c22224c6-cb86-46bc-954c-dea23291f65d"),
                UserTypeKey = Guid.Parse("76226cc0-20d3-4004-90e9-5f34dd5aef24"),
                UserName = "PM User"
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Userkey = Guid.Parse("0b87b103-c317-4be1-bc77-bfbda650f44a"),
                UserTypeKey = Guid.Parse("cbea8e8f-8b9f-48b5-a7d3-40c9be502fd8"),
                UserName = "Admin"
            });
            #endregion

            #region UserType Default

            modelBuilder.Entity<UserType>().HasData(new UserType
            {
                UserTypeKey = Guid.Parse("15b65d1f-b1a4-4b68-b562-f2dad9882007"),
                UserTypeName = "QA"
            });
            modelBuilder.Entity<UserType>().HasData(new UserType
            {
                UserTypeKey = Guid.Parse("8d5e5e67-6c1f-4379-bba2-ee0436253d85"),
                UserTypeName = "RD"
            });
            modelBuilder.Entity<UserType>().HasData(new UserType
            {
                UserTypeKey = Guid.Parse("76226cc0-20d3-4004-90e9-5f34dd5aef24"),
                UserTypeName = "PM"
            });
            modelBuilder.Entity<UserType>().HasData(new UserType
            {
                UserTypeKey = Guid.Parse("cbea8e8f-8b9f-48b5-a7d3-40c9be502fd8"),
                UserTypeName = "ADMIN"
            });
            #endregion

            #region TicketType Default

            //for QA
            modelBuilder.Entity<TicketType>().HasData(new TicketType
            {
                TicketTypeKey = Guid.Parse("146c4440-62e1-4aba-b120-f061554c57f5"),
                TicketTypeName = "Default",
                UserTypeKey = Guid.Empty,
                ReadOnly = false,
                ResolveOnly = false,
            }) ;

            modelBuilder.Entity<TicketType>().HasData(new TicketType
            {
                TicketTypeKey = Guid.Parse("f8bc3132-6332-4b58-afe9-1f9649ed3a6d"),
                TicketTypeName = "Feature Request",
                UserTypeKey = Guid.Parse("76226cc0-20d3-4004-90e9-5f34dd5aef24"),
                ReadOnly = false,
                ResolveOnly = true,
            });

            modelBuilder.Entity<TicketType>().HasData(new TicketType
            {
                TicketTypeKey = Guid.Parse("91741c42-3e16-4c16-97e5-7e31dbef8b83"),
                TicketTypeName = "Test Case",
                UserTypeKey = Guid.Parse("15b65d1f-b1a4-4b68-b562-f2dad9882007"),
                ReadOnly = true,
                ResolveOnly = false,
            });
            #endregion


        }
    }
}
