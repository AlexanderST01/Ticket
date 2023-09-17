using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticket.Models
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }

        [Required (ErrorMessage ="El compo Fecha es requerido")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo Cliente ID  es requerido")]
        public int ClienteId { get; set; }
        [ForeignKey(nameof(ClienteId))]
        public Clientes Cliente { get; set; }

        public int SistemaId { get; set; }
        [ForeignKey(nameof(SistemaId))]
        public Sistemas sistemas { get; set; }

        public int PrioridadId { get; set;}
        [ForeignKey(nameof(PrioridadId))]
        public Prioridades Prioridades { get; set; }

        [Required(ErrorMessage ="EL campo Solicitado por es requerido")]
        public string? SolicitadoPor { get; set; }

        [Required(ErrorMessage = "EL campo Asunto es requerido")]
        public string? Asunto { get; set; }

        [Required(ErrorMessage = "EL campo Descripcion es requerido")]
        public string? Descripcion { get; set; }

    }
}
