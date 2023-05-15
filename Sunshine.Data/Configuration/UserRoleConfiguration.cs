using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sunshine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunshine.Data.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            var hasher = new PasswordHasher<ApiUser>();
            builder.HasData(
                new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse("2e6c2d6a-dc83-4bab-b7a9-98ae31ee16bb"),
                    RoleId = Guid.Parse("2e6c2d6a-ca83-4bab-b7a9-98ae31ee16ec")
                }
            );
        }
    }
}
