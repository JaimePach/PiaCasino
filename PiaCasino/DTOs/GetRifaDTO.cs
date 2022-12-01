using PiaCasino.Entidades;
using System.ComponentModel.DataAnnotations;

namespace PiaCasino.DTOs
{
    public class GetRifaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Falta rifa")]

        public string NombreRifa { get; set; }

        
    }
}
