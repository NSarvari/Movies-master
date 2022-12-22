using Microsoft.AspNetCore.Mvc;
using Movies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    public class ActorController : Controller
    {
        private readonly AppDbContext _context;

        public ActorController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Actors.ToList();
            return View("Actor",data);
        }
    }
}
