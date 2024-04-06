namespace PI.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Amount { get; set; }
        public string EAN13 { get; set; }
        public string Description { get; set; }
    }
}
