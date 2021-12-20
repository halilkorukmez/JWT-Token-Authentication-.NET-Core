using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .HasMaxLength(30)
                .IsRequired(true);

            builder.Property(a => a.UserName)
                .HasMaxLength(15)
                .IsRequired(true);

            builder.Property(a => a.Password)
                .HasMaxLength(20)
                .IsRequired(true);

            builder.Property(a => a.IsActive)
                .IsRequired(true);
        }
    }
}
