using Microsoft.EntityFrameworkCore;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Data.Services
{
    public class MovieActorService : IMovieActorService
    {
        private readonly AppDbContext _appDbContext;

        public MovieActorService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Add(MovieActor movieActor)
        {
            await _appDbContext.MovieActors.AddAsync(movieActor);
            await _appDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MovieActor>> GetAll()
        {
            var result = await _appDbContext.MovieActors.ToListAsync();
            return result;
        }

        public async Task<MovieActor> GetById(int id)
        {
            var result = await _appDbContext.MovieActors.FirstOrDefaultAsync(n => n.MovieId == id);
            return result;
        }

        public async Task<MovieActor> Update(int id, MovieActor movieActor)
        {
            _appDbContext.Update(movieActor);
            await _appDbContext.SaveChangesAsync();
            return movieActor;
        }
    }
}
