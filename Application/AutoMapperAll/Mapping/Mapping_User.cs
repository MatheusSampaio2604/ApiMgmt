using Domain.Models.ApplicationUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapperAll.Mapping
{
    internal class Mapping_User : IEntityTypeConfiguration<ApplicationUser>
        {
            public void Configure(EntityTypeBuilder<ApplicationUser> builder)
            {
                builder.HasKey(x => x.Id);

                builder.Property(x => x.Id);
                builder.Property(x => x.Name);
                builder.Property(x => x.DateRegister);

                builder.Property(x => x.Email);
                builder.Property(x => x.NormalizedEmail);
                builder.Property(x => x.EmailConfirmed);
                builder.Property(x => x.UserName);
                builder.Property(x => x.NormalizedUserName);
                builder.Property(x => x.PhoneNumber);
                builder.Property(x => x.PhoneNumberConfirmed);
                builder.Property(x => x.AccessFailedCount);
                builder.Property(x => x.ConcurrencyStamp);
                builder.Property(x => x.SecurityStamp);
                builder.Property(x => x.TwoFactorEnabled);
                builder.Property(x => x.LockoutEnabled);
                builder.Property(x => x.LockoutEnd);
                builder.Property(x => x.PasswordHash);
                
            }
        }
    }
