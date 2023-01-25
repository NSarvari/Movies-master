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

        //Get: MovieActors
        public async Task<IActionResult> Index()
        {
            var data = await _movieActorService.GetAll();
            return View("MovieActor",data);
        }
        //Get: MovieActors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("MovieId,ActorId")] MovieActor movieActor)
        {
            await _movieActorService.Add(movieActor);
            return RedirectToAction(nameof(Index));
        }

        //Get:MovieActor/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var movieActorDetails = await _movieActorService.GetById(id);
            if (movieActorDetails == null)
            {
                return View("NotFound");
            }

            return View(movieActorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,ActorId")] MovieActor movieActor)
        {
            movieActor.MovieId = id;

            if (!ModelState.IsValid)
            {
                return View(movieActor);
            }
            await _movieActorService.Update(id, movieActor);
            return RedirectToAction(nameof(Index));
        }
    }
}
