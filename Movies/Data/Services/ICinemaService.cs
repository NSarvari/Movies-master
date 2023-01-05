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
        Cinema GetById(int id);
        void Add(Cinema cinema);
        void Update(int id, Cinema cinema);
        void Delete(int id);
    }
}
