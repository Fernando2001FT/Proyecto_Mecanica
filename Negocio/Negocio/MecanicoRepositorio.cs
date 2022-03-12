using AccesoData;
using AccesoData.Contexto;
using AutoMapper;
using Modelos;
using Negocio.Repositorio.IRepositorio;

namespace Negocio.Repositorio
{


    public class MecanicoRepositorio : IMecanicoRepositorio
        {
            private readonly AppDbContext _db;
            private readonly IMapper _mapper;

            public MecanicoRepositorio(AppDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }

            public async Task<MecanicoDTO> RegistrarMecanico(MecanicoDTO MecanicoDTO)
            {
                var Mecanico = _mapper.Map<Mecanico>(MecanicoDTO);
                var nuevoMecanico = _db.RegistroMecanico.Add(Mecanico);
                await _db.SaveChangesAsync();
                return _mapper.Map<MecanicoDTO>(nuevoMecanico.Entity);
            }
            public async Task<IEnumerable<MecanicoDTO>> ObtenerMecanicos()
            {
                return _mapper.Map<IEnumerable<MecanicoDTO>>(_db.RegistroMecanico);
            }
        }
    }

