using Microsoft.EntityFrameworkCore;
using ServiceOrder.Entities;


namespace ServiceOrder.Data
{
    public class SystemDbContext : DbContext
    {
        //Builder whos receives the DbContext configuration options
        public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options) {}

        //Tables definition
        public DbSet<Client> Clients { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<ServiceOrders> ServiceOrders { get; set; }

        //Method to configure the creation of tables and relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Relationships between entities
            modelBuilder.Entity<Client>()
                .HasMany(c => c.ServiceOrders)
                .WithOne(so => so.Client)
                .HasForeignKey(so => so.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Technician>()
                .HasMany(t => t.ServiceOrders)
                .WithOne(so => so.Technician)
                .HasForeignKey(so => so.TechnicianId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Technician>().ToTable("Technicians");
            modelBuilder.Entity<ServiceOrders>().ToTable("ServiceOrders");
        }
    }
}
