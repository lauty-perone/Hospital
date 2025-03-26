using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelos
{
    [MetadataType(typeof(MedicoMetaDato))]
    public partial class Medico //Extensión del modelo original con el mismo nombre
    {
    }
    public class MedicoMetaDato //se aplica como Metadato
    {
        [Required] //Campo obligatorio, esto es un validador
        [StringLength(10)]
        public string cedula { get; set; }
        [Required]
        [StringLength(50)]
        public string nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string apellidoPaterno { get; set; }
        [StringLength(50)]
        public string apellidoMaterno { get; set; }
        [Required]
        public bool esEspecialista { get; set; }
        [Required]
        public bool habilitado { get; set; }
    }
}
