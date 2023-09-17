using System.ComponentModel.DataAnnotations;

namespace Ticket.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadId { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [StringLength(150,ErrorMessage ="El campo Descripción no adminte mas de 150 caracteres")]
        public string? Descripcion { get; set; }

        [Range(1, 31, ErrorMessage = "Los dias prioridades deben estar entre 1 a 31")]
        public int DiasCompromiso { get; set; }
    }
}
