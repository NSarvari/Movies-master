using Microsoft.AspNetCore.Mvc;
using Movies.Data;
using Movies.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IMovieService MovieService => _movieService;

        public async Task<IActionResult> Index()
        {
            var data = await _movieService.GetAll();
            return View("Movie", data);
        }
    }
}
