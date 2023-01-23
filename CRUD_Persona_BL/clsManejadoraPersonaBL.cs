using CRUD_Persona_DAL;
using CRUD_Persona_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Persona_BL
{
    public class clsManejadoraPersonaBL
    {
        public static int editarPersonaBL(clsPersona personaModificada)
        {
            return clsManejadoraPersonasDAL.editarPersona(personaModificada);
        }

        public static int insertarPersonaBL(clsPersona personaInsertar)
        {
            return clsManejadoraPersonasDAL.insertarPersona(personaInsertar);
        }

        public static int eliminarPersonaBL(int idPersonaEliminar)
        {
            return clsManejadoraPersonasDAL.eliminarPersona(idPersonaEliminar);
        }

        public static clsPersona selectPersonaBL(int idPersonaSeleccionar)
        {
            return clsManejadoraPersonasDAL.selectPersonaDAL(idPersonaSeleccionar);
        }
    }
}
