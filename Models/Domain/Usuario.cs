using System.ComponentModel.DataAnnotations;

namespace biblioteca.Models.Domain
{
    public class Usuario
    {
        [Key]
        public int PkUsuario { get; set; }
        public string Nombre { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int FkRol { get; set; }
        public Rol Rol { get; set; } // Relación con la tabla de roles
    }
}
