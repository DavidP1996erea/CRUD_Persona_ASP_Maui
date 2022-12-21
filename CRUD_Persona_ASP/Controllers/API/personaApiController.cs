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
        public string Get(int id)
        {
            return clsManejadoraPersonaBL.";
        }

        // POST api/<personaApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<personaApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<personaApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
