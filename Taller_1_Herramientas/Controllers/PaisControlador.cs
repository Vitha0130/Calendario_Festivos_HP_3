using apiFestivos.core.servicios;
using apiFestivos.dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Taller_1_Herramientas.Controllers
{
    [Route("api/pais")]
    [ApiController]
    public class PaisControlador : ControllerBase
    {
        private readonly IPaisServicio servicio;

        public PaisControlador(IPaisServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Pais>))]
        public async Task<ActionResult<IEnumerable<Pais>>> ObtenerTodos()
        {
            var lista = await servicio.ObtenerTodos();
            return Ok(lista);
        }


        [HttpGet("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Pais))]
        public async Task<ActionResult<Pais>> Obtener(int Id)
        {
            var pais = await servicio.ObtenerPorId(Id);
            if (pais == null)
            {
                return NotFound(new { mensaje = $"No se encontró el País con ID= {Id}" });
            }
            return Ok(pais);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Pais))]
        public async Task<ActionResult<Pais>> Agregar([FromBody] Pais pais)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var nuevoPais = await servicio.Crear(pais);
            return CreatedAtAction(nameof(Obtener), new { Id = nuevoPais.Id }, nuevoPais);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]

        public async Task<ActionResult<bool>> Eliminar(int id)
        {
            var pais = await servicio.ObtenerPorId(id);
            if (pais == null)
            {
                return NotFound(new { mensaje = $"No se encontró el País con ID= {id}" });
            }
            await servicio.Eliminar(id);
            return Ok(true);
        }
        [HttpPut("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Pais))]
        public async Task<ActionResult<Pais>> Actualizar(int id, [FromBody] Pais pais)
        {
            var paisExistente = await servicio.ObtenerPorId(id);
            if (paisExistente == null)
            {
                return NotFound(new { mensaje = $"No se encontró el País con ID= {id}" });
            }

            pais.Id = id;
            await servicio.Actualizar(pais);
            return Ok(pais);
        }

    }
}
 