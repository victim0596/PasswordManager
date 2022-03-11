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
    internal class PswManagerEntityConfiguration : EntityTypeConfiguration<PswManager>
    {
        public PswManagerEntityConfiguration(EntityTypeBuilder<PswManager> builder)
        {
            builder.ToTable("pswManager");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).HasColumnName("id");
            builder.Property(x => x.USERNAME).HasColumnName("username");
            builder.Property(x => x.PASSWORD).HasColumnName("password");
            builder.Property(x => x.APPNAME).HasColumnName("sitename");
        }
    }
}