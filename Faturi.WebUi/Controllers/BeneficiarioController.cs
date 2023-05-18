using Faturi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Faturi.WebUi.Controllers
{
    public class BeneficiarioController : Controller
    {
        private readonly IBeneficiarioService _beneficiarioService;

        public BeneficiarioController(IBeneficiarioService beneficiarioService)
        {
            _beneficiarioService = beneficiarioService;
        }

        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var beneficiarios = await _beneficiarioService.GetBeneficiarios();
            return View(beneficiarios);
        }
    }
}
