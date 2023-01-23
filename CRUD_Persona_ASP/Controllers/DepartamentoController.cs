using CRUD_Persona_BL;
using CRUD_Persona_Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Persona_ASP.Controllers
{
    public class DepartamentoController : Controller
    {
       


        public ActionResult editarDepartamento(int id)
        {


            return View(clsListaDepartamentoBL.obtenerDepartamentoPorIdBL(id));
        }


        [HttpPost]
        [ActionName("editarDepartamento")]
        public ActionResult editarDepartamento2(clsDepartamento departamento)
        {
            clsManejadoraDepartamentosBL.editarDepartamentoBL(departamento);


            return RedirectToAction("listaDepartamentos", "Home");
        }


        public ActionResult borrarDepartamento(int id)
        {

            clsManejadoraDepartamentosBL.eliminarDepartamentoBL(id);

            return RedirectToAction("listaDepartamentos", "Home");
        }



        public ActionResult insertarDepartamento(int id)
        {


            return View(clsListaDepartamentoBL.obtenerDepartamentoPorIdBL(id));
        }


        [HttpPost]
        [ActionName("insertarDepartamento")]
        public ActionResult insertarDepartamento2(clsDepartamento departamento)
        {

            try
            {
                clsManejadoraDepartamentosBL.insertarDepartamentoBL(departamento);
            }
            catch(Exception)
            {
                return RedirectToAction("paginaError", "Home");
            }
            

            return RedirectToAction("listaDepartamentos", "Home");
        }
    }
}
