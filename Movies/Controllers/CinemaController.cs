using Microsoft.AspNetCore.Mvc;
using Movies.Data;
using Movies.Data.Services;
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
    }
}
