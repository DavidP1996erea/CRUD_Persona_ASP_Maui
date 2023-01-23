using CRUD_Persona_BL;
using CRUD_Persona_DAL;
using CRUD_Persona_Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_Persona_ASP.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class personaApiController : ControllerBase
    {
        // GET: api/<personaApiController>
        [HttpGet]
        public List<clsPersona> Get()
        {
            return clsListaPersonasBL.listadoPersonasCompletoBL();
        }

        // GET api/<personaApiController>/5
        [HttpGet("{id}")]
        public clsPersona Get(int id)
        {
            return clsManejadoraPersonaBL.selectPersonaBL(id);
        }

        // POST api/<personaApiController>
        [HttpPost]
        public int Post([FromBody] clsPersona personaInsertar)
        {
            return clsManejadoraPersonaBL.insertarPersonaBL(personaInsertar);
        }

        // PUT api/<personaApiController>/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] clsPersona personaUpdate)
        {
            return clsManejadoraPersonaBL.editarPersonaBL(personaUpdate);
        }

        // DELETE api/<personaApiController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return clsManejadoraPersonaBL.eliminarPersonaBL(id);
        }
    }
}
