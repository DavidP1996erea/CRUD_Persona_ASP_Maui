using CRUD_Persona_BL;
using CRUD_Persona_Entidades;

namespace CRUD_Persona_ASP.Models.ViewModel
{
    public class editarPersonaVM : clsPersona
    {

        #region Atributos
        private List<clsDepartamento> listadoDepartamentos = new List<clsDepartamento>();
        private clsPersona personaDatos = new clsPersona();
        #endregion


        #region Propiedades

        public List<clsDepartamento> ListadoDepartamentos
        {
            get { return listadoDepartamentos;}
            set { listadoDepartamentos = value; }
        }

        public clsPersona PersonaDatos
        {
            get { return personaDatos; }
            set { personaDatos = value; }
        }
        #endregion

        #region Constructor por defecto
        public editarPersonaVM(int id)
        {
            personaDatos = obtenerPersonaPorId(id);
            listadoDepartamentos=clsListaDepartamentoBL.listadoCompletoDepartamentosBL();
        }
        #endregion


        /// <summary>
        /// Este método recorre la lista de personas dada por la BL, y devuelve una persona obtenida a
        /// través de un id que se le pasa por parámetro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static clsPersona obtenerPersonaPorId(int id)
        {
            clsPersona personaEnviar = new clsPersona();

            for (int i = 0; i < clsListaPersonasBL.listadoPersonasCompletoBL().Count; i++)
            {
                if (clsListaPersonasBL.listadoPersonasCompletoBL()[i].ID == id)
                {
                    personaEnviar = clsListaPersonasBL.listadoPersonasCompletoBL()[i];
                }
            }
            return personaEnviar;


        }
    }
}
