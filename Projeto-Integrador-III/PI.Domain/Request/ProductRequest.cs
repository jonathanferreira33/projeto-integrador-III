using PI.Domain.Enum;

namespace PI.Domain.Request
{
    public class ProductRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public ECategory Category
        {
            get => _category;
            set
            {
                _category = value;
            }
        }
        public string Description { get; set; }
        
        ECategory _category;
    }

}
