﻿namespace PI.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        //public List<string> Role { get; set; }
    }
}