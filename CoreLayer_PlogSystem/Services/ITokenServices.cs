using CoreLayer_BlogSystem.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer_BlogSystem.Services
{
    public interface ITokenServices
    {
        public Task<string> CreateTokenasync(AppUser user, UserManager<AppUser> userManager);
    }
}
