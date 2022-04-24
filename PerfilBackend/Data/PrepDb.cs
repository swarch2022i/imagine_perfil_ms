using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PerfilBackend.Models;
using System;
using System.Linq;

namespace PerfilBackend.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            context.Database.Migrate();

            if (!context.Perfiles.Any())
            {
                Console.WriteLine("--> enviando Datos");

                context.Perfiles.AddRange(
                    new Perfil() {Nombre="un nombre", IdImagenPerfil ="dnawdawnd",Texto="hola",Numfollowers=0,Numfollows=0,IdUsuario = 1 },
                    new Perfil() {Nombre="do nombre", IdImagenPerfil ="dnawdawnd4",Texto="hola2",Numfollowers=0,Numfollows=0, IdUsuario = 2},
                    new Perfil() {Nombre = "tr nombre", IdImagenPerfil = "5eawddaw", Texto = "hola3", Numfollowers = 0, Numfollows = 0, IdUsuario = 3},
                    new Perfil() {Nombre = "cu nombre", IdImagenPerfil = "325fawdawd", Texto = "hola3", Numfollowers = 0, Numfollows = 0, IdUsuario = 4}
                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Tenemos DATOOOOS");
            }
        }
    }
}
