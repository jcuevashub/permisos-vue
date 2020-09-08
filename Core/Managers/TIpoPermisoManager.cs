using Core.Models;
using Core.Repositories;
using System.Collections.Generic;

namespace Core.Managers
{
    public sealed class TipoPermisoManager
    {
        private readonly ITipoPermisoRepository _tipoPermisoRepository;

        public TipoPermisoManager(ITipoPermisoRepository tipoPermisoRepository)
        {
            _tipoPermisoRepository = tipoPermisoRepository;
        }

        public IEnumerable<TipoPermiso> GetAllTipoPermisos()
        {
            IEnumerable<TipoPermiso> result = _tipoPermisoRepository.Get();

            return result;

        }
    }
}
