using Modelos;

namespace Negocio.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Task<IEnumerable<UsuarioDTO>> ObtenerUsuarios();
    }
}