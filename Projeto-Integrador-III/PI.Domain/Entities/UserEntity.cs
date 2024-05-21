namespace PI.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PassWordCrypt { get; set; }
        public List<RoleEntity> Role { get; set; }
    }
}