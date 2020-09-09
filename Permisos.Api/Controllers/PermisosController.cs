using Core.Contracts;
using Core.Managers;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Permisos.Controllers
{
    [Route("api/permisos")]
    [Produces("application/json")]
    [ApiController]

    public class PermisosController : ControllerBase
    {

        private readonly PermisoManager _permisosManager;
        private readonly TipoPermisoManager _tipoPermisoManager;

        public PermisosController(PermisoManager permisoManager, TipoPermisoManager tipoPermisoManager)
        {
            _permisosManager = permisoManager;
            _tipoPermisoManager = tipoPermisoManager;
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(Permiso), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] Permiso permiso)
        {
            IOperationResult<Permiso> operationResult = _permisosManager.Create(permiso);

            if (operationResult.Success)
            {
                return Ok(operationResult.Entity);
            }

            return BadRequest(operationResult.Message);
        }


        [HttpGet("")]
        [ProducesResponseType(typeof(Permiso), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Permiso> operationResult = await _permisosManager.GetAllPermisos();

            if (operationResult != null)
            {
                return Ok(operationResult);
            }

            return BadRequest(operationResult);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Permiso), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            IOperationResult<Permiso> operationResult = _permisosManager.Delete(id);

            if (operationResult != null)
            {
                return Ok(operationResult);
            }

            return BadRequest(operationResult);
        }

        [HttpGet("tipoPermisos")]
        [ProducesResponseType(typeof(TipoPermiso), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetTiposPermisos()
        {
            IEnumerable<TipoPermiso> operationResult = _tipoPermisoManager.GetAllTipoPermisos();

            if (operationResult != null)
            {
                return Ok(operationResult);
            }

            return BadRequest(operationResult);
        }
    }
}
