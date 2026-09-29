using apiFestivos.aplicacion;
using apiFestivos.core.repositorio;
using apiFestivos.core.servicios;
using Apifestivos.infraestructura.Persistencia;
using Apifestivos.infraestructura.repositorios;
using Microsoft.EntityFrameworkCore;

namespace Taller_1_Herramientas.InyeccionDependencias
{
    public  static class InyeccionDependencias
    {
        public static IServiceCollection AgregarDependencias(this IServiceCollection servicios,
                                               IConfiguration configuracion
                                               )
        {
            // agregar el DBContext
            servicios.AddDbContext<festivosApiContext>(opciones =>
            {
                opciones.UseSqlServer(configuracion.GetConnectionString("CampeonatosFIFA"));
            });

            // agregar los repositorios
            servicios.AddTransient<IPaisRepositorio, PaisesRepositorio>();

            // agregar los servicios
            servicios.AddTransient<IPaisServicio, PaisServicio>();



            return servicios;
        }
    }
}
