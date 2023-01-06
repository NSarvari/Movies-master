using Microsoft.AspNetCore.Mvc;
using Movies.Data;
using Movies.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService _actorService; 

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _actorService.GetAll();
            return View("Actor",data);
        }
        //Get: Actor/Create
        public IActionResult Create()
        {
            return View();
        }
    }
}
