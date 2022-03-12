namespace Modelos
{
    public class ClienteDTO
    {
        public int id_cliente { get; set; }
        public string EmailCliente { get; set; }
        public string CedulaCliente { get; set; }
        public string NombresCliente { get; set; }

        public string DireccionOficinaCliente { get; set; }
        public string CelularCliente { get; set; }

        public string DireccionDomicilioCliente { get; set; }

        public DateTime FechaCreacionCliente { get; set; }
    }
}
