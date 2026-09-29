using apiFestivos.core.repositorio;
using apiFestivos.core.servicios;
using apiFestivos.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiFestivos.aplicacion
{
    public class PaisServicio : IPaisServicio
    {
        private readonly IPaisRepositorio repositorio;

        public PaisServicio(IPaisRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<IEnumerable<Pais>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }

        public async Task<Pais?> ObtenerPorId(int id)
        {
            return await repositorio.ObtenerPorId(id);
        }

        public async Task<Pais> Crear(Pais pais)
        {
            return await repositorio.Crear(pais);
        }

        public async Task Actualizar(Pais pais)
        {
            await repositorio.Actualizar(pais);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await repositorio.Eliminar(id);
        }
    }
}
