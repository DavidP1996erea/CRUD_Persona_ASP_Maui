using _07_CRUD_Personas_DAL.Conexion;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CRUD_Persona_Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Persona_DAL
{
    public class clsManejadoraDepartamentoDAL
    {

        /// <summary>
        /// Este método devuelve un entero, que será el número de filas afectadas por
        /// la consulta. Se le pasa por parámetro un objeto clsDepartamento, para poder
        /// acceder a su id y a su nombre. Estos datos se introducirán en el comando
        /// sql para poder acceder al departamento deseado a través del id y cambiar
        /// su nombre.
        /// </summary>
        /// <param name="departamentoAEditar"></param>
        /// <returns></returns>
        public static int editarDepartamentoDAL(clsDepartamento departamentoAEditar)
        {

            clsMyConnection conexion = new clsMyConnection();
            SqlConnection miConexion = new SqlConnection();
            SqlCommand comandoEditarDepartamento = new SqlCommand();
            int numeroFilasAfectadas = 0;

            comandoEditarDepartamento.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = departamentoAEditar.ID;
            comandoEditarDepartamento.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = departamentoAEditar.Nombre;

            try
            {
                miConexion = conexion.getConnection();
                comandoEditarDepartamento.CommandText = "UPDATE Departamentos SET Nombre=@nombre WHERE ID=@id";
                comandoEditarDepartamento.Connection= miConexion;
                numeroFilasAfectadas = comandoEditarDepartamento.ExecuteNonQuery();


            }
            catch(SqlException e)
            {
                throw e;
            }

            return numeroFilasAfectadas;
        }



                                  
        /// <summary>
        /// Método que devuelve un entero que será el número de filas afectadas por la consulta sql.
        /// Recibe como parámetro un objeto de tipo clsDepartamento, del cual cogerá el nombre y lo 
        /// insertará en la tabla departamentos como uno nuevo.
        /// </summary>
        /// <param name="depatarmentoInsertar"></param>
        /// <returns></returns>
        public static int insertarDepartamentoDAL(clsDepartamento depatarmentoInsertar)
        {


            clsMyConnection conexion = new clsMyConnection();
            SqlConnection miConexion = new SqlConnection();
            SqlCommand comandoInsertarDepartamento = new SqlCommand();
            int numeroFilasAfectadas = 0;

            comandoInsertarDepartamento.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = depatarmentoInsertar.Nombre;

            try
            {
                miConexion = conexion.getConnection();
                comandoInsertarDepartamento.CommandText = "INSERT INTO Departamentos VALUES(@nombre)";
                comandoInsertarDepartamento.Connection = miConexion;
                numeroFilasAfectadas = comandoInsertarDepartamento.ExecuteNonQuery();


               

            }
            catch (SqlException e)
            {
                throw e;
            }

            return numeroFilasAfectadas;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPersonaAEliminar"></param>
        /// <returns></returns>
        public static int eliminarDepartamento(int idDepartamentoAEliminar)
        {
            clsMyConnection conexion = new clsMyConnection();
            SqlConnection miConexion = new SqlConnection();
            SqlCommand comandoEliminar = new SqlCommand();
            int numeroFilasAfectadas = 0;

            // Se crean los parámetros
            comandoEliminar.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = idDepartamentoAEliminar;

            try
            {

                miConexion = conexion.getConnection();
                comandoEliminar.CommandText = "DELETE FROM Departamentos WHERE ID=@id";
                comandoEliminar.Connection = miConexion;
                numeroFilasAfectadas = comandoEliminar.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw e;
            }



            return numeroFilasAfectadas;
        }


    }
}
