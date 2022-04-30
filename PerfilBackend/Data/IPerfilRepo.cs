using PerfilBackend.Models;
using System.Collections.Generic;

namespace PerfilBackend.Data
{
    public interface IPerfilRepo
    {
        bool SaveChanges();
        IEnumerable<Perfil> GetAllPerfiles();
        Perfil GetPerfilById(int id);
        Perfil GetPerfilByIdUsuario(string id);
        void CreatePerfil(Perfil perf);
        void UpdatePerfil(int id,Perfil perf);
        void DeletePerfil(Perfil perf);
    }
}
