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
    public class FestivosRepositorio: IFestivoRepositorio
    {
        private readonly festivosApiContext contexto;

        public FestivosRepositorio(festivosApiContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return await contexto.Festivos
                .Include(f => f.Tipo)
                .Include(f => f.Pais)
                .ToListAsync();
        }
         
        public async Task<Festivo?> ObtenerPorId(int id)
        {
            return await contexto.Festivos
                .Include(f => f.Tipo)
                .Include(f => f.Pais)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Festivo> Crear(Festivo festivo)
        {
            contexto.Festivos.Add(festivo);
            await contexto.SaveChangesAsync();
            return festivo;
        }

        public async Task Actualizar(Festivo festivo)
        {
            contexto.Festivos.Update(festivo);
            await contexto.SaveChangesAsync();
        }

        public async Task<bool> Eliminar(int id)
        {
            var festivo = await contexto.Festivos.FindAsync(id);
            if (festivo != null)
            {
                contexto.Festivos.Remove(festivo);
                await contexto.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Festivo>> ObtenerPorPais(int idPais)
        {
            return await contexto.Festivos
                .Include(f => f.Tipo)
                .Include(f => f.Pais)
                .Where(f => f.IdPais == idPais)
                .ToListAsync();
        }

    }
}
