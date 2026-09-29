using apiFestivos.core.repositorio;
using apiFestivos.dominio;
using apiFestivos.core.servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiFestivos.aplicacion
{
    public class CalendarioServicio : ICalendarioServicio
    {

        private readonly IFestivoRepositorio repositorio;

        public CalendarioServicio(IFestivoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        // Algoritmo dado en el enunciado (basado en el de Gauss)
        public DateTime CalcularDomingoPascua(int anio)
        {
            int a = anio % 19;
            int b = anio % 4;
            int c = anio % 7;
            int d = (19 * a + 24) % 30;
            int dias = d + ((2 * b + 4 * c + 6 * d + 5) % 7);

            DateTime domingoRamos = new DateTime(anio, 3, 15).AddDays(dias);
            DateTime domingoPascua = domingoRamos.AddDays(7);

            return domingoPascua;
        }

        public async Task<string> VerificarFecha(int idPais, int anio, int mes, int dia)
        {
            DateTime fechaConsulta;
            try
            {
                fechaConsulta = new DateTime(anio, mes, dia);
            }
            catch (ArgumentOutOfRangeException)
            {
                return "Fecha No valida";
            }

            var festivos = await repositorio.ObtenerPorPais(idPais);
            DateTime domingoPascua = CalcularDomingoPascua(anio);

            foreach (var festivo in festivos)
            {
                var fechaFestivo = CalcularFechaFestivo(festivo, anio, domingoPascua);
                if (fechaFestivo.HasValue && fechaFestivo.Value.Date == fechaConsulta.Date)
                    return "Es Festivo";
            }

            return "No es festivo";
        }

        public async Task<IEnumerable<(string Festivo, DateTime Fecha)>> ListarFestivosPorAnio(int idPais, int anio)
        {
            var festivos = await repositorio.ObtenerPorPais(idPais);
            DateTime domingoPascua = CalcularDomingoPascua(anio);

            var resultado = new List<(string Festivo, DateTime Fecha)>();

            foreach (var festivo in festivos)
            {
                var fecha = CalcularFechaFestivo(festivo, anio, domingoPascua);
                if (fecha.HasValue)
                    resultado.Add((festivo.Nombre, fecha.Value));
            }

            return resultado.OrderBy(f => f.Fecha);
        }

        
        private DateTime? CalcularFechaFestivo(Festivo festivo, int anio, DateTime domingoPascua)
        {
            DateTime fecha;

            switch (festivo.IdTipo)
            {
                case 1: // Fijo
                    fecha = new DateTime(anio, festivo.Mes, festivo.Dia);
                    break;

                case 2: // Ley de puente festivo
                    fecha = new DateTime(anio, festivo.Mes, festivo.Dia);
                    fecha = TrasladarASiguienteLunes(fecha);
                    break;

                case 3: // Basado en domingo de pascua
                    fecha = domingoPascua.AddDays(festivo.DiasPascua);
                    break;

                case 4: // Pascua + puente festivo
                    fecha = domingoPascua.AddDays(festivo.DiasPascua);
                    fecha = TrasladarASiguienteLunes(fecha);
                    break;

                default:
                    return null;
            }

            return fecha;
        }

        private DateTime TrasladarASiguienteLunes(DateTime fecha)
        {
            int diasHastaLunes = ((int)DayOfWeek.Monday - (int)fecha.DayOfWeek + 7) % 7;
            return fecha.AddDays(diasHastaLunes);
        }
    }
}
