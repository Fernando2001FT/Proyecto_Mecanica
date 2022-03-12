using AccesoData;
using AccesoData.Contexto;
using AutoMapper;
using Modelos;

namespace Negocio.Repositorio

{

    public class ServicioMecanicoRepositorio : IServicioMecanicoRepositorio
        {
            private readonly AppDbContext _db;
            private readonly IMapper _mapper;

            public ServicioMecanicoRepositorio(AppDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }

            public async Task<ServicioMecanicoDTO> RegistrarServicioMecanico(ServicioMecanicoDTO ServicioMecanicoDTO)
            {
                var ServicioMecanico = _mapper.Map<ServicioMecanico>(ServicioMecanicoDTO);
                var nuevoServicioMecanico = _db.RegistroServicio.Add(ServicioMecanico);
                await _db.SaveChangesAsync();
                return _mapper.Map<ServicioMecanicoDTO>(nuevoServicioMecanico.Entity);
            }
            public async Task<IEnumerable<ServicioMecanicoDTO>> ObtenerServicioMecanicos()
            {
                return _mapper.Map<IEnumerable<ServicioMecanicoDTO>>(_db.RegistroServicio);
            }
        }
    }

