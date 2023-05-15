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
    public class UserConfiguration : IEntityTypeConfiguration<ApiUser>
    {
        public void Configure(EntityTypeBuilder<ApiUser> builder)
        {
            var hasher = new PasswordHasher<ApiUser>();
            builder.HasData(
                new ApiUser
                {
                    Id = Guid.Parse("2e6c2d6a-dc83-4bab-b7a9-98ae31ee16bb"),
                    FirstName = "Mansur",
                    LastName = "Xamrayev",
                    UserName = "Khmansur",
                    NormalizedUserName = "KHMANSUR",
                    PasswordHash = hasher.HashPassword(null, "Khmansur8#")
                }
            );
        }
    }
}
