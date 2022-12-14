using System.ComponentModel.DataAnnotations;



namespace PiaCasino.Entidades
{
    public class ParticipanteRifa
    {
      
        public int Id { get; set; }

        [Required(ErrorMessage = "A que rifa pertenece el boleto??")]
        public int RifaID { get; set; }

        [Required(ErrorMessage = "Que Participante va a comprar el boleto??")]
        public int ParticipanteID { get; set; }

        public Rifa Rifa { get; set; }

        public Participante Participante { get; set; }
    }
}
