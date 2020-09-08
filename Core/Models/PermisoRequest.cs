using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class PermisoRequest
    {
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

        public int TipoPermisoId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaPermiso { get; set; }


    }
}
