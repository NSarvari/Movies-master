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
        Task<Movie> GetById(int id);
        Task Add(Movie actor);
        Task<Movie> Update(int id, Movie movie);
        Task Delete(int id);
    }
}
