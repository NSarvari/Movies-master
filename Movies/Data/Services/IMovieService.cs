using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Data.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAll();
        Movie GetById(int id);
        Task Add(Movie actor);
        void Update(int id, Movie movie);
        void Delete(int id);
    }
}
