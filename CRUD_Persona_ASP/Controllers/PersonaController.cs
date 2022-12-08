using CRUD_Persona_ASP.Models.ViewModel;
using CRUD_Persona_BL;
using CRUD_Persona_Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Persona_ASP.Controllers
{
    public class PersonaController : Controller
    {
        public ActionResult editarPersona(int id)
        {

            editarPersonaVM personaVM= new editarPersonaVM(id);

            return View(personaVM);
        }


        [HttpPost]
        [ActionName("editarPersona")]
        public ActionResult editarPersona2(clsPersona personaEditar)
        {

           clsManejadoraPersonaBL.editarPersonaBL(personaEditar);

            return RedirectToAction("listaPersonas", "Home");
        }


        public ActionResult borrarPersona(int id)
        {

            clsManejadoraPersonaBL.eliminarPersonaBL(id);

            return RedirectToAction("listaPersonas", "Home");
        }


        public ActionResult insertarPersona()
        {
            insertarPersonaVM personaInsertar = new insertarPersonaVM();

            return View(personaInsertar);
        }


        [HttpPost]
        [ActionName("insertarPersona")]
        public ActionResult insertarPersona2(clsPersona personaInsertar)
        {
            clsManejadoraPersonaBL.insertarPersonaBL(personaInsertar);

            return RedirectToAction("listaPersonas", "Home");
        }
    }
}
