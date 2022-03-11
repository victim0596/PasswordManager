using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PasswordManagerWPF.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerWPF.DBModels
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
