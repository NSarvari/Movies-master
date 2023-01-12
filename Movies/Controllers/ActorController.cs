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
            return View("Actor", data);
        }


        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")] Actor actor)
        {
            await _actorService.Add(actor);
            return RedirectToAction(nameof(Index));
        }


        //Get:Actors/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _actorService.GetById(id);

            if (actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);
        }

        //Get:Actors/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _actorService.GetById(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }

            return View(actorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ActorId,FullName,ProfilePictureUrl,Bio")] Actor actor)
        {
            actor.ActorId = id;

            if (!ModelState.IsValid)
            {

                    return View(actor);
            }
            await _actorService.Update(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _actorService.GetById(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }

            return View(actorDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var actorDetails = await _actorService.GetById(id);
            if (actorDetails==null)
            {
                return View("NotFound");
            }

            await _actorService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
