using FlightWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightWebApi.Data
{
    public class FlightDbContext:DbContext 
    {
        public DbSet<FlightModels> Flights { get; set; }
        public DbSet<FlightDocument> FlightsDocument { get; set; }
        public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightDocument>()
            .HasOne(f=>f.FlightModels)
            .WithMany(d=>d.FlightDocuments)
            .HasForeignKey(u => u.IdFlight);
        }
    }
}
