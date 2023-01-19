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


        public async Task Add(Cinema cinema)
        {
            await _appDbContext.Cinemas.AddAsync(cinema);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await _appDbContext.Cinemas.FirstOrDefaultAsync(n => n.CinemaId == id);
            _appDbContext.Cinemas.Remove(result);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cinema>> GetAll()
        {
            var result = await _appDbContext.Cinemas.ToListAsync();
            return result;
        }

        public async Task<Cinema> GetById(int id)
        {
            var result = await _appDbContext.Cinemas.FirstOrDefaultAsync(n => n.CinemaId == id);
            return result;
        }

        public async Task<Cinema> Update(int id, Cinema cinema)
        {
            _appDbContext.Update(cinema);
            await _appDbContext.SaveChangesAsync();
            return cinema;
        }
    }
}
