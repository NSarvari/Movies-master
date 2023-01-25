using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Data.Services
{
    public interface IMovieActorService
    {
        Task<IEnumerable<MovieActor>> GetAll();
        Task<MovieActor> GetById(int id);
        Task Add(MovieActor movieActor);
        Task<MovieActor> Update(int id, MovieActor movieActor);
        void Delete(int id);
    }
}
