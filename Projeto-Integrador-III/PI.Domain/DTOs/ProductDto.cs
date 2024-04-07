namespace PI.Domain.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string EAN13 { get; set; }
        public string Description { get; set; }
    }
}
