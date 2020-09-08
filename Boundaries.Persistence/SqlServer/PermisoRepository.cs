using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boundaries.Persistence.SqlServer
{
    public sealed class PermisoRepository : BaseRepository<Permiso>, IPermisoRepository
    {
        private readonly PermisoDbContext _permisoDbContext;

        public PermisoRepository(PermisoDbContext permisoDbContext) : base(permisoDbContext)
            => _permisoDbContext = permisoDbContext;

        public async Task<IEnumerable<Permiso>> GetPermisos()
        {
            var users = await _permisoDbContext.Permisos.Include(tp => tp.TipoPermiso).ToListAsync();
            return users;
        }
    }
}
