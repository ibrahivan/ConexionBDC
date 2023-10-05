using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBDC.Util
{
    internal class metodoExternos
    {
        //metodo para preguntar si queiere editar algun dato
        public bool PreguntaSiNo(String p)
        {
            bool respuesta = false;
            char tecla;
            bool error = false;
            

            do
            {
                error = false;
                Console.WriteLine("\n\n" + p + " (s=Sí; n=No): ");
                // Capturamos la respuesta (una pulsación)
                tecla = (Console.ReadKey()).KeyChar;
                if (tecla == 's' || tecla == 'S')
                {
                    respuesta = true;
                }
                else if (tecla == 'n' || tecla == 'N')
                {
                    respuesta = false;
                }
                else
                {
                    Console.WriteLine("\n\n\t** Error: por favor, responde s o n **");
                    error = true;
                }
            } while (error);

            return respuesta;
        }

        public void mostrarMenu()
        {
            Console.WriteLine("\n\t\t----Menú----");
            Console.WriteLine("\n\t\t1. Seleccionar libros");
            Console.WriteLine("\n\t\t2. Insertar libros");
            Console.WriteLine("\n\t\t3. Borrar libros");
            Console.WriteLine("\n\t\t4. Actualizar libros");
            Console.WriteLine("\n\t\t0. Cerrar app");

        }

        public int CapturaEntero(String mensaje, int min, int max)
        {


            Console.WriteLine(mensaje + " (" + min + ".." + max + "): ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            while (opcion < min || opcion > max)
            {
                Console.WriteLine("\tNo has introducido una opción válida.");
                Console.WriteLine("\tVuelve a introducir una opción" + " (" + min + ".." + max + "): ");
                opcion = Convert.ToInt32(Console.ReadLine());
            }
            return opcion;

        }
    }
}
