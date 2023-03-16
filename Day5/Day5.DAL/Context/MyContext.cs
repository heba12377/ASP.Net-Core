using Day5.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Day5.DAL.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Developer> Developers => Set<Developer>();

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var _departments = JsonSerializer.Deserialize<List<Department>>("""[{"Id":1,"Name":"Automotive \u0026 Baby"},{"Id":2,"Name":"Beauty \u0026 Health"},{"Id":3,"Name":"Electronics"}]""") ?? new();

            var _developers = JsonSerializer.Deserialize<List<Developer>>("""[{"Id":1,"Name":"Freddie"},{"Id":2,"Name":"Sophia"},{"Id":3,"Name":"Angela"},{"Id":4,"Name":"Jamie"},{"Id":5,"Name":"Geoffrey"}]""") ?? new();

            //var _tickets = JsonSerializer.Deserialize<List<Ticket>>("""[{"Id":1,"Description":"Cumque unde dolores placeat reprehenderit et porro minima sit.","Severity":0,"DepartmentId":1,"Developers":[{"Id":1,"Name":"Freddie"}]},{"Id":2,"Description":"Qui voluptatem itaque ducimus quibusdam dolores vero sunt.","Severity":0,"DepartmentId":1,"Developers":[{"Id":2,"Name":"Geoffrey"}]},{"Id":3,"Description":"Ab atque alias et maiores dicta rerum officiis perferendis.","Severity":2,"DepartmentId":1,"Developers":[{"Id":2,"Name":"Angela"}]}]""") ?? new();


            //modelBuilder.Entity<Ticket>().HasData(_tickets);
            modelBuilder.Entity<Developer>().HasData(_developers);
            modelBuilder.Entity<Department>().HasData(_departments);


        }


    }
}
