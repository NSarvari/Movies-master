using Microsoft.EntityFrameworkCore;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Data.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly AppDbContext _appDbContext;

        public CinemaService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(Cinema cinema)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cinema>> GetAll()
        {
            var result = await _appDbContext.Cinemas.ToListAsync();
            return result;
        }

        public Cinema GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Cinema cinema)
        {
            throw new NotImplementedException();
        }
    }
}
