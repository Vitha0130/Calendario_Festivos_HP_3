using apiFestivos.aplicacion;
using apiFestivos.core.repositorio;
using apiFestivos.core.servicios;
using Apifestivos.infraestructura.Persistencia;
using Apifestivos.infraestructura.repositorios;
using Microsoft.EntityFrameworkCore;

namespace apiFestivos.presentacion.InyeccionDependencias
{
    public static class InyeccionDependencias
    {
        public static IServiceCollection AgregarDependencias(this IServiceCollection servicios,
                                              IConfiguration configuracion
                                              )
        {
           
            servicios.AddDbContext<festivosApiContext>(opciones =>
            {
                opciones.UseSqlServer(configuracion.GetConnectionString("ApiFestivos"));
            });

            // agregar los repositorios
            servicios.AddTransient<IFestivoRepositorio, FestivosRepositorio>();
            servicios.AddTransient<IPaisRepositorio, PaisesRepositorio>();


            // agregar los servicios
            servicios.AddTransient<IFestivosServicio, FestivoServicio>();
            servicios.AddTransient<ICalendarioServicio, CalendarioServicio>();
            servicios.AddTransient<IPaisServicio, PaisServicio>();



            return servicios;
        }
    }
}
