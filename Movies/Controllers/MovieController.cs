using Microsoft.AspNetCore.Mvc;
using Movies.Data.Services;
using Movies.Models;
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

        //Get: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Description,ImageUrl,Price,StartDate,EndDate,MovieCategory")] Movie movie)
        {
            await _movieService.Add(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
