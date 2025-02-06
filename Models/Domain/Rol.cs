using System.ComponentModel.DataAnnotations;

namespace biblioteca.Models.Domain
{
    public class Rol
    {
        [Key]
        public int PkRol { get; set; }
        public string Nombre { get; set; }
    }
}
