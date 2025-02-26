using biblioteca.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace biblioteca.Servicios.Iservices
{
    public interface IRolServices
    {
        Task<List<Rol>> GetAll();
        Task<Rol> GetById(int id);
        Task Create(Rol rol);
        Task Update(Rol rol);
        Task Delete(int id);
    }
}
