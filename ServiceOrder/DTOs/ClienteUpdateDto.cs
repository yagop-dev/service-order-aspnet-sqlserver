using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ServiceOrder.DTOs
{
    public class ClienteUpdateDto
    {
        [DefaultValue(null)]
        [StringLength(120, MinimumLength = 3, ErrorMessage = "Name must be higher than 3 characters")]
        public string? Name { get; set; }

        [Phone(ErrorMessage = "Invalid Telephone")]
        [StringLength(20, ErrorMessage = "Telephone is too long")]
        [DefaultValue(null)]
        public string? Telephone { get; set; }

        [DefaultValue(null)]
        [EmailAddress(ErrorMessage = "Invalid E-mail")]
        [StringLength(150, ErrorMessage = "E-mail is too long")]
        public string? Email { get; set; }
    }
}
