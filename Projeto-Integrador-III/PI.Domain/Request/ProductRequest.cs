using PI.Domain.Enum;
using System;

namespace PI.Domain.Request
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Category { get; set; }
        public string Description { get; set; }
    }

}
