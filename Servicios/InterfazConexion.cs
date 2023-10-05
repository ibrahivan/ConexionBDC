using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBDC.Servicios
{
    /// <summary>
    /// Interfaz que define los métodos para generar conexiones a base de datos
    /// ivp
    /// </summary>
    internal interface InterfazConexion
    {
        /// <summary>
        /// Método que genera la conexión a bbdd
        /// </summary>
        /// <returns></returns>
        public NpgsqlConnection generarConexion();
    
    }
}
