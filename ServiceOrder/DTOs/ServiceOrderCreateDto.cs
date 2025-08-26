using ServiceOrder.Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceOrder.DTOs
{
    public class ServiceOrderCreateDto
    {
        [Required(ErrorMessage = "Client is required")]
        public int ClientId { get; set; }

        public int? TechnicianId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Title must have between 10 and 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Title must have between 10 and 500 characters")]
        public string Description { get; set; }
        public ServiceOrderStatus? Status { get; set; }
    }
}
