using HostCloudMVC.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostCloudMVC.DAL.Contexts;

public class AppDbContext:IdentityDbContext<AppUser,AppRole,string>
{

  

    public DbSet<Cloud> Clouds { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }

    
}
