using PerfilBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PerfilBackend.Data
{
    public class PerfilRepo : IPerfilRepo
    {
        private readonly AppDbContext _context;

        public PerfilRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePerfil(Perfil perf)
        {
            if(perf == null)
            {
                throw new ArgumentNullException(nameof(perf));
            }
            _context.Perfiles.Add(perf);
        }

        public IEnumerable<Perfil> GetAllPerfiles()
        {
            return _context.Perfiles.ToList();
        }

        public Perfil GetPerfilById(int id)
        {
            return _context.Perfiles.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
