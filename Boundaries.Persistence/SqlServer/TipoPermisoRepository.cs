using Core.Models;
using Core.Repositories;

namespace Boundaries.Persistence.SqlServer
{
    public sealed class TipoPermisoRepository : BaseRepository<TipoPermiso>, ITipoPermisoRepository
    {

        private readonly PermisoDbContext _permisoDbContext;

        public TipoPermisoRepository(PermisoDbContext permisoDbContext) : base(permisoDbContext)
            => _permisoDbContext = permisoDbContext;


    }
}
