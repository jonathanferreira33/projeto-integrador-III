namespace PI.Domain.Request
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string EAN13 { get; set; }
        public string Description { get; set; }
    }
}
