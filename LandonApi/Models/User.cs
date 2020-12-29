using System;

namespace LandonApi.Models
{
    public class User : Resource
    {
        public string Email { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}