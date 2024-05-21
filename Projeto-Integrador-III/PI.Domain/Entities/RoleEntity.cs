using PI.Domain.Enum;

namespace PI.Domain.Entities
{
    public class RoleEntity : BaseEntity
    {
        public string Description { get; set; }
        public ELevel Level { get; set; }
    }
}
