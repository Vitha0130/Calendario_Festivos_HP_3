using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiFestivos.core.servicios
{
    public interface ICalendarioServicio
    {
        Task<string> VerificarFecha(int idPais, int anio, int mes, int dia);

        Task<IEnumerable<(string Festivo, DateTime Fecha)>> ListarFestivosPorAnio(int idPais, int anio);

        DateTime CalcularDomingoPascua(int anio);
    }
}
