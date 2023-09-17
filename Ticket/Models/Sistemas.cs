using System.ComponentModel.DataAnnotations;

namespace Ticket.Models
{
    public class Sistemas
    {
        [Key]
        public int SistemasId { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [StringLength(50,ErrorMessage ="El campo Nombre no admite mas de 50 caracteres")]
        public string NombreSistema { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es requerido")]
        public string Descripcion { get; set; }
    }
}
