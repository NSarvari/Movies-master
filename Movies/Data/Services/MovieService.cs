using Microsoft.EntityFrameworkCore;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Data.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _appDbContext;

        public MovieService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Add(Movie movie)
        {
            await _appDbContext.Movies.AddAsync(movie);
            await _appDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            var result = await _appDbContext.Movies.ToListAsync();
            return result;
        }

        public Movie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
