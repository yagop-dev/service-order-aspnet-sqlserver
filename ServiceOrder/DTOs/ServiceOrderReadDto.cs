using ServiceOrder.Entities;

namespace ServiceOrder.DTOs
{
    public class ServiceOrderReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ServiceOrderStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public ClientDto Client { get; set; }
        public TechnicianDto Technician { get; set; }
    }
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class TechnicianDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
