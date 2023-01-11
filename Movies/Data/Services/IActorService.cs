using Movies.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Data.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAll();
        Task<Actor> GetById(int id);
        Task Add(Actor actor);
        void Update(int id, Actor actor);
        void Delete(int id);
    }
}
