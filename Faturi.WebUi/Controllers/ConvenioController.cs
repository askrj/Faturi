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
    }
}
