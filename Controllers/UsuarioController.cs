using biblioteca.Servicios.Iservices;
using Microsoft.AspNetCore.Mvc;

namespace biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;

        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        public IActionResult Index()
        {
            var usuarios = _usuarioServices.ObtenerUsuarios(); // Método de ejemplo
            return View(usuarios);
        }
    }
}
