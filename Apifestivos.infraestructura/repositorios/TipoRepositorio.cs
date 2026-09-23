using apiFestivos.core.repositorio;
using apiFestivos.dominio;
using Apifestivos.infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apifestivos.infraestructura.repositorios
{
    public class TipoRepositorio : ITipoRepositorio
    {

        private readonly festivosApiContext contexto;

        public TipoRepositorio(festivosApiContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return await contexto.Tipos
                .OrderBy(t => t.Id)
                .ToListAsync();
        }

        public async Task<Tipo?> ObtenerPorId(int id)
        {
            return await contexto.Tipos.FindAsync(id);
        }

        public async Task<Tipo> Crear(Tipo tipo)
        {
            contexto.Tipos.Add(tipo);
            await contexto.SaveChangesAsync();
            return tipo;
        }

        public async Task Actualizar(Tipo tipo)
        {
            contexto.Tipos.Update(tipo);
            await contexto.SaveChangesAsync();
        }

        public async Task<bool> Eliminar(int id)
        {
            var tipo = await contexto.Tipos.FindAsync(id);
            if (tipo != null)
            {
                contexto.Tipos.Remove(tipo);
                await contexto.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
