using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticket.Models
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }

        [Required(ErrorMessage = "El compo Fecha es requerido")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El campo Cliente ID  es requerido")]
        public int ClienteId { get; set; }
        [ForeignKey(nameof(ClienteId))]
        public Clientes Cliente { get; set; }
        [Required(ErrorMessage = "EL campo Cliente ID es requerido")]
        public int SistemaId { get; set; }
        [ForeignKey(nameof(SistemaId))]
        public Sistemas sistemas { get; set; }
        [Required(ErrorMessage = "EL campo Prioridad ID es requerido")]
        public int PrioridadId { get; set;}
        [ForeignKey(nameof(PrioridadId))]
        public Prioridades Prioridades { get; set; }

        [Required(ErrorMessage ="EL campo Solicitado es requerido")]
        [StringLength(50, ErrorMessage = "El compo Solicitado por supera los 50 caracteres")]
        public string? SolicitadoPor { get; set; }

        [Required(ErrorMessage = "EL campo Asunto es requerido")]
        [StringLength(100, ErrorMessage = "El compo Asunto supera los 100 caracteres")]
        public string? Asunto { get; set; }

        [Required(ErrorMessage = "EL campo Descripcion es requerido")]
        [StringLength(100, ErrorMessage = "El compo Decripción supera los 100 caracteres")]
        public string? Descripcion { get; set; }






    }
}
