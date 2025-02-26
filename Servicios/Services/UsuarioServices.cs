using biblioteca.Context;
using biblioteca.Models.Domain;
using biblioteca.Servicios.Iservices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace biblioteca.Servicios.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UsuarioServices> _logger;

        public UsuarioServices(ApplicationDbContext context, ILogger<UsuarioServices> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Usuario> ObtenerUsuariosConRoles()
        {
            return _context.Usuarios.Include(u => u.Rol).ToList();
        }

        public Usuario ObtenerUsuarioPorIdConRol(int id) // Método correcto
        {
            return _context.Usuarios.Include(u => u.Rol).FirstOrDefault(u => u.PkUsuario == id);
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return _context.Usuarios.Include(u => u.Rol).ToList();
        }

        public Usuario GetById(int id)
        {
            return _context.Usuarios.Include(u => u.Rol).FirstOrDefault(x => x.PkUsuario == id);
        }

        public bool CrearUsuario(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear usuario");
                return false;
            }
        }

        public bool EditarUsuario(Usuario usuario)
        {
            try
            {
                var usuarioExistente = _context.Usuarios.Find(usuario.PkUsuario);
                if (usuarioExistente == null) return false;

                usuarioExistente.Nombre = usuario.Nombre;
                usuarioExistente.UserName = usuario.UserName;
                usuarioExistente.FkRol = usuario.FkRol; // Asegurarse de que el rol se actualiza

                _context.Usuarios.Update(usuarioExistente);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al editar usuario");
                return false;
            }
        }

        

        public bool EliminarUsuario(int id)
        {
            try
            {
                var usuario = _context.Usuarios.Find(id);
                if (usuario == null) return false;

                _context.Usuarios.Remove(usuario);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar usuario");
                return false;
            }
        }
    }
}
