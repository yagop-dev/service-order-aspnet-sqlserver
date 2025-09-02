using ServiceOrder.Entities.ServiceOrder;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ServiceOrder.DTOs
{
    public class ServiceOrderUpdateDto
    {
        [DefaultValue(null)]
        public int? TechnicianId { get; set; }
        public ServiceOrderDepartment? Department { get; set; }

        [DefaultValue(null)]
        [StringLength(100, ErrorMessage = "Subject is too long")]
        public string? Subject { get; set; }
        [DefaultValue(null)]
        [StringLength(500, ErrorMessage = "Description is too long")]
        public string? Description { get; set; }

        [DefaultValue(null)]
        public ServiceOrderStatus? Status { get; set; }

        [DefaultValue(null)]
        public string? FilePath { get; set; }
    }
}
