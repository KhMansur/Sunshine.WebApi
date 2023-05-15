using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sunshine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                    new Role
                    {
                        Id = Guid.Parse("2e6c2d6a-ca83-4bab-b7a9-98ae31ee16ec"),
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new Role
                    {
                        Id = Guid.Parse("2e6c2d6a-ca12-4bab-b7a9-98ae31ee16ec"),
                        Name = "Manager",
                        NormalizedName = "MANAGER"
                    },
                    new Role
                    {
                        Id = Guid.Parse("2e6c7d6a-ca12-4bab-b7a9-98ae31ee16ec"),
                        Name = "Teacher",
                        NormalizedName = "TEACHER"
                    },
                    new Role
                    {
                        Id = Guid.Parse("2e6c7d6a-ca12-4bab-b7a9-98ae31ee89ec"),
                        Name = "Student",
                        NormalizedName = "STUDENT"
                    }
                );
        }
    }
}
