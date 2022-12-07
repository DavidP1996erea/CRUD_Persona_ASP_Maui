using _07_CRUD_Personas_DAL.Conexion;
using CRUD_Persona_Entidades;
using Microsoft.Data.SqlClient;

namespace Ejercicio10_ASP_Ejercicio1.Models.DAL
{
    public class clsListaPersonas 
    {


        /// <summary>
        /// Este método devuelve una lista de personas que recoge de la base de datos. Para ello
        /// se crea una conexión con la base de datos y un comando que se ejecutará para obtener
        /// todos los datos de la tabla Personas. En cada iteración del while se crea un nuevo
        /// objeto de tipo persona, del cual cogerá los datos de la lectura de la base de datos.
        /// </summary>
        /// <returns></returns>
        public static List<clsPersona> listaCompletaPersonas()
        {

            List<clsPersona> lista = new List<clsPersona>();

            clsMyConnection conexion= new clsMyConnection();
            SqlConnection miConexion = new SqlConnection();
            SqlCommand comandoLista = new SqlCommand();
            SqlDataReader lectorPersonas;
            clsPersona personas;
           

            try
            {
                miConexion = conexion.getConnection();
                comandoLista.CommandText = "SELECT * FROM Personas";
                comandoLista.Connection = miConexion;
                lectorPersonas = comandoLista.ExecuteReader();

                if (lectorPersonas.HasRows)
                {
                    while (lectorPersonas.Read())
                    {
                        personas = new clsPersona();
                        personas.ID = (int)lectorPersonas["ID"];
                        personas.Nombre = (string)lectorPersonas["Nombre"];
                        personas.Apellidos = (string)lectorPersonas["Apellidos"];
                        personas.Telefono = (string)lectorPersonas["Telefono"];
                        personas.Direccion = (string)lectorPersonas["Direccion"];
                        personas.Foto = (string)lectorPersonas["Foto"];
                        personas.FechaNacimiento = (DateTime)lectorPersonas["FechaNacimiento"];
                        /* Como el picker empieza en 0 y los valores de id de la base de datos comienzan en 1,
                         * se le resta uno para que coincidan los valores. Con esta comprobación se evita que 
                         * la aplicación no muestre la lista de personas cuando uno de los departamentos
                         * es nulo
                         */

                        if (lectorPersonas["IDDepartamento"] == System.DBNull.Value)
                        {
                            personas.IDDepartamento =-1;
                        }
                        else
                        {
                            personas.IDDepartamento = ((int)lectorPersonas["IDDepartamento"]) - 1;

                        }
                     
                      
                      
                       
                        lista.Add(personas);
                    }

                }

                lectorPersonas.Close();
                miConexion.Close();
            }catch(SqlException exSql) {

                throw exSql;
            }

            return lista;


        }
    }
}
