using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelos
{
    [MetadataType(typeof(EgresoMetaDato))]
    public partial class Egreso
    {
    }

    public class EgresoMetaDato
    {
        [Required]
        public System.DateTime fecha { get; set; }
        [Required]
        [Range(0,99999999999.99)]
        public decimal monto { get; set; }
        [Required]
        public long medicoId { get; set; }
        [Required]
        public long pacienteId { get; set; }
   
    }
}
