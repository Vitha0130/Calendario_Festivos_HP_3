using apiFestivos.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiFestivos.core.repositorio
{
    public interface IFestivoRepositorio
    {
        Task<IEnumerable<Festivo>> ObtenerTodos();
        Task<Festivo?> ObtenerPorId(int id);
        Task<Festivo> Crear(Festivo festivo);
        Task Actualizar(Festivo festivo);
        Task<bool> Eliminar(int id);

        Task<IEnumerable<Festivo>> ObtenerPorPais(int idPais);
    }
}
