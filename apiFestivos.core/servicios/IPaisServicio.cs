using apiFestivos.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiFestivos.core.servicios
{
    public interface IPaisServicio
    {
        Task<IEnumerable<Pais>> ObtenerTodos();
        Task<Pais?> ObtenerPorId(int id);
        Task<Pais> Crear(Pais pais);
        Task Actualizar(Pais pais);
        Task<bool> Eliminar(int id);
    }
}
