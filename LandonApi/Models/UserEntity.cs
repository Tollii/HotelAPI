using System;
using Microsoft.AspNetCore.Identity;

namespace LandonApi.Models
{
    public class UserEntity : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        
    }
}