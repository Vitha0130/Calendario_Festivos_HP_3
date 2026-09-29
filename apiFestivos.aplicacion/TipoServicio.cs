using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apiFestivos.dominio;
using apiFestivos.core.repositorio;
using apiFestivos.core.servicios;
namespace apiFestivos.aplicacion
{
    public class TipoServicio : ITipoServicio
    {
        private readonly ITipoRepositorio repositorio;

        public TipoServicio(ITipoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }

        public async Task<Tipo?> ObtenerPorId(int id)
        {
            return await repositorio.ObtenerPorId(id);
        }

        public async Task<Tipo> Crear(Tipo tipo)
        {
            return await repositorio.Crear(tipo);
        }


        public async Task Actualizar(Tipo tipo)
        {
            await repositorio.Actualizar(tipo);
        }


        public async Task<bool> Eliminar(int id)
        {
            return await repositorio.Eliminar(id);
        }
    }
}
