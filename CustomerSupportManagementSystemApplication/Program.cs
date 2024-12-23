using CustomerSupportManagementSystemApplication.Data;
using CustomerSupportManagementSystemApplication.Interface;
using CustomerSupportManagementSystemApplication.Repositories;
using CustomerSupportManagementSystemApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace CustomerSupportManagementSystemApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CustomerManagementDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped(typeof(ICustomerManangementRepo<>), typeof(CustomerManangementRepo<>));
            builder.Services.AddScoped<ITicketService, TicketService>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapAreaControllerRoute(
            name: "Admin",
            areaName: "Admin",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

            app.MapAreaControllerRoute(
                name: "Customer",
                areaName: "Customer",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

            app.MapAreaControllerRoute(
                name: "SupportAgent",
                areaName: "SupportAgent",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );



            app.Run();
        }
    }
}
