using HostCloudMVC.Bl.Services;
using HostCloudMVC.DAL.Contexts;
using HostCloudMVC.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HostCloudMVC.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string? connecStr = builder.Configuration.GetConnectionString("PC");
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connecStr));

            builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<AppDbContext>() .AddDefaultTokenProviders();
         
            
           
                 
                

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<CloudService>();

            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
            app.MapControllerRoute(
                
                
                name: "Default",
                pattern:"{controller=Home}/{action=Index}"
                
                );

         

            app.Run();
        }
    }
}
