using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUD_Persona_ASP.Models.ViewModel;
using CRUD_Persona_ASP.Models;

namespace CRUD_Persona_ASP.Controllers.API
{
    [Route("api/listadoPersonasConNombreDepartamento")]
    [ApiController]
    public class personasConNombreDepartamentoApiController : ControllerBase
    {
        // GET: api/<personasConNombreDepartamentoApiController>
        [HttpGet]
        public IEnumerable<clsPersonasConNombreDepartamento> Get()
        {

            listadoPersonasConNombreDept listado = new listadoPersonasConNombreDept();

            return listado.ListadoPersonasConNombreDepartamento;
        }


        // GET api/<personasConNombreDepartamentoApiController>/5
        [HttpGet("{id}")]
        public clsPersonasConNombreDepartamento Get(int id)
        {
            listadoPersonasConNombreDept listado = new listadoPersonasConNombreDept();

            return listado.obtenerPersonaPorId(id);
        }


    }
}
