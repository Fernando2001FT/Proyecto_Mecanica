namespace Modelos
{
    public class InicioSesionResponseDTO
    {
        public bool AutenticacionExistosa { get; set; }
        public string MensajeError { get; set; }
        public string Token { get; set; }
        public UsuarioDTO Usuario { get; set; }
    }
}
