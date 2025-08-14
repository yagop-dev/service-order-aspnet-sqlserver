using Microsoft.EntityFrameworkCore;
using ServiceOrder.Entities;


namespace ServiceOrder.Data
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options) {}

        public DbSet<Client> Clients { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<ServiceOrders> ServiceOrders { get; set; }
    }
}
