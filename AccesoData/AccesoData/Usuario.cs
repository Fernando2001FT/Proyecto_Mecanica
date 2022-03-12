using Microsoft.AspNetCore.Identity;

namespace AccesoData
{
    public class Usuario : IdentityUser
    {
        public string Nombre { get; set; }
        public decimal TotalExamenes { get; set; }
        public string RolUsuario { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
