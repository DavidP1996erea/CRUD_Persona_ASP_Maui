using CRUD_Persona_BL;
using CRUD_Persona_Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Persona_ASP.Controllers.API
{
    [Route("api/departamentosApi")]
    [ApiController]
    public class departamentoApiController : ControllerBase
    {

        // GET: api/<personaApiController>
        [HttpGet]
        public IEnumerable<clsDepartamento> Get()
        {
            return clsListaDepartamentoBL.listadoCompletoDepartamentosBL();
        }

        // GET api/<personaApiController>/5
        [HttpGet("{id}")]
        public clsDepartamento Get(int id)
        {
            return clsManejadoraDepartamentosBL.selectDepartamentoPorIdBL(id);
        }
    }
}
