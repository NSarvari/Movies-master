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
        MovieActor GetById(int id);
        void Add(MovieActor movieActor);
        void Update(int id, MovieActor movieActor);
        void Delete(int id);
    }
}
