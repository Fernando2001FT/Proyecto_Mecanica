using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccesoData
{
    public class ServicioMecanico
    {
        [Key]
        public int id_servicio { get; set; }
        public string TipoDeservicio { get; set; }
        public decimal PrecioReferencial { get; set; }
        public string LugarDeServicio { get; set; }

        [ForeignKey("id_Mecanico")] 
        public int id_Mecanico  { get; set; }

        [ForeignKey("id_cliente")]
        public string id_cliente { get; set; }
    }
}
