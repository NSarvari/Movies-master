using Microsoft.AspNetCore.Mvc;
using Movies.Data;
using Movies.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerService _producerService;

        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _producerService.GetAll();
            return View("Producer", data);
        }
    }
}
