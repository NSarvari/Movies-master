using Microsoft.EntityFrameworkCore;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Data.Services
{
    public class ActorService : IActorService
    {
        private readonly AppDbContext _appDbContext;
        public ActorService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Add(Actor actor)
        {
            await _appDbContext.Actors.AddAsync(actor);
            await _appDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var result = await _appDbContext.Actors.ToListAsync();
            return result;
        }

        public async Task<Actor> GetById(int id)
        {
            var result = await _appDbContext.Actors.FirstOrDefaultAsync(n => n.ActorId == id);
            return result;
        }

        public void Update(int id, Actor actor)
        {
            throw new NotImplementedException();
        }
    }
}
