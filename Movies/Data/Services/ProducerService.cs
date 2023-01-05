using Microsoft.EntityFrameworkCore;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Data.Services
{
    public class ProducerService : IProducerService
    {
        private readonly AppDbContext _appDbContext;

        public ProducerService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(Producer producer)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Producer>> GetAll()
        {
            var result = await _appDbContext.Producers.ToListAsync();
            return result;
        }

        public Producer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Producer producer)
        {
            throw new NotImplementedException();
        }
    }
}
