using CoreLayer_BlogSystem.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer_BlogSystem.Entities.Identity
{
     public class AppUser : IdentityUser
     {
        public UserRole Role { get; set; }


     }
}
