using Core.Contracts;
using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Managers
{
    public sealed class PermisoManager
    {
        private readonly IPermisoRepository _permisoRepository;

        public PermisoManager(IPermisoRepository permisoRepository)
        {
            _permisoRepository = permisoRepository;
        }

        public IOperationResult<Permiso> Create(Permiso permiso)
        {
            permiso.FechaPermiso = DateTime.Now;
            IOperationResult<Permiso> result = _permisoRepository.Create(permiso);

            if (result == null)
            {
                return BasicOperationResult<Permiso>.Fail(result.Message);
            }
            return BasicOperationResult<Permiso>.Ok(result.Entity);
        }

        public IOperationResult<Permiso> Delete(int id)
        {
            Permiso permisoFound = _permisoRepository.Find(permiso => permiso.Id == id);

            IOperationResult<Permiso> result = _permisoRepository.Remove(permisoFound);

            if (result == null)
            {
                return BasicOperationResult<Permiso>.Fail(result.Message);
            }

            return BasicOperationResult<Permiso>.Ok(result.Entity);
        }

        public async Task<IEnumerable<Permiso>> GetAllPermisos()
        {
            IEnumerable<Permiso> result = await _permisoRepository.GetPermisos();

            return result;

        }


    }
}
