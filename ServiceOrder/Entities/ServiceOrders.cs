namespace ServiceOrder.Entities
{
    public class ServiceOrders
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Status { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int? TechnicianId { get; set; }
        public Technician? Technician { get; set; }
    }
}
