using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace biblioteca.Models.Domain
{
    public class Rol
    {
        [Key]
        public int PkRol { get; set; }

        [Required] // ✅ Asegura que el Nombre sí sea obligatorio
        public string Nombre { get; set; }

        public ICollection<Usuario>? Usuarios { get; set; } // ✅ PERMITE NULL PARA EVITAR EL ERROR
    }
}
