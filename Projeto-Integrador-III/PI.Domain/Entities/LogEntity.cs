using PI.Domain.Enum;

namespace PI.Domain.Entities
{
    public class LogEntity : BaseEntity
    {
        public string UserName { get; set; }
        public string Log { get; set; }
        public DateTime DateRecord { get; set; }
        public ETypeLog TypeLog { get; set; }
    }
}
