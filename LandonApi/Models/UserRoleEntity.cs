using System;
using Microsoft.AspNetCore.Identity;

namespace LandonApi.Models
{
    public class UserRoleEntity : IdentityRole<Guid>
    {
        public UserRoleEntity() : base()
        {
            
        }
        
        public UserRoleEntity(string roleName) : base(roleName)
        {
            
        }
    }
}