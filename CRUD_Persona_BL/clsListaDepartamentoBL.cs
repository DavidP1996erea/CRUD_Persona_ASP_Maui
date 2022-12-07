using CRUD_Persona_DAL;
using CRUD_Persona_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Persona_BL
{
    public class clsListaDepartamentoBL
    {
        public static List<clsDepartamento> listadoCompletoDepartamentosBL()
        {
            return clsListaDepartamentos.listadoCompletoDepartamentos();
        }

        public static clsDepartamento obtenerDepartamentoPorIdBL(int id)
        {
            return clsListaDepartamentos.obtenerDepartamentoPorId(id);
        }

    }
}
