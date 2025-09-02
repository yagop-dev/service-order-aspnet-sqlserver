namespace ServiceOrder.Entities.ServiceOrder
{
    public class ServiceOrders
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ServiceOrderStatus Status { get; set; } = ServiceOrderStatus.Pending;
        public ServiceOrderDepartment Department { get; set; }
        public ServiceOrderType Type { get; set; }
        public string? FilePath { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int? TechnicianId { get; set; }
        public Technician? Technician { get; set; }
    }
}
