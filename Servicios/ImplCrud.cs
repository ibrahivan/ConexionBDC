using ConexionBDC.Util;
using ConexionBDC.Dtos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBDC.Servicios
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
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM gbp_almacen.gbp_alm_cat_libros", conexion);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                //Paso de DataReader a lista de alumnoDTO
                listaLibros = aDto.readerALibroDto(resultadoConsulta);
                int cont = listaLibros.Count();
                Console.WriteLine("[INFORMACIÓN-ImplCrud-seleccionarTodosLibros] Número de libros: " + cont);

                Console.WriteLine("[INFORMACIÓN-ImplCrud-seleccionarTodosLibros] Cierre conexión y conjunto de datos");
                
                resultadoConsulta.Close();

            }
            catch (Exception e)
            {

                Console.WriteLine("[ERROR-ImplCrud-seleccionarTodosLibros] Error al ejecutar consulta: " + e);
                conexion.Close();

            }
            return listaLibros;
        }

        /**
         * Metodo que nos permite hacer el Insert, delete o update, devuelve una lista actualizada con la que iremos trabajando
         */
   
    public void opcIDU(NpgsqlConnection conexionGenerada, int opc)
        {
            // TODO Auto-generated method stub

            NpgsqlCommand declaracionSQL = null;

            
            LibroDto libro = new LibroDto();
            metodoExternos util = new metodoExternos();

            bool p;
            switch (opc)
            {
                // Inserta datos de un libro
                case 1:
                    p = util.PreguntaSiNo("¿Desea insertar algún libro?");
                    while (p)
                    {
                        Console.Write("\nTítulo del libro: ");
                        libro.Titulo = Console.ReadLine();
                        Console.Write("Autor del libro: ");
                        libro.Autor = Console.ReadLine();
                        Console.Write("ISBN del libro: ");
                        libro.Isbn = Console.ReadLine();
                        Console.Write("Edición del libro: ");
                        libro.Edicion = int.Parse(Console.ReadLine());

                        try
                        {
                            // Se abre un comando y se define la consulta del comando y se ejecuta
                            declaracionSQL = new NpgsqlCommand(
                                "INSERT INTO gbp_almacen.gbp_alm_cat_libros (titulo, autor, isbn, edicion) VALUES (@Titulo, @Autor, @Isbn, @Edicion)",
                                conexionGenerada);

                            // Se insertan los datos
                            declaracionSQL.Parameters.AddWithValue("@Titulo", libro.Titulo);
                            declaracionSQL.Parameters.AddWithValue("@Autor", libro.Autor);
                            declaracionSQL.Parameters.AddWithValue("@Isbn", libro.Isbn);
                            declaracionSQL.Parameters.AddWithValue("@Edicion", libro.Edicion);
                            declaracionSQL.ExecuteNonQuery();

                            declaracionSQL.Dispose();
                        }
                        catch (NpgsqlException e)
                        {
                            Console.WriteLine("[ERROR-ImplCrud-insertaLibros] Error generando o ejecutando el comando SQL: " + e);
                        }
                        p = util.PreguntaSiNo("\t¿Desea insertar otro libro?");
                    }
                    break;

                // Borra un libro
                case 2:
                    p = util.PreguntaSiNo("¿Desea borrar algún libro?");
                    p = util.PreguntaSiNo("¿Estás seguro?");
                    while (p)
                    {
                        Console.WriteLine("\nQué libro quiere borrar por su id: ");
                        libro.Id_libro = long.Parse(Console.ReadLine());
                        try
                        {
                            // Se abre un comando y se define la consulta del comando y se ejecuta
                            declaracionSQL = new NpgsqlCommand(
                                "DELETE FROM gbp_almacen.gbp_alm_cat_libros WHERE id_libro = @IdLibro",
                                conexionGenerada);
                            declaracionSQL.Parameters.AddWithValue("@IdLibro", libro.Id_libro);
                            declaracionSQL.ExecuteNonQuery();

                            declaracionSQL.Dispose();
                        }
                        catch (NpgsqlException e)
                        {
                            Console.WriteLine("[ERROR-ImplCrud-borraLibros] Error generando o ejecutando el comando SQL: " + e);
                        }
                        p = util.PreguntaSiNo("¿Desea borrar algún libro más?");
                    }
                    break;

                case 3:
                    // Actualiza datos de algún libro
                    // Paso 1, preguntar
                    p = util.PreguntaSiNo("\t¿Desea actualizar algún dato?");
                    while (p)
                    {
                        Console.Write("\nIngrese el ID del libro que desea actualizar: ");
                        int idAActualizar = int.Parse(Console.ReadLine());

                        // Paso 2: Leer el atributo a actualizar
                        Console.Write("Elija el atributo a actualizar (titulo, autor, isbn, edicion): ");
                        string atributo = Console.ReadLine();

                        // Paso 3: Leer el nuevo valor del atributo
                        Console.Write("Ingrese el nuevo valor para " + atributo.ToUpper() + ": ");
                        string nuevoValor = Console.ReadLine();

                        try
                        {
                            // Se abre un comando y se define la consulta del comando y se ejecuta
                            declaracionSQL = new NpgsqlCommand(
                                "UPDATE gbp_almacen.gbp_alm_cat_libros SET " + atributo + " = @NuevoValor WHERE id_libro = @IdLibro",
                                conexionGenerada);
                            declaracionSQL.Parameters.AddWithValue("@NuevoValor", nuevoValor);
                            declaracionSQL.Parameters.AddWithValue("@IdLibro", idAActualizar);
                            declaracionSQL.ExecuteNonQuery();

                            declaracionSQL.Dispose();
                        }
                        catch (NpgsqlException e)
                        {
                            Console.WriteLine("[ERROR-ImplCrud-actualizaLibros] Error generando o ejecutando el comando SQL: " + e);
                        }
                        p = util.PreguntaSiNo("\t¿Desea actualizar algún dato más?");
                    }
                    break;
            }

        }
    }
}
