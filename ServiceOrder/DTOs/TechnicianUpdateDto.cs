using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ServiceOrder.DTOs
{
    public class TechnicianUpdateDto
    {
        [DefaultValue(null)]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(120, MinimumLength = 3, ErrorMessage = "Name must be higher than 3 characters")]
        public string? Name { get; set; }

        [DefaultValue(null)]
        [EmailAddress(ErrorMessage = "Invalid E-mail")]
        [StringLength(150, ErrorMessage = "E-mail too long")]
        public string? Email { get; set; }

        [DefaultValue(null)]
        [Required(ErrorMessage = "Registration is required")]
        [Range(1000, 9999, ErrorMessage = "Registration must have between 3 and 20 characters")]
        public int? Registration { get; set; }
    }
}
