using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Negocio.Repositorio.IRepositorio;

namespace ProyectoMecanica.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]/[action]")]
    public class MecanicoController : ControllerBase
    {

        private readonly IMecanicoRepositorio _mecanicoRepositorio;


        public MecanicoController(IMecanicoRepositorio mecanicoRepositorio)
        {

            _mecanicoRepositorio = mecanicoRepositorio;

        }

        [HttpPost]
        public async Task<IActionResult> Crear(MecanicoDTO registromecanicoDTO)
        {
            if (registromecanicoDTO is null)
                return BadRequest();
            registromecanicoDTO.FechaCreacionMecanico = DateTime.Now;
            var resultado = await _mecanicoRepositorio.RegistrarMecanico(registromecanicoDTO);


            return Ok();
        }
        //[Authorize(Roles = Roles.Administrador)]
        [HttpGet]
        public async Task<IActionResult> ObtenerMecanico()
        {
            return Ok(await _mecanicoRepositorio.ObtenerMecanicos());
        }





 
    }
}