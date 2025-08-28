using System.ComponentModel.DataAnnotations;

namespace ServiceOrder.DTOs
{
    public class ClientCreateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(120, MinimumLength = 3, ErrorMessage = "Name must be higher than 3 characters")]
        public string Name { get; set; }

        [Phone(ErrorMessage = "Invalid Telephone")]
        [StringLength(20, ErrorMessage = "Telephone too long")]
        public string Telephone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid E-mail")]
        [StringLength(150, ErrorMessage = "E-mail too long")]
        public string Email { get; set; }
    }
}
