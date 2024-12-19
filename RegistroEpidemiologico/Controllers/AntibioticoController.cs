using CAPA_NEGOCIO;
using Microsoft.AspNetCore.Mvc;

namespace RegistroEpidemiologico.Controllers
{
    public class AntibioticoController : Controller
    {
        private readonly AntibioticoBL _antibioticoBL;

        public AntibioticoController(AntibioticoBL  antibioticoBL)
        {
            _antibioticoBL = antibioticoBL;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult getAntibioticos()
        {
            return new JsonResult(_antibioticoBL.getAntibioticos());
        }
    }
}
