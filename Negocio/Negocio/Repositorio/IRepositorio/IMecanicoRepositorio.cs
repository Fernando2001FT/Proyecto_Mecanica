using Modelos;

namespace Negocio.Repositorio.IRepositorio

{
    public interface IMecanicoRepositorio
    {
        Task<IEnumerable<MecanicoDTO>> ObtenerMecanicos();
        Task<MecanicoDTO> RegistrarMecanico(MecanicoDTO MecanicoDTO);
    }
}