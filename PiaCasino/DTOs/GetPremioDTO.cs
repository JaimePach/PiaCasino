using PiaCasinoAppi.Entidades;
using System.ComponentModel.DataAnnotations;

namespace PiaCasino.DTOs
{
    public class GetPremioDTO
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Cual es el premio??")]
        public string Objeto { get; set; }

        [Required(ErrorMessage = "Que lugar se lleva el premio??")]
        public int Orden { get; set; }

       
        public int? BoletoID { get; set; }

        [Required(ErrorMessage = "A que rifa pertenece el premio???s")]
        public int RifaID { get; set; }

    }
}
