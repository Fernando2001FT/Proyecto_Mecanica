using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Negocio;

namespace ProyectoMecanica.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]/[action]")]
    public class ServicioMecanicoController : ControllerBase
    {

        private readonly IServicioMecanicoRepositorio _serviciomecanicoRepositorio;


        public ServicioMecanicoController(IServicioMecanicoRepositorio serviciomecanicoRepositorio)
        {

            _serviciomecanicoRepositorio = serviciomecanicoRepositorio;

        }

        [HttpPost]
        public async Task<IActionResult> Crear(ServicioMecanicoDTO registroseriviciomecanicoDTO)
        {
            if (registroseriviciomecanicoDTO is null)
                return BadRequest();
            
            var resultado = await _serviciomecanicoRepositorio.RegistrarServicioMecanico(registroseriviciomecanicoDTO);


            return Ok();
        }
        //[Authorize(Roles = Roles.Administrador)]
        [HttpGet]
        public async Task<IActionResult> ObtenerServicioMecanico()
        {
            return Ok(await _serviciomecanicoRepositorio.ObtenerServicioMecanicos());
        }

    }
}