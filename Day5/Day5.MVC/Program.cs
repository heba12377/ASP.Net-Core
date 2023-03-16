using Day5.BL.Managers.Tickets;
using Day5.DAL.Context;
using Day5.DAL.Repos.TicketRepo;
using Microsoft.EntityFrameworkCore;

namespace Day5.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            var connectionString = builder.Configuration.GetConnectionString("TicketSystem");
            builder.Services.AddDbContext<MyContext>(options
                => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<ITicketsManager, TicketsManager>();
            builder.Services.AddScoped<ITicketsRepo, TicketsRepo>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}