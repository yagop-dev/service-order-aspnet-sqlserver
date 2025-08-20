namespace ServiceOrder.DTOs
{
    public class ServiceOrderCreateDto
    {
        public int ClientId { get; set; }
        public int? TechnicianId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Status { get; set; }
    }
}
