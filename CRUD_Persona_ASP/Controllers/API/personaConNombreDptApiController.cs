using CRUD_Persona_ASP.Models;
using CRUD_Persona_ASP.Models.ViewModel;
using CRUD_Persona_BL;
using CRUD_Persona_DAL;
using CRUD_Persona_Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_Persona_ASP.Controllers.API
{
    [Route("api/listaPersonasConNombreDpt")]
    [ApiController]
    public class clsPersonasConNombreDepartamento : ControllerBase
    {
        // GET: api/<personaApiController>
        [HttpGet]
        public IEnumerable<clsPersonasConNombreDepartamento> Get()
        {
            listadoPersonasConNombreDept personasConDpt = new listadoPersonasConNombreDept();


            return (IEnumerable<clsPersonasConNombreDepartamento>)(personasConDpt.ListadoPersonasConNombreDepartamento);
        }


    }
}
