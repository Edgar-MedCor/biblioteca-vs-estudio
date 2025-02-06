using biblioteca.Models.Domain;
using biblioteca.Servicios.Iservices; 

namespace biblioteca.Servicios.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        public List<Usuario> ObtenerUsuarios()
        {
            // Retornar una lista de prueba por ahora
            return new List<Usuario>
            {
                new Usuario { PkUsuario = 1, Nombre = "Edgar", UserName = "emedrano" },
                new Usuario { PkUsuario = 2, Nombre = "Alejandro", UserName = "asanchez" }
            };
        }
    }
}
