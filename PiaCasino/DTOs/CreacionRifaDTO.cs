using System.ComponentModel.DataAnnotations;

namespace PiaCasino.DTOs
{
    public class CreacionRifaDTO
    {
        [Required(ErrorMessage = "Falta rifa")]
        public string NombreRifa { get; set; }



    }
}
