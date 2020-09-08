using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IPermisoRepository : IGenericRepository<Permiso>
    {
        Task<IEnumerable<Permiso>> GetPermisos();
   
    }
}
