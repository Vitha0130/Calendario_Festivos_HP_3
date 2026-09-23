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
    public class PaisesRepositorio: IPaisRepositorio
    {
        private readonly festivosApiContext contexto;

        public PaisesRepositorio(festivosApiContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task<IEnumerable<Pais>> ObtenerTodos()
        {
            return await contexto.Paises
                .OrderBy(p => p.Nombre)
                .ToListAsync();
        }

        public async Task<Pais?> ObtenerPorId(int id)
        {
            return await contexto.Paises.FindAsync(id);
        }

        public async Task<Pais> Crear(Pais pais)
        {
            contexto.Paises.Add(pais);
            await contexto.SaveChangesAsync();
            return pais;
        }

        public async Task Actualizar(Pais pais)
        {
            contexto.Paises.Update(pais);
            await contexto.SaveChangesAsync();
        }

        public async Task<bool> Eliminar(int id)
        {
            var pais = await contexto.Paises.FindAsync(id);
            if (pais != null)
            {
                contexto.Paises.Remove(pais);
                await contexto.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
