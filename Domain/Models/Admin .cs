using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Admin:IdentityUser
    {
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } 
    }
}
