using biblioteca.Context;
using biblioteca.Models.Domain;
using biblioteca.Servicios.Iservices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace biblioteca.Servicios.Services
{
    public class RolServices : IRolServices
    {
        private readonly ApplicationDbContext _context;

        public RolServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Rol>> GetAll()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Rol> GetById(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task Create(Rol rol)
        {
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync(); // Asegura que los cambios se guarden
        }



        public async Task Update(Rol rol)
        {
            _context.Roles.Update(rol);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol != null)
            {
                _context.Roles.Remove(rol);
                await _context.SaveChangesAsync();
            }
        }
    }
}
