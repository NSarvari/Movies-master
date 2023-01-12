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

        public async Task Add(Producer producer)
        {
            await _appDbContext.Producers.AddAsync(producer);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await _appDbContext.Producers.FirstOrDefaultAsync(n => n.ProducerId == id);
            _appDbContext.Producers.Remove(result);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Producer>> GetAll()
        {
            var result = await _appDbContext.Producers.ToListAsync();
            return result;
        }

        public async Task<Producer> GetById(int id)
        {
            var result = await _appDbContext.Producers.FirstOrDefaultAsync(n => n.ProducerId == id);
            return result;
        }

        public async Task<Producer> Update(int id, Producer producer)
        {
            _appDbContext.Update(producer);
            await _appDbContext.SaveChangesAsync();
            return producer;
        }
    }
}
