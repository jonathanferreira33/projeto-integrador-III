namespace PI.Domain.Request
{
    public class SearchRequest
    {
        public string Name { get; set; }
        public string Ean13 { get; set; }
        public string Description { get; set; }
    }
}
