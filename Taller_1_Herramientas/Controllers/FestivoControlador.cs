using apiFestivos.core.servicios;
using apiFestivos.dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Taller_1_Herramientas.Controllers
{
    [Route("api/festivo")]
    [ApiController]
    public class FestivoControlador : ControllerBase
    {

        private readonly IFestivosServicio servicio;

        public FestivoControlador(IFestivosServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Festivo>))]
        public async Task<ActionResult<IEnumerable<Festivo>>> ObtenerTodos()
        {
            var lista = await servicio.ObtenerTodos();
            return Ok(lista);
        }


        [HttpGet("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Festivo))]
        public async Task<ActionResult<Festivo>> Obtener(int Id)
        {
            var festivo = await servicio.ObtenerPorId(Id);
            if (festivo == null)
            {
                return NotFound(new { mensaje = $"No se encontró el Festivo con ID= {Id}" });
            }
            return Ok(festivo);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Festivo))]
        public async Task<ActionResult<Festivo>> Agregar([FromBody] Festivo festivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var nuevoFestivo = await servicio.Crear(festivo);
            return CreatedAtAction(nameof(Obtener), new { Id = nuevoFestivo.Id }, nuevoFestivo);
        }

        [HttpGet("pais/{idPais:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Festivo>))]
        public async Task<ActionResult<IEnumerable<Festivo>>> ObtenerPorPais(int idPais)
        {
            var lista = await servicio.ObtenerPorPais(idPais);
            return Ok(lista);
        }


    }
}
