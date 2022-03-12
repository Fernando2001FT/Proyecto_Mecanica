﻿using AccesoData;
using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Modelos;
using Negocio.Repositorio;
using ProyectoMecanica.API;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProyectoMecanica.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MecanicoController : ControllerBase
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ConfiguracionJWT _configuracionJwt;

        public MecanicoController(SignInManager<Usuario> signInManager, UserManager<Usuario> userManager, IUsuarioRepositorio usuarioRepositorio, IOptions<ConfiguracionJWT> opciones)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _usuarioRepositorio = usuarioRepositorio;
            _configuracionJwt = opciones.Value;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario([FromBody] RegistroUsuarioRequestDTO registroUsuarioRequestDTO)
        {
            if (registroUsuarioRequestDTO is null)
                return BadRequest();

            var usuario = new Usuario
            {
                UserName = registroUsuarioRequestDTO.Email,
                Email = registroUsuarioRequestDTO.Email,
                Nombre = registroUsuarioRequestDTO.Nombre,
                TotalExamenes = 0,
                FechaCreacion = DateTime.Now,
                EmailConfirmed = true
            };

            var resultadoCreacion = await _userManager.CreateAsync(usuario, registroUsuarioRequestDTO.Contrasenia);

            if (!resultadoCreacion.Succeeded)
                return BadRequest(new RegistroUsuarioResponseDTO
                {
                    RegistroSatisfactorio = false,
                    Errores = resultadoCreacion.Errors.Select(error => error.Description)
                });

            return Ok(new RegistroUsuarioResponseDTO { RegistroSatisfactorio = true });
        }

        

 

        [Authorize(Roles = Roles.Administrador)]
        [HttpGet]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            return Ok(await _usuarioRepositorio.ObtenerUsuarios());
        }

        private async Task<List<Claim>> ObtenerClaims(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim("Id", usuario.Id),
                new Claim("TotalExamenes", usuario.TotalExamenes.ToString())
            };

            var roles = await _userManager.GetRolesAsync(usuario);
            foreach (var rol in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }
            return claims;
        }

        private SigningCredentials ObtenerCredenciales()
        {
            var secreto = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracionJwt.Secreto));
            return new SigningCredentials(secreto, SecurityAlgorithms.HmacSha256);
        }
    }
}