

using Npgsql;
using System.Collections;
using ConexionBDC.Util;
using ConexionBDC.Servicios;
using ConexionBDC.Dtos;

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
            InterfazConexion cpi = new ImplConexion();
            InterfazCrud crud = new ImplCrud();
            metodoExternos util = new metodoExternos();
            List<LibroDto> listaLibros = new List<LibroDto>();
           

            
            int opcion;
            do
            {
                util.mostrarMenu(); // mostramos menu
                opcion = Console.ReadKey().KeyChar - '0';
                // control de errores
                while (opcion < 0 || opcion > 4)
                {

                    Console.WriteLine("\n\t\t\t**ERROR**");
                    Console.Write("\t\tIntroduce una opcion: ");
                    opcion = Console.ReadKey().KeyChar - '0';
                }
                Console.Clear();
                switch (opcion)
                {

                    case 1:
                        try
                        {
                            NpgsqlConnection conexion = cpi.generarConexion();

                            if (conexion != null)
                            {
                                Console.WriteLine("---MOSTRAR LIBROS---");
                                listaLibros = crud.seleccionarTodosLibros(conexion);
                                conexion.Close();
                                int n = util.CapturaEntero("Desea ver todos los libro (Opcion 1) o ver un libro (Opcion 2)", 1, 2);
                                if (n == 1)
                                {
                                    for (int i = 0; i < listaLibros.Count(); i++)
                                        Console.WriteLine("\n" + listaLibros[i].toString());
                                }
                                else
                                {
                                    Console.WriteLine("\nId libro disponible:");
                                    for (int i = 0; i < listaLibros.Count(); i++)
                                        Console.WriteLine(listaLibros[i].Id_libro);
                                    Console.WriteLine("\n¿Qué libro desea ver? Seleccione por id: ");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    for (int i = 0; i < listaLibros.Count(); i++)
                                    {
                                        if (listaLibros[i].Id_libro == id)
                                            Console.WriteLine("\n" + listaLibros[i].toString());
                                    }

                                }
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("[ERROR-Main] Se ha producido un error al ejecutar la aplicación: " + e);
                        }
                        break;
                    case 2:
                        try
                        {
                            NpgsqlConnection conexion = cpi.generarConexion();

                            if (conexion != null)
                            {
                                Console.WriteLine("---INSERTAR LIBROS---");
                                listaLibros = crud.seleccionarTodosLibros(conexion);
                                for (int i = 0; i < listaLibros.Count(); i++)
                                    Console.WriteLine("\n" + listaLibros[i].toString());
                                crud.opcIDU(conexion, 1);
                                conexion.Close();
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("[ERROR-Main] Se ha producido un error al ejecutar la aplicación: " + e);
                        }
                        break;
                    case 3:
                        try
                        {
                            NpgsqlConnection conexion = cpi.generarConexion();

                            if (conexion != null)
                            {
                                Console.WriteLine("---BORRAR LIBROS---");
                                listaLibros = crud.seleccionarTodosLibros(conexion);
                                for (int i = 0; i < listaLibros.Count(); i++)
                                    Console.WriteLine("\n" + listaLibros[i].toString());
                                crud.opcIDU(conexion, 2);
                                conexion.Close();
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("[ERROR-Main] Se ha producido un error al ejecutar la aplicación: " + e);
                        }
                        break;
                    case 4:
                        try
                        {
                            NpgsqlConnection conexion = cpi.generarConexion();

                            if (conexion != null)
                            {
                                Console.WriteLine("---ACTUALIZA LIBROS---");
                                listaLibros = crud.seleccionarTodosLibros(conexion);
                                for (int i = 0; i < listaLibros.Count(); i++)
                                    Console.WriteLine("\n" + listaLibros[i].toString());
                                crud.opcIDU(conexion, 3);
                                conexion.Close();

                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("[ERROR-Main] Se ha producido un error al ejecutar la aplicación: " + e);
                        }
                        break;

                }
                if (opcion != 0)
                {
                    Console.Write("\n\n\tPulsa una tecla para volver al menú... ");
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (opcion != 0);
            Console.WriteLine("\n\tSaliendo de la aplicacion  \n\tPulse cualquier tecla para cerrar el programa");
            Console.ReadLine();
        }
    }
}
