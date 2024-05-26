using PI.Domain.Entities;

namespace PI.Domain.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public List<RoleEntity> Role { get; set; }
    }
}
