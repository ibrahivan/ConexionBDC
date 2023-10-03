using JdbcConexionPostgresql.Dtos;
using JdbcConexionPostgresql.Util;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JdbcConexionPostgresql.Servicios
{
    /// <summary>
    /// Implementación de la interfaz de consultas a bbdd
    /// ivp
    /// </summary>
    internal class ImplCrud : InterfazCrud
    {
        public List<LibroDto> seleccionarTodosLibros(NpgsqlConnection conexion)
        {
            ADto aDto = new ADto();
            List<LibroDto> listaLibros = new List<LibroDto>();
            try
            {
                //Se define y ejecuta la consulta Select
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"gbp_almacen\".\"gbp_alm_cat_libros\"", conexion);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                //Paso de DataReader a lista de alumnoDTO
                listaLibros = aDto.readerALibroDto(resultadoConsulta);
                int cont = listaLibros.Count();
                Console.WriteLine("[INFORMACIÓN-ImplCrud-seleccionarTodosLibros] Número de libros: " + cont);

                Console.WriteLine("[INFORMACIÓN-ImplCrud-seleccionarTodosLibros] Cierre conexión y conjunto de datos");
                conexion.Close();
                resultadoConsulta.Close();

            }
            catch (Exception e)
            {

                Console.WriteLine("[ERROR-ImplCrud-seleccionarTodosLibros] Error al ejecutar consulta: " + e);
                conexion.Close();

            }
            return listaLibros;
        }
    }
}
