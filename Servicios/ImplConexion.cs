using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBDC.Servicios
{
    /// <summary>
    /// Implementación de la interfaz de conexión a postgresql
    /// ivp
    /// </summary>
    internal class ImplConexion : InterfazConexion
    {
        public NpgsqlConnection generarConexion()
        {
            //Se lee la cadena de conexión a bbdd del archivo de configuración
            string stringConexion = ConfigurationManager.ConnectionStrings["stringConexion"].ConnectionString;
            

            NpgsqlConnection conexion = null;
            string estado = "";

            if (!string.IsNullOrWhiteSpace(stringConexion))
            {
                try
                {
                    conexion = new NpgsqlConnection(stringConexion);
                    conexion.Open();
                    //Se obtiene el estado de conexión para informarlo por consola
                    estado = conexion.State.ToString();
                    if (estado.Equals("Open")) {

                        Console.WriteLine("[INFORMACIÓN-ImplConexion-generarConexion] Estado conexión: " + estado);

                    }
                    else
                    {
                        conexion = null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("[ERROR-ImplConexion-generarConexion] Error al generar la conexión:" + e);
                    conexion = null;
                    return conexion;

                }
            }

            return conexion;

        }
    }
}
