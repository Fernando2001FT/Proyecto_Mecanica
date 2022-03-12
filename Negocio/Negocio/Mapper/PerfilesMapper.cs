using AccesoData;
using AutoMapper;
using Modelos;

namespace Negocio.Mapper
{
    public class PerfilesMapper : Profile
    {
        public PerfilesMapper()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<ServicioMecanico, ServicioMecanicoDTO>().ReverseMap();
            CreateMap<Mecanico, MecanicoDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();

        }
    }
}