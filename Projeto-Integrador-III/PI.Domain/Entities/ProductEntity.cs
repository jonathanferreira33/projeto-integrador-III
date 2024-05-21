using PI.Domain.Enum;

namespace PI.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public ECategory Category { get; set; }
    }
}
