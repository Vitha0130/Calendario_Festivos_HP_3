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
    public class FestivoServicio : IFestivosServicio
    {

        private readonly IFestivoRepositorio repositorio;

        public FestivoServicio(IFestivoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }

        public async Task<Festivo?> ObtenerPorId(int id)
        {
            return await repositorio.ObtenerPorId(id);
        }

        public async Task<Festivo> Crear(Festivo festivo)
        {
            return await repositorio.Crear(festivo);
        }

        public async Task Actualizar(Festivo festivo)
        {
            await repositorio.Actualizar(festivo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await repositorio.Eliminar(id);
        }

        public async Task<IEnumerable<Festivo>> ObtenerPorPais(int idPais)
        {
            return await repositorio.ObtenerPorPais(idPais);
        }
    }
}
