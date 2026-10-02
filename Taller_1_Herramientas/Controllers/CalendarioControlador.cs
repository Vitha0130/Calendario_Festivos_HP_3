using apiFestivos.core.servicios;
using apiFestivos.dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Taller_1_Herramientas.Controllers
{
    [Route("api/calendario")]
    [ApiController]
    public class CalendarioControlador : ControllerBase
    {
        private readonly ICalendarioServicio servicio;

        public CalendarioControlador(ICalendarioServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet("verificar/{idPais}/{anio}/{mes}/{dia}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IActionResult))]
        public async Task<IActionResult> VerificarFecha(int idPais, int anio, int mes, int dia)
        {
            var resultado = await servicio.VerificarFecha(idPais, anio, mes, dia);
            return Ok(resultado);
        }

        [HttpGet("festivos/{idPais}/{anio}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IActionResult))]
        public async Task<IActionResult> ListarFestivosPorAnio(int idPais, int anio)
        {
            var festivos = await servicio.ListarFestivosPorAnio(idPais, anio);

            var respuesta = festivos.Select(f => new
            {
                festivo = f.Festivo,
                fecha = f.Fecha.ToString("yyyy-MM-dd")
            });

            return Ok(respuesta);
        }


    }
}
