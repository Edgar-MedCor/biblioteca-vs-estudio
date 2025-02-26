using biblioteca.Context;
using biblioteca.Models.Domain;
using biblioteca.Servicios.Iservices;
using Microsoft.AspNetCore.Mvc;

public class RolController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IRolServices _rolServices;

    // ✅ Un único constructor que recibe ambas dependencias
    public RolController(ApplicationDbContext context, IRolServices rolServices)
    {
        _context = context;
        _rolServices = rolServices;
    }

    public async Task<IActionResult> Index()
    {
        var roles = await _rolServices.GetAll();
        return View(roles);
    }

    [HttpGet]
    public IActionResult Crear()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Crear(Rol rol)
    {
        ModelState.Remove("Usuarios"); // ❗ IGNORA LA VALIDACIÓN DE USUARIOS

        if (!ModelState.IsValid)
        {
            return View(rol);
        }

        _context.Roles.Add(rol);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Editar(int id)
    {
        var rol = await _rolServices.GetById(id);
        if (rol == null) return NotFound();
        return View(rol);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(Rol rol)
    {
        if (ModelState.IsValid)
        {
            await _rolServices.Update(rol);
            return RedirectToAction(nameof(Index));
        }
        return View(rol);
    }

    [HttpPost]
    public async Task<IActionResult> Eliminar(int id)
    {
        await _rolServices.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
