using Modelos;

namespace Negocio.Repositorio.IRepositorio
{
    public interface IClienteRepositorio
    
    {
        Task<ClienteDTO> RegistrarCliente(ClienteDTO ClienteDTO);
        Task<IEnumerable<ClienteDTO>> ObtenerClientes();

    }
}