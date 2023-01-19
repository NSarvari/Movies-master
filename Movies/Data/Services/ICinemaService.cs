using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Data.Services
{
    public interface ICinemaService
    {
        Task<IEnumerable<Cinema>> GetAll();
        Task<Cinema> GetById(int id);
        Task Add(Cinema cinema);
        Task<Cinema> Update(int id, Cinema cinema);
        Task Delete(int id);
    }
}
