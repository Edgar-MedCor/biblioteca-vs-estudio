using biblioteca.Models.Domain;
using System.Collections.Generic;

namespace biblioteca.Servicios.Iservices
{
    public interface IUsuarioServices
    {
        List<Usuario> ObtenerUsuarios();
        Usuario ObtenerUsuarioPorIdConRol(int id); // Corregido: ahora devuelve un solo usuario
        Usuario GetById(int id);
        bool CrearUsuario(Usuario usuario);
        bool EditarUsuario(Usuario usuario);
        bool EliminarUsuario(int id);
        List<Usuario> ObtenerUsuariosConRoles();
    }
}
