using JdbcConexionPostgresql.Dtos;
using JdbcConexionPostgresql.Servicios;
using Npgsql;

namespace ConexionBDC

{
    /// <summary>
    /// Clase principal de la aplicación
    /// ivp
    /// </summary>
    class Program
    {
        /// <summary>
        /// Método main de la aplicación, puerta de entrada
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            InterfazConexion conexionInterfaz = new ImplConexion();
            InterfazCrud crudInterfaz = new ImplCrud();
            NpgsqlConnection conexion = null;
            conexion = conexionInterfaz.generarConexion();

            if (conexion != null)
            {
               foreach(LibroDto libro in crudInterfaz.seleccionarTodosLibros(conexion))
                {
                    Console.WriteLine(libro.Titulo);
                }
               
            }

        }
    }
}