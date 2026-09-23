using apiFestivos.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiFestivos.core.repositorio
{
    public interface ITipoRepositorio
    {
        Task<IEnumerable<Tipo>> ObtenerTodos();
        Task<Tipo?> ObtenerPorId(int id);
        Task<Tipo> Crear(Tipo tipo);
        Task Actualizar(Tipo tipo);
        Task<bool> Eliminar(int id);
    }
}
