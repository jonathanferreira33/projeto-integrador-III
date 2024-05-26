using PI.Domain.Enum;

namespace PI.Domain.Request
{
    public class SearchRequest
    {
        public string Name { get; set; }
        public ECategory Category { get; set; }
        public string Description { get; set; }
        public DateTime DateRecord { get; set; }
    }
}
