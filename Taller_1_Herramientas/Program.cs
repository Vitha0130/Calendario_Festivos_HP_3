
using Taller_1_Herramientas.InyeccionDependencias;

namespace Taller_1_Herramientas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //establecer objeto de configuracion
            var configuracion = builder.Configuration;

            //establecer los objetos a inyectar
            builder.Services.AgregarDependencias(configuracion);
            builder.Services.AddControllers();


            var app = builder.Build();


            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
