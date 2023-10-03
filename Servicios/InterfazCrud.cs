using JdbcConexionPostgresql.Dtos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JdbcConexionPostgresql.Servicios
{
    /// <summary>
    /// Interfaz que define las consultas a bbdd
    /// ivp
    /// </summary>
    internal interface InterfazCrud
    {
        /// <summary>
        /// Métdo que lee todos los registros de la base de datos
        /// </summary>
        /// <param name="conexion"></param>
        /// <returns></returns>
        public List<LibroDto> seleccionarTodosLibros(NpgsqlConnection conexion);

    }
}
