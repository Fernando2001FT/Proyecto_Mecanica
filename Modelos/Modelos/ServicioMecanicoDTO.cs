namespace Modelos
{
    public class ServicioMecanicoDTO
    {
        public int id_servicio { get; set; }
        public string TipoDeservicio { get; set; }
        public decimal PrecioReferencial { get; set; }
        public string LugarDeServicio { get; set; }
        public int id_Mecanico { get; set; }
        public string id_cliente { get; set; }
    }
}
