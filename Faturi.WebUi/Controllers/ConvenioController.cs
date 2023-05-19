using Faturi.Application.DTOs;
using Faturi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Faturi.WebUi.Controllers
{
    public class ConvenioController : Controller
    {
        private readonly IConvevioService _convevioService;

        public ConvenioController(IConvevioService convevioService)
        {
            _convevioService = convevioService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var convenios = await _convevioService.GetConvenios();
            return View(convenios);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ConvenioDTO category)
        {
            if (ModelState.IsValid)
            {
                await _convevioService.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var categoryDto = await _convevioService.GetById(id);
            if (categoryDto == null) return NotFound();
            return View(categoryDto);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(ConvenioDTO convenioDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _convevioService.Update(convenioDTO);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(convenioDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var convenioDTO = await _convevioService.GetById(id);

            if (convenioDTO == null) return NotFound();

            return View(convenioDTO);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _convevioService.Remove(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var convenioDTO = await _convevioService.GetById(id);

            if (convenioDTO == null)
                return NotFound();

            return View(convenioDTO);
        }
    }
}
