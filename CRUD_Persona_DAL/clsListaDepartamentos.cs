using _07_CRUD_Personas_DAL.Conexion;
using CRUD_Persona_Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Persona_DAL
{
    public class clsListaDepartamentos
    {

        /// <summary>
        /// Este método estático retorna una lista de departamentos, para ello se conecta a la base de datos y hace un select de todos los datos de 
        /// la tabla departamento. Para guardar los datos en objetos, por cada iteración del while se crea un nuevo objeto vacío, que irá
        /// obteniendo valores según recorra la tabla.
        /// 
        /// Postcondición: Debe existir una base de datos
        /// Precondición: Devolverá una lista de departamentos completa
        /// </summary>
        /// <returns></returns>
        public static List<clsDepartamento> listadoCompletoDepartamentos()
        {

            List<clsDepartamento> lista = new List<clsDepartamento>();
            clsMyConnection conexion = new clsMyConnection();
            clsDepartamento departamento;
            SqlConnection miConexion = new SqlConnection();
            SqlCommand comandoListaDepartamentos = new SqlCommand();
            SqlDataReader lectorDepartamentos;

            try
            {
                miConexion = conexion.getConnection();
              
           
                comandoListaDepartamentos.CommandText = "SELECT * FROM Departamentos";
                comandoListaDepartamentos.Connection = miConexion;
                lectorDepartamentos = comandoListaDepartamentos.ExecuteReader();

                if (lectorDepartamentos.HasRows)
                {
                    while (lectorDepartamentos.Read())
                    {
                        departamento = new clsDepartamento();
                        departamento.ID = (int)lectorDepartamentos["ID"];
                        departamento.Nombre = (string)lectorDepartamentos["Nombre"];
                       
                        lista.Add(departamento);
                    }

                }

                lectorDepartamentos.Close();
                miConexion.Close();
                
            }
            catch (SqlException exSql)
            {

                throw exSql;
            }

            return lista;



        }

        // Para ASP

        /// <summary>
        /// Con este método obtendremos un departamento a través del id, para ello se recorrerá la lista
        /// de departamentos creada anteriormente, y se irá comparando el id. Cuando coincida se igualará 
        /// el objeto vacío creado con el correspondiente.
        /// 
        /// Postcondición: Devolverá un objeto departamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static clsDepartamento obtenerDepartamentoPorId(int id)
        {

            clsDepartamento departamentoEnviar = new clsDepartamento();
            for (int i = 0; i < listadoCompletoDepartamentos().Count; i++)
            {
                if (listadoCompletoDepartamentos()[i].ID == id)
                {
                    departamentoEnviar = listadoCompletoDepartamentos()[i];
                }
            }
            return departamentoEnviar;


        }


    }
}
