namespace Modelos
{
    public class MecanicoDTO
    {
        public int id_Mecanico { get; set; }
        public string EmailMecanico { get; set; }
        public string CedulaMecanico { get; set; }
        public string NombresMecanico { get; set; }

        public string DireccionDomicilioMecanico { get; set; }
        public string CelularMecanico { get; set; }

        public DateTime FechaCreacionMecanico { get; set; }
    }
}
