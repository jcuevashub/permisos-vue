using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    /// <summary>
    /// Represents the class for Permiso
    /// </summary>
    public class Permiso
    {
        /// <summary>
        /// Identification of a permiso
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of a employee
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Last Name of the Employee
        /// </summary>
        public string EmployeeLastName { get; set; }


        /// <summary>
        /// Represents the TipoPermiso identification
        /// </summary>
        
        [ForeignKey("TipoPermisoId")]
        public int TipoPermisoId { get; set; }
        public virtual TipoPermiso TipoPermiso { get; set; }

        /// <summary>
        /// Represents the date of the permiso
        /// </summary>
        public DateTime FechaPermiso { get; set; }

    }
}
