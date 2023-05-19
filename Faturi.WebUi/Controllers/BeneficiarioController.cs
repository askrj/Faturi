using Faturi.Application.DTOs;
using Faturi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Faturi.WebUi.Controllers
{
    public class BeneficiarioController : Controller
    {
        private readonly IConvevioService _convenioService;
        private readonly IBeneficiarioService _beneficiarioService;
        private readonly IWebHostEnvironment _environment;

        public BeneficiarioController(IBeneficiarioService beneficiarioService, IConvevioService convenioService, IWebHostEnvironment environment)
        {
            _beneficiarioService = beneficiarioService;
            _environment = environment;
            _convenioService = convenioService;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var beneficiarios = await _beneficiarioService.GetBeneficiarios();
            return View(beneficiarios);
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            ViewBag.ConvenioId =
            new SelectList(await _convenioService.GetConvenios(), "Id", "Nome");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BeneficiarioDTO beneficiarioDTO)
        {
            if (ModelState.IsValid)
            {
                await _beneficiarioService.Add(beneficiarioDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(beneficiarioDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var beneficiarioDTO = await _beneficiarioService.GetById(id);

            if (beneficiarioDTO == null) return NotFound();

            var convenio = await _beneficiarioService.GetBeneficiarios();
            ViewBag.ConvenioId = new SelectList(convenio, "Id", "Nome", beneficiarioDTO.ConvenioId);

            return View(beneficiarioDTO);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(BeneficiarioDTO beneficiarioDTO)
        {
            if (ModelState.IsValid)
            {
                await _beneficiarioService.Update(beneficiarioDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(beneficiarioDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var productDto = await _beneficiarioService.GetById(id);

            if (productDto == null) return NotFound();

            return View(productDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _beneficiarioService.Remove(id);
            return RedirectToAction("Index");
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var productDto = await _beneficiarioService.GetById(id);

            if (productDto == null) return NotFound();
            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + productDto.Foto);
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(productDto);
        }
        
    }
}
