using System.ComponentModel.DataAnnotations;

namespace Registro_de_Prioridades.Models
{
    public class Prioridades {

        [Key]
        public int PrioridadId { get; set; }
        public string Descripcion { get; set; } = String.Empty;

        public DateTime DiasCompromiso { get; set; } = DateTime.Today;
    }
}
