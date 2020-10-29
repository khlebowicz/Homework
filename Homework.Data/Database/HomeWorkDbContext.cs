using Homework.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Data.Database
{
    public class HomeWorkDbContext : DbContext
    {
        public HomeWorkDbContext(DbContextOptions<HomeWorkDbContext> options) : base(options) { }

        public DbSet<Performance> Performance { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(user =>
            {
                user.HasKey(s => s.Id);
                user.Property(s => s.FullName).IsRequired();
                user.Property(s => s.IsVip).IsRequired();
            });

            modelBuilder.Entity<Performance>(performance =>
            {
                performance.HasKey(s => s.Id);
                performance.Property(s => s.Name).IsRequired();
                performance.HasMany(s => s.Seats).WithOne();
            });

            modelBuilder.Entity<Seat>(seat =>
            {
                seat.HasKey(c => c.Id);
                seat.Property(c => c.Row).IsRequired();
                seat.Property(c => c.Column).IsRequired();
                seat.HasMany(c => c.Reservations).WithOne();
            });

            modelBuilder.Entity<Reservation>(reservation =>
            {
                reservation.HasKey(t => t.Id);
                reservation.Property(t => t.UserId).IsRequired();
                reservation.Property(t => t.UntilWhen).IsRequired();
            });

        }
    }
}
