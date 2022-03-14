using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PasswordManager.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DBModels
{
    internal class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(x => x.USERNAME);
            builder.Property(x => x.USERNAME).HasColumnName("username");
            builder.Property(x => x.PASSWORD).HasColumnName("password");
        }
    }
}
