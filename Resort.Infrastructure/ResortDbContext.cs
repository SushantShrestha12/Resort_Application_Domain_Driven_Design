using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Resort.Domain;
using Resort.Domain.Bookings;
using Resort.Domain.Customers;
using Resort.Domain.Firms;
using Resort.Domain.LandingPages;
using Resort.Domain.Orders;
using Resort.Domain.RoomHistory;
using Resort.Domain.Rooms;
using Document = Resort.Domain.Document.Document;

namespace Resort.Infrastructure
{
    public class ResortDbContext : DbContext
    {
        public ResortDbContext(DbContextOptions<ResortDbContext> options)
            : base(options)
        {

        }

        public DbSet<Firm> Firms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CheckInOutLogs> CheckInOutLogs { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<SignUp> SignUps { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<CheckInDetail> CheckInDetails { get; set; }
        public DbSet<CheckOutDetail> CheckOutDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ResortDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

