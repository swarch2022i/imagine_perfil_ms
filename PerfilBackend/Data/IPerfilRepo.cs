using PerfilBackend.Models;
using System.Collections.Generic;

namespace PerfilBackend.Data
{
    public interface IPerfilRepo
    {
        bool SaveChanges();

        IEnumerable<Perfil> GetAllPerfiles();
        Perfil GetPerfilById(int id);
        void CreatePerfil(Perfil perf);
    }
}
