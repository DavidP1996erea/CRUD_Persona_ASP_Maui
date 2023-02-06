using CRUD_Persona_BL;
using CRUD_Persona_Entidades;

namespace CRUD_Persona_ASP.Models.ViewModel
{
    public class listadoPersonasConNombreDept
    {

        #region Atributos
        private List<clsPersonasConNombreDepartamento> listadoPersonasConNombreDepartamento = new List<clsPersonasConNombreDepartamento>();
        #endregion

        #region Propiedades
        public List<clsPersonasConNombreDepartamento> ListadoPersonasConNombreDepartamento
        {
            get { return listadoPersonasConNombreDepartamento; }
            set { listadoPersonasConNombreDepartamento = value; }
        }

        #endregion


        #region Constructor por defecto
        public listadoPersonasConNombreDept() {

            generarLista();
        }
        #endregion


        /// <summary>
        /// Este método recorre la lista de persona dada por la BL, y por cada iteración se va
        /// añadiendo una persona nueva de la clase clsPersonasConNombreDepartamento, con los datos
        /// de la persona original
        /// </summary>
        public void generarLista()
        {

            foreach (clsPersona persona in clsListaPersonasBL.listadoPersonasCompletoBL())
            {

                listadoPersonasConNombreDepartamento.Add(new clsPersonasConNombreDepartamento(
                    persona.ID, 
                    persona.Nombre, 
                    persona.Apellidos,
                    persona.Telefono, 
                    persona.Direccion, 
                    persona.Foto, 
                    persona.FechaNacimiento, 
                    mostrarNombreDepartamento(persona)));
            }
        }


        /// <summary>
        /// Con este método se obtiene el nombre de un departamento. Para ello como parámetro se pide una
        /// persona, y se recorre el listado de departamentos, comparando sus id con el idDepartamento
        /// de esa persona. Cuando se encuentra se guarda el nombre de ese departamento en una variable
        /// y se devuelve
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public string mostrarNombreDepartamento(clsPersona persona)
        {
            string nombreDepartamento = "";
            List<clsDepartamento> listaDepartamentos = clsListaDepartamentoBL.listadoCompletoDepartamentosBL();

            for (int i = 0; i < listaDepartamentos.Count; i++)
            {

                if ((persona.IDDepartamento+1) == listaDepartamentos[i].ID)
                {
                    nombreDepartamento = listaDepartamentos[i].Nombre;
                }
            }
            return nombreDepartamento;
        }
    }
}
