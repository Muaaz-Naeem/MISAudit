using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MISAudit.Models
{
    public class ApplicationUser : IdentityUser
    {
      
       
    }
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
 
            base.OnModelCreating(builder);
          
        }
    }

}
