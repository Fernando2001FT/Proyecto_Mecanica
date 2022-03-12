using Modelos;

namespace Negocio
{
    public interface IServicioMecanicoRepositorio
    {
        Task<IEnumerable<ServicioMecanicoDTO>> ObtenerServicioMecanicos();
        Task<ServicioMecanicoDTO> RegistrarServicioMecanico(ServicioMecanicoDTO ServicioMecanicoDTO);
    }
}