using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SportStore.Models
{
    public class UsersDbContext:IdentityDbContext<IdentityUser>
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options):base(options)
        {            
        }
    }
}
