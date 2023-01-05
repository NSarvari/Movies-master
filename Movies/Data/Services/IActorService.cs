using Movies.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Data.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAll();
        Actor GetById(int id);
        void Add(Actor actor);
        void Update(int id, Actor actor);
        void Delete(int id);
    }
}
