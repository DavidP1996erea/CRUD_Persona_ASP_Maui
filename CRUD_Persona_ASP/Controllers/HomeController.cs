using CRUD_Persona_ASP.Models;
using CRUD_Persona_ASP.Models.ViewModel;
using CRUD_Persona_BL;
using CRUD_Persona_Entidades;
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
            listadoPersonasConNombreDept listaPersonas;

            // En caso de que la lista se ha recogido correctamento se redirige a la vista correspondiente
            try
            {
                 listaPersonas = new listadoPersonasConNombreDept();
             }
            catch(Exception ex)
            {
                // Si hubo algún error se irá a una página error
                return RedirectToAction("paginaError", "Home");
                }

            return View((IEnumerable)(listaPersonas.ListadoPersonasConNombreDepartamento));
        }

        public ActionResult listaDepartamentos()
        {
            List<clsDepartamento> listaDepartamentos;
            // En caso de que la lista se ha recogido correctamento se redirige a la vista correspondiente
            try
            {
                listaDepartamentos = clsListaDepartamentoBL.listadoCompletoDepartamentosBL();
            }
            catch (Exception)
            {
                // Si hubo algún error se irá a una página error
                return RedirectToAction("paginaError", "Home");
            }
            return View((IEnumerable)(listaDepartamentos));
        }

        public ActionResult paginaError()
        {
            return View();
        }
    }
}