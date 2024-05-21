using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PI.Domain.Entities;

namespace PI.Data_Access.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("tb_category");
            builder.HasKey(x => x.Id);
        }
    }
}
