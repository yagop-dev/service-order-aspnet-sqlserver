using ServiceOrder.Entities.ServiceOrder;
using System.ComponentModel.DataAnnotations;

namespace ServiceOrder.DTOs
{
    public class ServiceOrderCreateDto
    {
        [Required(ErrorMessage = "Client is required")]
        public int ClientId { get; set; }

        public int? TechnicianId { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public ServiceOrderDepartment Department { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public ServiceOrderType Type { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Title must have between 10 and 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Title must have between 5 and 100 characters")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Title must have between 10 and 500 characters")]
        public string Description { get; set; }
        
        public IFormFile FilePath { get; set; }
    }
}
