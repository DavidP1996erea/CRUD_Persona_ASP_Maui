using _07_CRUD_Personas_DAL.Conexion;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CRUD_Persona_Entidades;
using Microsoft.Data.SqlClient;

namespace CRUD_Persona_DAL
{
    public class clsManejadoraPersonasDAL
    {

        /// <summary>
        /// Con este método se consigue actualizar a una persona. Como parámetro de entrada
        /// se necesita un objeto de la clase persona, que será la persona editada del viewModel.
        /// Una vez que obtiene esta persona, se crea la conexión con la base de datos y se crean
        /// los diferentes parámetros que se añadirán a la consulta para actualizar la persona.
        /// </summary>
        /// <param name="personaModificada"></param>
        /// <returns></returns>
        public static int editarPersona(clsPersona personaModificada)
        {

            clsMyConnection conexion = new clsMyConnection();
            SqlConnection miConexion = new SqlConnection();
            SqlCommand comandoInsert = new SqlCommand();
         
            // Se crean los parámetros
            comandoInsert.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = personaModificada.ID;
            comandoInsert.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = personaModificada.Nombre;
            comandoInsert.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = personaModificada.Apellidos;
            comandoInsert.Parameters.Add("@telefeno", System.Data.SqlDbType.VarChar).Value = personaModificada.Telefono;
            comandoInsert.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = personaModificada.Direccion;
            comandoInsert.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = personaModificada.Foto;
            comandoInsert.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.Date).Value = personaModificada.FechaNacimiento;
            // Aquí se le suma 1 al id del departamento porque el picker empieza en 0 y no en 1
            comandoInsert.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = personaModificada.IDDepartamento;

            // Variable que devolverá el número de filas afectadas
            int numeroFilasAfectadas=0;


            try
            {
                miConexion = conexion.getConnection();
                comandoInsert.CommandText = "UPDATE Personas SET Nombre= @nombre, Apellidos=@apellidos, " +
                    "Telefono=@telefeno, Direccion=@direccion, Foto=@foto, FechaNacimiento = @fechaNacimiento, " +
                    "IDDepartamento =@idDepartamento  WHERE ID = @id";
                comandoInsert.Connection = miConexion;
                numeroFilasAfectadas = comandoInsert.ExecuteNonQuery();



            }catch(SqlException e)
            {
                throw e;
            }

            return numeroFilasAfectadas;

        }


        /// <summary>
        /// Este método recibe como parámetro de entrada un objeto de tipo clsPersona. Los datos de la 
        /// persona recibida por parámetro se introducen en los diferentes parámetros de entrada que recibe
        /// la consulta sql. Una vez que se realiza todo, se ejecuta la consulta y si todo está correcto
        /// la persona es insertada en la base de datos.
        /// </summary>
        /// <param name="personaInsertar"></param>
        /// <returns></returns>
        public static int insertarPersona(clsPersona personaInsertar)
        {

            clsMyConnection conexion = new clsMyConnection();
            SqlConnection miConexion = new SqlConnection();
            SqlCommand comandoInsert = new SqlCommand();

            // Se crean los parámetros
            comandoInsert.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = personaInsertar.ID;
            comandoInsert.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = personaInsertar.Nombre;
            comandoInsert.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = personaInsertar.Apellidos;
            comandoInsert.Parameters.Add("@telefeno", System.Data.SqlDbType.VarChar).Value = personaInsertar.Telefono;
            comandoInsert.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = personaInsertar.Direccion;
            comandoInsert.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = personaInsertar.Foto;
            comandoInsert.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.Date).Value = personaInsertar.FechaNacimiento;
            comandoInsert.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = personaInsertar.IDDepartamento;

            // Variable que devolverá el número de filas afectadas
            int numeroFilasAfectadas = 0;


            try
            {
                miConexion = conexion.getConnection();
                comandoInsert.CommandText = "INSERT INTO Personas VALUES( @nombre, @apellidos, @telefeno, @direccion, @foto, @fechaNacimiento, @idDepartamento)";
                comandoInsert.Connection = miConexion;
                numeroFilasAfectadas = comandoInsert.ExecuteNonQuery();

               
            }
            catch (SqlException e)
            {
                throw e;
            }

            return numeroFilasAfectadas;
        }


        /// <summary>
        /// Este método recibe como parámetro de entrada un entero que será el id de la persona seleccionada. Este id servirá para buscar a esa persona
        /// y ejecutar el comando de eliminar persona.
        /// 
        /// Postcondidicón: Un entero como parámetro que hará referencia a un id de una persona
        /// Postcondición: Devolverá un entero con el número de filas afectadas 
        /// </summary>
        /// <param name="idPersonaAEliminar"></param>
        /// <returns></returns>
        public static int eliminarPersona(int idPersonaAEliminar)
        {
            clsMyConnection conexion = new clsMyConnection();
            SqlConnection miConexion = new SqlConnection();
            SqlCommand comandoEliminar = new SqlCommand();
            int numeroFilasAfectadas = 0;

            // Se crean los parámetros
            comandoEliminar.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = idPersonaAEliminar;

            try
            {

                miConexion= conexion.getConnection();
                comandoEliminar.CommandText = "DELETE FROM Personas WHERE ID=@id";
                comandoEliminar.Connection= miConexion;
                numeroFilasAfectadas = comandoEliminar.ExecuteNonQuery();


              
            }
            catch(SqlException e)
            {
                throw e;
            }



            return numeroFilasAfectadas;
        }


    }
}
