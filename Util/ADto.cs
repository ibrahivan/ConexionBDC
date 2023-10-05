using ConexionBDC.Dtos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBDC.Util
{
    /// <summary>
    /// Métodos que pasan a objeto de tipo DTO
    /// </summary>
    internal class ADto
    {
        public List<LibroDto> readerALibroDto(NpgsqlDataReader resultadoConsulta)
        {
            List<LibroDto> listaLibros = new List<LibroDto>();
            while (resultadoConsulta.Read())
            {
                listaLibros.Add(new LibroDto(
                     resultadoConsulta.GetInt64(resultadoConsulta.GetOrdinal("id_libro")),
                    resultadoConsulta.GetString(resultadoConsulta.GetOrdinal("titulo")),
                    resultadoConsulta.GetString(resultadoConsulta.GetOrdinal("autor")),
                    resultadoConsulta.GetString(resultadoConsulta.GetOrdinal("isbn")),
                    resultadoConsulta.GetInt32(resultadoConsulta.GetOrdinal("edicion"))
                    )
                    );

            }
            return listaLibros;
        }
    }
}
