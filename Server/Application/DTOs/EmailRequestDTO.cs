using System.ComponentModel.DataAnnotations;

namespace Server.Application.DTOs
{
    public class EmailRequestDTO
    {
        [Required(ErrorMessage = "FromEmail is required")]
        [EmailAddress(ErrorMessage = "FromEmail is invalid")]
        public string? FromEmail { get; set; }

        [Required(ErrorMessage = "ToEmail is required")]
        [EmailAddress(ErrorMessage = "ToEmail is invalid")]
        public string? ToEmail { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string? Subject { get; set; }

        [Required(ErrorMessage = "Body is required")]
        public string? Body { get; set; }

    }
}
