using System.ComponentModel.DataAnnotations;

namespace ServiceOrder.DTOs
{
    public class TechnicianCreateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(120, MinimumLength = 3, ErrorMessage = "Name must be higher than 3 characters")]
        public string Name { get; set; }
    }
}
