using AccesoData;
using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Negocio.Repositorio.IRepositorio;

namespace ProyectoMecanica.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]/[action]")]
    public class ClienteController : ControllerBase
    {
        
        private readonly IClienteRepositorio _clienteRepositorio;
        

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
      
            _clienteRepositorio = clienteRepositorio;
       
        }

        [HttpPost]
        public async Task<IActionResult> Crear (ClienteDTO registroclienteDTO)
        {
            if (registroclienteDTO is null)
                return BadRequest();
            registroclienteDTO.FechaCreacionCliente = DateTime.Now;
            var resultado = await _clienteRepositorio.RegistrarCliente(registroclienteDTO);


            return Ok(new RegistroUsuarioResponseDTO { RegistroSatisfactorio = true });
        }
        //[Authorize(Roles = Roles.Administrador)]
        [HttpGet]
        public async Task<IActionResult> ObtenerClientes()
        {
            return Ok(await _clienteRepositorio.ObtenerClientes());
        }





    }
}