using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AccesoData.Contexto
{
    public class AppDbContext : IdentityDbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> opciones) : base(opciones) { 
      
        }
        // Clases y entidades para interaccion entre base de datos y API
        public DbSet<Usuario> Usuarios { get; set; }
        
        public DbSet<Cliente> RegistroCliente { get; set; }
        public DbSet<Mecanico> RegistroMecanico { get; set; }
        public DbSet<ServicioMecanico> RegistroServicio { get; set; }


    }
}
