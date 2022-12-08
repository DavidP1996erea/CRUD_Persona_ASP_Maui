using CRUD_Persona_BL;
using CRUD_Persona_Entidades;

namespace CRUD_Persona_ASP.Models.ViewModel
{
    public class insertarPersonaVM:clsPersona
    {

        #region Atributos
        private List<clsDepartamento> listadoDepartamentos = new List<clsDepartamento>();
        private clsPersona personaDatos;
        #endregion


        #region Propiedades

        public List<clsDepartamento> ListadoDepartamentos
        {
            get { return listadoDepartamentos; }
            set { listadoDepartamentos = value; }
        }

        public clsPersona PersonaDatos
        {
            get { return personaDatos; }
            set { personaDatos = value; }
        }
        #endregion

        #region Constructor por defecto
        public insertarPersonaVM()
        {
            personaDatos = new clsPersona();
            listadoDepartamentos = clsListaDepartamentoBL.listadoCompletoDepartamentosBL();
        }
        #endregion
    }
}
