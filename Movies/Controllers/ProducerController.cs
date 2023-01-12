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
    public class ProducerController : Controller
    {
        private readonly IProducerService _producerService;

        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }
        //Get: Producers
        public async Task<IActionResult> Index()
        {
            var data = await _producerService.GetAll();
            return View("Producer", data);
        }


        //Get: Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")] Producer producer)
        {
            await _producerService.Add(producer);
            return RedirectToAction(nameof(Index));
        }


        //Get:Producer/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _producerService.GetById(id);

            if (producerDetails == null)
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }
        //Get:Producer/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _producerService.GetById(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }

            return View(producerDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ProducerId,FullName,ProfilePictureUrl,Bio")] Producer producer)
        {
            producer.ProducerId = id;

            if (!ModelState.IsValid)
            {

                return View(producer);
            }
            await _producerService.Update(id, producer);
            return RedirectToAction(nameof(Index));
        }


        //Get: Producer/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _producerService.GetById(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }

            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var producerDetails = await _producerService.GetById(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }

            await _producerService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
