namespace ServiceOrder.DTOs
{
    public class ServiceOrderUpdateDto
    {
        public int? TechnicianId { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
    }
}
