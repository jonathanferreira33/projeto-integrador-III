using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PI.Domain.Entities;

namespace PI.Data_Access.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("tb_user");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(60);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Email).HasMaxLength(60);
            builder.Property(x => x.Password).HasMaxLength(150);
        }
    }
}
