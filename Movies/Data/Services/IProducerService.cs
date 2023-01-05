using Movies.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Data.Services
{
    public interface IProducerService
    {
        Task<IEnumerable<Producer>> GetAll();
        Producer GetById(int id);
        void Add(Producer producer);
        void Update(int id, Producer producer);
        void Delete(int id);
    }
}
