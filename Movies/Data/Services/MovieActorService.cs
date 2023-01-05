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

        public void Add(MovieActor movieActor)
        {
            throw new NotImplementedException();
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

        public MovieActor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, MovieActor movieActor)
        {
            throw new NotImplementedException();
        }
    }
}
