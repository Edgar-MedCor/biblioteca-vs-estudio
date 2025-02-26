using biblioteca.Models.Domain;
using biblioteca.Servicios.Iservices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;
        private readonly IRolServices _rolServices;

        public UsuarioController(IUsuarioServices usuarioServices, IRolServices rolServices)
        {
            _usuarioServices = usuarioServices;
            _rolServices = rolServices;
        }

        public IActionResult Index()
        {
            var usuarios = _usuarioServices.ObtenerUsuariosConRoles(); // Obtener usuarios con su rol
            return View(usuarios);
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            ViewBag.Roles = new SelectList(await _rolServices.GetAll(), "PkRol", "Nombre");
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuario usuario)
        {
            _usuarioServices.CrearUsuario(usuario);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var usuario = _usuarioServices.ObtenerUsuarioPorIdConRol(id);
            if (usuario == null) return NotFound();

            ViewBag.Roles = new SelectList(await _rolServices.GetAll(), "PkRol", "Nombre");

            return View(usuario);
        }



        [HttpPost]
        public async Task<IActionResult> Editar(Usuario usuario)
        {
            var usuarioExistente = _usuarioServices.GetById(usuario.PkUsuario);
            if (usuarioExistente == null) return NotFound();

            if (string.IsNullOrWhiteSpace(usuario.Password))
            {
                usuario.Password = usuarioExistente.Password; // Mantiene la contraseña si no la cambia
            }

            usuarioExistente.Nombre = usuario.Nombre;
            usuarioExistente.UserName = usuario.UserName;
            usuarioExistente.FkRol = usuario.FkRol; // Asegura que el rol se actualiza

            _usuarioServices.EditarUsuario(usuarioExistente);

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Eliminar(int id)
        {
            _usuarioServices.EliminarUsuario(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
