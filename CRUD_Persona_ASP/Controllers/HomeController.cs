using CRUD_Persona_ASP.Models;
using CRUD_Persona_ASP.Models.ViewModel;
using CRUD_Persona_BL;
using Ejercicio10_ASP_Ejercicio1.Models.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics;

namespace CRUD_Persona_ASP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult listaPersonas()
        {
            listadoPersonasConNombreDept listaPersonas = new listadoPersonasConNombreDept();


            return View((IEnumerable)(listaPersonas.ListadoPersonasConNombreDepartamento));
        }

        public ActionResult listaDepartamentos()
        {
            return View((IEnumerable)(clsListaDepartamentoBL.listadoCompletoDepartamentosBL()));
        }

        public ActionResult paginaError()
        {
            return View();
        }
    }
}