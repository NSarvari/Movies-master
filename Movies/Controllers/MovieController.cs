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

        //Get:Movies/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _movieService.GetById(id);

            if (movieDetails == null)
            {
                return View("NotFound");
            }
            return View(movieDetails);
        }

        //Get:Movie/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _movieService.GetById(id);
            if (movieDetails == null)
            {
                return View("NotFound");
            }

            return View(movieDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,Name,Description,ImageUrl,Price,StartDate,EndDate,MovieCategory")] Movie movie)
        {
            movie.MovieId = id;

            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            await _movieService.Update(id, movie);
            return RedirectToAction(nameof(Index));
        }

        //Get: Movie/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var movieDetails = await _movieService.GetById(id);
            if (movieDetails == null)
            {
                return View("NotFound");
            }

            return View(movieDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var movieDetails = await _movieService.GetById(id);
            if (movieDetails == null)
            {
                return View("NotFound");
            }

            await _movieService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
