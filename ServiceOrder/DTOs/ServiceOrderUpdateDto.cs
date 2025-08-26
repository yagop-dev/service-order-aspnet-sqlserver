using ServiceOrder.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ServiceOrder.DTOs
{
    public class ServiceOrderUpdateDto
    {
        [DefaultValue(null)]
        public int? TechnicianId { get; set; }
        [DefaultValue(null)]
        [StringLength(500, ErrorMessage = "Description is too long")]
        public string? Description { get; set; }

        [DefaultValue(null)]
        public ServiceOrderStatus? Status { get; set; }
    }
}
