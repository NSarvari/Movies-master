using Movies.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Data.Services
{
    public interface IProducerService
    {
        Task<IEnumerable<Producer>> GetAll();
        Task<Producer> GetById(int id);
        Task Add(Producer producer);
        Task<Producer> Update(int id, Producer actor);
        Task Delete(int id);
    }
}
