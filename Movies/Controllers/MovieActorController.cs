using Microsoft.AspNetCore.Mvc;
using Movies.Data;
using Movies.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    public class MovieActorController : Controller
    {
        private readonly IMovieActorService _movieActorService;

        public MovieActorController(IMovieActorService movieActorService)
        {
            _movieActorService = movieActorService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _movieActorService.GetAll();
            return View("MovieActor",data);
        }
    }
}
