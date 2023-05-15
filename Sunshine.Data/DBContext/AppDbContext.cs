using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sunshine.Data.Configuration;
using Sunshine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Data.DBContext
{
    public class AppDbContext : IdentityDbContext<ApiUser, Role, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Speciality> Specialities { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentPayment> StudentPayments { get; set;}

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<TeacherPayment> TeacherPayments { get; set;}

        public DbSet<Message> Messages { get; set; }

        public DbSet<Chat> Chats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            
            base.OnModelCreating(builder);
        }
    }
}
