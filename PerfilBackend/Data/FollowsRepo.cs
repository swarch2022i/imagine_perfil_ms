using Microsoft.EntityFrameworkCore;
using PerfilBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PerfilBackend.Data{
    public class FollowsRepo : IFollowsRepo
    {
        private readonly AppDbContext _context;

        public FollowsRepo(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Follows> GetAllFollows()
        {
            return _context.FollowsT.ToList();
        }

        public IEnumerable<Follows> GetAllFollowersByid(string IdUsuarioFollowBy)
        {   
            return _context.FollowsT.ToList().FindAll(p => p.IdUsuarioFollowBy == IdUsuarioFollowBy);
        }


        public IEnumerable<Follows> GetAllFollowsByid(string IdUsuarioFollower)
        {
             return _context.FollowsT.ToList().FindAll(p => p.IdUsuarioFollower == IdUsuarioFollower);
        }

        public Follows GetFollowsByid(int id){
            return _context.FollowsT.FirstOrDefault(p => p.Id == id);
        }

        public void CreateFollows(Follows foll)
        {
            if(foll == null)
            {
                throw new ArgumentNullException(nameof(foll));
            }
            _context.FollowsT.Add(foll);
        }

        public void DeleteFollows(Follows foll)
        {
            _context.FollowsT.Remove(foll);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}