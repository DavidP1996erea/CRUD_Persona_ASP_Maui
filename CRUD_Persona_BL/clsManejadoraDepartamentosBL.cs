using CRUD_Persona_DAL;
using CRUD_Persona_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Persona_BL
{
    public class clsManejadoraDepartamentosBL
    {

        public static int editarDepartamentoBL(clsDepartamento departamentoEditar)
        {
            return clsManejadoraDepartamentoDAL.editarDepartamentoDAL(departamentoEditar);
        }

        public static int insertarDepartamentoBL(clsDepartamento departamentoInsertar)
        {
            return clsManejadoraDepartamentoDAL.insertarDepartamentoDAL(departamentoInsertar);
        }

        public static int eliminarDepartamentoBL(int departamentoEliminar)
        {
            return clsManejadoraDepartamentoDAL.eliminarDepartamento(departamentoEliminar);
        }


        public static clsDepartamento selectDepartamentoPorIdBL(int id)
        {
            return clsManejadoraDepartamentoDAL.selectDepartamentoDAL(id);
        }
    }
}
