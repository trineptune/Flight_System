using FlightWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightWebApi.Data
{
    public class FlightDbContext:DbContext 
    {
        public DbSet<FlightModels> Flights { get; set; }
        public DbSet<FlightDocument> FlightsDocument { get; set; }
        public DbSet<Permisson> Permission {  get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<GroupPermission> GroupPermission { get; set; }
        
        public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightDocument>()
            .HasOne(f=>f.FlightModels)
            .WithMany(d=>d.FlightDocuments)
            .HasForeignKey(u => u.IdFlight);

            modelBuilder.Entity<Permisson>()
           .HasOne(f => f.DocumentType)
           .WithMany(p=>p.permissons)
           .HasForeignKey(u => u.TypeId);

            modelBuilder.Entity<DocumentType>()
           .HasOne(f => f.Documents)
           .WithOne(d => d.DocumentTypes).HasForeignKey<FlightDocument>(i => i.TypeId);

            modelBuilder.Entity<GroupPermission>()
           .HasOne(p=>p.Permisson)
           .WithOne(g=>g.GroupPermission).HasForeignKey<Permisson>(i => i.GroupPermissionId);

        }
    }
}
