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
    public class CinemaController : Controller
    {
        private readonly ICinemaService _cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _cinemaService.GetAll();
            return View("Cinema", data);
        }

        //Get: Cinema/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            await _cinemaService.Add(cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get:Cinemas/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _cinemaService.GetById(id);

            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }

        //Get:Cinemas/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _cinemaService.GetById(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }

            return View(cinemaDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("CinemaId,Logo,Name,Description")] Cinema cinema)
        {
            cinema.CinemaId = id;

            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _cinemaService.Update(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinema/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _cinemaService.GetById(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }

            return View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var actorDetails = await _cinemaService.GetById(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }

            await _cinemaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
