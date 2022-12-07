using CRUD_Persona_Entidades;
using Ejercicio10_ASP_Ejercicio1.Models.DAL;

namespace CRUD_Persona_BL
{
    public class clsListaPersonasBL
    {
        public static List<clsPersona> listadoPersonasCompletoBL()
        {
            return clsListaPersonas.listaCompletaPersonas();
            
        }

    }
}