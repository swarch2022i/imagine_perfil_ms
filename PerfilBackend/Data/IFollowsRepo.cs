using PerfilBackend.Models;
using System.Collections.Generic;

namespace PerfilBackend.Data
{
    public interface IFollowsRepo
    {
        bool SaveChanges();
        IEnumerable<Follows> GetAllFollows();
        IEnumerable<Follows> GetAllFollowersByid(string IdUsuarioFollowBy);
        IEnumerable<Follows> GetAllFollowsByid(string IdUsuarioFollower);
        Follows GetFollowsByid(int id);
        void CreateFollows(Follows foll);
        void DeleteFollows(Follows foll);
    }
}