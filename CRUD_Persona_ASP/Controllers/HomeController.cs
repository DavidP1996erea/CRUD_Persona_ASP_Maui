using CRUD_Persona_ASP.Models;
using CRUD_Persona_BL;
using Ejercicio10_ASP_Ejercicio1.Models.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics;

namespace CRUD_Persona_ASP.Controllers
{
    public class HomeController : Controller
    {

      public ActionResult editarDepartamento(int id)
        {
           

            return View(clsListaDepartamentoBL.obtenerDepartamentoPorIdBL(id));
        } 
      public ActionResult listaPersonas()
        {

            return View((IEnumerable)(clsListaPersonasBL.listadoPersonasCompletoBL()));
        }

        public ActionResult listaDepartamentos()
        {
            return View((IEnumerable)(clsListaDepartamentoBL.listadoCompletoDepartamentosBL()));
        }
    }
}