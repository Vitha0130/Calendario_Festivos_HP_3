using apiFestivos.core.servicios;
using apiFestivos.dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Taller_1_Herramientas.Controllers
{
    [Route("api/tipo")]
    [ApiController]
    public class TipoControlador : ControllerBase
    {
        private readonly ITipoServicio servicio;

        public TipoControlador(ITipoServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet]
        [ProducesResponseType(statusCode: 200, Type = typeof(IEnumerable<Tipo>))]
        public async Task<ActionResult<IEnumerable<Tipo>>> ObtenerTodos()
        {
            var tipos = await servicio.ObtenerTodos();
            return Ok(tipos);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(statusCode:200, Type = typeof(Tipo))]
        public async Task<ActionResult<Tipo>> ObtenerPorId(int id)
        {
            var tipo = await servicio.ObtenerPorId(id);
            if (tipo == null)
            {
                return NotFound();
            }
            return Ok(tipo);
        }

    }
}
