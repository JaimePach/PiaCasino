using System.ComponentModel.DataAnnotations;

namespace PiaCasino.DTOs
{
    public class EditarAdminDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
