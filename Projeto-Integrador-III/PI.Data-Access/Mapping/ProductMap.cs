using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PI.Domain.Entities;

namespace PI.Data_Access.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("tb_product");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Category);
        }
    }
}