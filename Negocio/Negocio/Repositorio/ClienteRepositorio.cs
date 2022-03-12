using AccesoData;
using AutoMapper;
using Modelos;
using Negocio.Repositorio.IRepositorio;
using AccesoData.Contexto;

namespace Negocio.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public ClienteRepositorio(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> RegistrarCliente(ClienteDTO ClienteDTO)
        {
            var Cliente = _mapper.Map<Cliente>(ClienteDTO);
            var nuevoCliente = _db.RegistroCliente.Add(Cliente);
            await _db.SaveChangesAsync();
            return _mapper.Map<ClienteDTO>(nuevoCliente.Entity);
        }
        public async Task<IEnumerable<ClienteDTO>> ObtenerClientes()
        {
            return _mapper.Map<IEnumerable<ClienteDTO>>(_db.RegistroCliente);
        }
    }
}
