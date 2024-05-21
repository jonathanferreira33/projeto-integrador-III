using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PI.Domain.Entities;

namespace PI.Data_Access.Mapping
{
    public class RoleMap : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable("tb_role");
            builder.HasKey(x => x.Id);
        }
    }
}
