using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Persona_Entidades
{

    public class clsDepartamento
    {


        #region Atributos
        public int ID { get; set; }
        public string Nombre { get; set; }
        #endregion

        #region Constructor por defecto
        public clsDepartamento()
        {

        }
        #endregion

        #region Constructor con parámetros
        public clsDepartamento(int id, string nombre)
        {
            ID = id;
            Nombre = nombre;
        }
        #endregion

    }
}
