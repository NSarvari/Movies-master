﻿using Microsoft.AspNetCore.Mvc;
using Movies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    public class MovieActorController : Controller
    {
        private readonly AppDbContext _context;

        public MovieActorController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.MovieActors.ToList();
            return View("MovieActor",data);
        }
    }
}
