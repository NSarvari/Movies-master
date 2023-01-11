using Microsoft.AspNetCore.Mvc;
using Movies.Data;
using Movies.Data.Services;
using Movies.Models;
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

        //Get: Actors
        public async Task<IActionResult> Index()
        {
            var data = await _movieActorService.GetAll();
            return View("MovieActor",data);
        }


    }
}
