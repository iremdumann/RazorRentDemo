using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorRentDemo.Model;

namespace RazorRentDemo.Data
{
    public class RentDbContext : DbContext
    {
        public RentDbContext (DbContextOptions<RentDbContext> options)
            : base(options)
        {
        }

        public DbSet<RazorRentDemo.Model.Car> Car { get; set; } = default!;

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(b => b.Avaliable)
                .HasDefaultValue(true);
        }
    }
}
