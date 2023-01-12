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

        public async Task Delete(int id)
        {
            var result = await _appDbContext.Actors.FirstOrDefaultAsync(n => n.ActorId == id);
            _appDbContext.Actors.Remove(result);
            await _appDbContext.SaveChangesAsync();
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

        public async Task<Actor> Update(int id,Actor actor)
        {
            _appDbContext.Update(actor);
            await _appDbContext.SaveChangesAsync();
            return actor;
        }
    }
}
